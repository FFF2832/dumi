using UnityEngine;
using UnityEngine.EventSystems;

public class MaterialDragDrop : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    // public static bool throwMaterial;
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
        // // 拖放結束時，檢查是否材料被放在藥水瓶上
        // Vector3 dropPosition = eventData.pointerCurrentRaycast.worldPosition;
        // GameObject droppedOn = eventData.pointerCurrentRaycast.gameObject;
        // // Debug.Log("End Drag");
        // string materialName = gameObject.GetComponent<Material>().materialName;
        //  Debug.Log("Dropped material: " + materialName); // 輸出材料名稱到控制台
        // // if (droppedOn != null && droppedOn.CompareTag("PotionBottle"))
        // // {
        // //     // 取得材料名稱，然後將其倒入藥水瓶
        // //     string materialName = gameObject.GetComponent<Material>().materialName;
        // //     Debug.Log("Dropped material: " + materialName); // 輸出材料名稱到控制台
        // //     PotionBottle potionBottle = droppedOn.GetComponent<PotionBottle>();
        // //     potionBottle.PourMaterial(materialName);
        // // }



         // 從拖動的物體中獲取材料名稱
        //string materialName = eventData.pointerDrag.GetComponent<Material>().materialName;

       
    }

    // 使用Collider2D的Trigger進入檢測
    private void OnTriggerEnter2D(Collider2D other)
    {
        // if (other.CompareTag("PotionBottle"))
        // {
        //      // 從拖動的物體中獲取材料名稱
        // string materialName = gameObject.GetComponent<Material>().materialName;
        
        // //Debug.Log("Dropped material: " + materialName); // 輸出材料名稱到控制台
        // PotionBottle potionBottle = other.GetComponent<PotionBottle>();
        // potionBottle.PourMaterial(materialName);

   

        // }

          if (other.CompareTag("PotionBottle"))
    {
        string materialName = gameObject.GetComponent<Material>().materialName;

        //圖片
         Sprite materialImage = gameObject.GetComponent<Material>().materialSprite;

        PotionBottle potionBottle = other.GetComponent<PotionBottle>();

        if (potionBottle != null)
        {
            potionBottle.PourMaterial(materialName,materialImage);
           // throwMaterial=true;
            GameManager gm = other.GetComponent<GameManager>();
            Destroy(gameObject);
            if (gm != null)
            {
                // 確保將 materialName 傳遞給 PourMaterial 函數
                gm.GM(materialName,materialImage);
            
            }
        }
       
    }
    }
    // private void OnTriggerExit2D(Collider2D other){
    //     throwMaterial=false;
    // }

    //  public static bool UpdatethrowMaterial(){
    // return throwMaterial;
    // }
}
