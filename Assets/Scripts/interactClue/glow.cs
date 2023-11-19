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
        Debug.Log("inside"+inside);
        return inside;
    }

}