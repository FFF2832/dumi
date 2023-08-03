using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckInput : MonoBehaviour
{
     public Sprite sprite1; // 第一個圖片
    public Sprite sprite2; // 第二個圖片
     public Sprite sprite3; // 第二個圖片
     public Sprite sprite4; // 第二個圖片
     private SpriteRenderer spriteChange;
   
   
    public static bool ChangeScene ;
    void Start(){
        spriteChange = GetComponent<SpriteRenderer>();
    
        ChangeScene=false;
    }
    // Update is called once per frame
    void Update()
    {
        if(!PassWord.checkInput()){
            if (ItemOndrag.checktire1())
            {
        // 在正確的位置上且拖曳的物品輪胎1，更換成 sprite1
                spriteChange.sprite = sprite1;
            }
            if (ItemOndrag.checktire2())
            {
        // 在正確的位置上且拖曳的物品是輪胎2，更換成 sprite2
                spriteChange.sprite = sprite2;
            }
            if(ItemOndrag.checktire1()&&ItemOndrag.checktire2()){
                spriteChange.sprite = sprite3; // 切換好車
            }
            else
            {
            //壞車，顯示 sprite4
                spriteChange.sprite = sprite4;
            }
        }

       else{
            if (PassWord.checkInput()&&ItemOndrag.checktire1()&&ItemOndrag.checktire2()) // 呼叫 PassWord 的 checkInput 方法，回傳 bool 值
            {
            spriteChange.sprite = sprite3; // 切換好車
           
            ChangeScene=true;
            
            }
       
            else
            {
            spriteChange.sprite = sprite4; // 切換成第二個圖片
        
            ChangeScene=false;
            }
       }

    }
    public static void ChangeTonight(){
     Application.LoadLevel(3);
    Debug.Log("切換場景 " );
   } 
}
