using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PotionBottle : MonoBehaviour
{
    public string[] requiredMaterials = new string[3]; 
    // public string[] requiredMaterials; // 正確的材料配方
    private string[] currentMaterials; // 當前倒入的材料

    [SerializeField] Text materialText;
     [SerializeField] Text messageText; // 顯示消息的UI文本
     private void Start()
    {
        // 初始化 currentMaterials 陣列，使其具有與 requiredMaterials 相同的長度
        currentMaterials = new string[requiredMaterials.Length];


        requiredMaterials[0] = "pink";
        requiredMaterials[1] = "nail";
        requiredMaterials[2] = "lip";
    }
    // void Updated(){
       
    // }
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

  
public void PourMaterial(string materialName)
{
    UpdateMaterialUI(materialName);

    for (int i = 0; i < currentMaterials.Length; i++)
    {
         Debug.Log("i="+i);
        if (string.IsNullOrEmpty(currentMaterials[i]))
        {
            currentMaterials[i] = materialName;
            break;
        }

        // 如果所有材料都已經倒入，檢查是否正確
        if (i == currentMaterials.Length )
        {
            Debug.Log("CheckPotion"+CheckPotion());
            if (CheckPotion())
            {
                // 成功
                ShowSuccessMessage();
            }
            else
            {
                // 失敗
                ShowFailureMessage();
            }
        }
    }
}


// public void PourMaterial(string materialName)
// {
//     UpdateMaterialUI(materialName);

   
// }

// 檢查是否所有材料都已經倒入
private bool CheckAllMaterialsFilled()
{
    foreach (string material in currentMaterials)
    {
        if (string.IsNullOrEmpty(material))
        {
            return false;
        }
    }
    return true;
}


public void ShowFailureMessage()
{
    messageText.text = "YOU FAILED!";
}

     public void UpdateMaterialUI(string materialName)
    {
        // materialText.text = "Current Material: " + materialName;
        //Debug.Log("Updated material UI: " + materialText.text);

        materialText.text="Updated material UI:"+materialName;
    }

    // 顯示成功消息
    public void ShowSuccessMessage()
    {

        messageText.text = "Potion Successfully Brewed!";
    }
    public void ResetMaterials()
{
    // 這個方法用於重置所有材料，準備重新配置藥水
    for (int i = 0; i < currentMaterials.Length; i++)
    {
        currentMaterials[i] = ""; // 重置每個材料為空
    }
}
public void startBrew(string materialName){
    // bool allMaterialsFilled = true; // 假設所有材料都已經倒入

    // for (int i = 0; i < currentMaterials.Length; i++)
    // {
    //     Debug.Log("i=" + i);
    //     if (string.IsNullOrEmpty(currentMaterials[i]))
    //     {
    //         currentMaterials[i] = materialName;
    //         break;
    //     }

    //     if (i == currentMaterials.Length - 1)
    //     {
    //         // 迴圈結束後，檢查是否所有材料都已經倒入
    //         allMaterialsFilled = CheckAllMaterialsFilled();
            
    //     }
    // }

    // // 只在所有材料都已經倒入時執行檢查
    // if (allMaterialsFilled)
    // {
    //     if (CheckPotion())
    //     {
    //         // 成功
    //         ShowSuccessMessage();
    //     }
    //     else
    //     {
    //         // 失敗
    //         ShowFailureMessage();
    //         ResetMaterials();
    //         // 重新載入當前場景
    //         //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //     }
    // }

    PourMaterial(materialName); // 執行材料的倒入
    CheckPotion(); // 檢查藥水是否成功
}
}
