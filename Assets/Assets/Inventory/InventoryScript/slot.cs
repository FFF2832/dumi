//成功的版本
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slot : MonoBehaviour
{
    //命名為item類才能取得
    //public int slotID;
   public item slotItem;
    public Image slotImage;
    public GameObject itemInSlot;
    public string slotInfo;
    public int slotitemID;
     public Inventory myBag;
 
    //public int slotNum;
    public void ItemOnclicked(){
        InventoryManager.UpdateItemInfo(slotInfo);
    }
    public void SetupSlot(item itemobject){
        if(itemobject ==null){
                itemInSlot.SetActive(false);
                return;
        }
        slotImage.sprite =itemobject.itemImage;
        slotInfo=itemobject.itemInfo;
         slotitemID=itemobject.itemID;
       // Debug.Log(itemobject.itemID);
    }
     
}
//測試版本