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
     public Canvas popupCanvas; // 在Unity编辑器中将Canvas拖拽到这个字段中
public float popupDuration = 2f; // 指定弹出Canvas的持续时间，以秒为单位
private bool isPopupVisible = false; // 用于跟踪Canvas是否可见
private float popupTimer = 0f; // 用于计时显示Canvas的时间
   
   
    public static bool ChangeScene ;
    void Start(){
        spriteChange = GetComponent<SpriteRenderer>();
    
        ChangeScene=false;
        popupCanvas.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
         // 如果Canvas可见，开始计时
    if (isPopupVisible)
    {
        popupTimer += Time.deltaTime;
    //Debug.Log("popupTimer: " + popupTimer); // 输出计时器的值
        // 如果计时超过指定的持续时间，隐藏Canvas并重置计时器
        if (popupTimer >= popupDuration)
        {
            popupCanvas.gameObject.SetActive(false);
            popupCanvas.enabled = false;
            isPopupVisible = false;
            
        }
    }

        if(!PassWord.checkInput()){
            if (ItemOndrag.checktire1())
            {
        // 在正確的位置上且拖曳的物品輪胎1，更換成 sprite1
                spriteChange.sprite = sprite1;
            }
            else if (ItemOndrag.checktire2())
            {
        // 在正確的位置上且拖曳的物品是輪胎2，更換成 sprite2
                spriteChange.sprite = sprite2;
            }
            else if(ItemOndrag.checktire1()&&ItemOndrag.checktire2()){
                spriteChange.sprite = sprite3; // 切換好車
                 popupCanvas.gameObject.SetActive(true);
    isPopupVisible = true;
   
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
            popupCanvas.gameObject.SetActive(true);
            isPopupVisible = true;
    
            
            }
       
            else
            {
            spriteChange.sprite = sprite4; // 切換成第二個圖片
        
            ChangeScene=false;
            }
       }

    }
    public static void ChangeTonight(){
     if(ChangeScene)Application.LoadLevel(3);
    Debug.Log("切換場景 " );
   } 
   public static bool UpdateChangeScene(){
        return ChangeScene;
   }
}
