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
    public string slotInfo;
    //public int slotNum;
    public void ItemOnclicked(){
        InventoryManager.UpdateItemInfo(slotInfo);
    }
    public void SetupSlot(item item){
        if(item ==null){
                itemInSlot.SetActive(false);
                return;
        }
        slotImage.sprite =item.itemImage;
        slotInfo=item.itemInfo;
    }
}
