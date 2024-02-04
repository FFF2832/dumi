using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ClickAndShowHide : MonoBehaviour
{
    public GameObject targetObject; // 要显示和隐藏的GameObject
    private bool isClicked = false;

    void Start(){
 targetObject.SetActive(false);
    }
    private void Update()
    {
       // 监听鼠标点击事件
        if (Input.GetMouseButtonDown(0))
        {
            // 通过射线检测点击位置是否在目标GameObject上
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                // 如果点击的是当前GameObject，则触发显示和隐藏操作
                if (!isClicked)
                {
                    ShowAndHideTargetObject();
                }
            }
        }
    }

    private void ShowAndHideTargetObject()
    {
        // 显示目标GameObject，使用DOTween实现缩放效果
        targetObject.transform.localScale = Vector3.zero;
        targetObject.SetActive(true);
 targetObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        targetObject.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);

        // 在两秒后调用自动隐藏的方法
        Invoke("HideTargetObject", 2f);

        // 将点击状态设置为true，防止重复触发
        isClicked = true;
    }

    private void HideTargetObject()
    {
        // // 隐藏目标GameObject，使用DOTween实现缩放效果
        // targetObject.transform.DOScale(Vector3.zero, 0.5f).OnComplete(() =>
        // {
        //     targetObject.SetActive(false);
        // });
              // 隐藏目标GameObject，使用DOTween实现透明度效果
        targetObject.GetComponent<SpriteRenderer>().DOFade(0f, 0.5f).OnComplete(() =>
        {
            targetObject.SetActive(false);
        });
        //  targetObject.SetActive(false);

        // 重置点击状态
        isClicked = false;
    }
}
