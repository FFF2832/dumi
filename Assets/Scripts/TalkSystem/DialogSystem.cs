// 沒有改過的原始版本
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class DialogSystem : MonoBehaviour
{
    //public GameObject obj;
    
    [Header("UI组件")]
    public Image headImage;
    public Text textLabel;
    public Image dialogImage;
    

    [Header("文本文件")]
    public TextAsset textFile;
    public int index;
    public float textSpeed;

    [Header("头像")]
    public Sprite headPlayer;
    public Sprite headNPC;

    [Header("對話框")]
    public Sprite dialogPlayer;
    public Sprite dialogPlayer2;
    public Sprite dialogPlayer3;
    public Sprite dialogNpc;
    public Sprite dialogNpc2;
    public Sprite dialogNpc3;
    public Sprite dialogNpc4;
    public Sprite dialogIllustrate1;
    public Sprite dialogIllustrate2;
    public Sprite dialogIllustrate3;
    public Sprite dialogIllustrate4;
    bool textFinished;  //文本是否显示完毕
    private static bool videoPlayed;
    private static bool changeScene;
    public  static bool changeScene2;
    
    bool isTyping;  //是否在逐字显示

    List<string> textList = new List<string>();
    public static bool conversationUI; 

    void Start(){

      //headImage.enabled=false;
      conversationUI=true;

    }
    void Awake()
    {
        GetTextFromFile(textFile);
    }

    void OnEnable()
    {
        index = 0;  //对话框每次隐藏变为显示就重置对话
        textFinished = true;    //对话框每次隐藏变为显示状态变为文本已结束
        StartCoroutine(setTextUI());
        
       
    }

    void Update()
    {
        //如果按下F键并且对话全部结束后关闭对话框
        if ((Input.GetKeyDown(KeyCode.Space)|| Input.GetMouseButtonDown(0)) && index == textList.Count)
        {
            gameObject.SetActive(false);
            // Destroy(gameObject); //不刪除物件則可無限次數說話
            return;
        }

        //按下F键，当前行文本完成就执行协程，当前行文本未完成就直接显示当前行文本
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            if (textFinished)
            {
                StartCoroutine(setTextUI());
            }
            else if (!textFinished)
            {
                isTyping = false;
            }
        }
        // 如果按下跳到最后一段对话的按键（比如按下"A"键）
    if (Input.GetKeyDown(KeyCode.A))
    {
        // 将索引设置为对话文本列表的最后一个元素的索引
        index = textList.Count - 1;

        // 关闭对话框
        gameObject.SetActive(false);
        return;
    }

    if (Input.GetKeyDown(KeyCode.Q))
    {
        // 检查对话是否已经完成
        if (textFinished)
        {
            // 播放剩余的对话内容并关闭对话框
            StartCoroutine(AutoPlayAndCloseDialog());
        }
        else if (!textFinished)
        {
            isTyping = false;
        }
    }
    }

    void GetTextFromFile(TextAsset file)
    {
        //清空文本内容
        textList.Clear();

        //切割文本文件内容然后一行一行加到list集合中
        var lineDate = file.text.Split('\n');
        foreach (var line in lineDate)
        {
            textList.Add(line);
        }
    }

    IEnumerator AutoPlayAndCloseDialog() //自動播放
{
    // 自动播放剩余的对话内容
    while (index < textList.Count)
    {
        textFinished = false;
        textLabel.text = ""; // 重置文本内容

        switch (textList[index].Trim())
        {
             case "B":
                dialogImage.sprite = dialogPlayer;
                headImage.sprite = headPlayer;
                 //Destroy(dialogImage);
                //npcdialogImage.sprite.SetActive(false);
                index++;
                break;
            case "A":
                headImage.sprite = headNPC;
                dialogImage.sprite = dialogNpc;
                index++;
                break;
            case "A2":
                headImage.sprite = headNPC;
                dialogImage.sprite = dialogNpc2;
                index++;
                break;
            case "A3":
                headImage.sprite = headNPC;
                dialogImage.sprite = dialogNpc3;
                index++;
                break;
            case "A4":
                headImage.sprite = headNPC;
                dialogImage.sprite = dialogNpc4;
                index++;
                break;     
            case "I":
                headImage.sprite = headNPC;
                dialogImage.sprite = dialogIllustrate1;
                index++;
                break;
            case "I2":
                headImage.sprite = headNPC;
                dialogImage.sprite = dialogIllustrate2;
                index++;
                break;     
            case "CS1":
                textFinished = true; 
                changeScene=true;
                index++;
                break;
            case "学Unity！":
                textFinished = true; 
                videoPlayed=true;
                 
                break;// 设置对话框和头像的显示...
        }

        // 逐字显示文本内容
        int word = 0;
        while (word < textList[index].Length - 1)
        {
            // 逐字显示
            textLabel.text += textList[index][word];
            word++;
            yield return new WaitForSeconds(textSpeed);
        }

        // 快速显示文本内容为本行内容
        textLabel.text = textList[index];

        isTyping = true;
        textFinished = true;
        index++;
    }

    // 关闭对话框
    gameObject.SetActive(false);
}

    IEnumerator setTextUI()
    {
        textFinished = false;   //进入文字显示状态
        textLabel.text = "";    //重置文本内容
        //headImage.SetAsLastSibling(1);
        //判断文本文件里的内容
        switch (textList[index].Trim())
        {
            case "B":
                dialogImage.sprite = dialogPlayer;
                headImage.sprite = headPlayer;
                 //Destroy(dialogImage);
                //npcdialogImage.sprite.SetActive(false);
                index++;
                break;
            case "A":
                headImage.sprite = headNPC;
                dialogImage.sprite = dialogNpc;
                index++;
                break;
            case "I":
                headImage.sprite = headNPC;
                dialogImage.sprite = dialogIllustrate1;
                index++;
                break;
            case "I2":
                headImage.sprite = headNPC;
                dialogImage.sprite = dialogIllustrate2;
                index++;
                break; 
            case "I3":
                headImage.sprite = headNPC;
                dialogImage.sprite = dialogIllustrate3;
                index++;
                break;
            case "I4":
                headImage.sprite = headNPC;
                dialogImage.sprite = dialogIllustrate4;
                index++;
                break;           
            case "V":
                textFinished = true; 
                videoPlayed=true;
                gameObject.SetActive(false);
                // SceneManager.LoadScene("Scene Clear_1");

                break;
            case "A2":
                headImage.sprite = headNPC;
                dialogImage.sprite = dialogNpc2;
                index++;
                break;
            case "A3":
                headImage.sprite = headNPC;
                dialogImage.sprite = dialogNpc3;
                index++;
                break;
            case "A4":
                headImage.sprite = headNPC;
                dialogImage.sprite = dialogNpc4;
                index++;
                break;
            case "B2":
                dialogImage.sprite = dialogPlayer2;
                headImage.sprite = headPlayer;
                 //Destroy(dialogImage);
                //npcdialogImage.sprite.SetActive(false);
                index++;
                break;
            case "B3":
                dialogImage.sprite = dialogPlayer3;
                headImage.sprite = headPlayer;
                 //Destroy(dialogImage);
                //npcdialogImage.sprite.SetActive(false);
                index++;
                break;
            case "CS1":
                textFinished = true; 
                changeScene=true;
                index++;
                break;
            case "CS2":
                textFinished = true; 
                changeScene2=true;
                index++;
                break;
        }

        //每按一次F键播放一行文字
        int word = 0;
        while (isTyping && word < textList[index].Length - 1)
        {
            //逐字显示
            textLabel.text += textList[index][word];
            word++;
            yield return new WaitForSeconds(textSpeed);
        }
        //快速显示文本内容为本行内容
        textLabel.text = textList[index];

        isTyping = true;
        textFinished = true;
        conversationUI=false;
        index++;
    }

    public static bool UpdatevideoPlayed(){
            return videoPlayed;
    }
    public  static bool UpdatechangeScene(){
            return changeScene;
    }
    public  static bool UpdatechangeScene2(){
            return changeScene2;
    }
    public static bool UpadateconversationUI(){
        return conversationUI;
    }
}




// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;
// public class DialogSystem : MonoBehaviour
// {
//     //public GameObject obj;
    
//     [Header("UI组件")]
//     public Image headImage;
//     public Text textLabel;
//     public Image dialogImage;
    

//     [Header("文本文件")]
//     public TextAsset textFile;
//     public int index;
//     public float textSpeed;

//     [Header("头像")]
//     public Sprite headPlayer;
//     public Sprite headNPC;

//     [Header("對話框")]
//     public Sprite dialogPlayer;
//     public Sprite dialogNpc;
//     public Sprite dialogIllustrate1;
//     public Sprite dialogIllustrate2;
//     bool textFinished;  //文本是否显示完毕
//     bool isTyping;  //是否在逐字显示

//     List<string> textList = new List<string>();



// //對話選項
//     private bool isChoosingOption = false;
//     private List<string> options = new List<string>();

//     private int selectedOption = 0; // 新增一個變數用來追蹤玩家的選擇

//     public Button optionButton1;
//     public Button optionButton2;

//     private bool areOptionsVisible = false; // 追蹤按鈕的可見性
//     void Start(){
//       //\headImage.enabled=false;
//        HideOptions(); // 開始時隱藏按鈕
//     }
//     void Awake()
//     {
//         GetTextFromFile(textFile);
//     }

//     void OnEnable()
//     {
//         index = 0;  //对话框每次隐藏变为显示就重置对话
//         textFinished = true;    //对话框每次隐藏变为显示状态变为文本已结束
//         StartCoroutine(setTextUI());
//     }

//     void Update()
//     {
//         //如果按下F键并且对话全部结束后关闭对话框
//         if (Input.GetKeyDown(KeyCode.Space) && index == textList.Count)
//         {
//             gameObject.SetActive(false);
//             // Destroy(gameObject); //不刪除物件則可無限次數說話
//             return;
//         }

//         //按下F键，当前行文本完成就执行协程，当前行文本未完成就直接显示当前行文本
//         if (Input.GetKeyDown(KeyCode.Space))
//         {
//             if (textFinished)
//             {
//                 StartCoroutine(setTextUI());
//             }
//             else if (!textFinished)
//             {
//                 isTyping = false;
//             }
//         }
//         // 如果按下跳到最后一段对话的按键（比如按下"A"键）
//     if (Input.GetKeyDown(KeyCode.A))
//     {
//         // 将索引设置为对话文本列表的最后一个元素的索引
//         index = textList.Count - 1;

//         // 关闭对话框
//         gameObject.SetActive(false);
//         return;
//     }

//     if (Input.GetKeyDown(KeyCode.Q))
//     {
//         // 检查对话是否已经完成
//         if (textFinished)
//         {
//             // 播放剩余的对话内容并关闭对话框
//             StartCoroutine(AutoPlayAndCloseDialog());
//         }
//         else if (!textFinished)
//         {
//             isTyping = false;
//         }
//     }

//     if (isChoosingOption)
//         {
//             HandleOptionSelection();
//         }
//     }

//     void GetTextFromFile(TextAsset file)
//     {
//         //清空文本内容
//         textList.Clear();

//         //切割文本文件内容然后一行一行加到list集合中
//         var lineDate = file.text.Split('\n');
//         foreach (var line in lineDate)
//         {
//             textList.Add(line);
//         }
//     }

//     IEnumerator AutoPlayAndCloseDialog() //自動播放
// {
//     // 自动播放剩余的对话内容
//     while (index < textList.Count)
//     {
//         textFinished = false;
//         textLabel.text = ""; // 重置文本内容

//         switch (textList[index].Trim())
//         {
//              case "B":
//                 dialogImage.sprite = dialogPlayer;
//                 headImage.sprite = headPlayer;
//                  //Destroy(dialogImage);
//                 //npcdialogImage.sprite.SetActive(false);
//                 index++;
//                 break;
//             case "A":
//                 headImage.sprite = headNPC;
//                 dialogImage.sprite = dialogNpc;
//                 index++;
//                 break;
//             case "I":
//                 headImage.sprite = headNPC;
//                 dialogImage.sprite = dialogIllustrate1;
//                 index++;
//                 break;
//             case "I2":
//                 headImage.sprite = headNPC;
//                 dialogImage.sprite = dialogIllustrate2;
//                 index++;
//                 break;         
//             case "...":
//                 textFinished = true; 
//                 break;// 设置对话框和头像的显示...
//         }

//         // 逐字显示文本内容
//         int word = 0;
//         while (word < textList[index].Length - 1)
//         {
//             // 逐字显示
//             textLabel.text += textList[index][word];
//             word++;
//             yield return new WaitForSeconds(textSpeed);
//         }

//         // 快速显示文本内容为本行内容
//         textLabel.text = textList[index];

//         isTyping = true;
//         textFinished = true;
//         index++;
//     }

//     // 关闭对话框
//     gameObject.SetActive(false);
// }

//     IEnumerator setTextUI()
//     {
//         textFinished = false;   //进入文字显示状态
//         textLabel.text = "";    //重置文本内容


       

       

//         //headImage.SetAsLastSibling(1);
//         //判断文本文件里的内容
//         switch (textList[index].Trim())
//         {
//             case "B":
//                 dialogImage.sprite = dialogPlayer;
//                 headImage.sprite = headPlayer;
//                  //Destroy(dialogImage);
//                 //npcdialogImage.sprite.SetActive(false);
//                 index++;
//                 break;
//             case "A":
//                 headImage.sprite = headNPC;
//                 dialogImage.sprite = dialogNpc;
//                 index++;
//                 break;
//             case "I":
//                 headImage.sprite = headNPC;
//                 dialogImage.sprite = dialogIllustrate1;
//                 index++;
//                 break;
//             case "I2":
//                 headImage.sprite = headNPC;
//                 dialogImage.sprite = dialogIllustrate2;
//                 index++;
//                 break;         
//             case "...":
//                 textFinished = true; 
//                 break;
//         }
//          // 如果遇到選項
//         if (textList[index].Trim() == "Q")
//         {
//             ShowOptions();
//             isChoosingOption = true;
//             index++;
//             DisplayOptions();
//             yield break;
//         }
//         //每按一次F键播放一行文字
//         int word = 0;
//         while (isTyping && word < textList[index].Length - 1)
//         {
//             //逐字显示
//             textLabel.text += textList[index][word];
//             word++;
//             yield return new WaitForSeconds(textSpeed);
//         }
//         //快速显示文本内容为本行内容
//         textLabel.text = textList[index];

//         isTyping = true;
//         textFinished = true;
//         index++;
//     }




//     //對話選項
//     void HandleOptionSelection()
//     {
//         // 如果選項為0，表示玩家尚未選擇，等待玩家輸入
//         if (selectedOption == 0)
//         {
//             if (Input.GetKeyDown(KeyCode.Alpha1))
//             {
//                 selectedOption = 1;
//                 HandleOption(1);
//             }
//             else if (Input.GetKeyDown(KeyCode.Alpha2))
//             {
//                 selectedOption = 2;
//                 HandleOption(2);
//             }
//         }
//         else if (selectedOption == 1 || selectedOption == 2)
//         {
//             // 玩家已選擇選項，等待繼續按鍵
//             if (Input.GetKeyDown(KeyCode.Space))
//             {
//                 // 重置選項狀態
//                 selectedOption = 0;
//                 ClearOptions();

//                 // 繼續對話
//                 isChoosingOption = false;
//                 StartCoroutine(setTextUI());
//             }
//         }
//     }

//      // 新增方法來顯示選項
//    void DisplayOptions()
// {
//     // 清空選項列表
//     options.Clear();

//     // 尋找選項，直到遇到下一個空行或文本結束
//     while (index < textList.Count && !string.IsNullOrWhiteSpace(textList[index]))
//     {
//         options.Add(textList[index].Trim());
//         index++;
//     }

//     // 檢查選項數量，並根據選項數量來啟用或禁用相應的按鈕
//     if (options.Count >= 1)
//     {
//         optionButton1.interactable = true;
//         optionButton1.GetComponentInChildren<Text>().text = options[0];
//     }
//     else
//     {
//         optionButton1.interactable = false;
//     }

//     if (options.Count >= 2)
//     {
//         optionButton2.interactable = true;
//         optionButton2.GetComponentInChildren<Text>().text = options[1];
//     }
//     else
//     {
//         optionButton2.interactable = false;
//     }
//       // 顯示按鈕

// }

//        // 新增方法來處理選項的選擇
//     void HandleOption(int optionNumber)
//     {
//         // 根據選擇的選項號碼執行相應的操作，例如顯示不同的對話內容
//         // 這部分根據您的遊戲需求自行定義
//         // 在此處理選項選擇的邏輯
//         // 例如，根據選擇顯示不同的對話內容
//         switch (optionNumber)
//         {
//             case 1:
//                 // 玩家選擇選項1的處理邏輯
//                 // 例如，顯示相關的對話或執行相應的操作
//                 break;
//             case 2:
//                 // 玩家選擇選項2的處理邏輯
//                 // 例如，顯示相關的對話或執行相應的操作
//                 break;
//         }
//     }
//     // 新增方法來清除選項
//     void ClearOptions()
//     {
//         // 清空選項，此處應根據您的UI系統進行操作
//         // 清除之前顯示的選項，以準備顯示下一段對話
//     }

//     // 新增方法來顯示選項，此處應根據您的UI系統進行操作
  


//     // 隱藏按鈕
// void HideOptions()
// {
//     optionButton1.gameObject.SetActive(false);
//     optionButton2.gameObject.SetActive(false);
//     areOptionsVisible = false;
// }

// // 顯示按鈕
// void ShowOptions()
// {
//     optionButton1.gameObject.SetActive(true);
//     optionButton2.gameObject.SetActive(true);
//     areOptionsVisible = true;
// }
// }