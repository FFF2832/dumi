// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class CheckInput : MonoBehaviour
// {
//      public Sprite sprite1; // 第一個圖片
//     public Sprite sprite2; // 第二個圖片
//      public Sprite sprite3; // 第二個圖片
//      public Sprite sprite4; // 第二個圖片
//      private SpriteRenderer spriteChange;
//      public Canvas popupCanvas; // 在Unity编辑器中将Canvas拖拽到这个字段中
// public float popupDuration = 2f; // 指定弹出Canvas的持续时间，以秒为单位
// private bool isPopupVisible = false; // 用于跟踪Canvas是否可见
// private float popupTimer = 0f; // 用于计时显示Canvas的时间
   
   
//     public static bool ChangeScene ;
//     void Start(){
//         spriteChange = GetComponent<SpriteRenderer>();
    
//         ChangeScene=false;
//         popupCanvas.gameObject.SetActive(false);
//     }
//     // Update is called once per frame
//     void Update()
//     {
//          // 如果Canvas可见，开始计时
//     if (isPopupVisible)
//     {
//         popupTimer += Time.deltaTime;
//     //Debug.Log("popupTimer: " + popupTimer); // 输出计时器的值
//         // 如果计时超过指定的持续时间，隐藏Canvas并重置计时器
//         if (popupTimer >= popupDuration)
//         {
//             popupCanvas.gameObject.SetActive(false);
//             popupCanvas.enabled = false;
//             isPopupVisible = false;
            
//         }
//     }

//         if(!PassWord.checkInput()){
//             if (ItemOndrag.checktire1())
//             {
//         // 在正確的位置上且拖曳的物品輪胎1，更換成 sprite1
//                 spriteChange.sprite = sprite1;
//             }
//             else if (ItemOndrag.checktire2())
//             {
//         // 在正確的位置上且拖曳的物品是輪胎2，更換成 sprite2
//                 spriteChange.sprite = sprite2;
//             }
//             else if(ItemOndrag.checktire1()&&ItemOndrag.checktire2()){
//                 spriteChange.sprite = sprite3; // 切換好車
//                  popupCanvas.gameObject.SetActive(true);
//         isPopupVisible = true;
   
//             }
//             else
//             {
//             //壞車，顯示 sprite4
//                 spriteChange.sprite = sprite4;
//             }
//         }

//        else{
//             if (PassWord.checkInput()&&ItemOndrag.checktire1()&&ItemOndrag.checktire2()) // 呼叫 PassWord 的 checkInput 方法，回傳 bool 值
//             {
//             spriteChange.sprite = sprite3; // 切換好車
           
//             ChangeScene=true;
//             popupCanvas.gameObject.SetActive(true);
//             isPopupVisible = true;
    
            
//             }
       
//             else
//             {
//             spriteChange.sprite = sprite4; // 切換成第二個圖片
        
//             ChangeScene=false;
//             }
//        }

//     }
//     public void ChangeTonight(){
//     if(ChangeScene) spriteChange.sprite = sprite4; // 切換成第二個圖片
//     Application.LoadLevel(3);

//    } 
//    public static bool UpdateChangeScene(){
//         return ChangeScene;
//    }
// }
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

    // 从PlayerPrefs中获取ChangeScene标志
    private static int changeSceneFlag;
    public static bool ChangeScene ;
    private Enlarge enlargeScript; // 引用Enlarge脚本的变量
    private tire1change tire1Change;
  
     private void Awake()
     {
        enlargeScript = GetComponent<Enlarge>();
        spriteChange = GetComponent<SpriteRenderer>();
        tire1Change=  GetComponent<tire1change>();
         if (tire1Change == null)
        {
        Debug.LogError("tire1change script is not attached or not found.");
        }

        // 从PlayerPrefs中获取ChangeScene标志的值
        changeSceneFlag = PlayerPrefs.GetInt("ChangeSceneFlag", 0);

       // 在这里檢查物品是否已被收集，但不要馬上重置 isCollected
        if (changeSceneFlag == 1)
        {
         spriteChange.sprite = sprite3; // 切換成第二個圖片
        // 如果已被收集，你可以隱藏物品或者改變其外觀
            ChangeScene = true;
            spriteChange.sprite = sprite3; // 切換成第二個圖片
            
        }
        else
        {
        ChangeScene = false; // 如果未被收集，将 isCollected 设置为 false
        }

        popupCanvas.gameObject.SetActive(false);
     }
    // void Start()
    // {
    //     enlargeScript = GetComponent<Enlarge>();
    //     spriteChange = GetComponent<SpriteRenderer>();

    // // 从PlayerPrefs中获取ChangeScene标志的值
    // changeSceneFlag = PlayerPrefs.GetInt("ChangeSceneFlag", 0);

    // if (changeSceneFlag == 1)
    // {
    //     ChangeScene = true;
    // }
    // else
    // {
    //     ChangeScene = false;
    // }

    // popupCanvas.gameObject.SetActive(false);
    // }


    //  private void Awake()
    // {
       
    //     // 在这里檢查物品是否已被收集，但不要馬上重置 isCollected
    //     if (changeSceneFlag == 1)
    //     {
    //      spriteChange.sprite = sprite3; // 切換成第二個圖片
    //     // 如果已被收集，你可以隱藏物品或者改變其外觀
    //         ChangeScene = true;
    //         spriteChange.sprite = sprite3; // 切換成第二個圖片
        
    //     }
    //     else
    //     {
    //     ChangeScene = false; // 如果未被收集，将 isCollected 设置为 false
    //     }
    // }

    // Update is called once per frame
    void Update()
    {
        //場景未切換
        if(changeSceneFlag==0)
        {
                // 如果Canvas可见，开始计时
                if (isPopupVisible)
                {
                popupTimer += Time.deltaTime;

                    // 如果计时超过指定的持续时间，隐藏Canvas并重置计时器
                    if (popupTimer >= popupDuration)
                    {
                    popupCanvas.gameObject.SetActive(false);
                    popupCanvas.enabled = false;
                    isPopupVisible = false;
                    Destroy(popupCanvas);
                    }
                }
            //沒有輸入密碼
            if (!PassWord.checkInput())
            {
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
                else if (ItemOndrag.checktire1() && ItemOndrag.checktire2())
                {
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
            else
            {

                //輸入密碼且輪胎皆放置成功
               if (PassWord.checkInput() && ItemOndrag.checktire1() && ItemOndrag.checktire2()) 
             ///   if (PassWord.checkInput() && PlayerPrefs.GetInt("changeTire1", 1)) 
                {
                    Debug.Log("都正確");

                    spriteChange.sprite = sprite3; // 切換好車

                    // 设置ChangeScene为true
                    ChangeScene = true;

                    // 将ChangeScene标志存储在PlayerPrefs中
                    PlayerPrefs.SetInt("ChangeSceneFlag", 1);
                    PlayerPrefs.Save();

                    popupCanvas.gameObject.SetActive(true);
                    isPopupVisible = true;
                }
                else
                {
                    spriteChange.sprite = sprite4; // 切換成第二個圖片

                    // 设置ChangeScene为false
                    ChangeScene = false;

                    // 将ChangeScene标志存储在PlayerPrefs中
                    PlayerPrefs.SetInt("ChangeSceneFlag", 0);
                    PlayerPrefs.Save();
                }
            }
        }
        //場景已切換
        else {
            spriteChange.sprite = sprite3; // 切換好車
            

            if (enlargeScript != null)
            {
            // 禁用Enlarge脚本
            enlargeScript.enabled = false;
            }
           
            
              
        }
        
    }
        public void ChangeTonight(){
        if(changeSceneFlag==1) {
        spriteChange.sprite = sprite3; // 切換好車
        Application.LoadLevel(3);
        }

   } 
   public static bool UpdateChangeScene(){
        return ChangeScene;
   }
   public  int UpdatechangeSceneFlag(){
       
        return changeSceneFlag;
   }
}
