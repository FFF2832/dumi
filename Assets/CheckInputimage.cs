using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CheckInputimage : MonoBehaviour
{
       private Image imageChange;
       public Sprite sprite1; // 第一個圖片
    public Sprite sprite2; // 第二個圖片
    void Start()
    {
          imageChange = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PassWord.checkInput()&&ItemOndrag.checkTarget()) // 呼叫 PassWord 的 checkInput 方法，回傳 bool 值
        {
           
              imageChange.sprite = sprite2; // 切換成第一個圖片
       
            
        }
       
        else
        {
           
            imageChange.sprite = sprite1; // 切換成第一個圖片
           
        }
    }
}
