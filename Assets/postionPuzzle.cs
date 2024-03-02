using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class postionPuzzle : MonoBehaviour
{
    public Sprite sprite1; // 第一個圖片
    public Sprite sprite2; // 第二個圖片
    private Image spriteChange;

    public item itemToRemove;
    public Inventory playerInventory;
    private bool[] posionOk; // 初始化数组

    void Start()
    {
        spriteChange = GetComponent<Image>();
        if (spriteChange == null)
        {
            Debug.LogError("Image component not found!");
        }

        // 初始化 posionPuzzle 数组
        posionOk = new bool[2]; // 设置数组长度为 2
        posionOk[1] = false;
    }

    void Update()
    {
        // 檢查ItemOndrag腳本中的布林陣列值
        bool[] positionCorrect = ItemOndrag.checkPositionCorrect();
        bool[] itemCorrect = ItemOndrag.checkItemCorrect();

        bool[] checkPosionItemResult = ItemOndrag.CheckPosionItem();
        if (checkPosionItemResult != null && checkPosionItemResult.Length > 1)
        {
            posionOk[1] = checkPosionItemResult[1];
            if (posionOk[1])
            {
                RemoveItem(itemToRemove);
            }
        }
    }

    public void RemoveItem(item itemToRemove)
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
        changeImage();
    }

    public void changeImage()
    {
        if (posionOk[1])
        {
            spriteChange.sprite = sprite2; // 更新圖片
            Debug.Log("posionOk[1]:" + posionOk[1]);
        }
        else
        {
            spriteChange.sprite = sprite1; // 更新圖片
        }
    }

    public bool Updatechangetire1()
    {
        Debug.Log("posionOk[1]:" + posionOk[1]);
        return posionOk[1];
    }
}
