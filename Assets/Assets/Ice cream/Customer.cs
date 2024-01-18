using UnityEngine;
using UnityEngine.UI;
public class Customer : MonoBehaviour
{
    public string ExpectedIceCreamName;
    public string IceCreamName_50;
    private IceCreamController iceCreamController; // 新增這個欄位
    private int score = 0;
    public Text scoreText;
   // private Vector3 originalPosition; // 记录冰淇淋原始位置
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
    else if (IceCreamName_50 == deliveredIceCream.iceCreamName)
    {
        IceCreamDelivered50();
    }

    
    else
    {
        OnWrongIceCreamDelivered(deliveredIceCream);
    }
}

    private void UpdateScoreUI()
{
    // 假設你有一個Text元件用來顯示分數，請替換成實際的UI元件
    // 例如，如果有一個名為scoreText的Text元件：
    scoreText.text = score.ToString();

    // 如果你的UI元件有特定的名稱或位於特定的物件上，請根據實際情況調整
}

    private void OnCorrectIceCreamDelivered()
    {
        // 增加得分
        score += 100; // 你可以根據實際情況調整得分值

        // 更新UI介面顯示分數
        UpdateScoreUI();
        // 在這裡可以添加得分、播放正確冰淇淋的動畫等遊戲邏輯
        Debug.Log("成功拖到了正確的顧客所想要的冰淇淋！");
    }
      private void IceCreamDelivered50()
    {
        // 增加得分
        score += 50; // 你可以根據實際情況調整得分值

        // 更新UI介面顯示分數
        UpdateScoreUI();
        // 在這裡可以添加得分、播放正確冰淇淋的動畫等遊戲邏輯
        Debug.Log("只對一半！");
    }

   private void OnWrongIceCreamDelivered(IceCream deliveredIceCream)
{
    score += 0;
    Debug.Log("拖到的冰淇淋不是顧客所想要的！");

    // 调用冰淇淋的 ResetIceCreamPosition 方法，将其飞回原始位置
    if (deliveredIceCream != null)
    {
        deliveredIceCream.ResetIceCreamPosition();
    }
}

}
