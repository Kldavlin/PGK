using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Parent class for all items in game
public class Item
{
    private string name;
    private int cost;
    private ItemType itemType;
    private string itemDesc;

    public Item(string itemName, int itemCost, ItemType itemType, string itemDesc)
    {
        this.name = itemName;
        this.cost = itemCost;
        this.itemType = itemType;
        this.itemDesc = itemDesc;
    }

    public string getItemName()
    {
        return name;
    }

    public int getItemCost()
    {
        return cost;
    }

    public ItemType getItemType()
    {
        return itemType;
    }

    public string getItemDesc()
    {
        return itemDesc;
    }
}
