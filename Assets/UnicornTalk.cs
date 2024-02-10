using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnicornTalk : MonoBehaviour
{
    public GameObject talkUI;   //对话框
    public GameObject talkUI2; 
     public GameObject talkUI3; 
    public GameObject talkUI4; 
    //private bool isinside;
    // Start is called before the first frame update
    private static bool finishTalk;  
    private bool isCandleCorrect;
    
 
    void Start()
    {
       
       // isinside=false;
        talkUI.SetActive(false);
       //  talkUI2.SetActive(false);
        talkUI3.SetActive(false);
         if (CandleManager.UpdatecandleCorrect())
            {
                talkUI.SetActive(true);
                talkUI2.SetActive(false);
                
                    
                    if(CustomerController.UpdateiceCreamok()){ 
                        talkUI3.SetActive(true);
                        talkUI2.SetActive(false);
                        talkUI.SetActive(false);
                         talkUI4.SetActive(true);
                   
                    }  
                    else{
                    talkUI.SetActive(true);
                    talkUI2.SetActive(false);
                    talkUI3.SetActive(false);
                    }
                }
         else if(CandleManager.UpdatecandleCorrect()&&CustomerController.UpdateiceCreamok()){
                  talkUI3.SetActive(true);
                        talkUI2.SetActive(false);
                        talkUI.SetActive(false);
                         talkUI4.SetActive(true);
         }
            
                else {
                    talkUI.SetActive(false);
                    talkUI2.SetActive(true);
                     talkUI3.SetActive(false);
                       talkUI4.SetActive(false);
                }
           
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("update"+CustomerController.UpdateiceCreamok());
      
                    
            // 如果点击了鼠标左键
        if (Input.GetMouseButtonDown(0))
        {
            // 获取鼠标的位置
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // 获取被点击的物体的位置
            Vector2 objPos = transform.position;

            // 如果鼠标点击了这个物体
            if (mousePos.x >= objPos.x - 0.5f && mousePos.x <= objPos.x + 0.5f
                && mousePos.y >= objPos.y - 0.5f && mousePos.y <= objPos.y + 0.5f)
            {
                // 显示 Canvas

               
                // if(finishTalk){
                //     talkUI.SetActive(true);
                //     talkUI2.SetActive(false);
                // }
                

                if (CandleManager.UpdatecandleCorrect())
                {
                   
                      
                    talkUI.SetActive(true);
                    talkUI2.SetActive(false);
                     talkUI3.SetActive(false);
                    //   if(CustomerController.UpdateiceCreamok()){ 
                    //     talkUI3.SetActive(true);
                    //     talkUI2.SetActive(false);
                    //     talkUI.SetActive(false);
                   
                    // }   
                }
               else if(CandleManager.UpdatecandleCorrect()&&CustomerController.UpdateiceCreamok()){
                  talkUI3.SetActive(true);
                        talkUI2.SetActive(false);
                        talkUI.SetActive(false);
                         talkUI4.SetActive(true);
         }
                
            
                else {
                     talkUI3.SetActive(false);
                    talkUI.SetActive(false);
                    talkUI2.SetActive(true);
                }

            }
        }
                
        
       
    }

    // public static bool UpdatefinishTalk(){
    //     if(DialogSystem.UpdatevideoPlayed())finishTalk=true;
    //     else finishTalk=false;
    //     return finishTalk;
    // }

    // void OnTriggerEnter2D(Collider2D other)
    // {        
    //      Debug.Log("in");
    //     inside=true;
        
  
       
    // }
    //  void OnTriggerExit2D(Collider2D other)
    // {
    //     inside=false;
       
        
    // }
}
