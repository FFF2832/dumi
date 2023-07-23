
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.EventSystems;

// public class changeImage : MonoBehaviour
// {
//     public Sprite sprite1; // 第一個圖片
//     public Sprite sprite2; // 第二個圖片
//     private Image spriteChange;
//    // public Transform newCorrectParentTransform; // 在類別開頭定義變數
    
//     void Start()
//     {
//         spriteChange = GetComponent<Image>();
//         // if (spriteChange == null) {
//         //     Debug.LogError("Image component not found!");
//         // }

//         // // 觸發 OnNewCorrectParentSetEvent 事件，將新的 transform 傳遞給 ItemOndrag
//         // if (OnNewCorrectParentSetEvent != null) {
//         //     OnNewCorrectParentSetEvent(newCorrectParentTransform);
//         // }
//     }

//     void Update()
//     {
//         if (ItemOndrag.checkTarget())
//         {
//             spriteChange.sprite = sprite1;
//         }
//         else
//         {
//             spriteChange.sprite = sprite2;
//         }
//     }

//     // 定義 OnNewCorrectParentSetEvent 事件的委託
//     public delegate void OnNewCorrectParentSet(Transform newCorrectParentTransform);
//     // 定義 OnNewCorrectParentSetEvent 事件
//     public static event OnNewCorrectParentSet OnNewCorrectParentSetEvent;
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeImage : MonoBehaviour
{
    public Sprite sprite1; // 第一個圖片
    public Sprite sprite2; // 第二個圖片
    public Sprite sprite3; // 第二個圖片
     public Sprite sprite4; // 第二個圖片
    private Image spriteChange;
    public item itemToRemove;
     public item thisItem;
   public Inventory playerInventory;
    // 获取 ItemOndrag 组件
    //ItemOndrag item = GetComponent<ItemOndrag>();
    // 更改 correctParent 的值
    //item.correctParent = newCorrectParentGameObject.transform;
    void Start()
    {
        spriteChange = GetComponent<Image>();
          if (spriteChange == null) {
        Debug.LogError("Image component not found!");
    }
    }
//     void Update()
// {
//     if (gameObject == this.gameObject) // 只有當前物件才會執行以下操作
//     {

//          if ((ItemOndrag.checkPosition() == ItemOndrag.checkitemPosition()))
//             {
//                 if(ItemOndrag.checkPosition() ==1&&ItemOndrag.checkitemPosition()==1){
//                     AddNewItem();
//                 }
//             // AddNewItem();
//             spriteChange.sprite = sprite1;
//             RemoveItem(itemToRemove);
//             }
        
        
//             else
//             {
//             spriteChange.sprite = sprite2;
//             }
       
//     }
// }


// // /最開始的版本(同時換圖)
//     void Update()
//     {
      
//         //撿樹枝剪零件2
//         if(ItemOndrag.checkPosition()==1&&ItemOndrag.checkitemPosition()==1){
//               AddNewItem();
//               //Destroy(gameObject);
//                spriteChange.sprite = sprite1;
//                RemoveItem(itemToRemove);
//         }
//         //撿零件1到太陽位置
//        else if(ItemOndrag.checkPosition()==2&&ItemOndrag.checkitemPosition()==2){
//               spriteChange.sprite = sprite4;
//                  RemoveItem(itemToRemove);
//         }
//          //撿零件2到圓形位置
//         else if(ItemOndrag.checkPosition()==3&&ItemOndrag.checkitemPosition()==3){
//               spriteChange.sprite = sprite3;
//                  RemoveItem(itemToRemove);
//         }
        
//         else
//         {
//             spriteChange.sprite = sprite2;
//         }
//     }

//     void Update()
// {
//     if (gameObject == this.gameObject)
//     {
//         // 檢查拖曳的物品是否是樹枝或剪刀
//         int position = ItemOndrag.checkPosition();
//         int itemPosition = ItemOndrag.checkitemPosition();

//         if (position == 1 && itemPosition == 1)
//         {
//             AddNewItem(thisItem);
//             spriteChange.sprite = sprite1;
//             RemoveItem(itemToRemove);
//         }
//         else if (position == 2 && itemPosition == 2)
//         {
//             spriteChange.sprite = sprite4;
//             RemoveItem(itemToRemove);
//         }
//         else if (position == 3 && itemPosition == 3)
//         {
//             spriteChange.sprite = sprite3;
//             RemoveItem(itemToRemove);
//         }
//         else
//         {
//             spriteChange.sprite = sprite2;
//         }
//     }
// }



// 只會換一邊
void Update()
{
    if (gameObject == this.gameObject)
    {
        // 檢查拖曳的物品是否是樹枝或剪刀
        int position = ItemOndrag.checkPosition();
        int itemPosition = ItemOndrag.checkitemPosition();
        Debug.Log("itemPosition"+itemPosition);
        // 檢查是否在正確的位置上
        if (ItemOndrag.checkTarget())
        {
            if (position == 1 && itemPosition == 1)
            {
                // 在正確的位置上且拖曳的物品是樹枝，更換成 sprite1
                AddNewItem();
                spriteChange.sprite = sprite1;
                RemoveItem(itemToRemove);
                
            }
            else if (position == 2 && itemPosition == 2)
            {
                // 在正確的位置上且拖曳的物品是零件1，更換成 sprite4
                spriteChange.sprite = sprite4;
            }
            else if (position == 3 && itemPosition == 3)
            {
                // 在正確的位置上且拖曳的物品是零件2，更換成 sprite3
                spriteChange.sprite = sprite3;
            }
        }
        else
        {
            // 如果不在正確的位置上，顯示 sprite2
            spriteChange.sprite = sprite2;
        }
    }
}


  public static int GetTargetInfo(GameObject gameObject)
{
    if (gameObject.name == "輪胎")
    {
        return 1;
    }
    if (gameObject.name == "collecttem_car")
    {
        return 2;
    }
    else
    {
        return 0; // or any other appropriate value
    }
}
public void AddNewItem(){
    if(!playerInventory.itemList.Contains(thisItem)){
         //playerInventory.itemList.Add(thisItem);
          //未刪CreateNewItem
         //InventoryManager.CreateNewItem(thisItem);
         for(int i=0;i<playerInventory.itemList.Count;i++){
                if(playerInventory.itemList[i]==null){
                        playerInventory.itemList[i]=thisItem;
                        break;
                }
         }
    }
    else {
        thisItem.itemHeild += 1;
    }
    InventoryManager.RefreshItem(); 
   }
   public void RemoveItem(item itemToRemove)
{
    if (playerInventory.itemList.Contains(itemToRemove))
    {
        playerInventory.itemList.Remove(itemToRemove);
        InventoryManager.RefreshItem();
    }
}
}