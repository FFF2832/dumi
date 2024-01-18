using UnityEngine;

public class IceCream : MonoBehaviour
{
    public string iceCreamName; // 冰淇淋的名字或編號
    private Vector3 originalPosition; // 冰淇淋的原始位置
    private bool isIceCreamHeld = false;
    private Vector3 offset;

    void Start()
    {
        originalPosition = transform.position; // 记录冰淇淋原始位置
    }

    public void TryPickUpIceCream(Vector3 mousePosition)
    {
        if (!isIceCreamHeld)
        {
            isIceCreamHeld = true;
            offset = transform.position - mousePosition;
        }
    }

    public void DragIceCream()
    {
        if (isIceCreamHeld)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            transform.position = mousePosition + offset;
        }
    }

    public void ReleaseIceCream()
    {
        isIceCreamHeld = false;
    }

    public void ResetIceCreamPosition()
    {
         Debug.Log("Resetting ice cream position to: " + originalPosition);
        // 将冰淇淋位置设置回原始位置
        transform.position = originalPosition;
    }
}
