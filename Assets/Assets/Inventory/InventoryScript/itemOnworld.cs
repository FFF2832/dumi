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
    private void Start()
    {
    //     // 检查物体的销毁状态
    //    if (PlayerPrefs.GetInt("IsItemDestroy_" + gameObject.name, 0) == 1)
    //    {
    //        Destroy(gameObject);
    //        isDestroyed = true;
    //    }
        //sparkle.SetActive(true);
       
    }
  private void Update(){
    check2DObjectClicked();
     if (isMoving)
        {
          
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
   public void AddNewItem(item thisItem){
    if(!playerInventory.itemList.Contains(thisItem)){
         //playerInventory.itemList.Add(thisItem);
          //未刪CreateNewItem
         //InventoryManager.CreateNewItem(thisItem);
         for(int i=0;i<playerInventory.itemList.Count;i++){
                if(playerInventory.itemList[i]==null){
                        playerInventory.itemList[i]=thisItem;
                         // 開始移動動畫
                        // StartCoroutine(MoveItemToTargetPosition(itemObject));
                   
                        break;
                }
         }
    }
    else {
        thisItem.itemHeild += 1;
    }
    InventoryManager.RefreshItem(); 
   }

   void check2DObjectClicked()
{
    if (Input.GetMouseButtonDown(0))
    {
       // Debug.Log("Mouse is pressed down");
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
            if(hit.collider.name=="樹枝本人"){
             
                Debug.Log("We hit " + hit.collider.name);
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = moveSprite;
                animator.enabled = false;
                AddNewItem(thisItem);
                   isMoving = true;
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
               Debug.Log(" 2" );
                Debug.Log("We hit " + hit.collider.name);
                AddNewItem(thisItem);
                Destroy(hit.collider);
                Destroy(gameObject);
               
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
                // Destroy(hit.collider);
                // Destroy(gameObject);
    
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
       
        AddNewItem(thisItem);
       
        isMoving = true;

         Destroy(gameObject);
    }
  public  void correctKey(){
    if(keyChange.changekey_1){
        AddNewItem(thisItem);
         Destroy(gameObject);
    }
   
  }  
  public void wrongkey(){
         if(keyChange.changekey_2){
        AddNewItem(thisItem);
         Destroy(gameObject);
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
