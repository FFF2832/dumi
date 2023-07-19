using UnityEngine;
using UnityEngine.EventSystems;

public class clue : MonoBehaviour, IPointerClickHandler
{

   
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("點擊了UI物品：" + name);
        // 在這裡添加你想要的點擊功能邏輯
        AddNewItem();
        Destroy(gameObject); // 刪除點擊完的物品
    }
    public item thisItem;
   public Inventory playerInventory;
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
