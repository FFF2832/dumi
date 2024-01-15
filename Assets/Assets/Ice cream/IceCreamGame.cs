using UnityEngine;

public class IceCreamGame : MonoBehaviour
{
    public Transform playerHand; // 玩家手的位置
    public float deliveryRange = 1f; // 交付冰淇淋的範圍
    public LayerMask customerLayer; // 客人的圖層

    private GameObject heldIceCream; // 手上的冰淇淋

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PickUpIceCream();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            DeliverIceCream();
        }
    }

    void PickUpIceCream()
    {
        // 使用射線檢測冰淇淋
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        if (hit.collider != null && hit.collider.CompareTag("IceCream"))
        {
            // 拾取冰淇淋
            heldIceCream = hit.collider.gameObject;
            heldIceCream.transform.SetParent(playerHand);
            heldIceCream.transform.localPosition = Vector3.zero;
        }
    }

    void DeliverIceCream()
    {
        if (heldIceCream != null)
        {
            // 使用射線檢測客人
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, deliveryRange, customerLayer);

            if (hit.collider != null && hit.collider.CompareTag("Customer"))
            {
                // 交付冰淇淋給客人
                Destroy(heldIceCream); // 在實際遊戲中，你可能會播放交付動畫，增加分數等等
            }

            // 重置手上的冰淇淋
            heldIceCream = null;
        }
    }
}
