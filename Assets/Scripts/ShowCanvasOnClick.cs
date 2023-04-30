using UnityEngine;
using UnityEngine.UI;

public class ShowCanvasOnClick : MonoBehaviour
{

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