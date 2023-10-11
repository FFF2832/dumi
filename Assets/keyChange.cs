using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class keyChange : MonoBehaviour
{
     public GameObject layer1;
    public GameObject layer2;
    private Image spriteChange;

    public item itemToRemove1;

    public item itemToRemove2;

    public item itemToRemove3;

    public item itemToRemove4;

      public item itemToRemove5;

   // public item itemToRemove;
    public Inventory playerInventory;
    public static bool changekey_1;
    public static bool changekey_2;
    // Start is called before the first frame update
    void Start()
    {
        spriteChange = GetComponent<Image>();
    if (spriteChange == null)
    {
        Debug.LogError("Image component not found!");
    }
    changekey_1=false;
    changekey_2=false;
    }

    // Update is called once per frame
    void Update()
    {
         if (ItemOndrag.checkkeyCorrect())
        {
            Debug.Log("checkkeyCorrect"+ItemOndrag.checkkeyCorrect());
       
         RemoveItem(itemToRemove1);
         RemoveItem(itemToRemove2);
         RemoveItem(itemToRemove3);
         RemoveItem(itemToRemove4);
         RemoveItem(itemToRemove5);
         Destroy(layer1);
          Destroy(layer2);
          changekey_1=true;
         }
        // if (ItemOndrag.checkkey_F3correct())
        // {
       
        //  RemoveItem(itemToRemove);
        //  Destroy(layer1);
        //   Destroy(layer2);
        //    changekey_2=true;
        //  }

       
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
