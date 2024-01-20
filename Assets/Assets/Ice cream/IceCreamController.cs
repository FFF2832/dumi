using System.Collections.Generic;
using UnityEngine;

public class IceCreamController : MonoBehaviour
{
    private List<IceCream> iceCreams = new List<IceCream>(); // 用於管理所有冰淇淋的列表

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryPickUpIceCream();
        }
        else if (Input.GetMouseButton(0))
        {
            DragIceCream();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            ReleaseIceCream();
        }
       
    }

    void TryPickUpIceCream()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null && hit.collider.CompareTag("IceCream"))
        {
            IceCream iceCream = hit.collider.GetComponent<IceCream>();
            
            // 如果冰淇淋不存在於列表中，則添加它
            if (!iceCreams.Contains(iceCream))
            {
                iceCreams.Add(iceCream);
            }

            iceCream.TryPickUpIceCream(mousePosition);
        }
    }

    void DragIceCream()
    {
        foreach (IceCream iceCream in iceCreams)
        {
            iceCream.DragIceCream();
        }
    }

    void ReleaseIceCream()
    {
        foreach (IceCream iceCream in iceCreams)
        {
            iceCream.ReleaseIceCream();
              iceCream.ResetIceCreamPosition(); 
        }
    }
   
}
