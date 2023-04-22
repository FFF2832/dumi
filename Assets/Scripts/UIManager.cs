// using UnityEngine;
// using UnityEngine.UI;

// public class UIManager : MonoBehaviour
// {
//     public GameObject mainMenuCanvas;
//     public GameObject gameplayCanvas;
//     public Button startButton;
//     public Button backButton;

//     private void Start()
//     {
//         // 隱藏 gameplayCanvas，顯示 mainMenuCanvas
//         gameplayCanvas.SetActive(false);
//         mainMenuCanvas.SetActive(true);

//         // 設置按鈕點擊事件
//         startButton.onClick.AddListener(OnGameStartButtonClicked);
//         backButton.onClick.AddListener(OnBackToMainMenuButtonClicked);
//     }

//     private void OnGameStartButtonClicked()
//     {
//         // 隱藏 mainMenuCanvas，顯示 gameplayCanvas
//         mainMenuCanvas.SetActive(false);
//         gameplayCanvas.SetActive(true);
//     }

//     private void OnBackToMainMenuButtonClicked()
//     {
//         // 隱藏 gameplayCanvas，顯示 mainMenuCanvas
//         gameplayCanvas.SetActive(false);
//         mainMenuCanvas.SetActive(true);
//     }
// }

using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject gameplayCanvas;
    public GameObject thirdCanvas;
    public Button startButton;
    public Button backButton;
    public Button back2Button;
    public Button thirdButton;

    private void Start()
    {
        // 隱藏 gameplayCanvas 和 thirdCanvas，顯示 mainMenuCanvas
        gameplayCanvas.SetActive(false);
        thirdCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);

        // 設置按鈕點擊事件
        startButton.onClick.AddListener(OnGameStartButtonClicked);
        backButton.onClick.AddListener(OnBackToMainMenuButtonClicked);
        back2Button.onClick.AddListener(OnBackToMainMenuButtonClicked);
        thirdButton.onClick.AddListener(OnOpenThirdCanvasButtonClicked);
    }

    private void OnGameStartButtonClicked()
    {
        // 隱藏 mainMenuCanvas 和 thirdCanvas，顯示 gameplayCanvas
        mainMenuCanvas.SetActive(false);
        thirdCanvas.SetActive(false);
        gameplayCanvas.SetActive(true);
    }

    private void OnBackToMainMenuButtonClicked()
    {
        // 隱藏 gameplayCanvas 和 thirdCanvas，顯示 mainMenuCanvas
        gameplayCanvas.SetActive(false);
        thirdCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }

    private void OnOpenThirdCanvasButtonClicked()
    {
        // 隱藏 mainMenuCanvas 和 gameplayCanvas，顯示 thirdCanvas
        mainMenuCanvas.SetActive(false);
        gameplayCanvas.SetActive(false);
        thirdCanvas.SetActive(true);
    }
}