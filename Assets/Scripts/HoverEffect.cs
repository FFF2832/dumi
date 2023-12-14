using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class HoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image normalImage;
    public Image hoverImage;
    public float hoverSpeed = 5f; // 悬停颜色渐变的速度

    private Color normalColor;
    private Color hoverColor;
    private float lerpFactor = 0f;

    void Start()
    {
        normalColor = normalImage.color;
        hoverColor = hoverImage.color;

        normalImage.gameObject.SetActive(true);
        hoverImage.gameObject.SetActive(false);
    }
    // 当鼠标进入UI元素时调用
    public void OnPointerEnter(PointerEventData eventData)
    {
        // 在这里添加悬停时的效果，例如改变颜色或触发其他事件
        Debug.Log("Mouse entered UI!");
        normalImage.gameObject.SetActive(false);
        hoverImage.gameObject.SetActive(true);
        
    }

    // 当鼠标离开UI元素时调用
    public void OnPointerExit(PointerEventData eventData)
    {
        // 在这里添加离开时的效果，例如恢复原始颜色或执行其他操作
        Debug.Log("Mouse exited UI!");
        normalImage.gameObject.SetActive(true);
        hoverImage.gameObject.SetActive(false);
    }

    // void Update()
    // {
    //     Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    //     if (RectTransformUtility.RectangleContainsScreenPoint(normalImage.rectTransform, Input.mousePosition))
    //     {
    //         // 滑鼠在 UI 元素範圍內
    //         lerpFactor = Mathf.Clamp01(lerpFactor + Time.deltaTime * hoverSpeed);
    //         normalImage.color = Color.Lerp(normalColor, hoverColor, lerpFactor);
    //         hoverImage.color = Color.Lerp(hoverColor, normalColor, lerpFactor);

    //         normalImage.gameObject.SetActive(false);
    //         hoverImage.gameObject.SetActive(true);
    //     }
    //     else
    //     {
    //         // 滑鼠不在 UI 元素範圍內
    //         lerpFactor = Mathf.Clamp01(lerpFactor - Time.deltaTime * hoverSpeed); // 減少插值因子
    //         normalImage.color = Color.Lerp(hoverColor, normalColor, lerpFactor);
    //         hoverImage.color = Color.Lerp(normalColor, hoverColor, lerpFactor);

    //         // 當插值因子接近零時，恢復原始狀態
    //         if (lerpFactor < 0.01f)
    //         {
    //             lerpFactor = 0f; // 確保插值因子為零
    //             normalImage.color = normalColor;
    //             normalImage.gameObject.SetActive(true);
    //             hoverImage.gameObject.SetActive(false);
    //         }
    //     }
    // }
}