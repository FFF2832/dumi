
//版本三
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;




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
     public static int positioncorrect;

    public static bool tire1ok;
    public static bool tire2ok;
    public static bool treeok;
    public static bool puzzle1ok;
    public static bool puzzle2ok;
     public static bool puzzle3ok;

    public static bool magicOk;
    public static bool keyCorrect;
    public static bool key_F3correct;
    public static bool key_F4correct;

    public bool ispuzzle1ok;


     public static bool[] itemCorrect;
    public static bool[] positionCorrect;

//放大
      private Vector3 originalScale; // 儲存原始尺寸
    private RectTransform rectTransform;

     private void Awake()
    {
        // 初始化陣列
        itemCorrect = new bool[20];
        positionCorrect = new bool[20];
        //放大
         originalScale = transform.localScale; // 儲存原始尺寸
       // rectTransform = GetComponent<RectTransform>();
    }
    
   


    public void OnBeginDrag(PointerEventData eventData)
    {
        
        
        this.transform.SetAsLastSibling();
        originalParent = transform.parent;
        transform.SetParent(transform.parent.parent);
        //跟隨鼠標
        transform.position = eventData.position;

          //放大物品
        //   rectTransform.localScale = originalScale * 1.2f; // 可以調整放大倍數



        //  if(eventData.pointerDrag.GetComponent<Image>().sprite.name == "1"){
        //     transform.localScale = originalScale * 6f; // 可以調整放大倍數
        //  }
        //  else if(eventData.pointerDrag.GetComponent<Image>().sprite.name == "2"){
        //     transform.localScale = originalScale * 6f; // 可以調整放大倍數
        //  }
        //   else if(eventData.pointerDrag.GetComponent<Image>().sprite.name == "3 (1)"){
        //     transform.localScale = originalScale * 6f; // 可以調整放大倍數
        //  }
     
        // transform.localScale = originalScale * 3f; // 可以調整放大倍數
    }
    public void OnDrag(PointerEventData eventData)
    {
       
        transform.position = eventData.position;
        

    
         if(eventData.pointerDrag.GetComponent<Image>().sprite.name == "1"){
            transform.localScale = originalScale * 7.8f; // 可以調整放大倍數
            Debug.Log("(1): " + targetTransform.name + ", position: " + eventData.position);
         }
         else if(eventData.pointerDrag.GetComponent<Image>().sprite.name == "2"){
            transform.localScale = originalScale * 8.3f; // 可以調整放大倍數
            Debug.Log("(2): " + targetTransform.name + ", position: " + eventData.position);
         }
         else if(eventData.pointerDrag.GetComponent<Image>().sprite.name == "3"){
            transform.localScale = originalScale * 9f; // 可以調整放大倍數
            Debug.Log("(3): " + targetTransform.name + ", position: " + eventData.position);
         }
        else if(eventData.pointerDrag.GetComponent<Image>().sprite.name == "樹枝本人"){
            transform.localScale = originalScale * 7f; // 可以調整放大倍數
            Debug.Log("(3): " + targetTransform.name + ", position: " + eventData.position);
         }
        else if(eventData.pointerDrag.GetComponent<Image>().sprite.name == "零件1"){
            transform.localScale = originalScale * 5f; // 可以調整放大倍數
            Debug.Log("(3): " + targetTransform.name + ", position: " + eventData.position);
         }
        else if(eventData.pointerDrag.GetComponent<Image>().sprite.name == "零件2"){
            transform.localScale = originalScale * 7f; // 可以調整放大倍數
            Debug.Log("(3): " + targetTransform.name + ", position: " + eventData.position);
         }
         else if(eventData.pointerDrag.GetComponent<Image>().sprite.name == "鹿頭_背包鑰匙F2"){
            transform.localScale = originalScale * 2f; // 可以調整放大倍數
            Debug.Log("(3): " + targetTransform.name + ", position: " + eventData.position);
         }
        else if(eventData.pointerDrag.GetComponent<Image>().sprite.name == "correctKey"){
            transform.localScale = originalScale * 2f; // 可以調整放大倍數
            Debug.Log("(3): " + targetTransform.name + ", position: " + eventData.position);
         }
        else if(eventData.pointerDrag.GetComponent<Image>().sprite.name == "鹿頭_背包鑰匙F1"){
            transform.localScale = originalScale * 2f; // 可以調整放大倍數
            Debug.Log("(3): " + targetTransform.name + ", position: " + eventData.position);
         }
        else if(eventData.pointerDrag.GetComponent<Image>().sprite.name == "鹿頭_背包鑰匙F4"){
            transform.localScale = originalScale * 2f; // 可以調整放大倍數
            Debug.Log("(3): " + targetTransform.name + ", position: " + eventData.position);
         }
        else if(eventData.pointerDrag.GetComponent<Image>().sprite.name == "key_F3"){
            transform.localScale = originalScale * 2f; // 可以調整放大倍數
            Debug.Log("(3): " + targetTransform.name + ", position: " + eventData.position);
         }
         else if(eventData.pointerDrag.GetComponent<Image>().sprite.name == "紙條_F左"){
            transform.localScale = originalScale * 7.8f; // 可以調整放大倍數
            Debug.Log("(3): " + targetTransform.name + ", position: " + eventData.position);
         }
        
        // // 放大物品
        // transform.localScale = originalScale * 3f; // 可以調整放大倍數
      
        //  float scaleMultiplier = 1.0f + eventData.delta.magnitude * 0.01f;
        // rectTransform.localScale = originalScale * scaleMultiplier;
        
    }
   
    public void OnEndDrag(PointerEventData eventData)
    {
        // correct = false;
        // 判斷是否碰撞到目標
        Vector2 localPoint;
        RectTransform targetRectTransform = targetTransform as RectTransform;



          // 還原物品尺寸
        transform.localScale = originalScale;

        
      
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
           // Destroy(gameObject);
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
           // Destroy(gameObject);
             } 
       
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
          //  Destroy(gameObject);
             }   
        
            else {
                correct=false;
            // 如果沒有碰撞到目標，將物體放回原來的位置
            transform.SetParent(originalParent);
            transform.position = originalParent.position;
        
            }
      }
    else if((eventData.pointerDrag.GetComponent<Image>().sprite.name == "1")){
        
        Debug.Log("find 1");
             itemCorrect[4]=true;
              itemcorrect=4;
            if(  positionCorrect[4]){
                    //Destroy(gameObject);
                    // transform.localScale = originalScale;
             }   
        
            else {
                correct=false;
            // 如果沒有碰撞到目標，將物體放回原來的位置
            transform.SetParent(originalParent);
            transform.position = originalParent.position;
        
            }
      }
       else if((eventData.pointerDrag.GetComponent<Image>().sprite.name == "2")){
             itemCorrect[5]=true;
              itemcorrect=5;
            if(  positionCorrect[5]){
                Destroy(gameObject);
             }   
        
            else {
                correct=false;
            // 如果沒有碰撞到目標，將物體放回原來的位置
            transform.SetParent(originalParent);
            transform.position = originalParent.position;
        
            }
      }
       else if((eventData.pointerDrag.GetComponent<Image>().sprite.name == "3")){
             itemCorrect[6]=true;
              itemcorrect=6;
            if(  positionCorrect[6]){
                Destroy(gameObject);
             }   
        
            else {
                correct=false;
            // 如果沒有碰撞到目標，將物體放回原來的位置
            transform.SetParent(originalParent);
            transform.position = originalParent.position;
        
            }
      }
        else if((eventData.pointerDrag.GetComponent<Image>().sprite.name == "magicPotion")){
             itemCorrect[7]=true;
              itemcorrect=7;
            if(  positionCorrect[7]){
                Destroy(gameObject);
             }   
        
            else {
                correct=false;
            // 如果沒有碰撞到目標，將物體放回原來的位置
            transform.SetParent(originalParent);
            transform.position = originalParent.position;
        
            }
      }
      
        else if((eventData.pointerDrag.GetComponent<Image>().sprite.name == "correctKey")){
             itemCorrect[8]=true;
              itemcorrect=8;
            if(  positionCorrect[8]){
                Destroy(gameObject);
             }   
        
            // else {
            //     correct=false;
            // // 如果沒有碰撞到目標，將物體放回原來的位置
            // transform.SetParent(originalParent);
            // transform.position = originalParent.position;
        
            // }
      }
       else if((eventData.pointerDrag.GetComponent<Image>().sprite.name == "鹿頭_背包鑰匙F2")){
             itemCorrect[9]=true;
              itemcorrect=9;
            if(  positionCorrect[9]){
                Destroy(gameObject);
             }   
            
        
      }
       else if((eventData.pointerDrag.GetComponent<Image>().sprite.name == "鹿頭_背包鑰匙F4")){
             itemCorrect[10]=true;
              itemcorrect=10;
            if(  positionCorrect[10]){
                Destroy(gameObject);
             }   
            
        
      }
      else  {
        correct=false;
            // 如果沒有碰撞到目標，將物體放回原來的位置
            transform.SetParent(originalParent);
            transform.position = originalParent.position;
            // Debug.Log("not on target");
            //  Debug.Log("correct"+correct);

      }
   
    }
        else
        {
              
              correct=false;
            // 如果沒有碰撞到目標，將物體放回原來的位置
            transform.SetParent(originalParent);
            transform.position = originalParent.position;
            // Debug.Log("not on target");
            //  Debug.Log("correct"+correct);
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
        Debug.Log("Target detected: " + targetTransform.name + ", position: " + targetTransform.position);
       // Debug.Log("Target detected: " + targetTransform.name + ", position: " + targetTransform.position);
        if(targetTransform.name =="collectitem_car"){
          
            positionCorrect[1]=true;
            //  positioncorrect=1;
        }
         else if(targetTransform.name =="輪胎"){
          
              positionCorrect[2]=true;
            //  positioncorrect=2;
        }
        else if(targetTransform.name =="輪胎2"){
          
              positionCorrect[3]=true;
            //  positioncorrect=3;
        }


         else if(targetTransform.name =="piece1_pos"){
          
              positionCorrect[4]=true;
            // positioncorrect=4;
        }
         else if(targetTransform.name =="piece2_pos"){
         
              positionCorrect[5]=true;
            // positioncorrect=5;
        }
         else if(targetTransform.name =="piece3_pos"){
           
              positionCorrect[6]=true;
          
        }
        else if(targetTransform.name =="Msbamboo"){
           
              positionCorrect[7]=true;
           
        }
         else if(targetTransform.name =="leftkeyspace"){
          
              positionCorrect[8]=true;
            
        }
        else if(targetTransform.name =="rightkeyspcae"){
              positionCorrect[9]=true;
           
        }
        else if(targetTransform.name =="heartkeyspcae"){
              positionCorrect[10]=true;
           
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
  //  Debug.Log("treeok: " + treeok);
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
   // Debug.Log("checktire1: " + tire1ok);
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
   // Debug.Log("checktire2: " + tire2ok);
    return tire2ok;
}

public static bool checkpuzzle1()
{
    if (positionCorrect[4] && itemCorrect[4])
        {
             PlayerPrefs.SetInt("puzzle1Pos",1);
            if (!puzzle1ok) // 增加判斷，只有在未完成拼圖時返回 true
            {
                puzzle1ok = true; // 將標誌設置為 true
                return true;
            }
        }
        return false; // 否則返回 false
}
public static bool checkpuzzle2()
{
    if (positionCorrect[5] && itemCorrect[5])
        {
             PlayerPrefs.SetInt("puzzle2Pos",1);
            if (!puzzle2ok) // 增加判斷，只有在未完成拼圖時返回 true
            {
                puzzle2ok = true; // 將標誌設置為 true
                return true;
            }
            
        }
        return false; // 否則返回 false
}
public static bool checkpuzzle3()
{
    // 檢查對應索引位置的值是否相等且不為 0
    if (positionCorrect[6]&& itemCorrect[6])
    {
        puzzle3ok = true;
        PlayerPrefs.SetInt("puzzle3Pos",1);
    }
    else
    {
        puzzle3ok = false;
    }
   // Debug.Log("checktire1: " + tire1ok);
    return puzzle3ok;
}

 public  bool checkpuzzle1ok()
{
    // 檢查對應索引位置的值是否相等且不為 0
    if (positionCorrect[4]&& itemCorrect[4])
    {
        puzzle1ok = true;
        
    }
    else
    {
        puzzle1ok = false;
    }
   // Debug.Log("checktire1: " + tire1ok);
    return puzzle1ok;
}

public static bool checkmagicOk()
{
    // 檢查對應索引位置的值是否相等且不為 0
    if (positionCorrect[7]&& itemCorrect[7])
    {
        magicOk = true;
    }
    else
    {
        magicOk = false;
    }
   // Debug.Log("checktire1: " + tire1ok);
    return magicOk;
}

public static bool checkkeyCorrect()
{
    // 檢查對應索引位置的值是否相等且不為 0
    if (positionCorrect[8]&& itemCorrect[8])
    {
        keyCorrect = true;
    }
    else
    {
        keyCorrect = false;
    }
   // Debug.Log("checktire1: " + tire1ok);
    return keyCorrect;
}
public static bool checkkey_F3correct()
{
    // 檢查對應索引位置的值是否相等且不為 0
    if (positionCorrect[9]&& itemCorrect[9])
    {
        key_F3correct = true;
    }
    else
    {
        key_F3correct = false;
    }
   // Debug.Log("checktire1: " + tire1ok);
    return key_F3correct;
}
public static bool checkkey_F4correct()
{
    // 檢查對應索引位置的值是否相等且不為 0
    if (positionCorrect[10]&& itemCorrect[10])
    {
        key_F4correct = true;
    }
    else
    {
        key_F4correct = false;
    }
   // Debug.Log("checktire1: " + tire1ok);
    return key_F4correct;
}
}
