using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class EnterKey : MonoBehaviour
{
    public GameObject[] slot;//密码格子数组
    string password;//正确密码
    public string inputPassword;//输入密码
    // Start is called before the first frame update
    void Start()
    {
        password = "123";
    }
    /// <summary>
    /// 检查密码方法
    /// </summary>
    public void CheckPass()
{
    // 檢查 slot 是否為 null 或長度為 0
    if (slot == null || slot.Length == 0)
    {
        Debug.LogError("slot 陣列為 null 或長度為 0");
        return;
    }

    // 將每個密碼格子中的數字拼接成字符串，然後判斷下
    inputPassword = ""; // 重置輸入密碼
    for (int i = 0; i < slot.Length; i++)
    {
        // 檢查每個 slot 是否為 null
        if (slot[i] == null)
        {
            Debug.LogError("slot 中的元素為 null");
            return;
        }

        // 檢查每個 slot 是否有 NumMove 組件
        NumMove numMoveComponent = slot[i].GetComponent<NumMove>();
        if (numMoveComponent == null)
        {
            Debug.LogError("slot 中的元素缺少 NumMove 組件");
            return;
        }

        inputPassword = inputPassword + numMoveComponent.Num;
        Debug.Log("inputPassword"+inputPassword);
    }

    if (inputPassword == password)
    {
        print("解鎖成功");
    }
    else
    {
        print("密碼錯誤");
        inputPassword = null;
    }
}

}