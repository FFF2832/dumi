using UnityEngine;

public class IceCream : MonoBehaviour
{
    public string iceCreamName; // 冰淇淋的名字或編號

    private bool isIceCreamHeld = false;
    private Vector3 offset;

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
}
