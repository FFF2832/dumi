// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.EventSystems;

// public class changeImage : MonoBehaviour
// {
//     public Sprite sprite1; // 第一個圖片
//     public Sprite sprite2; // 第二個圖片
//     private Image spriteChange;
//     public Transform newCorrectParentGameObject; // 在類別開頭定義變數
//     // 获取 ItemOndrag 组件
//      public delegate void OnNewCorrectParentSet(Transform newCorrectParentTransform);
//     public static event OnNewCorrectParentSet OnNewCorrectParentSetEvent;
    
//     void Start()
//     {
//        ItemOndrag item = GetComponent<ItemOndrag>();
      
//         // 更改 correctParent 的值
//         //item.correctParent = newCorrectParentTransform;
//         spriteChange = GetComponent<Image>();
//           if (spriteChange == null) {
//         Debug.LogError("Image component not found!");
//     }
//     }

//     void Update()
//     {
//         if (ItemOndrag.checkTarget())
//         {
//             spriteChange.sprite = sprite1;
//         }
//         else
//         {
//             spriteChange.sprite = sprite2;
//         }
//     }
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class changeImage : MonoBehaviour
{
    public Sprite sprite1; // 第一個圖片
    public Sprite sprite2; // 第二個圖片
    private Image spriteChange;
    public Transform newCorrectParentTransform; // 在類別開頭定義變數
    
    void Start()
    {
        spriteChange = GetComponent<Image>();
        if (spriteChange == null) {
            Debug.LogError("Image component not found!");
        }

        // 觸發 OnNewCorrectParentSetEvent 事件，將新的 transform 傳遞給 ItemOndrag
        if (OnNewCorrectParentSetEvent != null) {
            OnNewCorrectParentSetEvent(newCorrectParentTransform);
        }
    }

    void Update()
    {
        if (ItemOndrag.checkTarget())
        {
            spriteChange.sprite = sprite1;
        }
        else
        {
            spriteChange.sprite = sprite2;
        }
    }

    // 定義 OnNewCorrectParentSetEvent 事件的委託
    public delegate void OnNewCorrectParentSet(Transform newCorrectParentTransform);
    // 定義 OnNewCorrectParentSetEvent 事件
    public static event OnNewCorrectParentSet OnNewCorrectParentSetEvent;
}
