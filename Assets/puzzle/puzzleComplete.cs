using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleComplete : MonoBehaviour
{
     public item thisItem;
    public Inventory playerInventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("puzzle1"+puzzleChange.puzzle1complete());
         Debug.Log("puzzle2"+puzzle2.puzzle2complete());
          Debug.Log("puzzle3"+puzzle3.puzzle3complete());
        if(puzzleChange.puzzle1complete()&&puzzle2.puzzle2complete()&&puzzle3.puzzle3complete()){
            AddNewItem(thisItem);
        }
    }
     public void AddNewItem(item thisItem){
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
