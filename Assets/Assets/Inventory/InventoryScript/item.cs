using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName="New Item",menuName="Inventory/New Item")]
public class item : ScriptableObject
{
     public string itemName;
     public Sprite itemImage;
     public Sprite detailedItemImage; // 新增属性用于存储详细图片
     public int itemHeild;
     [TextArea]
     public string itemInfo;
     public bool equip;
      public int itemID;

}
