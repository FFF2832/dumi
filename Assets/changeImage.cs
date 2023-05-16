
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
    
    void Update()
    {
        // if (ItemOndrag.checkTarget())
        // {

        //     spriteChange.sprite = sprite1;
        //     if(ItemOndrag.checkPosition()==1)AddNewItem();
        // }
        // if (ItemOndrag.checkTarget())
        // {

        //     spriteChange.sprite = sprite1;
        //     if(ItemOndrag.checkPosition()==1)AddNewItem();
        // }
        if(ItemOndrag.checkPosition()==1&&ItemOndrag.checkitemPosition()==1){
              AddNewItem();
              //Destroy(gameObject);
               RemoveItem(itemToRemove);
        }
       if(ItemOndrag.checkPosition()==2&&ItemOndrag.checkitemPosition()==2){
              spriteChange.sprite = sprite3;
                 RemoveItem(itemToRemove);
        }
        
        else
        {
            spriteChange.sprite = sprite2;
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