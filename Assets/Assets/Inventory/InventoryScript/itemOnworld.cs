using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemOnworld : MonoBehaviour
{
   public item thisItem;
   public Inventory playerInventory;

  
   private void OnTriggerEnter2D(Collider2D other)
   {
    if(other.gameObject.CompareTag("Player")){
        AddNewItem();
        Destroy(gameObject);
        Debug.Log("touch");
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
}
