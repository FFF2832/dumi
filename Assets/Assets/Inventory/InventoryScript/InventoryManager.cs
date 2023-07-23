using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryManager : MonoBehaviour
{
 public Image detailedItemImage; // 引用用于显示详细图片的Image组件

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
        //  ClearDetailedItemInfo(); // 在打开背包时，先清空详细图片内容显示
    }
    public static void UpdateItemInfo(string itemDescription){
        instance.itemInformation.text=itemDescription;
    }
    // 新增方法用于更新详细图片
    public static void UpdateDetailedItemInfo(Sprite detailedImage)
    {
         if (instance.detailedItemImage == null)
    {
        Debug.LogError("DetailedItemImage is not assigned. Make sure you have assigned the detailedItemImage variable in the InventoryManager script.");
        return;
    }

    instance.detailedItemImage.sprite = detailedImage;
    }

    // 新增方法用于清空详细图片显示区域
    public static void ClearDetailedItemInfo()
    {
        instance.detailedItemImage.sprite = null;
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
