using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deerKey : MonoBehaviour
{
    public GameObject[] objectsToMonitor;  // 要監控的物件

    // private SpriteRenderer spriteRenderer;  // 用於更換Sprite的SpriteRenderer

    // private Image spriteChange;
    public static bool allObjectsDisappeared ;
    public GameObject obj1;
      public GameObject obj2;
       public GameObject obj3;
        public GameObject obj4;
         public GameObject obj5;

    void Start()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();
        //  spriteChange = GetComponent<Image>();
        // if (spriteChange == null)
        // {
        // Debug.LogError("Image component not found!");
        // }
    }

    void Update()
    {
        // 如果要監控的物件為null或已被刪除，則返回
        if (objectsToMonitor == null)
            return;

        // 檢查物件是否消失
        allObjectsDisappeared = true;
        foreach (GameObject obj in objectsToMonitor)
        {
            // 如果物件仍然存在，則不算所有物件都消失
            if (obj != null && obj.activeSelf)
            {
                allObjectsDisappeared = false;
                break;
            }
        }

        // 如果所有物件都消失，則更換Sprite
        if (allObjectsDisappeared)
        {
            Debug.Log("物件都消失了");
           

        }
        changekeyImage();
    }

    public static bool UpdateallObjectsDisappeared(){
        return allObjectsDisappeared;
    }
    public void changekeyImage(){
        if(PlayerPrefs.GetInt("IsCollected_key1") == 1)Destroy(obj1);
        if(PlayerPrefs.GetInt("IsCollected_key2") == 1)Destroy(obj2);
           if(PlayerPrefs.GetInt("IsCollected_key3") == 1)Destroy(obj3);
    }
}
