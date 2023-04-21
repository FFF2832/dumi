
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// [CreateAssetMenu(fileName="New Inventory",menuName="Inventory/New Inventory")]
// public class   Inventory : ScriptableObject
// {
//     [SerializeField] public List<Item> itemList = new List<Item>();

//     void Awake()
//     {
//         Item newItem = new Item(); // 創建一個新的 Item 物件
//         AddItem(newItem); // 將新的 Item 物件添加到 itemList 中
//     }

//     void AddItem(Item newItem)
//     {
//         itemList.Add(newItem);
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Inventory",menuName="Inventory/New Inventory")]
public class Inventory : ScriptableObject
{
    public List<Item> itemList = new List<Item>();
    public string itemName;
     public Sprite itemImage;
     public int itemHeild;
     [TextArea]
     public string itemInfo;
     public bool equip;
}
