using UnityEngine;

public class Candle : MonoBehaviour
{
    public CandleManager candleManager; // 連接到CandleManager腳本
    private Animator animcandle1;
    private Animator paint;
    public int candleNumber;
   private void Start()
    {
       
       paint = GetComponent<Animator>();
        animcandle1 = GetComponent<Animator>();
      
    }
    private void OnMouseDown()
    {
        if(candleNumber==1) {
             //paint.SetInteger("paint1",1);
            animcandle1.SetInteger("candle1Anim",1);
           Debug.Log("Animator component: " + paint); // 检查获取到的 Animator 组件
            paint.SetInteger("paint1", 1);
            Debug.Log("Setting paint1 to 1");


        }
        if(candleNumber==2) animcandle1.SetInteger("animCandle2",1);
        // 當蠟燭被點擊時呼叫CandleManager的CandleClicked函數
        candleManager.CandleClicked(gameObject);
       
    }
}
