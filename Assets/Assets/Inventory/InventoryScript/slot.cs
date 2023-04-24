using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class slot : MonoBehaviour
{
    //命名為item類才能取得
   public item slotItem;
    public Image slotImage;
    public GameObject itemInSlot;
    //public int slotNum;
    public void ItemOnclicked(){
        InventoryManager.UpdateItemInfo(slotItem.itemInfo);
    }
    public void SetupSlot(item item){
        if(item ==null){
                itemInSlot.SetActive(false);
                return;
        }
        slotImage.sprite =item.itemImage;
        
    }
}
