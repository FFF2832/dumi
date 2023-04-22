using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryManager : MonoBehaviour
{

    static InventoryManager instance;
    public Inventory myBag;
    public GameObject slotGrid;
    public slot slotPrefab;
    public Text itemInformation;
    void Awake(){
        if(instance !=null){
            Destroy(this);
            instance=this;
        }

    }
    //將item 的資料傳送到 slot
    public static void  CreateNewItem(item item){
        slot newItem=Instantiate(instance.slotPrefab,instance.slotGrid.transform.position,Quaternion.identity);
        //子集
      
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        newItem.slotItem=item;
        newItem.slotImage.sprite=item.itemImage;
        
    }
}
