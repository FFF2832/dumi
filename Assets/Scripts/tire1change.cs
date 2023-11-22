using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tire1change : MonoBehaviour
{
    public Sprite sprite1; // 第一個圖片
    public Sprite sprite2; // 第二個圖片
    private Image spriteChange;

    public item itemToRemove;
    public Inventory playerInventory;
  //  public Image tire;
private bool changetire1;


// 在 Start 方法中獲取 ItemOndrag 腳本的參考
void Start()
{
    spriteChange = GetComponent<Image>();
    if (spriteChange == null)
    {
        Debug.LogError("Image component not found!");
    }
   // spriteChange.enabled = false;
   changetire1=false;
   PlayerPrefs.SetInt("changeTire1", 0);
}

// 在 Update 方法中使用 ItemOndrag 腳本中的陣列值
void Update()
{
    
     
    // 檢查ItemOndrag腳本中的布林陣列值
    bool[] positionCorrect = ItemOndrag.checkPositionCorrect();
    bool[] itemCorrect = ItemOndrag.checkItemCorrect();

 

    if (ItemOndrag.checktire1())
    {
        // RemoveItem(itemToRemove);
        // 在正確的位置上且拖曳的物品是零件1，更換成 sprite1
    //    spriteChange.sprite = sprite1;
         changetire1=true;
       // spriteChange.enabled = true;

       RemoveItem(itemToRemove);
      
    }

    else
    {
        // 如果不在正確的位置上，顯示 sprite2
       //spriteChange.sprite = sprite2;
          changetire1=false;
       //spriteChange.enabled = false;
    }
    
   
}


 public  void RemoveItem(item itemToRemove)
    {
        List<item> itemsToRemove = new List<item>();

    // Find all instances of itemToRemove in the itemList
    foreach (var item in playerInventory.itemList)
    {
        if (item == itemToRemove)
        {
            itemsToRemove.Add(item);
        }
    }

    // Remove all instances of itemToRemove
    foreach (var item in itemsToRemove)
    {
        playerInventory.itemList.Remove(item);
    }

    InventoryManager.RefreshItem();
    changeImage();
    }
    public void changeImage(){
          if (changetire1)
        {
            spriteChange.sprite = sprite2; // 更新圖片
              PlayerPrefs.SetInt("changeTire1", 1);
            //changetire1 = false;
            Debug.Log("changetire1"+changetire1);
        }
        else {
             spriteChange.sprite = sprite1; // 更新圖片
        }

    }
    public bool Updatechangetire1(){
          Debug.Log(changetire1);
        return changetire1;
    }

}
//  public class tire1change : MonoBehaviour{

 
// public enum TireState {
//     Default,
//     Correct,
//     Incorrect
// }

// public TireState tireState; 

// public Sprite defaultSprite;
// public Sprite correctSprite;
// public Sprite incorrectSprite;

// private Image tireImage;

//  public item itemToRemove;
// public Inventory playerInventory;

// void Start() {
//   tireImage = GetComponent<Image>();
//   tireState = TireState.Default;
// }

// void UpdateSprite() {
//   switch(tireState) {
//     case TireState.Default:
//       tireImage.sprite = defaultSprite;
//       break;
//     case TireState.Correct:
//       tireImage.sprite = correctSprite;
//       break;
//     case TireState.Incorrect:
//       tireImage.sprite = incorrectSprite;
//       break;
//   }
// }

// void UpdateInventory() {
//   if (tireState == TireState.Correct) {
//     RemoveItem(itemToRemove);
//   }
// }

// void Update() {

//   if (ItemOndrag.checktire1()) {
    
//       tireState = TireState.Correct;
    
//   } else {
//     tireState = TireState.Incorrect;
//   }

//   UpdateSprite();

//   if (tireState == TireState.Correct) {
//     UpdateInventory();
//   }

// }

// void RemoveItem(item itemToRemove) {
//    List<item> itemsToRemove = new List<item>();

//     // Find all instances of itemToRemove in the itemList
//     foreach (var item in playerInventory.itemList)
//     {
//         if (item == itemToRemove)
//         {
//             itemsToRemove.Add(item);
//         }
//     }

//     // Remove all instances of itemToRemove
//     foreach (var item in itemsToRemove)
//     {
//         playerInventory.itemList.Remove(item);
//     }

//     InventoryManager.RefreshItem();
//     }
  

//  }