using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.Collections; // 用于协程的命名空间
using UnityEngine.UI;
public class MusicManager : MonoBehaviour, IPointerClickHandler
{
    public GameObject[] musics;
    private int currentIndex = 0;
    private Animator anim;
    //private Animator animMusic1;
    private static bool musicCorrect;
    private int clickCount = 0;
    private bool animationInitialized = false;
    private List<GameObject> clickedMusics = new List<GameObject>();

    public GameObject talkUI;
    private bool musicFinished;
      public item thisItem;
   public Inventory playerInventory;
   
   public RectTransform targetPosition; // 引用Canvas中的目标位置
    public float moveSpeed = 2.0f; // 移动速度
    public float shrinkSpeed = 0.1f;
       public Image itemImage; // 引用UI物品的Image组件
    public Sprite newSprite; // 要设置的新Sprite

    public float initialScaleFactor = 0.2f; // 指定的初始缩放倍数

    private Vector3 originalScale;
    //    public  bool isCollected;
       public Animator animator;
    private void Start()
    {
        SetNextMusic();
        anim = GetComponent<Animator>();
      //  animMusic1 = GetComponent<Animator>();
        //anim.SetInteger("CandleCorrect", 0);
           anim.SetInteger("snakeSucess", 0);
           musicCorrect=false;
    }

    void Update()
    {
        // 如果你希望每帧都更新动画状态，可以在这里调用 UpdateAnimationState()
  
    }

    public void MusicClicked(GameObject clickedMusic)
    {
        // if (!clickedMusics.Contains(clickedMusic))
        // {
            clickedMusics.Add(clickedMusic);

            if (clickedMusic == musics[currentIndex])
            {
                // 正確的音樂
                PlayMusicAnimation(clickedMusic, currentIndex);
                currentIndex++;
                clickCount++;

                if (currentIndex == musics.Length)
                {
                    // 完成整個順序
                    // anim.SetInteger("snakeSucess", 1);
                    Debug.Log("完成順序！");
                    musicCorrect = true;
                    ResetMusicSequence();
                  
                   
                }
                else
                {
                    // 設置下一個應點擊的音樂
                    SetNextMusic();
                }
            }
            else
            {
                // anim.SetInteger("snakeSucess", 2);
                // 錯誤的音樂，可以在這裡添加錯誤處理邏輯
                
                musicCorrect = false;
               // ResetMusicSequence();
                clickCount++;
                 
            }

            // 更新動畫狀態
            if (clickCount == 3) {
                if(musicCorrect){
                    UpdateAnimationState();
                    musicFinished=true;
                }
                else  {
                    currentIndex = 0;
                    clickCount=0;
                    Debug.Log("錯誤的順序！");
                }
                }
        // }
        // else
        // {
        //     // 已經點過這個音樂，你可以添加相應的處理邏輯，例如提示或其他操作
        //     Debug.Log("這個音樂已經點過了！");
        // }
    }

    private void PlayMusicAnimation(GameObject music, int index)
    {
        // 在這裡添加播放動畫的邏輯
        switch (index)
        {
            case 0:
              //  Debug.Log("點到音樂1");
                // 播放第一个音樂的动画
              //  animMusic1.SetInteger("music1Anim", 1);
                break;
            case 1:
                // 播放第二个音樂的动画
                // 添加你的第二个音乐的动画播放逻辑
                break;
            // ... 继续添加其他音乐的情况
        }
    }

    private void SetNextMusic()
    {
        // 在這裡添加設置下一個音樂的邏輯
    }

    private void ResetMusicSequence()
    {
        currentIndex = 0;
       
    }

    private void UpdateAnimationState()
    {
        // 根據musicCorrect狀態設置動畫
        if (musicCorrect)
        {
              anim.SetInteger("snakeSucess", 1);
           // anim.SetInteger("CandleCorrect", 1);
            // float delayAnim = 3.0f;
           // Invoke("showAnim", delayAnim);
            Debug.Log("成功到一");
         
        }
        else
        {
              anim.SetInteger("snakeSucess", 2);
            //anim.SetInteger("CandleCorrect", 2);
            float delayInSeconds = 4.0f;
          //  Invoke("LoadNextScene", delayInSeconds);
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void showAnim()
    {
        talkUI.SetActive(true);
    }

    public static bool UpdateMusicCorrect()
    {
        return musicCorrect;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("點擊了UI物品：" + name);
        if (musicCorrect)
        {
        // 在這裡添加你想要的點擊功能邏輯
        originalScale = transform.localScale;

        // 设置初始缩放
        transform.localScale = originalScale * initialScaleFactor;
        animator.enabled = false;
        AddNewItem();
        // 更改UI物品的Image组件的Sprite
        if (itemImage != null && newSprite != null)
        {
            itemImage.sprite = newSprite;
        }
        // 启动协程，实现平滑移动
        StartCoroutine(MoveToTargetPosition(targetPosition.position));
        //  Destroy(gameObject);
        }
       
    }
     // 协程用于平滑移动
    private IEnumerator MoveToTargetPosition(Vector3 targetPos)
    {
       while (Vector3.Distance(transform.position, targetPos) > 0.01f)
        {
            // 移动
            transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);

            // 缩小
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, shrinkSpeed * Time.deltaTime);

            yield return null;
        }

        // 确保最终位置和缩放准确
        transform.position = targetPos;
        transform.localScale = Vector3.zero;


        // 在这里添加你的其他点击功能逻辑

        // 销毁点击完的物品
        Destroy(gameObject);
    }
     public void AddNewItem(){
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
        // thisItem.itemHeild += 1;
    }
    InventoryManager.RefreshItem(); 
    
   }
}
