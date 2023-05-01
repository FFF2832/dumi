using UnityEngine;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool isHovered = false;
    	public void ToDray()
    {
        transform.localPosition =new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2);
        Debug.Log("跩成功");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;
        Debug.Log("Mouse entered item");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
        Debug.Log("Mouse exited item");
    }
}