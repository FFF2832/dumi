using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickPanel : MonoBehaviour
{
    public GameObject obj;
     public GameObject panel;
    // Update is called once per frame
    
    private void Awake()
    {
         panel.SetActive(true);
    }
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
//     void checkclick(){
//  Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//         if (Input.GetMouseButton(0))
//         {
//             RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 10, -1); ;
//             if (hit.collider)
//             {
//                 Debug.DrawLine(ray.origin, hit.transform.position, Color.red, 0.1f, true);
//                 Debug.Log(hit.transform.name);
//             }
//         }
//     }
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
            
            if(hit.collider.name=="Bagicon"){
             
                Debug.Log("We hit " + hit.collider.name);
                panel.SetActive(true);
            }
              

        }
    } 
    
}

}
