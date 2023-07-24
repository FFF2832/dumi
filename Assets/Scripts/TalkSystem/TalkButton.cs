using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkButton : MonoBehaviour
{
    public GameObject Button;   //按钮提示
    public GameObject talkUI;   //对话框
    private bool isinside;
    private bool selected;
    public static List<TalkButton> moveableObjects = new List<TalkButton>();
     private void Start()
     {
          Button.SetActive(false);
          talkUI.SetActive(false);
          isinside=false;
     }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Button.SetActive(true);
        isinside=true;
        //Debug.Log("123");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Button.SetActive(false);
        talkUI.SetActive(false);
         isinside=false;
    }

    void Update()
    {
        // if (Button.activeSelf&&isinside )
        // {
        //     talkUI.SetActive(true);
        // }
        if (isinside )
        {
            Button.SetActive(true);
           if(Input.GetMouseButtonDown(0)&&selected){
             talkUI.SetActive(true);
            }
        }
        else if(!isinside){
            Button.SetActive(false);
             // selected=false;
        }
        else {
            Button.SetActive(false);
            isinside=false;
        }
        
    }
    private void OnMouseDown()
    {
        selected=true;
        //gameObject.GetComponent<SpriteRenderer>().color=Color.green;
        foreach(TalkButton obj in moveableObjects){
            if(obj!=this){
                obj.selected=false;
                obj.gameObject.GetComponent<SpriteRenderer>().color=Color.white;
            }
        }
        Debug.Log("有問題");
    }
}
