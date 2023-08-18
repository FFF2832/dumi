// using UnityEngine;
// using UnityEngine.EventSystems;

// public class DragFromInventory : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
// {
//     private RectTransform rectTransform;
//     private Vector2 originalPosition;
//     private Inventory inventory; // 背包的引用，這個需要根據你的情況來設置

//     private void Awake()
//     {
//         rectTransform = GetComponent<RectTransform>();
//         originalPosition = rectTransform.anchoredPosition;
//     }

//     public void OnBeginDrag(PointerEventData eventData)
//     {
//         // 檢查是否拖曳的是拼圖碎片
//         if (IsPuzzlePiece())
//         {
//             // 從背包中移除拼圖碎片
//             inventory.RemoveItem(this.gameObject);
//         }
//     }

//     public void OnDrag(PointerEventData eventData)
//     {
//         rectTransform.anchoredPosition += eventData.delta;
//     }

//     public void OnEndDrag(PointerEventData eventData)
//     {
//         // 檢查是否放置在正確位置
//         if (CheckIfCorrectlyPlaced())
//         {
//             // 在這裡添加拼圖放置在正確位置後的相應邏輯
//         }
//         else
//         {
//             // 將拼圖碎片放回原位
//             rectTransform.anchoredPosition = originalPosition;
//         }
//     }

//     private bool IsPuzzlePiece()
//     {
//         // 在這裡添加檢查是否是拼圖碎片的邏輯
//         return true; // 替換成實際的檢查邏輯
//     }

//     private bool CheckIfCorrectlyPlaced()
//     {
//         // 在這裡寫檢查拼圖是否放置在正確位置的邏輯，同之前的操作
//         return false;
//     }
// }
