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
        if(instance !=null)Destroy(this);
            instance=this;
        

    }
   
    private void OnEnable()
    {
        RefreshItem();
    }
    //將item 的資料傳送到 slot
    public static void  CreateNewItem(item item){
        slot newItem=Instantiate(instance.slotPrefab,instance.slotGrid.transform.position,Quaternion.identity);
        //子集
      
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        newItem.slotItem=item;
        newItem.slotImage.sprite=item.itemImage;
        
    }
    //  用來計算數量
    public static void RefreshItem()
    {
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            if(instance.slotGrid.transform.childCount==0)break;
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < instance.myBag.itemList.Count ; i++)
        {
            CreateNewItem(instance.myBag.itemList[i]);
        }
        
    }
}
