using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public Sprite newSprite; // 新圖片

    private bool isDragging = false;
    private Vector2 offset;
    private Transform targetTransform;
    public float snapDistance = 0.5f; // 物品被吸附的距離
    private bool isSnapped = false;

    private void OnMouseDown()
    {
          if (!isSnapped)
        {
            isDragging = true;
            offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void OnMouseDrag()
    {
        if (isDragging && !isSnapped)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition + offset;
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;

        if (targetTransform != null)
        {
            float distance = Vector2.Distance(transform.position, targetTransform.position);

            if (distance <= snapDistance)
            {
                // 替換圖片
                //GetComponent<SpriteRenderer>().sprite = newSprite;

                // 移動到目標位置
                transform.position = targetTransform.position;
                isSnapped = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Target")
        {
            targetTransform = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Target")
        {
            targetTransform = null;
            isSnapped = false;
        }
    }
}
// using UnityEngine;
// using UnityEngine.EventSystems;

// public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
// {
//     private bool isDragging = false;
//     private Vector2 offset;
//     private RectTransform targetRectTransform;
//     public float snapDistance = 0.5f; // 物品被吸附的距離

//     private void Start()
//     {
//         targetRectTransform = GameObject.FindGameObjectWithTag("Target").GetComponent<RectTransform>();
//     }

//     public void OnPointerDown(PointerEventData eventData)
//     {
//         isDragging = true;
//         offset = transform.position - eventData.position;
//     }

//     public void OnDrag(PointerEventData eventData)
//     {
//         if (isDragging)
//         {
//             transform.position = eventData.position + offset;
//         }
//     }

//     public void OnPointerUp(PointerEventData eventData)
//     {
//         isDragging = false;

//         if (targetRectTransform != null)
//         {
//             float distance = Vector2.Distance(transform.position, targetRectTransform.position);

//             if (distance <= snapDistance)
//             {
//                 transform.position = targetRectTransform.position;
//                 targetRectTransform.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
//                 gameObject.SetActive(false);
//             }
//         }
//     }
// }