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
        // 1. 更新物品信息文本
        InventoryManager.UpdateItemInfo(slotInfo);

        // 2. 更新详细图片内容
        if (slotItem != null && slotItem.detailedItemImage != null)
        {
            InventoryManager.UpdateDetailedItemInfo(slotItem.detailedItemImage);
        }
        else
        {
            // 如果没有详细图片，则清空显示区域
            InventoryManager.ClearDetailedItemInfo();
        }
    }
    public void SetupSlot(item itemobject){
        if(itemobject ==null){
                itemInSlot.SetActive(false);
                return;
        }
        slotImage.sprite =itemobject.itemImage;
        slotInfo=itemobject.itemInfo;
         slotitemID=itemobject.itemID;
         slotItem = itemobject; // 确保将itemobject赋值给slotItem
       // Debug.Log(itemobject.itemID);
    }
     
}
//測試版本