// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.EventSystems;
// public class ItemOndrag : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
// {
// //      void Start() {
// //    EventSystem.current = GameObject.FindObjectOfType<EventSystem>();
// //      }
//     public Transform originalParent;
//     public Transform correctParent;
//     public Sprite newSprite; // 新圖片

//     private bool isDragging = false;
//     private Vector2 offset;
//     private Transform targetTransform;
//     public float snapDistance = 0.5f; // 物品被吸附的距離
//     private bool isSnapped = false;
    
//    public void OnBeginDrag(PointerEventData eventData)
//    {
//      originalParent=transform.parent;
//      transform.SetParent(transform.parent.parent);
//         transform.position=eventData.position;
//         GetComponent<CanvasGroup>().blocksRaycasts=false;
//         Debug.Log("startmove");
//         //GetComponent<characterMove>().enabled = false;
//    }
//    public void OnDrag(PointerEventData eventData)
//    {
//         transform.position=eventData.position;
//         Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
//         Debug.Log("moving");
    
        
    

//    }
//    public void OnEndDrag(PointerEventData eventData)
//    {
//      //判斷是否有物品
//      if(eventData.pointerCurrentRaycast.gameObject.name=="Item Image"){
//           transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
//           transform.position=eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;
//           eventData.pointerCurrentRaycast.gameObject.transform.parent.position=originalParent.position;
//           eventData.pointerCurrentRaycast.gameObject.transform.SetParent(originalParent);
//            GetComponent<CanvasGroup>().blocksRaycasts=true;
//            return;
//      }
//       transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
//       transform.position=eventData.pointerCurrentRaycast.gameObject.transform.position;
//           GetComponent<CanvasGroup>().blocksRaycasts=false;
//         Debug.Log("endmoving");
   
  
//    }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemOndrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform originalParent;
    //public Transform correctParent;
    public Sprite newSprite; // 新圖片
    public GameObject target;
    private bool isDragging = false;
    private Vector2 offset;
    private Transform targetTransform;
    public float snapDistance = 0.5f; // 物品被吸附的距離
    private bool isSnapped = false;
    private RectTransform _rectTransform;
     private CanvasGroup _canvasGroup;
     private Vector2 originPosition;
    private void Awake()
    {
        _rectTransform=GetComponent<RectTransform>();
        originPosition=_rectTransform.position;
         _canvasGroup=GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        transform.SetParent(transform.parent.parent);
        //跟隨鼠標
        transform.position = eventData.position;
       _canvasGroup.blocksRaycasts = false;
        Debug.Log("startmove");
     
    }

    public void OnDrag(PointerEventData eventData)
    {
         //跟隨鼠標
        //transform.position = eventData.position;
        _rectTransform.position=eventData.position;
        //Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
        Debug.Log("moving");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (targetTransform != null && Vector2.Distance(transform.position, targetTransform.position) < snapDistance)
        {
            transform.position = targetTransform.position;
            transform.SetParent(targetTransform);
           _canvasGroup.blocksRaycasts = true;
            isSnapped = true;
            
        }
       
        else
        {
           
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
            transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
           
            Debug.Log("endmoving");
        }
        // _rectTransform.position=originPosition;
        // _canvasGroup.blocksRaycasts = true;
        //  Debug.Log("endmoving");
    }
    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.tag == "Target")
    //     {
    //         targetTransform = collision.transform;
    //         Debug.Log("inside");
    //     }
    // }

    // private void OnTriggerExit2D(Collider2D collision)
    // {
    //     if (collision.tag == "Target")
    //     {
    //         targetTransform = null;
    //         isSnapped = false;
    //     }
    // }
      public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.tag == "Target")
        {
            targetTransform = eventData.pointerCurrentRaycast.gameObject.transform;
            Debug.Log("inside");
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.tag == "Target")
        {
            targetTransform = null;
            isSnapped = false;
        }
    }
}

