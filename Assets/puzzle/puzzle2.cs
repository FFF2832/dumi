using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class puzzle2 : MonoBehaviour
{
    
    public Sprite puzzleSprites; // 儲存不同拼圖的圖片
    private Image spriteChange;

       public item itemToRemove;
    public Inventory playerInventory;
     public static bool complete2;
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
        // 檢查拼圖的狀態
        bool[] positionCorrect = ItemOndrag.checkPositionCorrect();
        bool[] itemCorrect = ItemOndrag.checkItemCorrect();

       
        // if(ItemOndrag.checkpuzzle1())  ChangeSpriteIfCorrect(puzzleSprites[0], itemToRemove);
        if(ItemOndrag.checkpuzzle2())  ChangeSpriteIfCorrect(puzzleSprites, itemToRemove);
        // if(ItemOndrag.checkpuzzle3())  ChangeSpriteIfCorrect(puzzleSprites[2], itemToRemove);
    }

    // ... 其他方法 ...

    private void ChangeSpriteIfCorrect(Sprite newSprite, item itemToRemove)
    {
        spriteChange.sprite = newSprite;
        complete2=true;
        // 可能需要在這裡處理物品的移除
          if (itemToRemove != null)
        {
            playerInventory.itemList.Remove(itemToRemove);
        }
    }
     public static bool puzzle2complete(){
        return complete2;
    }

}
