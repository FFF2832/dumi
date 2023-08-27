using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PotionBottle : MonoBehaviour
{
    public string[] requiredMaterials = new string[3]; 
    // public string[] requiredMaterials; // 正確的材料配方
    private string[] currentMaterials; // 當前倒入的材料


     private int currentMaterialIndex = 0; // 追蹤當前倒入的材料索引


    [SerializeField] Text materialText;
     [SerializeField] Text messageText; // 顯示消息的UI文本
    // [SerializeField] Image materialImages; // 使用 Image 陣列來處理多張圖片
       
    [SerializeField] Image materialImage1;    
    [SerializeField] Image materialImage2;
    [SerializeField] Image materialImage3;
     private int i = 0; // 定義 i 作為成員變量
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

  
// public void PourMaterial(string materialName)
// {
//     UpdateMaterialUI(materialName);

//     for (int i = 0; i < currentMaterials.Length; i++)
//     {
//          Debug.Log("i="+i);
//         if (string.IsNullOrEmpty(currentMaterials[i]))
//         {
//             currentMaterials[i] = materialName;
//             break;
//         }

//         // 如果所有材料都已經倒入，檢查是否正確
//         if (i == currentMaterials.Length )
//         {
//             Debug.Log("CheckPotion"+CheckPotion());
//             if (CheckPotion())
//             {
//                 // 成功
//                 ShowSuccessMessage();
//             }
//             else
//             {
//                 // 失敗
//                 ShowFailureMessage();
//             }
//         }
//     }
// }

// public void PourMaterial(string materialName)
//     {
//         UpdateMaterialUI(materialName);

//         if (i < currentMaterials.Length) // 檢查是否可以倒入更多材料
//         {
//             currentMaterials[i] = materialName;
//             i++; // 增加 i
//         }
        
       
//     }


public void PourMaterial(string materialName,Sprite materialSprite)
    {
        UpdateMaterialUI(materialName);
       
        if(i==0)UpdateMaterialSprite1(materialSprite);
        if(i==1)UpdateMaterialSprite2(materialSprite);
        if(i==2)UpdateMaterialSprite3(materialSprite);
        if (i < currentMaterials.Length) // 檢查是否可以倒入更多材料
        {
            currentMaterials[i] = materialName;
            i++; // 增加 i
        }
       
        
       
    }

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

public void UpdateMaterialSprite1(Sprite materialSprite)
    {
        if (materialSprite != null)
        {
            materialImage1.sprite = materialSprite;
        }
    }
public void UpdateMaterialSprite2(Sprite materialSprite)
    {
        if (materialSprite != null)
        {
            materialImage2.sprite = materialSprite;
        }
    }
    public void UpdateMaterialSprite3(Sprite materialSprite)
    {
        if (materialSprite != null)
        {
            materialImage3.sprite = materialSprite;
        }
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
// public void startBrew(string materialName,Sprite materialSprite ){

//     PourMaterial(materialName,materialSprite); // 執行材料的倒入
//     if (i == currentMaterials.Length)
//         {
//             if (CheckPotion())
//             {
//                 ShowSuccessMessage();
//             }
//             else
//             {
//                 ShowFailureMessage();
//                 SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
//             }
//         }
// }
public void startBrew(string materialName ){

   
    if (i == currentMaterials.Length)
        {
            if (CheckPotion())
            {
                ShowSuccessMessage();
            }
            else
            {

                ShowFailureMessage();
                
                // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                // 延遲換場景，例如延遲 2 秒
            float delayInSeconds = 2.0f;
            Invoke("LoadNextScene", delayInSeconds);
            }
        }
}
// 在這個函式中實現換場景的邏輯
private void LoadNextScene()
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
}
