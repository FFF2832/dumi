using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potionAnim : MonoBehaviour
{
    //動畫
     private Animator anim; 
    private Animator animskill;
    private enum MovementState{ startBrew,throwMaterial,potionSucess,potionFail};
    // private bool sucessPotion;
    // private bool throwMaterial;
     private void Start()
    {
        anim =GetComponent<Animator>();
        animskill =GetComponent<Animator>();
      
       // sucessPotion=false;
       
       
    }
    // Update is called once per frame
    void Update()
    {
         UpdateAnimationState();
    }

      private void UpdateAnimationState()
    {
        // MovementState state;
       // Debug.Log("sucessPotion"+sucessPotion);
       
        // if(MaterialDragDrop.UpdatethrowMaterial()){
           
        //      anim.SetBool("throw",true);
        //      Debug.Log("throwMaterial"+MaterialDragDrop.UpdatethrowMaterial());
        //         //state=MovementState.throwMaterial;
        // }
        // else{
        //      Debug.Log("throwMaterial"+MaterialDragDrop.UpdatethrowMaterial());
        //      anim.SetBool("throw",false);
        //          //state=MovementState.startBrew;
        // }

        if(PotionBottle.UpdatethrowMaterial()){
           
             anim.SetBool("throw",true);
             Debug.Log("throwMaterial"+PotionBottle.UpdatethrowMaterial());
                //state=MovementState.throwMaterial;
        }
        else{
             Debug.Log("throwMaterial"+PotionBottle.UpdatethrowMaterial());
             anim.SetBool("throw",false);
                 //state=MovementState.startBrew;
        }
        if(PotionBottle.UpdatesucessPotion()==1){
                // state=MovementState.potionSucess;
                anim.SetInteger("sucessPotion",1);
               Debug.Log("sucessPotion"+PotionBottle.UpdatesucessPotion());
                
        }
         else if(PotionBottle.UpdatesucessPotion()==2){
                // state=MovementState.potionSucess;
                anim.SetInteger("sucessPotion",2);
               Debug.Log("sucessPotion"+PotionBottle.UpdatesucessPotion());
                
        }
        
        else  {
             anim.SetInteger("sucessPotion",0);
            Debug.Log("sucessPotion"+PotionBottle.UpdatesucessPotion());
            // state=MovementState.potionFail;
           // state=MovementState.startBrew;
            // moving = false;
        }
     
    //    anim.SetInteger("state",(int)state);
    }
}
