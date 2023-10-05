using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deerKey : MonoBehaviour
{
      public GameObject[] objectsToMonitor;  // 要監控的物件
    public Sprite newSprite;  // 新的Sprite

    private SpriteRenderer spriteRenderer;  // 用於更換Sprite的SpriteRenderer

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // 檢查物件是否消失
        bool allObjectsDisappeared = true;
        foreach (GameObject obj in objectsToMonitor)
        {
            if (obj.activeSelf)
            {
                allObjectsDisappeared = false;
                break;
            }
        }

        // 如果所有物件都消失，則更換Sprite
        if (allObjectsDisappeared)
        {
            allObjectsDisappeared = true;
            Debug.Log("物件都消失了");
        }
    }

   
}
