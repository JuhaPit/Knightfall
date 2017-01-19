using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryController : MonoBehaviour {

    GameObject inventoryPanel;
    GameObject slotPanel;
    ItemDatabase database;
    public GameObject inventorySlot;
    public GameObject inventoryItem;

    int slotAmount;
    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();

    public PlayerWeaponController playerWeaponController;
    public Item sword;
   
    void Start() {

        database = GetComponent<ItemDatabase>();
        slotAmount = 20;
        inventoryPanel = GameObject.Find("Inventory Panel");
        slotPanel = inventoryPanel.transform.FindChild("Slot Panel").gameObject;
        for (int i = 0; i < slotAmount; i++) {

            items.Add(new Item());
            slots.Add(Instantiate(inventorySlot));
            slots[i].transform.SetParent(slotPanel.transform);

        }

        AddItem(0);
        AddItem(1);

        playerWeaponController = GameObject.Find("Player").GetComponent<PlayerWeaponController>();
        List<BaseStat> swordStats = new List<BaseStat>();
        swordStats.Add(new BaseStat(6, "Power", "Your power level."));
        sword = new Item(swordStats, "sword");
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.V)) {

            playerWeaponController.EquipWeapon(sword);

        }

    }

    public void AddItem(int id) {

        Item itemToAdd = database.FetchItemByID(id);
        for (int i = 0; i < items.Count; i++) {

            if (items[i].ID == -1) {

                items[i] = itemToAdd;
                GameObject itemObj = Instantiate(inventoryItem);
                itemObj.transform.SetParent(slots[i].transform);
                itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                itemObj.name = itemToAdd.Title;
                break;
            }
        }

    }
     
}
