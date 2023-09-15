using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text materialText; // 顯示當前材料的UI文本
    public Text messageText; // 顯示消息的UI文本
     public Canvas uiCanvas;
     public GameObject grid;
   
     void Start()
    {
        grid.SetActive(true);
    }
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
    void Update(){
        ChangeOrder();
    }
    public void ChangeOrder()
{
    // int newSortOrder = 0;  // 預設值

    // // 根據條件設置新的 sort order
    // if (PotionBottle.UpdatesucessPotion() == 1)
    // {
    //     newSortOrder = 1;  // 你想要的 sort order
    // }
    // else if (PotionBottle.UpdatesucessPotion() == 2)
    // {
    //     newSortOrder = 1;  // 另一種條件下的 sort order
    // }
    // else   newSortOrder = 2;

    
    
     if (PotionBottle.UpdatesucessPotion() == 1)
    {
        grid.SetActive(false);
    }
    else if (PotionBottle.UpdatesucessPotion() == 2)
    {
       grid.SetActive(false);
    }
    else  grid.SetActive(true);
}
}
