using UnityEngine;
using UnityEngine.EventSystems;

public class DisableMovementOnClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isPointerDown = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        isPointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPointerDown = false;
    }

    private void Update()
    {
        if (isPointerDown)
        {
            // 禁止玩家移動的代碼
            Debug.Log("Player cannot move");
        }
    }
}

