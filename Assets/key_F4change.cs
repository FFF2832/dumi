//key_F3change
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class key_F4change : MonoBehaviour
{
     public GameObject layer1;
    public GameObject layer2;
    private Image spriteChange;

    public item itemToRemove1;
    public Inventory playerInventory;
    public static bool changekey_1;
    // Start is called before the first frame update
    void Start()
    {
        spriteChange = GetComponent<Image>();
    if (spriteChange == null)
    {
        Debug.LogError("Image component not found!");
    }
    changekey_1=false;
    }

    // Update is called once per frame
    void Update()
    {
          if (ItemOndrag.checkkey_F4correct())
        {
            Debug.Log("有4"+ItemOndrag.checkkey_F4correct());
       
         RemoveItem(itemToRemove1);
         Destroy(layer1);
          Destroy(layer2);
          changekey_1=true;
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
    }
}
