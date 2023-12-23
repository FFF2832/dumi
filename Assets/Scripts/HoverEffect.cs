using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class HoverEffect : MonoBehaviour{private Image image;
    private RectTransform rectTransform;
    private bool isMouseOver = false;
    private float targetAlpha = 0.0f;
    private float currentAlpha = 0.0f;
    private float fadeSpeed = 2.0f;

    void Start()
    {
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
        SetAlpha(targetAlpha);
    }

    void Update()
    {
        if (IsMouseOverRect())
        {
            targetAlpha = 1.0f;
        }
        else
        {
            targetAlpha = 0.0f;
        }

        currentAlpha = Mathf.Lerp(currentAlpha, targetAlpha, Time.deltaTime * fadeSpeed);
        SetAlpha(currentAlpha);
    }

    void SetAlpha(float alpha)
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
    }

    bool IsMouseOverRect()
    {
        Vector2 mousePos = Input.mousePosition;
        return RectTransformUtility.RectangleContainsScreenPoint(rectTransform, mousePos);
    }
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
