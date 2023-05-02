// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.EventSystems;
// public class Drag : MonoBehaviour
// {
//    [SerializeField]
//    private Canvas canvas;
//    public void DragHandler(BaseEventData data){
//         PointerEventData pointerData=(PointerEventData) data;
//         Vector2 position;
//         RectTransformUtility.ScreenPointToLocalPointInRectangle(
//             (RectTransform)canvas.transform,
//             pointerData.position,
//             canvas.worldCamera,
//             out position);
//         transform.position=canvas.transform.TransformPoint(position);
//    }
// }
// using System;
// using DG.Tweening;
// using UnityEngine;
// using UnityEngine.EventSystems;
// using UnityEngine.UI;


// public class Drag : MonoBehaviour
// {
//     private Transform beginParentTransform; //记录开始拖动时的父级对象        
//     /// <summary>
//     /// UI界面的顶层，这里我用的是 Canvas
//     /// (这个变量在开发中设置到单例中较好，不然每一个物品都会初始化查找
//     /// GameObject.Find("Canvas").transform;)
//     /// </summary>
//     private Transform topOfUiT;


//     void Start()
//     {
//         topOfUiT = GameObject.Find("Canvas").transform;
//     }


//     /// <summary>
//     /// 开始拖动时
//     /// </summary>
//     public void Begin(BaseEventData data)
//     {
//         if (transform.parent == topOfUiT) return;
//         beginParentTransform = transform.parent;
//         transform.SetParent(topOfUiT);
//     }


//     /// <summary>
//     /// 拖动中
//     /// </summary>
//     /// <param name="_">UI事件数据</param>
//     public void OnDrag(BaseEventData _)
//     {
//         transform.position = Input.mousePosition;
//         if (transform.GetComponent<Image>().raycastTarget) transform.GetComponent<Image>().raycastTarget = false;
//     }


//     /// <summary>
//     /// 结束时
//     /// </summary>
//     public void End(BaseEventData data)
//     {
//         PointerEventData _ = data as PointerEventData;
//         if (_ == null) return;
//         GameObject go = _.pointerCurrentRaycast.gameObject;
//         if (go.tag == "Grid") //如果当前拖动物体下是：格子 -（没有物品）时
//         {
//             SetPosAndParent(transform, go.transform);
//             transform.GetComponent<Image>().raycastTarget = true;
//         }
//         else if (go.tag == "Good") //如果是物品
//         {
//             SetPosAndParent(transform, go.transform.parent);                              //将当前拖动物品设置到目标位置
//             go.transform.SetParent(topOfUiT);                                             //目标物品设置到 UI 顶层
//             if (Math.Abs(go.transform.position.x - beginParentTransform.position.x) <= 0) //以下 执行置换动画，完成位置互换 （关于数据的交换，根据自己的工程情况，在下边实现）
//             {
//                 go.transform.DOMoveY(beginParentTransform.position.y, 0.3f).OnComplete(() =>
//                 {
//                     go.transform.SetParent(beginParentTransform);
//                     transform.GetComponent<Image>().raycastTarget = true;
//                 }).SetEase(Ease.InOutQuint);
//             }
//             else
//             {
//                 go.transform.DOMoveX(beginParentTransform.position.x, 0.2f).OnComplete(() =>
//                 {
//                     go.transform.DOMoveY(beginParentTransform.position.y, 0.3f).OnComplete(() =>
//                     {
//                         go.transform.SetParent(beginParentTransform);
//                         transform.GetComponent<Image>().raycastTarget = true;
//                     }).SetEase(Ease.InOutQuint);
//                 });
//             }
//         }
//         else //其他任何情况，物体回归原始位置
//         {
//             SetPosAndParent(transform, beginParentTransform);
//             transform.GetComponent<Image>().raycastTarget = true;
//         }
//     }


//     /// <summary>
//     /// 设置父物体，UI位置归正
//     /// </summary>
//     /// <param name="t">对象Transform</param>
//     /// <param name="parent">要设置到的父级</param>
//     private void SetPosAndParent(Transform t, Transform parent)
//     {
//         t.SetParent(parent);
//         t.position = parent.position;
//     }
// }
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Drag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, ICanvasRaycastFilter
{
    private Transform nowparent;//记录原始坐标位置
    private bool isRaycastLocationValid = true;//默认射线不能穿透物体
    public Transform IconList;
    /// <summary>
    /// 开始拖拽
    /// </summary>
    public void OnBeginDrag(PointerEventData eventData)
    {
        this.transform.SetAsLastSibling();
//1.SetAsFirstSibling();
 
//2.SetAsLastSibling();
 
//3.SetSiblingIndex(n)
 
//SetAsFirstSibling()是设置为最先渲染的，即会被后渲染的挡住。
 
//SetAsLastSibling();是设置为最后渲染的，即会挡住比他先渲染的
 
//SetSiblingIndex(n)是设置层级，从0开始到childcount -1
 
//当n为0时，其效果与SetAsFirstSibling();相同
 
//但是当层级小于0时，其效果与SetAsLastSibling()一致
 
//当层级为大于等于transform.parent.childCount - 1时，其效果与SetAsLastSibling一致
        nowparent =this.transform.parent;//初始位置
        isRaycastLocationValid = false;//设置为可以穿透
        transform.SetParent(IconList);//将当前拖拽的物品放在最外层下 效果：可以挡住随意UI 避免呗其他UI挡住
    }
    /// <summary>
    /// UI跟随 鼠标
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }
    /// <summary>
    /// 拖拽结束
    /// </summary>
    public void OnEndDrag(PointerEventData eventData)
    {
         //获取鼠标终点位置可能存在的物品
         GameObject go = eventData.pointerCurrentRaycast.gameObject;
        if (go != null)//落点位置不为空
        {
            Debug.Log(go.name);//打印一下落点位置名称
            if (go.tag == ("Gird"))//鼠标终点位置是空格子
            {
                Debug.Log("空格子");
                SetParentAndPosition(transform, go.transform);
                Debug.Log("123");
            }
            else if (go.tag == transform.tag)//标签相同 放回
            {
                //将拖拽的物品1放到鼠标终点下的位置
                SetParentAndPosition(transform, go.transform);
            }
            else//无效位置，物品回到原来的位置
            {
                SetParentAndPosition(transform, nowparent);
            }
        }
        else
        {
            SetParentAndPosition(transform, nowparent);
        }
        isRaycastLocationValid = true;//射线不可以穿透物体
    }
    // 将child放到parent下做其子物体
    private void SetParentAndPosition(Transform child, Transform parent)
    {
        child.SetParent(parent);
        child.position = parent.position;//子物体的坐标跟随父物体
    }
    public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
    {
        return isRaycastLocationValid;
    }
}