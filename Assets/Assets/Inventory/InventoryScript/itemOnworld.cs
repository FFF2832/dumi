using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemOnworld : MonoBehaviour
{
   public item thisItem;
   public Inventory playerInventory;
    //public GameObject sparkle;
     private bool isDestroyed = false; // 标记物体是否被销毁
     public item itemToRemove;

//動畫
    // public GameObject itemObject;
    // public Transform targetPosition;  // 包包的目標位置
    // public float movementDuration = 1.0f;  // 移動動畫的持續時間
 public Transform initialPosition;  // 物品初始位置
    public Transform targetPosition;   // 包包的目標位置
    public float movementSpeed = 1.0f;  // 移動速度

    private bool isMoving = false;
    
    public Sprite moveSprite;
    public Animator animator;


    public RectTransform Recttarget; // 引用Canvas中的目标位置
    public float moveSpeed = 2.0f; // 移动速度
    public float shrinkSpeed = 0.1f;
       public Image itemImage; // 引用UI物品的Image组件
    public Sprite newSprite; // 要设置的新Sprite

    public float initialScaleFactor = 0.2f; // 指定的初始缩放倍数

    private Vector3 originalScale;
    //
  
    public  bool isCollected;
    
     private void Awake()
    {
       
        // 在这里檢查物品是否已被收集，但不要馬上重置 isCollected
    if (PlayerPrefs.GetInt("IsCollected_" + thisItem.itemName, 0) == 1)
    {
        // 如果已被收集，你可以隱藏物品或者改變其外觀
        isCollected = true;
        if (isCollected)
        {
            gameObject.SetActive(false); // 隱藏物品
        }
    }
    else
    {
        isCollected = false; // 如果未被收集，将 isCollected 设置为 false
    }
    }
    private void Start()
    {
         
    //     // 检查物体的销毁状态
    //    if (PlayerPrefs.GetInt("IsItemDestroy_" + gameObject.name, 0) == 1)
    //    {
    //        Destroy(gameObject);
    //        isDestroyed = true;
    //    }
        //sparkle.SetActive(true);

        // 檢查物品是否已被收集
    // if (PlayerPrefs.GetInt("IsCollected_" + thisItem.itemName, 0) == 1)
    // {
    //     // 如果已被收集，你可以隱藏物品或者改變其外觀
    //     isCollected = true;
    //     gameObject.SetActive(false); // 隱藏物品
       
    // }
    
       
    }
  private void Update(){
    
  // Debug.Log("isCollected"+isCollected);
    check2DObjectClicked();
     if (isMoving)
        {
          //Debug.Log("isMoving"+isMoving);
            MoveItemToTargetPosition();
        }
      
  }
   private void OnTriggerEnter2D(Collider2D other)
   {
     
    if(other.gameObject.CompareTag("Player")){
        AddNewItem(thisItem);
        Destroy(gameObject);
      
    }  
   
   } 
   //原始addItem()
//      public void AddNewItem(item thisItem){
//     if(!playerInventory.itemList.Contains(thisItem)){
//          //playerInventory.itemList.Add(thisItem);
//           //未刪CreateNewItem
//          //InventoryManager.CreateNewItem(thisItem);
//          for(int i=0;i<playerInventory.itemList.Count;i++){
//                 if(playerInventory.itemList[i]==null){
//                         playerInventory.itemList[i]=thisItem;
//                          // 開始移動動畫
//                         // StartCoroutine(MoveItemToTargetPosition(itemObject));
                   
//                         break;
//                 }
//          }
//     }
//     else {
//         thisItem.itemHeild += 1;
//     }
//     InventoryManager.RefreshItem(); 
//    }
     public void SaveItemState()
    {
        // 使用物品的名稱作為唯一標識，保存物品的狀態
        PlayerPrefs.SetInt("IsCollected_" + thisItem.itemName, isCollected ? 1 : 0);
        PlayerPrefs.Save();
    }
   public void AddNewItem(item thisItem){
    
     if (!isCollected)
    {
        // 將物品添加到玩家背包的相應邏輯
        // ...
        if(!playerInventory.itemList.Contains(thisItem)){
         //playerInventory.itemList.Add(thisItem);
          //未刪CreateNewItem
         //InventoryManager.CreateNewItem(thisItem);
         for(int i=0;i<playerInventory.itemList.Count;i++){
                if(playerInventory.itemList[i]==null){
                        playerInventory.itemList[i]=thisItem;
                        //  // 開始移動動畫
                        //  MoveItemToTargetPosition();
                   
                        break;
                }
         }
        }
        else {
        // thisItem.itemHeild += 1;
        }
        
        // 設置物品為已收集
            isCollected = true;

            // 保存物品狀態
            SaveItemState();

            // 隱藏物品
            //gameObject.SetActive(false);
    }
    InventoryManager.RefreshItem(); 
    
   }

   void check2DObjectClicked()
{
    if (Input.GetMouseButtonDown(0))
    {
       
        Camera cam = Camera.main;

        //Raycast depends on camera projection mode
        Vector2 origin = Vector2.zero;
        Vector2 dir = Vector2.zero;

        if (cam.orthographic)
        {
            origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            origin = ray.origin;
            dir = ray.direction;
        }

        RaycastHit2D hit = Physics2D.Raycast(origin, dir);

        //Check if we hit anything
        //判斷是不是ui之下
        if (hit)
        {
            // Debug.Log("We hit " + hit.collider.name);
             //如果點到
            // if(Enlarge.UpdateifUI()){

            // }
            if(hit.collider.name=="branch"){
             
                //Debug.Log("We hit " + hit.collider.name);
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = moveSprite;
                animator.enabled = false;
                AddNewItem(thisItem);
                   isMoving = true;
                   isCollected =true;
                // Destroy(hit.collider);
                //  Destroy(gameObject);
             //   isDestroyed = true;

        //    // 保存物体的销毁状态
        //    PlayerPrefs.SetInt("IsItemDestroy_" + gameObject.name, 1);
        //    PlayerPrefs.Save();
                //Debug.Log("touch");
            }
            // else if(hit.collider.name=="collectitem_car"){
             
            //   //  Debug.Log("We hit " + hit.collider.name);
            //      Debug.Log(" 1" );
            //     AddNewItem(thisItem);
            //     Destroy(hit.collider);
            //     Destroy(gameObject);
            //       //sparkle.SetActive(false);
           
            //    // Debug.Log("touch");
            // }

            // if(hit.collider.name=="decoration_roof"){
             
            //     Debug.Log("We hit " + hit.collider.name);
            //     AddNewItem();
               
            //     Destroy(gameObject);
            //     Destroy(hit.collider);
            //     Debug.Log("touch");
            // }
            else if(hit.collider.name=="decoration_sun"){
            
            //     AddNewItem(thisItem);
            //     Destroy(hit.collider);
            //     Destroy(gameObject);
            Debug.Log("We hit " + hit.collider.name);
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = moveSprite;
                animator.enabled = false;
                AddNewItem(thisItem);
                   isMoving = true;
               
            }

            else if(hit.collider.name=="clue"){
             
                Debug.Log("We hit " + hit.collider.name);
                AddNewItem(thisItem);
                Destroy(hit.collider);
                Destroy(gameObject);
            
            }
            else if(hit.collider.name=="puzzle1"){
             
                Debug.Log("We hit " + hit.collider.name);
                AddNewItem(thisItem);
                Destroy(hit.collider);
                Destroy(gameObject);
               
            }
            else if(hit.collider.name=="puzzle2"){
             
                Debug.Log("We hit " + hit.collider.name);
                AddNewItem(thisItem);
                Destroy(hit.collider);
                Destroy(gameObject);
               
               
            }
           else  if(hit.collider.name=="puzzle3"){
             
                Debug.Log("We hit " + hit.collider.name);
                AddNewItem(thisItem);
                Destroy(hit.collider);
                Destroy(gameObject);
    
            }
              else  if(hit.collider.name=="test"){
             
                Debug.Log("We hit " + hit.collider.name);
                AddNewItem(thisItem);
                 isMoving = true;
              
    
            }
               else  if(hit.collider.name=="gecko"){
             
                Debug.Log("We hit " + hit.collider.name);
                AddNewItem(thisItem);
                 isMoving = true;
              
    
            }
             else  if(hit.collider.name=="key_f1"){
             
                Debug.Log("We hit " + hit.collider.name);
                AddNewItem(thisItem);
                 isMoving = true;
                
    
            }
            // if(hit.collider.name=="fullpiece"){
             
            //     Debug.Log("We hit " + hit.collider.name);
            //     AddNewItem(thisItem);
            //     Destroy(hit.collider);
            //     Destroy(gameObject);
    
            // }

        }
    } 
    
}
public  void OnButtonClick()
    {
       
        // AddNewItem(thisItem);
       
        // isMoving = true;

        //  Destroy(gameObject);

          // 在這裡添加你想要的點擊功能邏輯
        originalScale = transform.localScale;

        // 设置初始缩放
        transform.localScale = originalScale * initialScaleFactor;
        AddNewItem(thisItem);
       
        // 更改UI物品的Image组件的Sprite
        if (itemImage != null && newSprite != null)
        {
            itemImage.sprite = newSprite;
        }
        // 启动协程，实现平滑移动
        StartCoroutine(MoveToTargetPosition(Recttarget.position));
    }
  public  void correctKey(){
    if(keyChange.changekey_1){
         // 在這裡添加你想要的點擊功能邏輯
        originalScale = transform.localScale;

        // 设置初始缩放
        transform.localScale = originalScale * initialScaleFactor;
        AddNewItem(thisItem);
       
        // 更改UI物品的Image组件的Sprite
        if (itemImage != null && newSprite != null)
        {
            itemImage.sprite = newSprite;
        }
        // 启动协程，实现平滑移动
        StartCoroutine(MoveToTargetPosition(Recttarget.position));
        
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
  public void wrongkey(){
         if(key_F3change.changekey_2){
         // 在這裡添加你想要的點擊功能邏輯
        originalScale = transform.localScale;

        // 设置初始缩放
        transform.localScale = originalScale * initialScaleFactor;
        AddNewItem(thisItem);
        // 更改UI物品的Image组件的Sprite
        if (itemImage != null && newSprite != null)
        {
            itemImage.sprite = newSprite;
        }
        // 启动协程，实现平滑移动
        StartCoroutine(MoveToTargetPosition(Recttarget.position));
    }
  }
  public void wrongkey_2(){
         if(key_F4change.changekey_1){
         // 在這裡添加你想要的點擊功能邏輯
        originalScale = transform.localScale;

        // 设置初始缩放
        transform.localScale = originalScale * initialScaleFactor;
        AddNewItem(thisItem);
        // 更改UI物品的Image组件的Sprite
        if (itemImage != null && newSprite != null)
        {
            itemImage.sprite = newSprite;
        }
        // 启动协程，实现平滑移动
        StartCoroutine(MoveToTargetPosition(Recttarget.position));
    }
  }
 public  void RemoveItem(item itemToRemove)
    {
        playerInventory.itemList.Remove(itemToRemove);
    }
//     public static void RemoveItem(item itemToRemove)
// {
//     if (playerInventory.itemList.Contains(itemToRemove))
//     {
//         playerInventory.itemList.Remove(itemToRemove);
//         InventoryManager.RefreshItem();
//     }
// }  

//  private IEnumerator MoveItemToTargetPosition(GameObject itemObject)
//     {
//         float elapsedTime = 0f;
//         Vector3 initialPosition = itemObject.transform.position;
//         Vector3 targetPosition = this.targetPosition.position;
//         Debug.Log("Starting animation...");

//         while (elapsedTime < movementDuration)
//         {
//             elapsedTime += Time.deltaTime;
//             float t = Mathf.Clamp01(elapsedTime / movementDuration);

//             // 使用向量插值平滑地移動物品到目標位置
//             itemObject.transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
//             Debug.Log("Animation completed.");


//             yield return null;
//         }

//         // 確保物品最終位置準確
//         itemObject.transform.position = targetPosition;
//         // 隱藏物品遊戲物件
//     itemObject.SetActive(false);

//     // 等待一小段時間後刪除或者隱藏視覺上的表示
//     yield return new WaitForSeconds(0.5f);


//         // 刪除物品或者隱藏視覺上的表示
//         Destroy(itemObject);
//     }


           private void MoveItemToTargetPosition()
    {
        // 检查是否已到达目标位置
        if (Vector3.Distance(transform.position, targetPosition.position) > 0.1f)
        {
            // 计算物品朝向目标的方向
            Vector3 direction = (targetPosition.position - transform.position).normalized;

            // 移动物品
            transform.Translate(direction * movementSpeed * Time.deltaTime);
        }
        else
        {
            // 到达目标位置，停止移动
            isMoving = false;
            Destroy(gameObject);
        }
    }

    public void ResetItem()
    {
        // 重置物品狀態
        isCollected = false;
        // 啟用物品遊戲物件
        gameObject.SetActive(true);

        // 清除 PlayerPrefs 中的收集狀態
        PlayerPrefs.DeleteKey("IsCollected_" + thisItem.itemName);
        PlayerPrefs.Save();
    }

     private void OnApplicationQuit()
    {
        // 在游戏退出时将特定的PlayerPrefs值重置为0
        PlayerPrefs.SetInt("IsCollected_" + thisItem.itemName, 0);
        PlayerPrefs.Save();
    }


}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class itemOnworld : MonoBehaviour
// {
//    public item thisItem;
//    public Inventory playerInventory;

//   private void Update(){
//     check2DObjectClicked();
//   }
//    private void OnTriggerEnter2D(Collider2D other)
//    {
//     if(other.gameObject.CompareTag("Player")){
//         AddNewItem();
//         Destroy(gameObject);
//         Debug.Log("touch");
//     }  
//    } 
//    public void AddNewItem(){
//     if(!playerInventory.itemList.Contains(thisItem)){
//          //playerInventory.itemList.Add(thisItem);
//           //未刪CreateNewItem
//          //InventoryManager.CreateNewItem(thisItem);
//          for(int i=0;i<playerInventory.itemList.Count;i++){
//                 if(playerInventory.itemList[i]==null){
//                         playerInventory.itemList[i]=thisItem;
//                         Debug.Log(thisItem.itemID);
//                         break;
//                 }
//          }
//     }
//     else {
//         thisItem.itemHeild += 1;
//     }
//     InventoryManager.RefreshItem(); 
//    }

//    void check2DObjectClicked()
// {
//     if (Input.GetMouseButtonDown(0))
//     {
//         Debug.Log("Mouse is pressed down");
//         Camera cam = Camera.main;

//         //Raycast depends on camera projection mode
//         Vector2 origin = Vector2.zero;
//         Vector2 dir = Vector2.zero;

//         if (cam.orthographic)
//         {
//             origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//         }
//         else
//         {
//             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//             origin = ray.origin;
//             dir = ray.direction;
//         }

//         RaycastHit2D hit = Physics2D.Raycast(origin, dir);

//         //Check if we hit anything
//         if (hit)
//         {
            
          
//             if(hit.collider.name=="樹枝本人"){
             
//                 Debug.Log("We hit " + hit.collider.name);
//                 AddNewItem();
//                 Destroy(hit.collider);
//                  Destroy(gameObject);
//                 Debug.Log("touch");
//             }
//             if(hit.collider.name=="零件"){
             
//                 Debug.Log("We hit " + hit.collider.name);
//                 AddNewItem();
//                 Destroy(gameObject);
//                 Destroy(hit.collider);
//                 Debug.Log("touch零件");
//             }
             

//         }
//     } 
    
// }

// }
