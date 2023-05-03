using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckInput : MonoBehaviour
{
     public Sprite sprite1; // 第一個圖片
    public Sprite sprite2; // 第二個圖片
     private SpriteRenderer spriteChange;
    public static bool ChangeScene ;
    void Start(){
        spriteChange = GetComponent<SpriteRenderer>();
        ChangeScene=false;
    }
    // Update is called once per frame
    void Update()
    {
        if (PassWord.checkInput()&&ItemOndrag.checkTarget()) // 呼叫 PassWord 的 checkInput 方法，回傳 bool 值
        {
            spriteChange.sprite = sprite2; // 切換成第一個圖片
            ChangeScene=true;
            
        }
        else
        {
            spriteChange.sprite = sprite1; // 切換成第二個圖片
            ChangeScene=false;
        }

    }
    public static void ChangeTonight(){
     Application.LoadLevel(3);
    Debug.Log("切換場景 " );
   } 
}
