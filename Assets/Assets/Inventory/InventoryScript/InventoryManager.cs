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
     public item itemToRemove;
    public Text itemInformation;
    //public int itemID;
    public List<GameObject> slots= new  List<GameObject>();
    public GameObject emptySlot;
    public Button closeButton; // 用於關閉詳細圖片的按鈕參考

    void Awake(){
        if(instance !=null)Destroy(this);
            instance=this;
        // 一開始隱藏關閉按鈕
        closeButton.gameObject.SetActive(false);
        detailedItemImage.gameObject.SetActive(false);
    }
   
    public void OnEnable()
    {
        RefreshItem();
        instance.itemInformation.text="";
        //  ClearDetailedItemInfo(); // 在打开背包时，先清空详细图片内容显示
        closeButton.onClick.AddListener(CloseDetailedImage); // 監聽關閉按鈕的點擊事件
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
    instance.detailedItemImage.gameObject.SetActive(true); // 將物件設定為開啟
    instance.closeButton.gameObject.SetActive(true); // 顯示關閉按鈕
    instance.detailedItemImage.sprite = detailedImage;
    }

    // 新增方法用于清空详细图片显示区域
    public static void ClearDetailedItemInfo()
    {
        instance.detailedItemImage.sprite = null;
       instance.detailedItemImage.gameObject.SetActive(false); // 將物件設定為關閉狀態
      instance.closeButton.gameObject.SetActive(false); // 顯示關閉按鈕
    }
     // 新增的方法：關閉詳細圖片
    private void CloseDetailedImage()
    {
        ClearDetailedItemInfo(); // 清空詳細圖片內容顯示
    }

    // public static void UpdateItemID(int itemID){
    //     instance.itemInformation.text=itemDescription;
    // }
    //  未刪
    // 將item 的資料傳送到 slot
    // public static void  CreateNewItem(item item){
    //     slot newItem=Instantiate(instance.slotPrefab,instance.slotGrid.transform.position,Quaternion.identity);
    //     //子集
      
    //     newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
    //     newItem.slotItem=item;
    //     newItem.slotImage.sprite=item.itemImage;
        
    // }
    //  原版
    // public static void RefreshItem()
    // {
    //     //清除舊格子和清單(原版)
    //     for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
    //     {
           
    //         if(instance.slotGrid.transform.childCount==0)break;
    //         Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
    //         instance.slots.Clear();
    //         if(instance.myBag.itemList.Count==0){
    //             instance.slots.Add(Instantiate(instance.emptySlot));
    //              instance.slots[0].transform.SetParent(instance.slotGrid.transform);
    //              instance.slots[0].GetComponent<slot>().SetupSlot(instance.myBag.itemList[0]);
    //         }
    //     }
    //      Debug.Log(instance.myBag.itemList.Count);

    //     //   //清除舊格子和清單
    //     // for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
    //     // {
    //     //     if(instance.slotGrid.transform.childCount==0)break;
    //     //     //   if(i==0){
    //     //     //     instance.slots.Add(Instantiate(instance.emptySlot));
                
    //     //     //   }
    //     //     else{Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
    //     //     instance.slots.Clear();}
    //     // }

    //     //重新生成對應的slot
    //     for (int i = 0; i < instance.myBag.itemList.Count ; i++)
    //     {
    //          //未刪
    //         //CreateNewItem(instance.myBag.itemList[i]);
    //         instance.slots.Add(Instantiate(instance.emptySlot));
    //         instance.slots[i].transform.SetParent(instance.slotGrid.transform);
    //         instance.slots[i].GetComponent<slot>().SetupSlot(instance.myBag.itemList[i]);
    //     }
        
    // }
//   public static void RefreshItem()
// {
//     // 清除舊格子和清單(原版)
//     for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
//     {
//         Destroy(instance.slotGrid.transform.GetChild(i).gameObject);

//     }

//     instance.slots.Clear();

//     Debug.Log(instance.myBag.itemList.Count);

//     // 如果背包為空，新增一個空格子
//     if (instance.myBag.itemList.Count == 0)
//     {
//         // 新增一個空物品到 itemList
//         instance.myBag.itemList.Add(null);

//         GameObject newEmptySlot = Instantiate(instance.emptySlot);
//         newEmptySlot.transform.SetParent(instance.slotGrid.transform);
//         instance.slots.Add(newEmptySlot);
//         newEmptySlot.GetComponent<slot>().SetupSlot(instance.myBag.itemList[0]);
//     }
//     else
//     {
//         // 重新生成對應的 slot
//         for (int i = 0; i < instance.myBag.itemList.Count; i++)
//         {
//             // 創建新的物品格子
//             GameObject newSlot = Instantiate(instance.emptySlot);
//             newSlot.transform.SetParent(instance.slotGrid.transform);
//             instance.slots.Add(newSlot);

//             // 將物品資料設置到格子中
//             newSlot.GetComponent<slot>().SetupSlot(instance.myBag.itemList[i]);
            
//         }
//     }
// }
//7格
// public static void RefreshItem()
// {
//     // 清除舊格子和清單(原版)
//     for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
//     {
//         Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
//     }

//     instance.slots.Clear();

//     Debug.Log(instance.myBag.itemList.Count);

//     // 保持格子數量為7
//     int targetSlotCount = 6;

//     // 如果背包為空，新增空格子
//     while (instance.myBag.itemList.Count < targetSlotCount)
//     {
//         // 新增一個空物品到 itemList
//         instance.myBag.itemList.Add(null);

//         GameObject newEmptySlot = Instantiate(instance.emptySlot);
//         newEmptySlot.transform.SetParent(instance.slotGrid.transform);
//         instance.slots.Add(newEmptySlot);
//         newEmptySlot.GetComponent<slot>().SetupSlot(instance.myBag.itemList[instance.myBag.itemList.Count - 1]);
//     }

//     // 重新生成對應的 slot
//     for (int i = 0; i < instance.myBag.itemList.Count; i++)
//     {
//         // 創建新的物品格子
//         GameObject newSlot = Instantiate(instance.emptySlot);
//         newSlot.transform.SetParent(instance.slotGrid.transform);
//         instance.slots.Add(newSlot);

//         // 將物品資料設置到格子中
//         newSlot.GetComponent<slot>().SetupSlot(instance.myBag.itemList[i]);
//     }
// }

public static void RefreshItem()
{
    // 清除舊格子和清單(原版)
    for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
    {
        Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
    }

    instance.slots.Clear();

    Debug.Log(instance.myBag.itemList.Count);

    // 保持格子數量為12，6個為一排
    int rows = 2; // 兩排
    int columns = 6; // 每排六個

    for (int row = 0; row < rows; row++)
    {
        for (int col = 0; col < columns; col++)
        {
            // 創建新的物品格子
            GameObject newSlot = Instantiate(instance.emptySlot);
            newSlot.transform.SetParent(instance.slotGrid.transform);
            instance.slots.Add(newSlot);

            // 將物品資料設置到格子中
            int index = row * columns + col;
            if (index < instance.myBag.itemList.Count)
            {
                newSlot.GetComponent<slot>().SetupSlot(instance.myBag.itemList[index]);
            }
        }
    }
}

          



}
