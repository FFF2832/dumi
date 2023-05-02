// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.EventSystems;

// public class SlotHandle : MonoBehaviour,IDropHandler
// {
//     public GameObject item
//     {
//         get
//         {
//             // 如果有子物体在返回，没有就为空
//             if(transform.childCount > 0)
//             {
//                 return transform.GetChild(0).gameObject;
//             }
//             return null; 
//         }
//     }

//     // 
//     public void OnDrop(PointerEventData eventData)
//     {
//         // 如果上面没有物体，就能放置
//         if (!item)
//         {
//             ItemOndrag.itemBeginDragged.transform.SetParent(transform);
//         }
//     }

    
// }