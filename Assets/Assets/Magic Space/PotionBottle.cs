using UnityEngine;

public class PotionBottle : MonoBehaviour
{
    public string[] requiredMaterials; // 正確的材料配方
    private string[] currentMaterials; // 當前倒入的材料

    // 檢查是否成功製作藥水
    public bool CheckPotion()
    {
        if (currentMaterials.Length != requiredMaterials.Length)
        {
            return false;
        }

        for (int i = 0; i < requiredMaterials.Length; i++)
        {
            if (currentMaterials[i] != requiredMaterials[i])
            {
                return false;
            }
        }

        return true;
    }

    // 倒入材料到藥水瓶
    public void PourMaterial(string materialName)
    {
        for (int i = 0; i < currentMaterials.Length; i++)
        {
            if (string.IsNullOrEmpty(currentMaterials[i]))
            {
                currentMaterials[i] = materialName;
                // 更新UI顯示當前材料
                // 更新藥水瓶的外觀，例如改變顏色
                break;
            }
        }
    }
}
