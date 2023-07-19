using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzlePiece : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Vector2 originalPosition;
    private bool isPlaced = false;
    private bool isCorrectlyPlaced = false; // 標記拼圖是否放置在正確位置

    public RectTransform targetPosition; // 目標位置的RectTransform
    public float snapDistance = 50f; // 拼圖碎片放置的吸附距離

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // 如果拼圖已經放置在正確位置，則不處理拖動
        if (isCorrectlyPlaced) return;

        // 將物品放到最前面
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        // 如果拼圖已經放置在正確位置，則不處理拖動
        if (isCorrectlyPlaced) return;

        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // 如果拼圖已經放置在正確位置，則不處理拖動
        if (isCorrectlyPlaced) return;

        float distanceToTarget = Vector2.Distance(rectTransform.anchoredPosition, targetPosition.anchoredPosition);

        // 如果距離小於吸附距離，則放置拼圖碎片在目標位置上
        if (distanceToTarget < snapDistance)
        {
            rectTransform.anchoredPosition = targetPosition.anchoredPosition;
            isPlaced = true;

            // 判斷是否放置在正確位置
            if (CheckIfCorrectlyPlaced())
            {
                isCorrectlyPlaced = true;
                // 在這裡添加拼圖放置在正確位置後的相應邏輯，例如播放正確位置放置成功的音效、顯示拼圖完成的提示等
            }
        }
        else
        {
            rectTransform.anchoredPosition = originalPosition;
        }
    }

    // 檢查是否放置在正確位置
    private bool CheckIfCorrectlyPlaced()
    {
        // 在這裡寫檢查拼圖是否放置在正確位置的邏輯，你可以根據自己的需求進行修改
        // 返回true表示拼圖放置在正確位置，否則返回false
        return false;
    }
}

