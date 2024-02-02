using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottleAnim : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject content;
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
            Debug.Log("true"+ItemOndrag.checkunicornHorn());
              Invoke("DeactivateAndHandleItem", 3f);
        }
    }
    void DeactivateAndHandleItem()
    {
        // 將整個物件設為非啟用狀態
        gameObject.SetActive(false);

        // 執行點裡面的物品的相關代碼
        //HandleItemInside();
    }
}
