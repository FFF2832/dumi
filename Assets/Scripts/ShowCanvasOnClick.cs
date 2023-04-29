using UnityEngine;
using UnityEngine.UI;

public class ShowCanvasOnClick : MonoBehaviour
{
    // public GameObject canvas;

    // void Start()
    // {
    //     // 隐藏 Canvas
    //     canvas.SetActive(false);
    // }

    // void Update()
    // {
    //     // 如果点击了鼠标左键
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         // 获取鼠标的位置
    //         Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    //         // 获取被点击的物体的位置
    //         Vector2 objPos = transform.position;

    //         // 如果鼠标点击了这个物体
    //         if (mousePos.x >= objPos.x - 0.5f && mousePos.x <= objPos.x + 0.5f
    //             && mousePos.y >= objPos.y - 0.5f && mousePos.y <= objPos.y + 0.5f)
    //         {
    //             // 显示 Canvas
    //             canvas.SetActive(true);
    //         }
    //     }
    // }
 public GameObject canvasToToggle;

    private bool canvasIsActive = false;

    void Start()
    {
        canvasToToggle.SetActive(canvasIsActive);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (RectTransformUtility.RectangleContainsScreenPoint(
                GetComponent<RectTransform>(), mousePos, null))
            {
                canvasIsActive = !canvasIsActive;
                canvasToToggle.SetActive(canvasIsActive);
            }
            else if (canvasIsActive && !RectTransformUtility.RectangleContainsScreenPoint(
                canvasToToggle.GetComponent<RectTransform>(), mousePos, null))
            {
                canvasIsActive = false;
                canvasToToggle.SetActive(false);
            }
        }
    }
}