using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ItemOndrag : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
//      void Start() {
//    EventSystem.current = GameObject.FindObjectOfType<EventSystem>();
//      }
    public Transform originalParent;
    public Transform correctParent;
    public Sprite newSprite; // 新圖片

    private bool isDragging = false;
    private Vector2 offset;
    private Transform targetTransform;
    public float snapDistance = 0.5f; // 物品被吸附的距離
    private bool isSnapped = false;
    
   public void OnBeginDrag(PointerEventData eventData)
   {
     originalParent=transform.parent;
     transform.SetParent(transform.parent.parent);
        transform.position=eventData.position;
        GetComponent<CanvasGroup>().blocksRaycasts=false;
        Debug.Log("startmove");
        //GetComponent<characterMove>().enabled = false;
   }
   public void OnDrag(PointerEventData eventData)
   {
        transform.position=eventData.position;
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
        Debug.Log("moving");
    //  isDragging = false;

    //     if (targetTransform != null)
    //     {
    //         float distance = Vector2.Distance(transform.position, targetTransform.position);

    //         if (distance <= snapDistance)
    //         {
    //             // 替換圖片
    //             //GetComponent<SpriteRenderer>().sprite = newSprite;

    //             // 移動到目標位置
    //             transform.position = targetTransform.position;
    //             isSnapped = true;
    //         }
    //     }
        
    

   }
   public void OnEndDrag(PointerEventData eventData)
   {
     //判斷是否有物品
     if(eventData.pointerCurrentRaycast.gameObject.name=="Item Image"){
          transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
          transform.position=eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;
          eventData.pointerCurrentRaycast.gameObject.transform.parent.position=originalParent.position;
          eventData.pointerCurrentRaycast.gameObject.transform.SetParent(originalParent);
           GetComponent<CanvasGroup>().blocksRaycasts=true;
           return;
     }
      transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
      transform.position=eventData.pointerCurrentRaycast.gameObject.transform.position;
          GetComponent<CanvasGroup>().blocksRaycasts=false;
        Debug.Log("endmoving");
   
    //更新
//      if (eventData.pointerCurrentRaycast.gameObject.name == "Item Image")
//         {
//             // move to correct parent
//             transform.SetParent(correctParent);
//             transform.position = correctParent.position;
//             GetComponent<CanvasGroup>().blocksRaycasts = true;
//             return;
//         }

//         transform.SetParent(originalParent);
//         transform.position = originalParent.position;
//         //GetComponent<CanvasGroup>().blocksRaycasts = true;

//           Debug.Log("endmoving");
//    }
    //   private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.CompareTag("CorrectItem"))
    //     {
    //         correctParent = other.transform;
    //     }
    // }

    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     if (other.CompareTag("CorrectItem"))
    //     {
    //         correctParent = null;
    //     }
    // }
   }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Target")
        {
            targetTransform = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Target")
        {
            targetTransform = null;
            isSnapped = false;
        }
    }


}
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.EventSystems;

// public class ItemOndrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
// {
//     public Transform originalParent;
//     public Transform correctParent;
//     public Sprite newSprite; // 新圖片

//     private bool isDragging = false;
//     private Vector2 offset;
//     private Transform targetTransform;
//     public float snapDistance = 0.5f; // 物品被吸附的距離
//     private bool isSnapped = false;

//     public void OnBeginDrag(PointerEventData eventData)
//     {
//         originalParent = transform.parent;
//         transform.SetParent(transform.parent.parent);
//         transform.position = eventData.position;
//         GetComponent<CanvasGroup>().blocksRaycasts = false;
//         Debug.Log("startmove");
//     }

//     public void OnDrag(PointerEventData eventData)
//     {
//         transform.position = eventData.position;
//         Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
//         Debug.Log("moving");
//         isDragging = false;

//         if (targetTransform != null)
//         {
//             float distance = Vector2.Distance(transform.position, targetTransform.position);

//             if (distance <= snapDistance)
//             {
//                 // 替換圖片
//                 //GetComponent<SpriteRenderer>().sprite = newSprite;

//                 // 移動到目標位置
//                 transform.position = targetTransform.position;
//                 isSnapped = true;
//             }
//         }
//     }

//     public void OnEndDrag(PointerEventData eventData)
//     {
//         if (eventData.pointerCurrentRaycast.gameObject.tag == "Target" && !isSnapped)
//         {
//             // 物品沒有吸附，則返回原位
//             transform.SetParent(originalParent);
//             transform.position = originalParent.position;
//             GetComponent<CanvasGroup>().blocksRaycasts = true;
//             Debug.Log("endmoving");
//             return;
//         }

//         if (eventData.pointerCurrentRaycast.gameObject.tag == "Target" && isSnapped)
//         {
//             // 物品吸附，移至目標位置
//             transform.SetParent(targetTransform);
//             transform.position = targetTransform.position;
//             GetComponent<CanvasGroup>().blocksRaycasts = true;
//             Debug.Log("endmoving, item snapped");
//             return;
//         }

//         // 物品拖曳到其他位置
//         transform.SetParent(originalParent);
//         transform.position = originalParent.position;
//         GetComponent<CanvasGroup>().blocksRaycasts = true;
//         Debug.Log("endmoving");
//     }

//     private void OnTriggerEnter2D(Collider2D collision)
//     {
//         if (collision.tag == "Target")
//         {
//             targetTransform = collision.transform;
//         }
//     }

//     private void OnTriggerExit2D(Collider2D collision)
//     {
//         if (collision.tag == "Target")
//         {
//             targetTransform = null;
//             isSnapped = false;
//         }
//     }
// }
