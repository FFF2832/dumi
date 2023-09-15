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

     private float delay = 16.0f;
    private float timer;
     private void Start()
     {
         timer = delay;
          //Button.SetActive(false);
         // talkUI.SetActive(false);
          hint.SetActive(false);
          isinside=false;
        showHint();
         
     }
    // void Update()
    // {
    //     // Decrement the timer each frame
    //     timer -= Time.deltaTime;

    //     // Check if the timer has reached 0 or less
    //     if (timer <= 0)
    //     {
    //         // Reset the timer to the delay value
    //         timer = delay;

    //         // Call the waitHint method
    //         WaitHint();
    //     }
    // }
    void showHint(){
        Invoke("WaitHint", delay);
    }
    void WaitHint(){
        if(PotionBottle.UpdatemagicDone()){
           // talkUI.SetActive(true);
            hint.SetActive(true);
        }
    }
}
