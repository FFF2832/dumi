using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIslidepuzzle : MonoBehaviour
{
    public Text puzzleStatusText; // 拼图状态文本
    public Button resetButton;    // 重置按钮

    private bool win = false;     // 是否完成拼图

    void Start()
    {
        // 为重置按钮添加点击事件监听器
        resetButton.onClick.AddListener(ResetPuzzle);
    }

    void Update()
    {
        // 更新拼图状态文本内容
        puzzleStatusText.text = (win) ? "完成" : "未完成";

        // 监听键盘输入，按下 ESC 键时退出应用
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    // 重置拼图的方法
    void ResetPuzzle()
    {
        
            //  notRepeatingRandom();
              SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        
    }
}
