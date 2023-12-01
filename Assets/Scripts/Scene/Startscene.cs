using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Startscene : MonoBehaviour
{
     public GameObject obj;
    //  Animator anim;
    // Update is called once per frame
    private bool start;
    private void Start()
    {
        //  anim = GetComponent<Animator>();
          start=true;
    }
    void Update()
    {
        
        check2DObjectClicked();
       // anim.SetBool("start", true);
        
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
            if(hit.collider.name=="button"){
                OnBtnShowClick1();
                Debug.Log("We hit " + hit.collider.name);
            }
            if(hit.collider.name=="Skipbutton"){
                  SceneManager.LoadScene("Scene Start");
                Debug.Log("We hit " + hit.collider.name);
            }
            if(hit.collider.name=="paint_room"){
                  SceneManager.LoadScene("Scene Test");
                Debug.Log("We hit " + hit.collider.name);
            }
              

        }
    } 
    
}
public void OnBtnShowClick1(){
     Application.LoadLevel(7);
    Debug.Log("切換場景 " );
   } 
}
