using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slot : MonoBehaviour
{
    //命名為item類才能取得
    public int slotID;
   public item slotItem;
    public Image slotImage;
    public GameObject itemInSlot;
    public string slotInfo;
    public int slotitemID;

     public GameObject itemPrefab; // 物品預製體
    public Transform inventoryParent; // 背包的父物件
     public Inventory myBag;
    //  public static slots thislot;
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
         //slotitemID=itemobject.itemID;
       // Debug.Log(itemobject.itemID);
    }
     // 在背包中生成物品
    // public void SpawnItem(item itemData)
    // {
    //     for (int i = 0; i < instance.myBag.itemList.Count ; i++)
    //     {
    //     GameObject newItem = Instantiate(itemPrefab, inventoryParent);
    //     // 在這裡設置物品的圖像、文本等屬性，使用 itemData 中的資料
    //     // newItem.GetComponent<ItemDisplay>().SetItemData(itemData);
    //     myBag.itemList[i].Add(newItem);
    //     }
    // }
    // public void ClearInventory()
    // {
    //       for (int i = 0; i < instance.myBag.itemList.Count ; i++){
    //                 Destroy(item);
    //       }
        
        
    //     myBag.itemList[i].Clear();
    // }
}
