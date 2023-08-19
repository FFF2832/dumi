using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text materialText; // 顯示當前材料的UI文本
    public Text messageText; // 顯示消息的UI文本

    // 更新UI顯示當前材料
    public void UpdateMaterialUI(string materialName)
    {
        materialText.text = "Current Material: " + materialName;
        Debug.Log("Updated material UI: " + materialText.text);
    }

    // 顯示成功消息
    public void ShowSuccessMessage()
    {
        messageText.text = "Potion Successfully Brewed!";
    }
}
