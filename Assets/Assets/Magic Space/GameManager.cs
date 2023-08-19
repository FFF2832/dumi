using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PotionBottle potionBottle; // 將藥水瓶拖入這個欄位
    public UIController uiController; // 管理UI的腳本，請自行創建

    // 玩家倒入材料的操作，你可以根據你的遊戲設計自行實現
    public void PourMaterial(string materialName)
    {
        potionBottle.PourMaterial(materialName);
        uiController.UpdateMaterialUI(materialName);
        
        if (potionBottle.CheckPotion())
        {
            // 玩家成功調配藥水的處理
            uiController.ShowSuccessMessage();
        }
    }
}
