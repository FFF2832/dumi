
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class changeImage : MonoBehaviour
// {
//     public Sprite sprite1; // 第一個圖片
//     public Sprite sprite2; // 第二個圖片
//     public Sprite sprite3; // 第二個圖片
//      public Sprite sprite4; // 第二個圖片
//     private Image spriteChange;
//     public item itemToRemove;
//      public item thisItem;
//    public Inventory playerInventory;
//     // 获取 ItemOndrag 组件
//     //ItemOndrag item = GetComponent<ItemOndrag>();
//     // 更改 correctParent 的值
//     //item.correctParent = newCorrectParentGameObject.transform;
//     void Start()
//     {
//         spriteChange = GetComponent<Image>();
//           if (spriteChange == null) {
//         Debug.LogError("Image component not found!");
//     }
//     }
// //     void Update()
// // {
// //     if (gameObject == this.gameObject) // 只有當前物件才會執行以下操作
// //     {

// //          if ((ItemOndrag.checkPosition() == ItemOndrag.checkitemPosition()))
// //             {
// //                 if(ItemOndrag.checkPosition() ==1&&ItemOndrag.checkitemPosition()==1){
// //                     AddNewItem();
// //                 }
// //             // AddNewItem();
// //             spriteChange.sprite = sprite1;
// //             RemoveItem(itemToRemove);
// //             }
        
        
// //             else
// //             {
// //             spriteChange.sprite = sprite2;
// //             }
       
// //     }
// // }


// // // /最開始的版本(同時換圖)
// //     void Update()
// //     {
      
// //         //撿樹枝剪零件2
// //         if(ItemOndrag.checkPosition()==1&&ItemOndrag.checkitemPosition()==1){
// //               AddNewItem();
// //               //Destroy(gameObject);
// //                spriteChange.sprite = sprite1;
// //                RemoveItem(itemToRemove);
// //         }
// //         //撿零件1到太陽位置
// //        else if(ItemOndrag.checkPosition()==2&&ItemOndrag.checkitemPosition()==2){
// //               spriteChange.sprite = sprite4;
// //                  RemoveItem(itemToRemove);
// //         }
// //          //撿零件2到圓形位置
// //         else if(ItemOndrag.checkPosition()==3&&ItemOndrag.checkitemPosition()==3){
// //               spriteChange.sprite = sprite3;
// //                  RemoveItem(itemToRemove);
// //         }
        
// //         else
// //         {
// //             spriteChange.sprite = sprite2;
// //         }
// //     }

// //     void Update()
// // {
// //     if (gameObject == this.gameObject)
// //     {
// //         // 檢查拖曳的物品是否是樹枝或剪刀
// //         int position = ItemOndrag.checkPosition();
// //         int itemPosition = ItemOndrag.checkitemPosition();

// //         if (position == 1 && itemPosition == 1)
// //         {
// //             AddNewItem(thisItem);
// //             spriteChange.sprite = sprite1;
// //             RemoveItem(itemToRemove);
// //         }
// //         else if (position == 2 && itemPosition == 2)
// //         {
// //             spriteChange.sprite = sprite4;
// //             RemoveItem(itemToRemove);
// //         }
// //         else if (position == 3 && itemPosition == 3)
// //         {
// //             spriteChange.sprite = sprite3;
// //             RemoveItem(itemToRemove);
// //         }
// //         else
// //         {
// //             spriteChange.sprite = sprite2;
// //         }
// //     }
// // }



// // 只會換一邊
// void Update()
// {
//     if (gameObject == this.gameObject)
//     {
//         // 檢查拖曳的物品是否是樹枝或剪刀
//         int position = ItemOndrag.checkPosition();
//         int itemPosition = ItemOndrag.checkitemPosition();
//         Debug.Log("itemPosition"+itemPosition);
//         // 檢查是否在正確的位置上
//         if (ItemOndrag.checkTarget())
//         {
//             // if (position == 1 && itemPosition == 1)
//             // {
//             //     // 在正確的位置上且拖曳的物品是樹枝，更換成 sprite1
//             //     AddNewItem();
//             //     spriteChange.sprite = sprite1;
//             //     RemoveItem(itemToRemove);
                
//             // }
//             if (position == 2 && itemPosition == 2)
//             {
//                 // 在正確的位置上且拖曳的物品是零件1，更換成 sprite4
//                 spriteChange.sprite = sprite4;
//             }
//             else if (position == 3 && itemPosition == 3)
//             {
//                 // 在正確的位置上且拖曳的物品是零件2，更換成 sprite3
//                 spriteChange.sprite = sprite3;
//             }
//         }
//         else
//         {
//             // 如果不在正確的位置上，顯示 sprite2
//             spriteChange.sprite = sprite2;
//         }
//     }
// }


 

// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeImage : MonoBehaviour
{
    public Sprite sprite1; // 第一個圖片
    public Sprite sprite2; // 第二個圖片
    public Sprite sprite3; // 第三個圖片
    public Sprite sprite4; // 第四個圖片
    private Image spriteChange;
    public item itemToRemove;
    public item thisItem;
    public Inventory playerInventory;
    private bool isChanged = false;

    private int itemcorrect = 0; // 新增拖曳物件的屬性 itemcorrect
    private int positioncorrect = 0; // 新增拖曳物件的屬性 positioncorrect

    void Start()
    {
        spriteChange = GetComponent<Image>();
        if (spriteChange == null)
        {
            Debug.LogError("Image component not found!");
        }
    }

    void Update()
    {
        // 只在拖曳物件的位置或零件有變動時更新圖片
        int position = ItemOndrag.checkPosition();
        int itemPosition = ItemOndrag.checkitemPosition();

        if (itemcorrect != itemPosition || positioncorrect != position)
        {
            itemcorrect = itemPosition;
            positioncorrect = position;

            if (positioncorrect == 2 && itemcorrect == 2)
            {
                spriteChange.sprite = sprite4;
                isChanged = true;
            }
            else if (positioncorrect == 3 && itemcorrect == 3)
            {
                spriteChange.sprite = sprite3;
                isChanged = true;
            }
            else
            {
                spriteChange.sprite = sprite2;
                isChanged = true;
            }
        }
    }

    // 其他程式碼不變
}
