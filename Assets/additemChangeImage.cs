
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
     public GameObject itemcollect;
   public Inventory playerInventory;
    
    void Start()
    {
        spriteChange = GetComponent<Image>();
          if (spriteChange == null) {
        Debug.LogError("Image component not found!");
    }
    }




void Update()
{
    
     
    // 檢查ItemOndrag腳本中的布林陣列值
    bool[] positionCorrect = ItemOndrag.checkPositionCorrect();
    bool[] itemCorrect = ItemOndrag.checkItemCorrect();

    // 您可以在這裡使用Debug.Log輸出這些陣列的值，以便檢查它們是否正確更新
    Debug.Log("positionCorrect[1]: " + positionCorrect[1]);
    Debug.Log("itemCorrect[1]: " + itemCorrect[1]);

    if (ItemOndrag.checktree())
    {
        // 在正確的位置上且拖曳的物品是零件1，更換成 sprite1
        spriteChange.sprite = sprite1;
         AddNewItem(thisItem);
        RemoveItem(itemToRemove);
        Destroy(itemcollect);
    }
    else
    {
        // 如果不在正確的位置上，顯示 sprite2
        spriteChange.sprite = sprite2;
    }
}


public void AddNewItem(item thisItem){
    if(!playerInventory.itemList.Contains(thisItem)){
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