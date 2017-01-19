using UnityEngine;
using System.Collections.Generic;

public class Item  {

    public int ID { get; set; }
    public string Title { get; set; }
    public int Value { get; set; }
    public int Power { get; set; }
    public int Defence { get; set; }
    public int Vitality { get; set; }
    public string Description { get; set; }
    public bool Stackable { get; set; }
    public int Rarity { get; set; }
    public string Slug { get; set; }
    public Sprite Sprite { get; set; }

    public List<BaseStat> Stats { get; set; }
    public string ObjectSlug { get; set; }

    public Item(List<BaseStat> _Stats, string _ObjectSlug) {

        this.Stats = _Stats;
        this.ObjectSlug = _ObjectSlug;

    }

    public Item(int id, string title, int value, int power, int defence, int vitality, string description, bool stackable, int rarity, string slug) {

        this.ID = id;
        this.Title = title;
        this.Value = value;
        this.Power = power;
        this.Vitality = vitality;
        this.Description = description;
        this.Stackable = stackable;
        this.Rarity = rarity;
        this.Slug = slug;
        this.Sprite = Resources.Load<Sprite>("Sprites/Items/" + slug);

    }

    public Item() {

        this.ID = -1;
    }

}
