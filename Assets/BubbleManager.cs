using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class BubbleManager : MonoBehaviour
{
    public GameObject[] bubbles;
    private int currentIndex = 0;
    private Animator anim;
    private Animator animBubble1;
    private static bool bubbleCorrect;
    private int clickCount = 0;
    private List<GameObject> clickedBubbles = new List<GameObject>();

    public GameObject talkUI;

    private void Start()
    {
        SetNextBubble();
        anim = GetComponent<Animator>();
        animBubble1 = GetComponent<Animator>();
        anim.SetInteger("BubbleCorrect", 0);
    }

    void Update()
    {
        // 如果你希望每帧都更新动画状态，可以在这里调用 UpdateAnimationState()
    }

public void BubbleClicked(GameObject clickedBubble)
{
    if (!clickedBubbles.Contains(clickedBubble))
    {
        clickedBubbles.Add(clickedBubble);

        // 检查是否所有泡泡都已被点击
        if (clickedBubbles.Count == bubbles.Length)
        {
            // 所有泡泡都已被点击，开启 talkUI
            Debug.Log("所有泡泡都已被点击！");
            float delayAnim = 3.0f;
           Invoke("showAnim", delayAnim);
        }
    }
    else
    {
        Debug.Log("这个泡泡已经点击过了！");
    }
}

    private void PlayBubbleAnimation(GameObject bubble, int index)
    {
        // 在這裡添加播放動畫的邏輯
        switch (index)
        {
            case 0:
                Debug.Log("點到泡泡1");
                // 播放第一个泡泡的动画
                animBubble1.SetInteger("bubble1Anim", 1);
                break;
            case 1:
                // 播放第二个泡泡的动画
                // 添加你的第二个泡泡的动画播放逻辑
                break;
            // ... 继续添加其他泡泡的情况
        }
    }

    private void SetNextBubble()
    {
        // 在這裡添加設置下一個泡泡的邏輯
    }

    private void ResetBubbleSequence()
    {
        currentIndex = 0;
    }

    private void UpdateAnimationState()
    {
        // 根據bubbleCorrect狀態設置動畫
        if (bubbleCorrect)
        {
            anim.SetInteger("BubbleCorrect", 1);
            float delayAnim = 3.0f;
            Invoke("showAnim", delayAnim);
        }
        else
        {
            anim.SetInteger("BubbleCorrect", 2);
            float delayInSeconds = 4.0f;
            Invoke("LoadNextScene", delayInSeconds);
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void showAnim()
    {
        talkUI.SetActive(true);
    }

    public static bool UpdateBubbleCorrect()
    {
        return bubbleCorrect;
    }
}
