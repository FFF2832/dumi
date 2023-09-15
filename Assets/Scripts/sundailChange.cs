using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sundailChange : MonoBehaviour
{

    public Sprite sprite1; // 第一個圖片
    public Sprite sprite2; // 第二個圖片
    private Image spriteChange;

    // public item itemToRemove;
    // public Inventory playerInventory;



// 在 Start 方法中獲取 ItemOndrag 腳本的參考
void Start()
{
    spriteChange = GetComponent<Image>();
    if (spriteChange == null)
    {
        Debug.LogError("Image component not found!");
    }

}

// 在 Update 方法中使用 ItemOndrag 腳本中的陣列值
void Update()
{
    

    if (EnterKey.UpdatepasswordCorrect())
    {
        
        spriteChange.sprite = sprite2;
    
    }

    else
    {
   
        spriteChange.sprite = sprite1;
    }
}

}
