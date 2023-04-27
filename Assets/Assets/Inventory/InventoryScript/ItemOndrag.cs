using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ItemOndrag : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
   public void OnBeginDrag(PointerEventData eventData)
   {
        transform.position=eventData.position;
        Debug.Log("move");
   }
   public void OnDrag(PointerEventData eventData)
   {
        transform.position=eventData.position;
   }
   public void OnEndDrag(PointerEventData eventData)
   {

   }


}
