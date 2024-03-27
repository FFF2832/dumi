
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections; // 用于协程的命名空间
using UnityEngine.UI;
public class bottleContent : MonoBehaviour, IPointerClickHandler
{

   public RectTransform targetPosition; // 引用Canvas中的目标位置
    public float moveSpeed = 2.0f; // 移动速度
    public float shrinkSpeed = 0.1f;
       public Image itemImage; // 引用UI物品的Image组件
    public Sprite newSprite; // 要设置的新Sprite

    public float initialScaleFactor = 0.2f; // 指定的初始缩放倍数

    private Vector3 originalScale;
    public  bool isCollected;
    public Animator animator;
    
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
    
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("點擊了UI物品：" + name);
        // 在這裡添加你想要的點擊功能邏輯
        originalScale = transform.localScale;
        animator.enabled = false;
        // 设置初始缩放
        transform.localScale = originalScale * initialScaleFactor;
        AddNewItem();
        // 更改UI物品的Image组件的Sprite
        if (itemImage != null && newSprite != null)
        {
            itemImage.sprite = newSprite;
        }
        // 启动协程，实现平滑移动
        StartCoroutine(MoveToTargetPosition(targetPosition.position));
        // Destroy(gameObject); // 刪除點擊完的物品
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
    public item thisItem;
   public Inventory playerInventory;
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
        thisItem.itemHeild += 1;
    }
    InventoryManager.RefreshItem(); 
    
   }
}