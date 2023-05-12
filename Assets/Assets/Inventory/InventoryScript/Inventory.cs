
//成功的版本
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Inventory",menuName="Inventory/New Inventory")]
public class Inventory : ScriptableObject
{
    public List<item> itemList = new List<item>();
 
}
//失敗的方法