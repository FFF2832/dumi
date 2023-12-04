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
     private bool UIstate2;
     private CheckInput checkInputInstance;
    private glow glowInstance; // 假設你有一個 glow 實例的引用
     
    void Start(){
         checkInputInstance = new CheckInput();
        glowInstance = GetComponent<glow>(); 
    }
    void Update()
    {
        UIstate=Enlarge.UpdateisMouseOverobj();
        UIstate2=Look.UpdateifUI();
      //  Debug.Log("UIstate"+UIstate);
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
                            //Debug.Log("碰到物件");
        
                    }

               
        }
        
    }
    //找點到的物件名字
    void checkclick(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 10, -1); ;
             // if (hit.collider&&!UIstate&&!UIstate2)
             //if (hit.collider&&!UIstate)
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
        if (hit&&!UIstate)
        {
           
            if(hit.collider.name=="樹枝畫"&&!UIstate){
               
                OnBtnShowClick1();

                
            }
            // else if(hit.collider.name=="closebtn"){
            //    Enlarge.ifUI=false;
               
            // }
            else if(hit.collider.name=="back"){
                OnBtnShowClick2();
            }
             else if(hit.collider.name=="球"){
                OnBtnShowClick2();
            }
            else if((hit.collider.name=="btn-paint")&&glowInstance.Updateinside()){
                OnBtnShowClick3(); 
            }
            else if(hit.collider.name=="paint"){
                OnBtnShowClick3();
              
            }
            // else if(hit.collider.name=="glowobj"){
            //     OnBtnShowClick3();
                
            // }
           
            else if(hit.collider.name=="Bagicon"){
             
                
            }
            else if(hit.collider.name=="裝飾畫1"){
             
                   OnBtnShowClick4();
               
            }
             else if(hit.collider.name=="Exit"){
             
                     Application.LoadLevel(3);
               
            }
            
            else if(hit.collider.name=="Password"||hit.collider.name=="lookicon_car"){
                // 獲取當前場景的名稱
                string currentSceneName = SceneManager.GetActiveScene().name;
                if(checkInputInstance.UpdatechangeSceneFlag()==1){
                    //checkInputInstance.ChangeTonight();
                    Application.LoadLevel(3);
                   
                    }
                else if(CheckInput.UpdateChangeScene())Application.LoadLevel(3);
                else if(!CheckInput.UpdateChangeScene()&&currentSceneName == "Scene night"){
                    Application.LoadLevel(1);
                Debug.Log("切換場景 " );
                }
             
            }
            else if(hit.collider.name=="closebtn"){
                 Application.LoadLevel(3);
                 Debug.Log("切回夜晚");
            }
            // else if(hit.collider.name=="closebtnNight"){
            //      Application.LoadLevel(3);
            // }
            else if(hit.collider.name=="car"){
                 Application.LoadLevel(1);
            }
            else if(hit.collider.name=="paint_room"){
             
                     Application.LoadLevel(5);
                      Debug.Log("切換場景 " );
               
            }
           // else if((hit.collider.name=="magic_room"||hit.collider.name=="light4"))
             else if((hit.collider.name=="magic_room"||hit.collider.name=="light4")){
             
                     Application.LoadLevel(4);
               
            }
             else if(hit.collider.name=="gohall_btn"||hit.collider.name=="gohall_L"){
                    Debug.Log("去大廳");
                    SceneManager.LoadScene("Scene Hall");
               
            }
            else if(hit.collider.name=="gohall_btn"||hit.collider.name=="gohall_R"){
                    Debug.Log("去大廳");
                    SceneManager.LoadScene("Scene Hall");
               
            }
             else if(hit.collider.name=="paintyell"||hit.collider.name=="glowobj_pain"){
                SceneManager.LoadScene("Scene nightmare");
              
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
      public void OnBtnShowClick10(){
     Application.LoadLevel(10);
    Debug.Log("切換場景 " );
   } 
         public void OnBtnShowClick9(){
     Application.LoadLevel(9);
    Debug.Log("切換場景 " );
   } 
    public void OnBtnShowClick7(){
     Application.LoadLevel(3);
    Debug.Log("切換場景 " );
   } 
      public void OnBtnShowClick77(){
     Application.LoadLevel(7);
    Debug.Log("切換場景 " );
   } 
   void OnMouseEnter()
    {
        Debug.Log("HOVER");
        Cursor.SetCursor(fingerCursorTexture, hotSpot, cursorMode); // 使用手指指针纹理
    
    }

    void OnMouseExit()
    {
        // Pass 'null' to the texture parameter to use the default system cursor.
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
   
}
