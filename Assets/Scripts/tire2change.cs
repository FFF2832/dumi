// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class tire2change : MonoBehaviour
// {
//     public Sprite sprite1; // 第一個圖片
//     public Sprite sprite2; // 第二個圖片
//     private Image spriteChange;

//     public item itemToRemove;
//     public Inventory playerInventory;
// private bool changetire2;


// // 在 Start 方法中獲取 ItemOndrag 腳本的參考
// void Start()
// {
//     spriteChange = GetComponent<Image>();
//     if (spriteChange == null)
//     {
//         Debug.LogError("Image component not found!");
//     }
//      changetire2=false;

// }

// // 在 Update 方法中使用 ItemOndrag 腳本中的陣列值
// void Update()
// {
    
     
//     // 檢查ItemOndrag腳本中的布林陣列值
//     bool[] positionCorrect = ItemOndrag.checkPositionCorrect();
//     bool[] itemCorrect = ItemOndrag.checkItemCorrect();

 

//     if (ItemOndrag.checktire2())
//     {
        
//             changetire2=true;
//        // spriteChange.enabled = true;

//        RemoveItem(itemToRemove);
          
//     }
//     else
//     {
//         // 如果不在正確的位置上，顯示 sprite2
//               changetire2=false;
//         spriteChange.sprite = sprite2;
//     }
// }
//  public  void RemoveItem(item itemToRemove)
//     {
//         List<item> itemsToRemove = new List<item>();

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
//     changeImage();
//     }
//     public void changeImage(){
//           if (changetire2)
//         {
//             spriteChange.sprite = sprite2; // 更新圖片
//             changetire2 = false;
//         }
//         else {
//              spriteChange.sprite = sprite1; // 更新圖片
//         }

//     }

// }

// 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tire2change : MonoBehaviour
{
    public Sprite sprite1; // 第一個圖片
    public Sprite sprite2; // 第二個圖片
    private Image spriteChange;

    public item itemToRemove;
    public Inventory playerInventory;
  //  public Image tire;
private bool changetire2;


// 在 Start 方法中獲取 ItemOndrag 腳本的參考
void Start()
{
    spriteChange = GetComponent<Image>();
    if (spriteChange == null)
    {
        Debug.LogError("Image component not found!");
    }
   // spriteChange.enabled = false;
   changetire2=false;
}

// 在 Update 方法中使用 ItemOndrag 腳本中的陣列值
void Update()
{
    
     
    // 檢查ItemOndrag腳本中的布林陣列值
    bool[] positionCorrect = ItemOndrag.checkPositionCorrect();
    bool[] itemCorrect = ItemOndrag.checkItemCorrect();

 

    if (ItemOndrag.checktire2())
    {
     //   Debug.Log("checktire2 is true");
        changetire2 = true;
        RemoveItem(itemToRemove);
          Debug.Log("checktire2"+ItemOndrag.checktire2());
    }
    else
    {
      //  Debug.Log("checktire2 is false");
        changetire2 = false;
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
    changeImage2();
    }
    public void changeImage2(){
          if (changetire2)
        {
            spriteChange.sprite = sprite2; // 更新圖片
            changetire2 = false;
        }
        else {
             spriteChange.sprite = sprite1; // 更新圖片
        }

    }

}