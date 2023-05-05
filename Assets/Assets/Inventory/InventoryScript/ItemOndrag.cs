
//版本二
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.EventSystems;

// public class ItemOndrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
// {
//     public Transform originalParent;
//     //public Transform correctParent;
//     public Sprite newSprite; // 新圖片
//     public GameObject target;
//     private bool isDragging = false;
//     private Vector2 offset;
//     private Transform targetTransform;
//     public float snapDistance = 0.5f; // 物品被吸附的距離
//     private bool isSnapped = false;
//     private RectTransform _rectTransform;
//      private CanvasGroup _canvasGroup;
//      private Vector2 originPosition;
//     private void Awake()
//     {
//         _rectTransform=GetComponent<RectTransform>();
//         originPosition=_rectTransform.position;
//          _canvasGroup=GetComponent<CanvasGroup>();
//     }
//     public void OnBeginDrag(PointerEventData eventData)
//     {
//         originalParent = transform.parent;
//         transform.SetParent(transform.parent.parent);
//         //跟隨鼠標
//         transform.position = eventData.position;
//        _canvasGroup.blocksRaycasts = false;
//         Debug.Log("startmove");
     
//     }

//     public void OnDrag(PointerEventData eventData)
//     {
//          //跟隨鼠標
//         //transform.position = eventData.position;
//         _rectTransform.position=eventData.position;
//         //Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
//         Debug.Log("moving");
//     }

//     public void OnEndDrag(PointerEventData eventData)
//     {
//         if (targetTransform != null && Vector2.Distance(transform.position, targetTransform.position) < snapDistance)
//         {
//             transform.position = targetTransform.position;
//             transform.SetParent(targetTransform);
//            _canvasGroup.blocksRaycasts = true;
//             isSnapped = true;
            
//         }
       
//         else
//         {
//             //float dis=Vector2.Distance(transform.position, targetTransform.position);
           
//             transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
//             transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
           
//             Debug.Log("endmoving");
//         }
//         // _rectTransform.position=originPosition;
//         // _canvasGroup.blocksRaycasts = true;
//         //  Debug.Log("endmoving");
//     }
//     // private void OnTriggerEnter2D(Collider2D collision)
//     // {
//     //     if (collision.tag == "Target")
//     //     {
//     //         targetTransform = collision.transform;
//     //         Debug.Log("inside");
//     //     }
//     // }

//     // private void OnTriggerExit2D(Collider2D collision)
//     // {
//     //     if (collision.tag == "Target")
//     //     {
//     //         targetTransform = null;
//     //         isSnapped = false;
//     //     }
//     // }
//       public void OnPointerEnter(PointerEventData eventData)
//     {
//         if (eventData.pointerCurrentRaycast.gameObject.tag == "Target")
//         {
//             targetTransform = eventData.pointerCurrentRaycast.gameObject.transform;
//             Debug.Log("inside");
//         }
//     }

//     public void OnPointerExit(PointerEventData eventData)
//     {
//         if (eventData.pointerCurrentRaycast.gameObject.tag == "Target")
//         {
//             targetTransform = null;
//             isSnapped = false;
//         }
//     }
// }

//版本三
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
// public class ItemOndrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
// {
//     public Transform originalParent;
//     public Transform correctParent;
//     private bool isDragging = false;
//     private Vector2 offset;
//     private Transform targetTransform;

//     public void OnBeginDrag(PointerEventData eventData)
//     {
//          this.transform.SetAsLastSibling();
//         originalParent = transform.parent;
//         transform.SetParent(transform.parent.parent);
//         //跟隨鼠標
//         transform.position = eventData.position;
//         Debug.Log("start");
//     }

//     public void OnDrag(PointerEventData eventData)
//     {
//         //跟隨鼠標
//         transform.position = eventData.position;
//         Debug.Log("moving");
//     }

//     public void OnEndDrag(PointerEventData eventData)
//     {
//         if (targetTransform != null)
//         {
//             transform.position = targetTransform.position;
//             transform.SetParent(correctParent);
//             Debug.Log("endmoving_in");
//         }
//         else
//         {
//             transform.SetParent(originalParent);
//             transform.position = originalParent.position;
//             Debug.Log("endmoving_out");
//         }
//     }

//     private void OnTriggerEnter2D(Collider2D collision)
//     {
//         if (collision.tag == "Target")
//         {
//             targetTransform = collision.transform;
//             Debug.Log("onTarget");
//         }
//     }

//     private void OnTriggerExit2D(Collider2D collision)
//     {
//         if (collision.tag == "Target")
//         {
//             targetTransform = null;
//         }
//     }
// }

//版本四
// public class ItemOndrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
// {
//     public Transform originalParent;
//     public Transform correctParent;
//     private bool isDragging = false;
//     private Vector2 offset;
//     private Transform targetTransform;
    

//     public void OnBeginDrag(PointerEventData eventData)
//     {
//         this.transform.SetAsLastSibling();
//         originalParent = transform.parent;
//         transform.SetParent(transform.parent.parent);
//         //跟隨鼠標
//         transform.position = eventData.position;
//     }

//     public void OnDrag(PointerEventData eventData)
//     {
//         //跟隨鼠標
//         transform.position = eventData.position;
//     }

//     public void OnEndDrag(PointerEventData eventData)
//     {
//         // 判斷是否碰撞到目標
//         Vector2 localPoint;
//         RectTransform targetRectTransform = targetTransform as RectTransform;
//         if (targetRectTransform != null &&
//             RectTransformUtility.ScreenPointToLocalPointInRectangle(
//                 targetRectTransform,
//                 eventData.position,
//                 eventData.pressEventCamera,
//                 out localPoint))
//         {
//             // 如果碰撞到了目標，將物體吸附到目標上
//             transform.SetParent(correctParent);
//             transform.localPosition = localPoint;
//             Debug.Log("on target");
//         }
//         else
//         {
//             // 如果沒有碰撞到目標，將物體放回原來的位置
//             transform.SetParent(originalParent);
//             transform.position = originalParent.position;
//             Debug.Log("not on target");
//         }
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
//         }
//     }
// }

//好像也沒用的何小姐版本
public class ItemOndrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //
    public Transform originalParent;
    public Transform correctParent;
    private bool isDragging = false;
    //偏移量
    private Vector3 offset;
    private Transform targetTransform;
    private Transform anchor;
    public Inventory myBag;
    private int currentItemID;
    // private Image changeImage;
     
  
    public static bool correct;
    public void OnBeginDrag(PointerEventData eventData)
    {
        this.transform.SetAsLastSibling();
        originalParent = transform.parent;
        currentItemID=originalParent.GetComponent<slot>().slotID;
        transform.SetParent(transform.parent.parent);
        //跟隨鼠標
        transform.position = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //跟隨鼠標
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        correct = false;
        // 判斷是否碰撞到目標
        Vector2 localPoint;
        RectTransform targetRectTransform = targetTransform as RectTransform;
//
var temp=myBag.itemList[currentItemID];
myBag.itemList[currentItemID]=myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponent<slot>().slotID];
        
        if (targetRectTransform != null &&
    RectTransformUtility.ScreenPointToLocalPointInRectangle(
        targetRectTransform,
        eventData.position,
        eventData.pressEventCamera,
        out localPoint))
   
{
    Debug.Log(myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponent<item>().itemID]);
     // 计算偏移量
    //offset = transform.localPosition - anchor.localPosition;
    // 如果碰撞到了目標，將物體吸附到目標上
    // transform.SetParent(correctParent);
    // transform.localPosition = anchor.localPosition + offset;
    //
   // transform.SetParent(correctParent);
    transform.localPosition = targetTransform.localPosition; // 将拖曳物体设置到目标物体的位置上
     //GetComponent<Image>().sprite = newSprite;
      Debug.Log("on target");
    Debug.Log("correct"+correct);
     correct=true;
   Destroy(gameObject);
}
        else
        {
              
              correct=false;
            // 如果沒有碰撞到目標，將物體放回原來的位置
            transform.SetParent(originalParent);
            transform.position = originalParent.position;
            Debug.Log("not on target");
             Debug.Log("correct"+correct);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.tag == "Target")
    {
       
        targetTransform = collision.transform;
        anchor = targetTransform.Find("Anchor");
        Debug.Log("Target detected: " + targetTransform.name + ", position: " + targetTransform.position);
    }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Target")
    {
         //correct=false;
        targetTransform = null;
        anchor = null;
    }
    }
    public static bool checkTarget() // 宣告為靜態方法，回傳靜態變數 Check
    {
        return correct;
    }
}
//UI 介面鎖屏
//拖曳問題 (一半)  判斷拖曳物件是甚麼
//木頭勾零件