using UnityEngine;

public class Look : MonoBehaviour
{
    public Sprite imageToShow; // 要显示的图像

    private SpriteRenderer spriteRenderer;

    public Texture2D fingerCursorTexture; // 新增手指指针纹理
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

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

    // void OnMouseEnter()
    // {
    //     Debug.Log("HOVER");
    //     Cursor.SetCursor(fingerCursorTexture, hotSpot, cursorMode); // 使用手指指针纹理
    
    // }

    // void OnMouseExit()
    // {
    //     // Pass 'null' to the texture parameter to use the default system cursor.
    //     Cursor.SetCursor(null, Vector2.zero, cursorMode);
    // }
}