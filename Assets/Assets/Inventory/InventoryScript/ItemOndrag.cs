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
   public void OnBeginDrag(PointerEventData eventData)
   {
     originalParent=transform.parent;
     transform.SetParent(transform.parent.parent);
        transform.position=eventData.position;
        GetComponent<CanvasGroup>().blocksRaycasts=false;
     //    Debug.Log("move");
   }
   public void OnDrag(PointerEventData eventData)
   {
        transform.position=eventData.position;
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
        

    // // 判斷是否有可吸附的目標物件
    // Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);
    // foreach (Collider2D col in colliders)
    // {
    //     if (col.gameObject.CompareTag("TargetObject"))
    //     {
    //         // 將物品移至目標物件上方
    //         transform.SetParent(col.gameObject.transform);
    //         transform.position = col.gameObject.transform.position;
    //         GetComponent<CanvasGroup>().blocksRaycasts = false;
    //         return;
    //     }
    // }

    // // 若無可吸附的目標物件，則將物品移回原始位置
    // transform.SetParent(originalParent);
    // transform.position = originalParent.position;
    // GetComponent<CanvasGroup>().blocksRaycasts = true;

   }
   public void OnEndDrag(PointerEventData eventData)
   {
     //判斷是否有物品
    //  if(eventData.pointerCurrentRaycast.gameObject.name=="Item Image"){
    //       transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
    //       transform.position=eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;
    //       eventData.pointerCurrentRaycast.gameObject.transform.parent.position=originalParent.position;
    //       eventData.pointerCurrentRaycast.gameObject.transform.SetParent(originalParent);
    //        GetComponent<CanvasGroup>().blocksRaycasts=true;
    //        return;
    //  }
    //   transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
    //   transform.position=eventData.pointerCurrentRaycast.gameObject.transform.position;
    //       GetComponent<CanvasGroup>().blocksRaycasts=false;

    //更新
     if (eventData.pointerCurrentRaycast.gameObject.name == "Item Image")
        {
            // move to correct parent
            transform.SetParent(correctParent);
            transform.position = correctParent.position;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            return;
        }

        transform.SetParent(originalParent);
        transform.position = originalParent.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

          
   }
      private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CorrectItem"))
        {
            correctParent = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("CorrectItem"))
        {
            correctParent = null;
        }
    }


}
