﻿using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using System.IO;

public class ItemDatabase : MonoBehaviour {

    private List<Item> database = new List<Item>();
    private JsonData itemData;

    void Start() {

        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
        constructItemDatabase();
    }

    public Item FetchItemByID(int id) {

        for (int i = 0; i < database.Count; i++)

            if(database[i].ID == id)
                return database[i];

        return null;

    }

    void constructItemDatabase() {

        for (int i = 0; i < itemData.Count; i++) {

            database.Add(new Item((int)itemData[i]["id"], itemData[i]["title"].ToString(), (int)itemData[i]["value"],
                (int)itemData[i]["stats"]["power"], (int)itemData[i]["stats"]["defence"], (int)itemData[i]["stats"]["vitality"], itemData[i]["description"].ToString(),
                (bool)itemData[i]["stackable"], (int)itemData[i]["rarity"], itemData[i]["slug"].ToString()));

        }

    }
}
