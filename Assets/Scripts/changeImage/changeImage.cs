
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeImage : MonoBehaviour
{
    public Sprite sprite1; // 第一個圖片
    public Sprite sprite2; // 第二個圖片
     private SpriteRenderer spriteChange;
    //  public Gameobject obj1;
    //   public Gameobject obj2;
    //    public Gameobject obj3;
void Start(){
        spriteChange = GetComponent<SpriteRenderer>();
    }
void Update()
{
     if (EnterKey.UpdatepasswordCorrect()||PlayerPrefs.GetInt("IsCollected_piece3")==1)
    {
        
        spriteChange.sprite = sprite2;
    
    }
    // if (deerKey.UpdateallObjectsDisappeared())
    // {
        
    //     spriteChange.sprite = sprite2;
    
    // }
   

    else
    {
   
        spriteChange.sprite = sprite1;
    }
}


 

}

