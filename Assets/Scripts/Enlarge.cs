using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enlarge : MonoBehaviour
{
    public GameObject canvas;
    public Texture2D fingerCursorTexture; // 新增手指指针纹理
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    //public static bool ifUI;
    private static bool isMouseOverobj;
    public GameObject imageToShow; // 要显示的图像
    
    void Start()
    {
        imageToShow.SetActive(false);
        // 隐藏 Canvas
        canvas.SetActive(false);
       //  ifUI=false;
       isMouseOverobj=true;
    }

    void Update()
    {
       
        // 如果点击了鼠标左键
        if (Input.GetMouseButtonDown(0))
        {
             // 現在點的是不是gameObject
            isMouseOverobj =EventSystem.current.IsPointerOverGameObject();
           // Debug.Log("isMouseOverobj"+isMouseOverobj);
            // 获取鼠标的位置
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // 获取被点击的物体的位置
            Vector2 objPos = transform.position;

          
            if (mousePos.x >= objPos.x - 0.5f && mousePos.x <= objPos.x + 0.5f
                && mousePos.y >= objPos.y - 0.5f && mousePos.y <= objPos.y + 0.5f&&!isMouseOverobj)
            {
                // 显示 Canvas
                canvas.SetActive(true);
                //ifUI=true;
                
            }
          
            //   else
            // {
            // // 隐藏 Canvas
            // canvas.SetActive(false);
            // 
            // }
            
        }
    }
    public void closebtnOnclick(){
        canvas.SetActive(false);
         isMouseOverobj=false;
        //ifUI=false;
    }
    void OnMouseEnter()
    {
       
        Cursor.SetCursor(fingerCursorTexture, hotSpot, cursorMode); // 使用手指指针纹理
       // Debug.Log("Mouse entered: " + gameObject.name);
    }

    void OnMouseExit()
    {
        // Pass 'null' to the texture parameter to use the default system cursor.
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
         ///Debug.Log("Mouse exited: " + gameObject.name);
    }
    // public static bool UpdateifUI(){
    //   //  Debug.Log("ifUI"+ifUI);
    //     return ifUI;
    // } 
     public static bool UpdateisMouseOverobj(){
      //  Debug.Log("ifUI"+ifUI);
        return isMouseOverobj;
    } 

     private void OnTriggerEnter2D(Collider2D other)
    {
        // 当检测到接近时显示图像
        if (other.gameObject.CompareTag("Player"))
        {
              imageToShow.SetActive(true);
              Debug.Log("in");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // 当检测到离开时隐藏图像
        if (other.gameObject.CompareTag("Player"))
        {
             imageToShow.SetActive(false);
               Debug.Log("out");
        }
    }



     void check2DObjectClicked()
{
    if (Input.GetMouseButtonDown(0))
    {
       
       // Debug.Log("Mouse is pressed down");
        Camera cam = Camera.main;

        //Raycast depends on camera projection mode
        Vector2 origin = Vector2.zero;
        Vector2 dir = Vector2.zero;

        if (cam.orthographic)
        {
            origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            origin = ray.origin;
            dir = ray.direction;
        }

        RaycastHit2D hit = Physics2D.Raycast(origin, dir);

        //Check if we hit anything
        // if (hit&&!(Enlarge.UpdateifUI())||!(DialogSystem.UpadateconversationUI()))
        if (hit)
        {
           
            if(hit.collider.name=="cabinet"){
          
                canvas.SetActive(true);
                Debug.Log("打到了");
                
            }
           
            else if(hit.collider.name=="back"){
         
            }
            

        }
    } 
    
}
}
