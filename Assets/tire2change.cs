using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tire2change : MonoBehaviour
{
    public Sprite sprite1; // 第一個圖片
    public Sprite sprite2; // 第二個圖片
    private Image spriteChange;

    public item itemToRemove;
    public Inventory playerInventory;



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
    
     
    // 檢查ItemOndrag腳本中的布林陣列值
    bool[] positionCorrect = ItemOndrag.checkPositionCorrect();
    bool[] itemCorrect = ItemOndrag.checkItemCorrect();

    // 您可以在這裡使用Debug.Log輸出這些陣列的值，以便檢查它們是否正確更新
    Debug.Log("positionCorrect[3]: " + positionCorrect[3]);
    Debug.Log("itemCorrect[3]: " + itemCorrect[3]);

    if (ItemOndrag.checktire2())
    {
        // 在正確的位置上且拖曳的物品是零件1，更換成 sprite1
        spriteChange.sprite = sprite1;
    }
    else
    {
        // 如果不在正確的位置上，顯示 sprite2
        spriteChange.sprite = sprite2;
    }
}


}
