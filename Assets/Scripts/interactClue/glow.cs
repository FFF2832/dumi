using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class glow : MonoBehaviour
{
    private SpriteRenderer light_glow;
    public GameObject obj;
    private CanvasGroup canvasGroup;
     //private SpriteRenderer sprite;
    private float fadeTime =0.3f;
    private  bool inside;
     private void Start()
    {
        //sprite=GetComponent<SpriteRenderer>();
         canvasGroup = GetComponent<CanvasGroup>();
         inside=false;
        // Debug.Log("inside"+inside);
    }

    void Awake(){
        light_glow=this.transform.Find("light_glow").GetComponent<SpriteRenderer>();
        light_glow.DOFade(0f,0.01f);
        //canvasGroup=this.transform.Find("Canvas").GetComponent<CanvasGroup>();
        //canvasGroup.DOFade(0f,0.01f);
           inside=false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {        
         Debug.Log("in");
        inside=true;
      
        //sprite.DOFade(0f,0.01f);
        canvasGroup.DOFade(1f,fadeTime);
        light_glow.DOFade(1f,fadeTime);
        //check2DObjectClicked();
       
    }
     void OnTriggerExit2D(Collider2D other)
    {
        inside=false;
      
        //inform.SetActive(false);
        Debug.Log("out");
        
         //sprite.DOFade(0f,fadeTime);
         canvasGroup.DOFade(0f,fadeTime);
         light_glow.DOFade(0f,fadeTime);
        canvasGroup.DOFade(0, 5);
        
    }
    public  bool Updateinside(){
       // Debug.Log("inside"+inside);
        return inside;
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
         
           
            if((hit.collider.name=="btn-paint"||hit.collider.name=="light_glow"||hit.collider.name=="light")){
                OnBtnShowClick3(); 
            }
            else if(hit.collider.name=="paint"){
             Debug.Log("點化");
                OnBtnShowClick3();
              
            }
            else if(hit.collider.name=="glowobj"){
                OnBtnShowClick3();
                
            }
            
            else if(hit.collider.name=="paint_room"){
             
                     Application.LoadLevel(5);
                      Debug.Log("切換場景 " );
               
            }
           
             else if((hit.collider.name=="magic_room"||hit.collider.name=="light4")){
             
                     Application.LoadLevel(4);
               
            }
            

        }
    } 
    
}
 public void OnBtnShowClick3(){
     Application.LoadLevel(2);
    Debug.Log("切換場景 " );
   } 

}