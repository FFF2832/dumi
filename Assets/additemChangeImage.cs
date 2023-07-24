
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class additemChangeImage : MonoBehaviour
{
    public Sprite sprite1; // 第一個圖片
    public Sprite sprite2; // 第二個圖片
   
    private Image spriteChange;
    public item itemToRemove;
     public item thisItem;
   public Inventory playerInventory;
    
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
        
            if (position == 1 && itemPosition == 1)
            {
                // 在正確的位置上且拖曳的物品是樹枝，更換成 sprite1
                AddNewItem();
                spriteChange.sprite = sprite1;
                RemoveItem(itemToRemove);
                
            }
        
        else
        {
            // 如果不在正確的位置上，顯示 sprite2
            spriteChange.sprite = sprite2;
        }
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