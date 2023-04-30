using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enlarge : MonoBehaviour
{
    public GameObject canvas;

    void Start()
    {
        // 隐藏 Canvas
        canvas.SetActive(false);
    }

    void Update()
    {
        // 如果点击了鼠标左键
        if (Input.GetMouseButtonDown(0))
        {
            // 获取鼠标的位置
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // 获取被点击的物体的位置
            Vector2 objPos = transform.position;

            // 如果鼠标点击了这个物体
            if (mousePos.x >= objPos.x - 0.5f && mousePos.x <= objPos.x + 0.5f
                && mousePos.y >= objPos.y - 0.5f && mousePos.y <= objPos.y + 0.5f)
            {
                // 显示 Canvas
                canvas.SetActive(true);
            }
        }
    }
}
