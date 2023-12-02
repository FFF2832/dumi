// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class puzzleChange : MonoBehaviour
// {
    
//     public Sprite puzzleSprites; // 儲存不同拼圖的圖片
//     private Image spriteChange;

//        public item itemToRemove;
//     public Inventory playerInventory;
//     public static bool complete1;
// void Start()
// {
//     spriteChange = GetComponent<Image>();
//     if (spriteChange == null)
//     {
//         Debug.LogError("Image component not found!");
//     }
//       // 讀取拼圖狀態
//         complete1 = PlayerPrefs.GetInt("puzzle1Pos", 0) == 1;
//         if (complete1)
//         {
//             // 如果拼圖已完成，則設定新的圖片
//             ChangeSpriteIfCorrect(puzzleSprites, itemToRemove);
//         }
// }
//     void Update()
//     {
//         // 檢查拼圖的狀態
//         bool[] positionCorrect = ItemOndrag.checkPositionCorrect();
//         bool[] itemCorrect = ItemOndrag.checkItemCorrect();

       
//         if(ItemOndrag.checkpuzzle1()) {

//              if( PlayerPrefs.GetInt("puzzle1Pos")==1){
//                 ChangeSpriteIfCorrect(puzzleSprites, itemToRemove);
//                  PlayerPrefs.SetInt("puzzle1Pos", 1);
//                }
             
//         }
//         // if(ItemOndrag.checkpuzzle2())  ChangeSpriteIfCorrect(puzzleSprites[2], itemToRemove);
//         // if(ItemOndrag.checkpuzzle3())  ChangeSpriteIfCorrect(puzzleSprites[3], itemToRemove);
//     }

//     // ... 其他方法 ...

//     private void ChangeSpriteIfCorrect(Sprite newSprite, item itemToRemove)
//     {
//         spriteChange.sprite = newSprite;
//         complete1=true;
//          // 删除物品，确保 itemToRemove 引用了正确的物品对象
//         if (itemToRemove != null)
//         {
//             playerInventory.itemList.Remove(itemToRemove);
//         }
//         // 可能需要在這裡處理物品的移除
//     }
//     public static bool puzzle1complete(){
//         return complete1;
//     }




// //原始的版本
// //      public Sprite sprite1; // 第一個圖片
// //     public Sprite sprite2; // 第二個圖片
// //     private Image spriteChange;

// //     public item itemToRemove;
// //     public Inventory playerInventory;



// // // 在 Start 方法中獲取 ItemOndrag 腳本的參考
// // void Start()
// // {
// //     spriteChange = GetComponent<Image>();
// //     if (spriteChange == null)
// //     {
// //         Debug.LogError("Image component not found!");
// //     }

// // }

// // // 在 Update 方法中使用 ItemOndrag 腳本中的陣列值
// // void Update()
// // {
    
     
// //     // 檢查ItemOndrag腳本中的布林陣列值
// //     bool[] positionCorrect = ItemOndrag.checkPositionCorrect();
// //     bool[] itemCorrect = ItemOndrag.checkItemCorrect();

// //     // 您可以在這裡使用Debug.Log輸出這些陣列的值，以便檢查它們是否正確更新
// //     // Debug.Log("positionCorrect[2]: " + positionCorrect[2]);
// //     // Debug.Log("itemCorrect[2]: " + itemCorrect[2]);

// //     if (ItemOndrag.checkpuzzle1())
// //     {
// //           //  RemoveItem(itemToRemove);
// //         // 在正確的位置上且拖曳的物品是零件1，更換成 sprite1
// //         spriteChange.sprite = sprite1;
    
// //     }

// //     else
// //     {
// //         // 如果不在正確的位置上，顯示 sprite2
// //         spriteChange.sprite = sprite2;
// //     }
// // }

// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class puzzleChange : MonoBehaviour
{


      public Sprite puzzleSprites; // 儲存不同拼圖的圖片
    private Image spriteChange;

       public item itemToRemove;
    public Inventory playerInventory;
    public static bool complete1;
void Start()
{
    spriteChange = GetComponent<Image>();
        if (spriteChange == null)
        {
            Debug.LogError("Image component not found!");
        }

        // 讀取拼圖狀態
        complete1 = PlayerPrefs.GetInt("puzzle1Pos", 0) == 1;
        if (complete1)
        {
            // 如果拼圖已完成，則設定新的圖片
            ChangeSpriteIfCorrect(puzzleSprites, itemToRemove);
        }
}
    void Update()
    {
        // 檢查拼圖的狀態
        bool[] positionCorrect = ItemOndrag.checkPositionCorrect();
        bool[] itemCorrect = ItemOndrag.checkItemCorrect();

       
        // if(ItemOndrag.checkpuzzle1())  ChangeSpriteIfCorrect(puzzleSprites[1], itemToRemove);
        // if(ItemOndrag.checkpuzzle2())  ChangeSpriteIfCorrect(puzzleSprites[2], itemToRemove);
        if(ItemOndrag.checkpuzzle1()) { 
         

               if( PlayerPrefs.GetInt("puzzle1Pos")==1){
                ChangeSpriteIfCorrect(puzzleSprites, itemToRemove);
                 PlayerPrefs.SetInt("puzzle1Pos", 1);
               }
            }
    }

    // ... 其他方法 ...

    private void ChangeSpriteIfCorrect(Sprite newSprite, item itemToRemove)
    {
     
            spriteChange.sprite = newSprite;
        complete1=true;
        // 可能需要在這裡處理物品的移除
          if (itemToRemove != null)
        {
            playerInventory.itemList.Remove(itemToRemove);
        }
        
    }

 public static bool puzzle1complete(){
       return complete1;
    }


}
