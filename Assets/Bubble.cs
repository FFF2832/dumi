using UnityEngine;
using UnityEngine.EventSystems;

public class Bubble : MonoBehaviour, IPointerDownHandler
{
    public BubbleManager bubbleManager; // 連接到BubbleManager腳本
    private Animator animBubble;
    public int bubbleNumber;

    private void Start()
    {
        animBubble = GetComponent<Animator>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown called");
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out localPoint);

        if (bubbleNumber == 1)
        {
            animBubble.SetInteger("candle1Anim", 1);
            Debug.Log("Animator component: " + animBubble); // 檢查獲取到的 Animator 組件
            Debug.Log("設置 bubble1Anim 為 1");
        }

        if (bubbleNumber == 2)
        {
            animBubble.SetInteger("candle1Anim", 1);
        }

        // animBubble.SetInteger("animBubble2", 1);
        // 當泡泡被點擊時呼叫BubbleManager的BubbleClicked函數
        bubbleManager.BubbleClicked(gameObject);

        if (bubbleNumber == 3)
        {
            animBubble.SetInteger("candle1Anim", 1);
        }

        if (bubbleNumber == 4)
        {
            animBubble.SetInteger("bubble1Anim", 1);
        }
    }
}
