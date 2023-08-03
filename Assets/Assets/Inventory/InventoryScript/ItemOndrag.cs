
//版本三
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//版本四
// public class ItemOndrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
// {
//     public Transform originalParent;
//     public Transform correctParent;
//     private bool isDragging = false;
//     private Vector2 offset;
//     private Transform targetTransform;

//好像也沒用的何小姐版本
// public class ItemOndrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
// {
//     //
//     public Transform originalParent;
//     public Transform correctParent;
//     private bool isDragging = false;
//     //偏移量
//     private Vector3 offset;
//     private Transform targetTransform;
//     private Transform anchor;
//     public Inventory myBag;
//     private int currentItemID;
//     // private Image changeImage;
     
  
//     public static bool correct;
//     public void OnBeginDrag(PointerEventData eventData)
//     {
//         this.transform.SetAsLastSibling();
//         originalParent = transform.parent;
//         currentItemID=originalParent.GetComponent<slot>().slotID;
//         transform.SetParent(transform.parent.parent);
//         //跟隨鼠標
//         transform.position = eventData.position;
//     }

//     public void OnDrag(PointerEventData eventData)
//     {
//         //跟隨鼠標
//         transform.position = eventData.position;
//     }

//     public void OnEndDrag(PointerEventData eventData)
//     {
//         correct = false;
//         // 判斷是否碰撞到目標
//         Vector2 localPoint;
//         RectTransform targetRectTransform = targetTransform as RectTransform;
// //
// var temp=myBag.itemList[currentItemID];
// myBag.itemList[currentItemID]=myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponent<slot>().slotID];
        
//         if (targetRectTransform != null &&
//     RectTransformUtility.ScreenPointToLocalPointInRectangle(
//         targetRectTransform,
//         eventData.position,
//         eventData.pressEventCamera,
//         out localPoint))
   
// {
//     Debug.Log(myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponent<item>().itemID]);
//      // 计算偏移量
//     //offset = transform.localPosition - anchor.localPosition;
//     // 如果碰撞到了目標，將物體吸附到目標上
//     // transform.SetParent(correctParent);
//     // transform.localPosition = anchor.localPosition + offset;
//     //
//     transform.SetParent(correctParent);
//     transform.localPosition = targetTransform.localPosition; // 将拖曳物体设置到目标物体的位置上
//      //GetComponent<Image>().sprite = newSprite;
//       Debug.Log("on target");
//     Debug.Log("correct"+correct);
//      correct=true;
//    Destroy(gameObject);
// }
//         else
//         {
              
//               correct=false;
//             // 如果沒有碰撞到目標，將物體放回原來的位置
//             transform.SetParent(originalParent);
//             transform.position = originalParent.position;
//             Debug.Log("not on target");
//              Debug.Log("correct"+correct);
//         }
//     }

//     private void OnTriggerEnter2D(Collider2D collision)
//     {
//        if (collision.tag == "Target")
//     {
       
//         targetTransform = collision.transform;
//         anchor = targetTransform.Find("Anchor");
//         Debug.Log("Target detected: " + targetTransform.name + ", position: " + targetTransform.position);
//     }
//     }

//     private void OnTriggerExit2D(Collider2D collision)
//     {
//         if (collision.tag == "Target")
//     {
//          //correct=false;
//         targetTransform = null;
//         anchor = null;
//     }
//     }
//     public static bool checkTarget() // 宣告為靜態方法，回傳靜態變數 Check
//     {
//         return correct;
//     }
// }



public class ItemOndrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //
    public Transform originalParent;
    public Transform correctParent;
    private bool isDragging = false;
    //偏移量
    private Vector3 offset;
    private Transform targetTransform;
    private Transform anchor;
    // private Image changeImage;
      public item thisItem;
   public Inventory myBag;
    public static bool ok;
    public itemOnworld itemonworld;
 
    
    
    public static bool correct;
     public static int itemcorrect;
    // public static int positioncorrect;

    public static bool tire1ok;
    public static bool tire2ok;
    public static bool treeok;

     public static bool[] itemCorrect;
    public static bool[] positionCorrect;



     private void Awake()
    {
        // 初始化陣列
        itemCorrect = new bool[4];
        positionCorrect = new bool[4];
    }
    //  public changeImage changeImageScript;
   

//    void Start()
//     {
//         // 在 Start 方法中初始化 changeImage 物件的參考
//         changeImageScript = GameObject.FindObjectOfType<changeImage>();
//         if (changeImageScript == null)
//         {
//             Debug.LogError("changeImage component not found!");
//         }
//     }
    public void OnBeginDrag(PointerEventData eventData)
    {
        
        
        this.transform.SetAsLastSibling();
        originalParent = transform.parent;
        transform.SetParent(transform.parent.parent);
        //跟隨鼠標
        transform.position = eventData.position;
    }
    public void OnDrag(PointerEventData eventData)
    {
        //跟隨鼠標
        // GameObject draggedItem = eventData.pointerDrag;
        // item itemData = draggedItem.GetComponent<item>();
        transform.position = eventData.position;
        //itemImage
        // Debug.Log(eventData.pointerCurrentRaycast.gameObject);
      
       
        
    }
   
    public void OnEndDrag(PointerEventData eventData)
    {
        // correct = false;
        // 判斷是否碰撞到目標
        Vector2 localPoint;
        RectTransform targetRectTransform = targetTransform as RectTransform;
        
        //放在正確的位置上
        if (targetRectTransform != null &&
    RectTransformUtility.ScreenPointToLocalPointInRectangle(
        targetRectTransform,
        eventData.position,
        eventData.pressEventCamera,
        out localPoint))
        {
        // Debug.Log(thisItem.itemID);
        transform.SetParent(correctParent);
        transform.localPosition = targetTransform.localPosition; // 将拖曳物体设置到目标物体的位置上
   
         itemCorrect[0]=false;
        positionCorrect[0]=false;
      //用圖片找
      if(eventData.pointerDrag.GetComponent<Image>().sprite.name == "樹枝本人"){
          
       

        itemcorrect=1;

        itemCorrect[1]=true;
            if(  positionCorrect[1]){
            Destroy(gameObject);
             }

        // if(positioncorrect==1){
        //    // correct=true;
        //       Destroy(gameObject);

        //     }
            else {
            correct=false;
            // 如果沒有碰撞到目標，將物體放回原來的位置
            transform.SetParent(originalParent);
            transform.position = originalParent.position;
        
            }
      
      }
      //太陽零件對應到輪胎1
      else if((eventData.pointerDrag.GetComponent<Image>().sprite.name == "零件1")){

         itemCorrect[2]=true;
        itemcorrect=2;
            if(  positionCorrect[2]){
            Destroy(gameObject);
             } 
         
        //      if(positioncorrect==2){
        //    // correct=true;
        //       Destroy(gameObject);
            
        //     }
            else {
                correct=false;
            // 如果沒有碰撞到目標，將物體放回原來的位置
            transform.SetParent(originalParent);
            transform.position = originalParent.position;
        
            }
      }
      else if((eventData.pointerDrag.GetComponent<Image>().sprite.name == "零件2")){
             itemCorrect[3]=true;
              itemcorrect=3;
            if(  positionCorrect[3]){
            Destroy(gameObject);
             }   
           
        //      if(positioncorrect==3){
        //    // correct=true;
        //       Destroy(gameObject);
              
        //     }
        
            else {
                correct=false;
            // 如果沒有碰撞到目標，將物體放回原來的位置
            transform.SetParent(originalParent);
            transform.position = originalParent.position;
        
            }
      }
      else  {
        correct=false;
            // 如果沒有碰撞到目標，將物體放回原來的位置
            transform.SetParent(originalParent);
            transform.position = originalParent.position;
            Debug.Log("not on target");
             Debug.Log("correct"+correct);

      }
   
    }
        else
        {
              
              correct=false;
            // 如果沒有碰撞到目標，將物體放回原來的位置
            transform.SetParent(originalParent);
            transform.position = originalParent.position;
            Debug.Log("not on target");
             Debug.Log("correct"+correct);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.tag == "Target")
    {
        //correct=true;
        //Debug.Log("Trigger的correct"+correct);
        targetTransform = collision.transform;
        anchor = targetTransform.Find("Anchor");
       // Debug.Log("Target detected: " + targetTransform.name + ", position: " + targetTransform.position);
        if(targetTransform.name =="collectitem_car"){
            Debug.Log("Target detected: " + targetTransform.name + ", position: " + targetTransform.position);
            positionCorrect[1]=true;
            // positioncorrect=1;
        }
         else if(targetTransform.name =="輪胎"){
            Debug.Log("Target detected(true): " + targetTransform.name + ", position: " + targetTransform.position);
              positionCorrect[2]=true;
            // positioncorrect=2;
        }
        else if(targetTransform.name =="輪胎2"){
            Debug.Log("Target detected(true): " + targetTransform.name + ", position: " + targetTransform.position);
              positionCorrect[3]=true;
            // positioncorrect=3;
        }
    }
    else if (collision.tag == "TargetObject")
    {
        ok=true;
        targetTransform = collision.transform;
        anchor = targetTransform.Find("Anchor");
        Debug.Log("新的Target detected: " + targetTransform.name + ", position: " + targetTransform.position);
    }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Target")
    {
       // correct=true;
        targetTransform = null;
        anchor = null;
    }
          else if (collision.tag == "TargetObject")
    {
        ok=true;
        targetTransform = null;
        anchor = null;
    }
    }
    // public static bool checkTarget() // 宣告為靜態方法，回傳靜態變數 Check
    // {
    
    //     if(positioncorrect==itemcorrect&&positioncorrect!=0)correct=true;
    //     Debug.Log("correct:"+correct);
    //     return correct;
    // }


    public static bool checkTarget()
{
    // 檢查對應索引位置的值是否相等且不為 0
    if (positionCorrect[1] == itemCorrect[1] && positionCorrect[1])
    {
        correct = true;
    }
    else if (positionCorrect[2] == itemCorrect[2] && positionCorrect[2])
    {
        correct = true;
    }
    else if (positionCorrect[3] == itemCorrect[3] && positionCorrect[3])
    {
        correct = true;
    }
    else
    {
        correct = false;
    }
    Debug.Log("correct: " + correct);
    return correct;
}


        public static bool checkTarget2() // 宣告為靜態方法，回傳靜態變數 Check
    {
        return ok;
    } 
    // public static int checkPosition() // 宣告為靜態方法，回傳靜態變數 Check
    // {
    
    //     return positioncorrect;
    // }  

   
     public static int checkitemPosition() // 宣告為靜態方法，回傳靜態變數 Check
    {
    
        return itemcorrect;
    } 
    public static bool[] checkPositionCorrect() // 宣告為靜態方法，回傳靜態陣列 positionCorrect
    {
    return positionCorrect;
    }

    public static bool[] checkItemCorrect() // 宣告為靜態方法，回傳靜態陣列 itemCorrect
    {
    return itemCorrect;
    }
    
    
public static bool checktree()
{
    // 檢查對應索引位置的值是否相等且不為 0
    if (positionCorrect[1] &&itemCorrect[1])
    {
        treeok = true;
    }
    else
    {
        treeok = false;
    }
    Debug.Log("treeok: " + treeok);
    return treeok;
}
public static bool checktire1()
{
    // 檢查對應索引位置的值是否相等且不為 0
    if (positionCorrect[2]&& itemCorrect[2])
    {
        tire1ok = true;
    }
    else
    {
        tire1ok = false;
    }
    Debug.Log("checktire1: " + tire1ok);
    return tire1ok;
}
    
public static bool checktire2()
{
    // 檢查對應索引位置的值是否相等且不為 0
    if (positionCorrect[3] &&itemCorrect[3])
    {
        tire2ok = true;
    }
    else
    {
        tire2ok = false;
    }
    Debug.Log("checktire2: " + tire2ok);
    return tire2ok;
}

}
