using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayerPosition : MonoBehaviour
{
 void Start()
    {
        // 檢查PlayerPrefs中是否有保存的位置
        if (PlayerPrefs.HasKey("PlayerX") && PlayerPrefs.HasKey("PlayerY"))
        {
            float playerX = PlayerPrefs.GetFloat("PlayerX");
            float playerY = PlayerPrefs.GetFloat("PlayerY");

            // 將角色放置到保存的位置
            transform.position = new Vector2(playerX, playerY);
        }}
}
