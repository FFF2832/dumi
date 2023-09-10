using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class magicDone : MonoBehaviour
{
  
    // Update is called once per frame
    public GameObject talkUI;   //对话框
    public GameObject hint;
     private bool isinside;
    private bool selected;
    public static List<TalkButton> moveableObjects = new List<TalkButton>();
     private void Start()
     {
          //Button.SetActive(false);
         // talkUI.SetActive(false);
          hint.SetActive(false);
          isinside=false;
     }
    void Update()
    {
        if(PotionBottle.UpdatemagicDone()){
           // talkUI.SetActive(true);
            hint.SetActive(true);
        }
    }
}
