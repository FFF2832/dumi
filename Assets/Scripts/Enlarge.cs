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
    void Start()
    {
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
            Debug.Log("isMouseOverobj"+isMouseOverobj);
            // 获取鼠标的位置
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // 获取被点击的物体的位置
            Vector2 objPos = transform.position;

            // // 如果鼠标点击了这个物体
            // if (mousePos.x >= objPos.x - 0.5f && mousePos.x <= objPos.x + 0.5f
            //     && mousePos.y >= objPos.y - 0.5f && mousePos.y <= objPos.y + 0.5f&&(!(ifUI)||!(DialogSystem.UpadateconversationUI())))
                
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
        //Debug.Log("HOVER");
        Cursor.SetCursor(fingerCursorTexture, hotSpot, cursorMode); // 使用手指指针纹理
    
    }

    void OnMouseExit()
    {
        // Pass 'null' to the texture parameter to use the default system cursor.
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
    // public static bool UpdateifUI(){
    //   //  Debug.Log("ifUI"+ifUI);
    //     return ifUI;
    // } 
     public static bool UpdateisMouseOverobj(){
      //  Debug.Log("ifUI"+ifUI);
        return isMouseOverobj;
    } 
}
