using UnityEngine;
using UnityEngine.EventSystems;

public class MaterialDragDrop : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // 拖放結束時，檢查是否材料被放在藥水瓶上
        Vector3 dropPosition = eventData.pointerCurrentRaycast.worldPosition;
        GameObject droppedOn = eventData.pointerCurrentRaycast.gameObject;
        // Debug.Log("End Drag");
        string materialName = gameObject.GetComponent<Material>().materialName;
         Debug.Log("Dropped material: " + materialName); // 輸出材料名稱到控制台
        // if (droppedOn != null && droppedOn.CompareTag("PotionBottle"))
        // {
        //     // 取得材料名稱，然後將其倒入藥水瓶
        //     string materialName = gameObject.GetComponent<Material>().materialName;
        //     Debug.Log("Dropped material: " + materialName); // 輸出材料名稱到控制台
        //     PotionBottle potionBottle = droppedOn.GetComponent<PotionBottle>();
        //     potionBottle.PourMaterial(materialName);
        // }
    }
}
