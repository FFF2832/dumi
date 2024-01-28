using UnityEngine;
using UnityEngine.UI;
public class Customer : MonoBehaviour
{
    public string ExpectedIceCreamName;
    public string IceCreamName_50;
    private IceCreamController iceCreamController; // 新增這個欄位
    private int score = 0;
    // public Text scoreText;
   // private Vector3 originalPosition; // 记录冰淇淋原始位置
    private Animator customerAnimator;
     private CustomerController customerController;

    void Start()
    {
        iceCreamController = FindObjectOfType<IceCreamController>();
        customerController = FindObjectOfType<CustomerController>();
        customerAnimator = GetComponent<Animator>(); // 获取Animator组件
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
    else if (IceCreamName_50 == deliveredIceCream.iceCreamName)
    {
        IceCreamDelivered50();
    }

    
    else
    {
        OnWrongIceCreamDelivered(deliveredIceCream);
    }
}

//     private void UpdateScoreUI()
// {
//     // 假設你有一個Text元件用來顯示分數，請替換成實際的UI元件
//     // 例如，如果有一個名為scoreText的Text元件：
//     scoreText.text = score.ToString();

//     // 如果你的UI元件有特定的名稱或位於特定的物件上，請根據實際情況調整
// }

    private void OnCorrectIceCreamDelivered()
    {
        // 增加得分
       // score += 100; // 你可以根據實際情況調整得分值
    customerController.AddScore(100); // 100 是你的得分值
        // 更新UI介面顯示分數
       // UpdateScoreUI();
        // 在這裡可以添加得分、播放正確冰淇淋的動畫等遊戲邏輯
      //  Debug.Log("成功拖到了正確的顧客所想要的冰淇淋！");
        customerAnimator.SetTrigger("out");
          Invoke("MoveToNextCustomerWithDelay", 3f);
    }
      private void IceCreamDelivered50()
    {
        // 增加得分
        //score += 50; // 你可以根據實際情況調整得分值
        customerController.AddScore(50); // 100 是你的得分值
        // 更新UI介面顯示分數
       // UpdateScoreUI();
        // 在這裡可以添加得分、播放正確冰淇淋的動畫等遊戲邏輯
       // Debug.Log("只對一半！");
        customerAnimator.SetTrigger("out");
         Invoke("MoveToNextCustomerWithDelay", 3f);
    }

   private void OnWrongIceCreamDelivered(IceCream deliveredIceCream)
{
    // score += 0;
     customerController.AddScore(0); // 100 是你的得分值
  //  Debug.Log("拖到的冰淇淋不是顧客所想要的！");
    customerAnimator.SetTrigger("out");
      Invoke("MoveToNextCustomerWithDelay", 3f);

    // 调用冰淇淋的 ResetIceCreamPosition 方法，将其飞回原始位置
    if (deliveredIceCream != null)
    {
        deliveredIceCream.ResetIceCreamPosition();
    }
}
  private void MoveToNextCustomerWithDelay()
    {
        customerController.MoveToNextCustomer();
    }
}
