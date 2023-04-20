using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public enum ItemType{
        Sword,
        HealkthPotion,
        ManaPotion,
        Coin
    }
    public ItemType itemType;
    public int amount;
}
