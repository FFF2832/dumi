using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class keyChange : MonoBehaviour
{
     public GameObject layer1;
    public GameObject layer2;
    private Image spriteChange;

    public item itemToRemove;
    public Inventory playerInventory;
    // Start is called before the first frame update
    void Start()
    {
        spriteChange = GetComponent<Image>();
    if (spriteChange == null)
    {
        Debug.LogError("Image component not found!");
    }
    }

    // Update is called once per frame
    void Update()
    {
         if (ItemOndrag.checkkeyCorrect())
        {
       
         RemoveItem(itemToRemove);
         Destroy(layer1);
          Destroy(layer2);
         }

        else
        {
       
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
