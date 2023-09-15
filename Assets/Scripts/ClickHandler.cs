using UnityEngine;
using UnityEngine.UI;
//提示消失
public class ClickHandler : MonoBehaviour
{
    public Canvas tempCanvas;
    public GameObject tempCanvaspic;
    public float displayTime = 2f;
    public Button startButton;

    private float timer;
    private bool displayTempCanvas;

    private void Start()
    {
        tempCanvas.enabled = false;
         tempCanvaspic.SetActive(false);
         startButton.onClick.AddListener(OnGameStartButtonClicked);
    }

    private void Update()
    {
        if (displayTempCanvas)
        {
            timer += Time.deltaTime;

            if (timer >= displayTime)
            {
                tempCanvas.enabled = false;
                displayTempCanvas = false;
                timer = 0f;
                 tempCanvaspic.SetActive(false);
            }
        }
    }

    public void OnImageClick()
    {
        tempCanvas.enabled = true;
        tempCanvaspic.SetActive(true);
        displayTempCanvas = true;
        Debug.Log("按下按鈕");
    }
    
    private void OnGameStartButtonClicked()
    {
        // 隱藏 mainMenuCanvas 和 thirdCanvas，顯示 gameplayCanvas
        tempCanvaspic.SetActive(true);
       
    }
}