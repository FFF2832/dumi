using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
 public ParticleSystem clickEffect; // 用于保存粒子系统对象

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 检测鼠标左键是否按下
        {
            // 获取鼠标点击的位置
            Vector3 clickPosition = Input.mousePosition;
            clickPosition.z = 10; // 将 z 坐标设置为 10，使粒子系统在摄像机前方

            // 将粒子系统位置设置为鼠标点击的位置
            clickEffect.transform.position = Camera.main.ScreenToWorldPoint(clickPosition);

            // 播放粒子效果
            clickEffect.Play();
        }
    }
}
