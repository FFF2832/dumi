using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottleAnim : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject item1;
    public GameObject item2;
   public GameObject item3;
    public item thisItem;
    public Inventory playerInventory;
      private Animator anim; 

    void Start()
    {
         anim =GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ItemOndrag.checkunicornHorn()){
            anim.SetBool("dirt",true);
            Debug.Log("checkunicornHorn"+ItemOndrag.checkunicornHorn());
              Invoke("DeactivateAndHandleItem", 3f);
        }
         else if(ItemOndrag.checkunicornHorn_2()){
            anim.SetBool("dirt2",true);
            Debug.Log("checkunicornHorn_2"+ItemOndrag.checkunicornHorn_2());
             Invoke("DestroyItem", 3f);
           //  
        }
         else if(ItemOndrag.checkunicornHorn_3()){
            anim.SetBool("dirt3",true);
            Debug.Log("checkunicornHorn_3"+ItemOndrag.checkunicornHorn_3());
              Invoke("DestroyItem3", 3f);
        }
        else{
            
        }

    }
    void DeactivateAndHandleItem()
    {
        // 將整個物件設為非啟用狀態
        item1.SetActive(false);

        // 執行點裡面的物品的相關代碼
        //HandleItemInside();
    }
     void DestroyItem()
    {
        // 將整個物件設為非啟用狀態
        Destroy(item2);
        // Destroy(item3);

        // 執行點裡面的物品的相關代碼
        //HandleItemInside();
    }
         void DestroyItem3()
    {
        // 將整個物件設為非啟用狀態
        Destroy(item3);
        // Destroy(item3);

        // 執行點裡面的物品的相關代碼
        //HandleItemInside();
    }
}
