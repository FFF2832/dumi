using UnityEngine;

public class Candle : MonoBehaviour
{
    public CandleManager candleManager; // 連接到CandleManager腳本

    private void OnMouseDown()
    {
        // 當蠟燭被點擊時呼叫CandleManager的CandleClicked函數
        candleManager.CandleClicked(gameObject);
    }
}
