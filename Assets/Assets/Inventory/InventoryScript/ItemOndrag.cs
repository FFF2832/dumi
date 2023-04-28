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

   }
   public void OnEndDrag(PointerEventData eventData)
   {
     if(eventData.pointerCurrentRaycast.gameObject.name=="Item Image"){
          transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
          //transform.position=eventData.pointerCurrentRaycast.gameObject.transform.parent.parent;
     }
          GetComponent<CanvasGroup>().blocksRaycasts=false;
   }


}
