// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class postionPuzzle : MonoBehaviour
// {
//     public Sprite sprite1; // 第一個圖片
//     public Sprite sprite2; // 第二個圖片
//     private Image spriteChange;

//     public item itemToRemove;
//     public Inventory playerInventory;
//     private bool[] posionOk; // 初始化数组

//     void Start()
//     {
//         spriteChange = GetComponent<Image>();
//         if (spriteChange == null)
//         {
//             Debug.LogError("Image component not found!");
//         }

//         // 初始化 posionPuzzle 数组
//         posionOk = new bool[2]; // 设置数组长度为 2
//         posionOk[1] = false;
//     }

//     void Update()
//     {
//         // 檢查ItemOndrag腳本中的布林陣列值
//         bool[] positionCorrect = ItemOndrag.checkPositionCorrect();
//         bool[] itemCorrect = ItemOndrag.checkItemCorrect();

//         bool[] checkPosionItemResult = ItemOndrag.CheckPosionItem();
//         if (checkPosionItemResult != null && checkPosionItemResult.Length > 1)
//         {
//             posionOk[1] = checkPosionItemResult[1];
//             if (posionOk[1])
//             {
//                 RemoveItem(itemToRemove);
//             }
//         }
//     }

//     public void RemoveItem(item itemToRemove)
//     {
//         List<item> itemsToRemove = new List<item>();

//         // Find all instances of itemToRemove in the itemList
//         foreach (var item in playerInventory.itemList)
//         {
//             if (item == itemToRemove)
//             {
//                 itemsToRemove.Add(item);
//             }
//         }

//         // Remove all instances of itemToRemove
//         foreach (var item in itemsToRemove)
//         {
//             playerInventory.itemList.Remove(item);
//         }

//         InventoryManager.RefreshItem();
//         changeImage();
//     }

//     public void changeImage()
//     {
//         if (posionOk[1])
//         {
//             spriteChange.sprite = sprite2; // 更新圖片
//             Debug.Log("posionOk[1]:" + posionOk[1]);
//         }
//         else
//         {
//             spriteChange.sprite = sprite1; // 更新圖片
//         }
//     }

//     public bool Updatechangetire1()
//     {
//         Debug.Log("posionOk[1]:" + posionOk[1]);
//         return posionOk[1];
//     }
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class postionPuzzle : MonoBehaviour
{
    // public Sprite sprite1; // 第一個圖片
    // public Sprite sprite2; // 第二個圖片
    // public Sprite sprite3; // 第三個圖片
    //    public Sprite sprite4; // 第三個圖片
    private Image spriteChange;

    public item[] itemsToRemove;
    public Inventory playerInventory;
    private bool[] posionOk; // 初始化数组
    public GameObject layer1;
    public GameObject layer2;
    public GameObject layer3;
    public item itemToRemove1;
    public item itemToRemove2;
    public item itemToRemove3;

    void Start()
    {
        // spriteChange = GetComponent<Image>();
        // if (spriteChange == null)
        // {
        //     Debug.LogError("Image component not found!");
        // }

        // 初始化 posionPuzzle 数组
        posionOk = new bool[3]; // 设置数组长度为 3
        for (int i = 0; i < posionOk.Length; i++)
        {
            posionOk[i] = false;
        }
    }

    void Update()
    {
        // 檢查ItemOndrag腳本中的布林陣列值
        // bool[] checkPosionItemResult = ItemOndrag.CheckPosionItem();
//        Debug.Log("checkPosionItemResult"+checkPosionItemResult[1]);
        changeImage();
        // if (checkPosionItemResult != null && checkPosionItemResult.Length >= posionOk.Length)
        // {
            // for (int i = 0; i < posionOk.Length; i++)
            // {
            //     posionOk[i] = checkPosionItemResult[i];
                
            //     if (posionOk[i])
            //     {
            //         RemoveItem(itemsToRemove[i]);
            //         Debug.Log("posionOk"+posionOk[i]);
            //     }
            // }
        //    if(posionOk[0])PlayerPrefs.SetInt("geckoOk", 1);
        //     if(posionOk[1])PlayerPrefs.SetInt("frogOk", 1);
        //     if(posionOk[2])PlayerPrefs.SetInt("centiOk", 1);
            // else {
            //     PlayerPrefs.SetInt("geckoOk", 0);
            //     PlayerPrefs.SetInt("frogOk", 0);
            //     PlayerPrefs.SetInt("centiOk", 0);
            // }
        // }
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
        if (ItemOndrag.CheckPosionItemdone1())
        {
            Debug.Log("有進壁虎" );
            RemoveItem(itemToRemove1);
            Destroy(layer1);

        }
        else if (ItemOndrag.CheckPosionItemdone2())
        {
            Debug.Log("有進蛙" );
            RemoveItem(itemToRemove2);
            Destroy(layer2);
        }
        else if (ItemOndrag.CheckPosionItemdone3())
        {
            Debug.Log("有進蜈蚣" );
            RemoveItem(itemToRemove3);
            Destroy(layer3);
        }
        // else
        // {
        //     Debug.Log("都沒進" );
        // }
        // if (PlayerPrefs.GetInt("geckoOk")==1)
        // {
        //     Debug.Log("有進壁虎" );
        //     spriteChange.sprite = sprite2; // 更新圖片
        //     RemoveItem(itemsToRemove[0]);

        // }
        // else if (PlayerPrefs.GetInt("frogOk")==1)
        // {
        //     Debug.Log("有進蛙" );
        //     spriteChange.sprite = sprite3; // 更新圖片
        //      RemoveItem(itemsToRemove[1]);
        // }
        // else if (PlayerPrefs.GetInt("centiOk")==1)
        // {
        //     Debug.Log("有進蜈蚣" );
        //     spriteChange.sprite = sprite4; // 更新圖片
        //      RemoveItem(itemsToRemove[2]);
        // }
        // else
        // {
        //     Debug.Log("都沒進" );
        //     spriteChange.sprite = sprite1; // 更新圖片
        // }
    }

    public bool[] GetPosionOk()
    {
        return posionOk;
    }
}
