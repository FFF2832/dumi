using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemOnworld : MonoBehaviour
{
   public item thisItem;
   public Inventory playerInventory;

  private void Update(){
    check2DObjectClicked();
  }
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

   void check2DObjectClicked()
{
    if (Input.GetMouseButtonDown(0))
    {
       // Debug.Log("Mouse is pressed down");
        Camera cam = Camera.main;

        //Raycast depends on camera projection mode
        Vector2 origin = Vector2.zero;
        Vector2 dir = Vector2.zero;

        if (cam.orthographic)
        {
            origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            origin = ray.origin;
            dir = ray.direction;
        }

        RaycastHit2D hit = Physics2D.Raycast(origin, dir);

        //Check if we hit anything
        if (hit)
        {
            
          
            if(hit.collider.name=="樹枝本人"){
             
                Debug.Log("We hit " + hit.collider.name);
                AddNewItem();
                Destroy(hit.collider);
                 Destroy(gameObject);
                Debug.Log("touch");
            }
            if(hit.collider.name=="collectitem_car"){
             
                Debug.Log("We hit " + hit.collider.name);
                AddNewItem();
                Destroy(gameObject);
                Destroy(hit.collider);
                Debug.Log("touch");
            }
             

        }
    } 
    
}

          
        


}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class itemOnworld : MonoBehaviour
// {
//    public item thisItem;
//    public Inventory playerInventory;

//   private void Update(){
//     check2DObjectClicked();
//   }
//    private void OnTriggerEnter2D(Collider2D other)
//    {
//     if(other.gameObject.CompareTag("Player")){
//         AddNewItem();
//         Destroy(gameObject);
//         Debug.Log("touch");
//     }  
//    } 
//    public void AddNewItem(){
//     if(!playerInventory.itemList.Contains(thisItem)){
//          //playerInventory.itemList.Add(thisItem);
//           //未刪CreateNewItem
//          //InventoryManager.CreateNewItem(thisItem);
//          for(int i=0;i<playerInventory.itemList.Count;i++){
//                 if(playerInventory.itemList[i]==null){
//                         playerInventory.itemList[i]=thisItem;
//                         Debug.Log(thisItem.itemID);
//                         break;
//                 }
//          }
//     }
//     else {
//         thisItem.itemHeild += 1;
//     }
//     InventoryManager.RefreshItem(); 
//    }

//    void check2DObjectClicked()
// {
//     if (Input.GetMouseButtonDown(0))
//     {
//         Debug.Log("Mouse is pressed down");
//         Camera cam = Camera.main;

//         //Raycast depends on camera projection mode
//         Vector2 origin = Vector2.zero;
//         Vector2 dir = Vector2.zero;

//         if (cam.orthographic)
//         {
//             origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//         }
//         else
//         {
//             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//             origin = ray.origin;
//             dir = ray.direction;
//         }

//         RaycastHit2D hit = Physics2D.Raycast(origin, dir);

//         //Check if we hit anything
//         if (hit)
//         {
            
          
//             if(hit.collider.name=="樹枝本人"){
             
//                 Debug.Log("We hit " + hit.collider.name);
//                 AddNewItem();
//                 Destroy(hit.collider);
//                  Destroy(gameObject);
//                 Debug.Log("touch");
//             }
//             if(hit.collider.name=="零件"){
             
//                 Debug.Log("We hit " + hit.collider.name);
//                 AddNewItem();
//                 Destroy(gameObject);
//                 Destroy(hit.collider);
//                 Debug.Log("touch零件");
//             }
             

//         }
//     } 
    
// }

// }
