using UnityEngine;
using UnityEngine.SceneManagement;

public class CandleManager : MonoBehaviour
{
    public GameObject[] candles;
    private int currentIndex = 0;
    private Animator anim;
    private Animator animskill;
    private bool candleCorrect;
    private int clickCount = 0;
    private bool animationInitialized = false;

    private void Start()
    {
        SetNextCandle();
        anim = GetComponent<Animator>();
        animskill = GetComponent<Animator>();
        anim.SetInteger("CandleCorrect", 0);
    }

    void Update()
    {
        // 如果你希望每帧都更新动画状态，可以在这里调用 UpdateAnimationState()
    }

   // 當點擊蠟燭時呼叫此函數
public void CandleClicked(GameObject clickedCandle)
{
    // while( clickCount <4){

    // }
    if (clickedCandle == candles[currentIndex])
    {
        // 正確的蠟燭
        PlayCandleAnimation(clickedCandle);
        currentIndex++;
        clickCount++;
        if (currentIndex == candles.Length)
        {
            // 完成整個順序
            Debug.Log("完成順序！");
            ResetCandleSequence();
            candleCorrect = true;
        }
        else
        {
            // 設置下一個應點擊的蠟燭
            SetNextCandle();
        }
    }
    else
    {
        // 錯誤的蠟燭，可以在這裡添加錯誤處理邏輯
        Debug.Log("錯誤的順序！");
        candleCorrect = false;  
        ResetCandleSequence();
        clickCount++;
        
    }

    // 更新動畫狀態
    if(clickCount==4)UpdateAnimationState();
}


    private void PlayCandleAnimation(GameObject candle)
    {
        // 在這裡添加播放動畫的邏輯

    }

    private void SetNextCandle()
    {
        // 在這裡添加設置下一個蠟燭的邏輯
    }

    private void ResetCandleSequence()
    {
        currentIndex = 0;
    }

    private void UpdateAnimationState()
    {
        // 根据candleCorrect状态设置动画
        if (candleCorrect)
        {
            anim.SetInteger("CandleCorrect", 1);
        }
        else
        {
            anim.SetInteger("CandleCorrect", 2);
              float delayInSeconds = 4.0f;
            Invoke("LoadNextScene", delayInSeconds);
        }
    }
    private void LoadNextScene()
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
}
