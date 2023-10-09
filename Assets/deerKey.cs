using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deerKey : MonoBehaviour
{
    public GameObject[] objectsToMonitor;  // 要監控的物件

    // private SpriteRenderer spriteRenderer;  // 用於更換Sprite的SpriteRenderer

    // private Image spriteChange;
    public static bool allObjectsDisappeared ;

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
    }

    public static bool UpdateallObjectsDisappeared(){
        return allObjectsDisappeared;
    }
}
