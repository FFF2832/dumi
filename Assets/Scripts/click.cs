using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class click : MonoBehaviour
{
     public GameObject obj;
    // Update is called once per frame

    public Texture2D fingerCursorTexture; // 新增手指指针纹理
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    private bool UIstate;
    void Update()
    {
        UIstate=Enlarge.UpdateifUI();
        check2DObjectClicked();
        checkclick();
        
    }
    
    private void OnMouseDown()
    {
        if(Input.GetMouseButtonDown(0) ){
                 Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if(Physics.Raycast(ray,out hit)){
                            obj=hit.collider.gameObject;
                            //OnBtnShowClick();
                            Debug.Log("碰到物件");
        
                    }

               
        }
        
    }
    //找點到的物件名字
    void checkclick(){
 Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 10, -1); ;
            if (hit.collider&&!UIstate)
            {
                Debug.DrawLine(ray.origin, hit.transform.position, Color.red, 0.1f, true);
                Debug.Log(hit.transform.name);
            }
        }
    }
//點擊的程式
   void check2DObjectClicked()
{
    if (Input.GetMouseButtonDown(0))
    {
       
        Debug.Log("Mouse is pressed down");
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
        if (hit&&!UIstate)
        {
            if(hit.collider.name=="樹枝畫"&&glow.Updateinside()){
               
                OnBtnShowClick1();
                
               
                Debug.Log("We hit " + hit.collider.name);
            }
            else if(hit.collider.name=="back"){
                OnBtnShowClick2();
                Debug.Log("We hit " + hit.collider.name);
            }
             else if(hit.collider.name=="球"){
                OnBtnShowClick2();
                Debug.Log("We hit " + hit.collider.name);
            }
            else if(hit.collider.name=="paint"&&glow.Updateinside()){
                OnBtnShowClick3();
                Debug.Log("We hit " + hit.collider.name);
            }
            else if(hit.collider.name=="glowobj"){
                OnBtnShowClick3();
                Debug.Log("We hit " + hit.collider.name);
            }
            else if(hit.collider.name=="Bagicon"){
             
                Debug.Log("We hit " + hit.collider.name);
            }
            else if(hit.collider.name=="裝飾畫1"){
             
                   OnBtnShowClick4();
                Debug.Log("We hit " + hit.collider.name);
            }
             else if(hit.collider.name=="Exit"){
             
                     Application.LoadLevel(3);
                Debug.Log("We hit " + hit.collider.name);
            }
            
            else if(hit.collider.name=="Password"){
             
                Debug.Log("We hit " + hit.collider.name);
            }
              

        }
    } 
    
}
public void OnBtnShowClick1(){
     Application.LoadLevel(2);
    Debug.Log("切換場景 " );
   } 
   public void OnBtnShowClick2(){
    //  Application.LoadLevel(1);
    // Debug.Log("切換場景 " );
int previousScene = PlayerPrefs.GetInt("PreviousScene");

    if (previousScene == 1)
    {
        SceneManager.LoadScene(1);
        Debug.Log("返回第一个场景");
    }
    else if (previousScene == 3)
    {
        SceneManager.LoadScene(3);
        Debug.Log("返回第三个场景");
    }
    else
    {
        Debug.Log("无法确定上一个场景");
    }
   } 
    public void OnBtnShowClick3(){
     Application.LoadLevel(2);
    Debug.Log("切換場景 " );
   } 

   public void OnBtnShowClick4(){
     Application.LoadLevel(4);
    Debug.Log("切換場景 " );
   } 

//    void OnMouseEnter()
//     {
//         Debug.Log("HOVER");
//         Cursor.SetCursor(fingerCursorTexture, hotSpot, cursorMode); // 使用手指指针纹理
    
//     }

//     void OnMouseExit()
//     {
//         // Pass 'null' to the texture parameter to use the default system cursor.
//         Cursor.SetCursor(null, Vector2.zero, cursorMode);
//     }
   
}
