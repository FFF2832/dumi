using UnityEngine;

public class Look : MonoBehaviour
{
    public Sprite imageToShow; // 要显示的图像

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        // 获取 SpriteRenderer 组件
        spriteRenderer = GetComponent<SpriteRenderer>();

        // 将图像附加到 SpriteRenderer 组件
        spriteRenderer.sprite = imageToShow;

        // 隐藏图像
        spriteRenderer.enabled = false;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 当检测到接近时显示图像
        if (other.gameObject.CompareTag("Player"))
        {
            spriteRenderer.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // 当检测到离开时隐藏图像
        if (other.gameObject.CompareTag("Player"))
        {
            spriteRenderer.enabled = false;
        }
    }
}