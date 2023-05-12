using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryManager : MonoBehaviour
{

    static InventoryManager instance;
    public Inventory myBag;
    public GameObject slotGrid;
    //未刪
    //public slot slotPrefab;
    public item itemobject;
    public Text itemInformation;
    //public int itemID;
    public List<GameObject> slots= new  List<GameObject>();
    public GameObject emptySlot;
    void Awake(){
        if(instance !=null)Destroy(this);
            instance=this;
        

    }
   
    public void OnEnable()
    {
        RefreshItem();
        instance.itemInformation.text="";
    }
    public static void UpdateItemInfo(string itemDescription){
        instance.itemInformation.text=itemDescription;
    }
    // public static void UpdateItemID(int itemID){
    //     instance.itemInformation.text=itemDescription;
    // }
     //未刪
    //將item 的資料傳送到 slot
    // public static void  CreateNewItem(item item){
    //     slot newItem=Instantiate(instance.slotPrefab,instance.slotGrid.transform.position,Quaternion.identity);
    //     //子集
      
    //     newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
    //     newItem.slotItem=item;
    //     newItem.slotImage.sprite=item.itemImage;
        
    // }
     //用來計算數量
    public static void RefreshItem()
    {
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            if(instance.slotGrid.transform.childCount==0)break;
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
            instance.slots.Clear();
        }
        //重新生成對應的slot
        for (int i = 0; i < instance.myBag.itemList.Count ; i++)
        {
             //未刪
            //CreateNewItem(instance.myBag.itemList[i]);
            instance.slots.Add(Instantiate(instance.emptySlot));
            instance.slots[i].transform.SetParent(instance.slotGrid.transform);
        // instance.slot[i].GetComponent<slot>().slotID=i;
         // 將生成的 itemID 賦值給對應的 item 物件

            instance.slots[i].GetComponent<slot>().SetupSlot(instance.myBag.itemList[i]);
        }
        
    }
 
}
