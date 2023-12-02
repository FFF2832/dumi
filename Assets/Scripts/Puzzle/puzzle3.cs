using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class puzzle3 : MonoBehaviour
{


      public Sprite puzzleSprites; // 儲存不同拼圖的圖片
    private Image spriteChange;

       public item itemToRemove;
    public Inventory playerInventory;
    public static bool complete3;
void Start()
{
    spriteChange = GetComponent<Image>();
        if (spriteChange == null)
        {
            Debug.LogError("Image component not found!");
        }

        // 讀取拼圖狀態
        complete3 = PlayerPrefs.GetInt("puzzle3Pos", 0) == 1;
        if (complete3)
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
        if(ItemOndrag.checkpuzzle3()) { 
         

               if( PlayerPrefs.GetInt("puzzle3Pos")==1){
                ChangeSpriteIfCorrect(puzzleSprites, itemToRemove);
                 PlayerPrefs.SetInt("puzzle3Pos", 1);
               }
            }
    }

    // ... 其他方法 ...

    private void ChangeSpriteIfCorrect(Sprite newSprite, item itemToRemove)
    {
     
            spriteChange.sprite = newSprite;
        complete3=true;
        // 可能需要在這裡處理物品的移除
          if (itemToRemove != null)
        {
            playerInventory.itemList.Remove(itemToRemove);
        }
        
    }

 public static bool puzzle3complete(){
       return complete3;
    }


}
