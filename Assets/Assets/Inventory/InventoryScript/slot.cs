using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class slot : MonoBehaviour
{
    //命名為item類才能取得
   public item slotItem;
    public Image slotImage;
    //public int slotNum;
    public void ItemOnclicked(){
        InventoryManager.UpdateItemInfo(slotItem.itemInfo);
    }
}
