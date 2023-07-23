using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class NumMove : MonoBehaviour
{
    public Transform moveObj;//要移动的物体
    public Transform upPos;
    public Transform startPos;
    public Transform downPos;
    Transform targetPos;//滚动的目标位置
    float moveSpeed;//滚动速度
    public bool isMove;//是否在滚动
    public Text middleText;
    public Text downText;
    public Text upText;
    public int Num;//用来计算当前格子中的数字
 
    private void Start()
    {
        moveSpeed = 5f;
        Num = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            moveObj.position = Vector3.Lerp(moveObj.position, targetPos.position, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(moveObj.position, targetPos.position)<0.5f)
            {
                //先让数字滚上去，然后改变文本中的数字，再归位回来
                moveObj.position = targetPos.position;
                isMove = false;
                middleText.text = Num.ToString();
                moveObj.position = startPos.position;
            }
        }
    }
    /// <summary>
    /// 上滚动方法
    /// </summary>
    public void PageUp()
    {
        if (!isMove)
        {
            Num += 1;
            if (Num>9)
            {
                Num = 0;
            }
        }
        targetPos = upPos;
        downText.text = Num.ToString();
        isMove = true;
    }
    /// <summary>
    /// 下滚动方法
    /// </summary>
    public void PageDown()
    {
        if (!isMove)
        {
            Num -= 1;
            if (Num<0)
            {
                Num = 9;
            }
        }
        targetPos = downPos;
        upText.text = Num.ToString();
        isMove = true;
    }
}