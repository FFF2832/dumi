using UnityEngine;

public class Customer : MonoBehaviour
{
    public string ExpectedIceCreamName;
    private IceCreamController iceCreamController; // 新增這個欄位

    void Start()
    {
        iceCreamController = FindObjectOfType<IceCreamController>(); // 在 Start 函數中設置它
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("IceCream"))
        {
            IceCream deliveredIceCream = other.GetComponent<IceCream>();
            if (deliveredIceCream != null)
            {
                CheckDeliveredIceCream(deliveredIceCream);
            }
        }
    }

   public void CheckDeliveredIceCream(IceCream deliveredIceCream)
{
    // 判斷是否是顧客想要的冰淇淋
    if (ExpectedIceCreamName == deliveredIceCream.iceCreamName)
    {
        OnCorrectIceCreamDelivered();
    }
    else
    {
        OnWrongIceCreamDelivered();
    }
}


    private void OnCorrectIceCreamDelivered()
    {
        // 在這裡可以添加得分、播放正確冰淇淋的動畫等遊戲邏輯
        Debug.Log("成功拖到了正確的顧客所想要的冰淇淋！");
    }

    private void OnWrongIceCreamDelivered()
    {
        // 在這裡可以添加錯誤提示、扣分等遊戲邏輯
        Debug.Log("拖到的冰淇淋不是顧客所想要的！");
    }
}
