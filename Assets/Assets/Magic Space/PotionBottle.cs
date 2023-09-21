using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//按下按鈕成功或失敗要在圖層最上方
public class PotionBottle : MonoBehaviour
{
    public string[] requiredMaterials = new string[5]; 
    // public string[] requiredMaterials; // 正確的材料配方
    private string[] currentMaterials; // 當前倒入的材料


     private int currentMaterialIndex = 0; // 追蹤當前倒入的材料索引


    [SerializeField] Text materialText;
     [SerializeField] Text messageText; // 顯示消息的UI文本
    // [SerializeField] Image materialImages; // 使用 Image 陣列來處理多張圖片
       
    [SerializeField] Image materialImage1;    
    [SerializeField] Image materialImage2;
    [SerializeField] Image materialImage3;
    [SerializeField] Image materialImage4;
    [SerializeField] Image materialImage5;
     private int i = 0; // 定義 i 作為成員變量

    public item thisItem;
    public Inventory playerInventory;

//動畫
    //  private Animator anim; 
    // private Animator animskill;
    private enum MovementState{ startBrew,throwMaterial,potionSucess,potionFail};
    public static int sucessPotion;
     public static bool throwMaterial;

     public static bool magicDone;

      public static int sortOrder;
     private void Start()
    {
        // anim =GetComponent<Animator>();
        // animskill =GetComponent<Animator>();
        // 初始化 currentMaterials 陣列，使其具有與 requiredMaterials 相同的長度
        currentMaterials = new string[requiredMaterials.Length];

        sucessPotion=0;
       //這裡改成ui
        requiredMaterials[0] = "pink";
        requiredMaterials[1] = "nail";
        requiredMaterials[2] = "lip";
        requiredMaterials[3] = "fan";
        requiredMaterials[4] = "water";
    }
   
    // 檢查是否成功製作藥水
    public bool CheckPotion()
    {
      
       //Debug.Log("CheckPotion()");
        if (currentMaterials.Length != requiredMaterials.Length)

        {
            //sucessPotion=false;
            return false;
        }

        for (int i = 0; i < requiredMaterials.Length; i++)
        {
            if (currentMaterials[i] != requiredMaterials[i])
            {
                //sucessPotion=false;
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

// public void Update(){
//         UpdateAnimationState();
// }
public void PourMaterial(string materialName,Sprite materialSprite)
    {
       
         //這裡改成ui
        if(i==0)UpdateMaterialSprite1(materialSprite);
        if(i==1)UpdateMaterialSprite2(materialSprite);
        if(i==2)UpdateMaterialSprite3(materialSprite);
        if(i==3)UpdateMaterialSprite4(materialSprite);
        if(i==4)UpdateMaterialSprite5(materialSprite);
        if (i < currentMaterials.Length) // 檢查是否可以倒入更多材料
        {
            
           throwMaterial=true;
           sortOrder=-1;
            currentMaterials[i] = materialName;
            i++; // 增加 i
            float delay = 1.0f;
            Invoke("waitAnim", delay);
             
        }

         //UpdateAnimationState();
       
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
        // throwMaterial=true;
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
        public void UpdateMaterialSprite4(Sprite materialSprite)
    {
        if (materialSprite != null)
        {
            materialImage4.sprite = materialSprite;
        }
    }
        public void UpdateMaterialSprite5(Sprite materialSprite)
    {
        if (materialSprite != null)
        {
            materialImage5.sprite = materialSprite;
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

   //UpdateAnimationState();
    if (i == currentMaterials.Length)
        {
            if (CheckPotion())
            {
                sucessPotion=1;
                sortOrder=1;
                //ShowSuccessMessage();
                AddNewItem(thisItem);
                magicDone=true;
            }
            else
            {
                sortOrder=1;
                sucessPotion=2;
               // throwMaterial=false;
                //ShowFailureMessage();
                
                // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                // 延遲換場景，例如延遲 2 秒
            float delayInSeconds = 4.0f;
            Invoke("LoadNextScene", delayInSeconds);

            }
        }
}

private void waitAnim()
{
  throwMaterial=false;
}
// 在這個函式中實現換場景的邏輯
private void LoadNextScene()
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}

   public void AddNewItem(item thisItem){
    if(!playerInventory.itemList.Contains(thisItem)){
         //playerInventory.itemList.Add(thisItem);
          //未刪CreateNewItem
         //InventoryManager.CreateNewItem(thisItem);
         for(int i=0;i<playerInventory.itemList.Count;i++){
                if(playerInventory.itemList[i]==null){
                        playerInventory.itemList[i]=thisItem;
                        break;
                }
         }
    }
    else {
        thisItem.itemHeild += 1;
    }
    InventoryManager.RefreshItem(); 
   }

//    private void UpdateAnimationState()
//     {
//         // MovementState state;
//         Debug.Log("sucessPotion"+sucessPotion);
       
//         if(throwMaterial){
           
//              anim.SetBool("throw",true);
//                Debug.Log("throwMaterial"+throwMaterial);
//                 //state=MovementState.throwMaterial;
//         }
//         else{
//              anim.SetBool("throw",false);
//                  //state=MovementState.startBrew;
//         }
//     //     if(sucessPotion){
//     //             state=MovementState.potionSucess;
 
                
//     //     }
        
//     //     else  {
//     //         state=MovementState.potionFail;
//     //        // state=MovementState.startBrew;
//     //         // moving = false;
//     //     }
     
//     //    anim.SetInteger("state",(int)state);
//     }
    public static bool UpdatethrowMaterial(){
    return throwMaterial;
    }

    public static int UpdatesucessPotion(){
        return sucessPotion;
    }

     public static bool UpdatemagicDone(){
       // magicDone=true;
        return magicDone;
    }

    public static int UpdatesortOrder(){
        return sortOrder;
    }
}
