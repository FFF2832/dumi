using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeImage : MonoBehaviour
{
    public Sprite sprite1; // 第一個圖片
    public Sprite sprite2; // 第二個圖片
    private Image spriteChange;

    void Start()
    {
        spriteChange = GetComponent<Image>();
          if (spriteChange == null) {
        Debug.LogError("Image component not found!");
    }
    }

    void Update()
    {
        if (ItemOndrag.checkTarget())
        {
            spriteChange.sprite = sprite1;
        }
        else
        {
            spriteChange.sprite = sprite2;
        }
    }
}
