using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class click : MonoBehaviour
{
     public GameObject obj;
    // Update is called once per frame
    void Update()
    {
        
        check2DObjectClicked();
        //checkclick();
        
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
            if (hit.collider)
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
        if (hit)
        {
            if(hit.collider.name=="樹枝畫"){
                OnBtnShowClick1();
                Debug.Log("We hit " + hit.collider.name);
            }
            else if(hit.collider.name=="back"){
                OnBtnShowClick2();
                Debug.Log("We hit " + hit.collider.name);
            }
            else if(hit.collider.name=="paint"){
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
     Application.LoadLevel(1);
    Debug.Log("切換場景 " );
   } 
    public void OnBtnShowClick3(){
     Application.LoadLevel(2);
    Debug.Log("切換場景 " );
   } 
   
}
