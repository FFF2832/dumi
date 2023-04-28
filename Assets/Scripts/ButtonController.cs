using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Canvas canvas2;
    public Button button;

    void Start()
    {
        button.onClick.AddListener(OpenCanvas2);
        canvas2.gameObject.SetActive(false); // 將 Canvas2 隱藏起來
    }

    void OpenCanvas2()
    {
        Debug.Log("OpenCanvas2 is called");
        canvas2.gameObject.SetActive(true); // 將 Canvas2 顯示出來

    }
}