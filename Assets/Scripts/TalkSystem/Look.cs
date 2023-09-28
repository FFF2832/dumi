using UnityEngine;

public class Look : MonoBehaviour
{
    public GameObject canvas;
    public Sprite imageToShow; // 要显示的图像

    private SpriteRenderer spriteRenderer;

    public Texture2D fingerCursorTexture; // 新增手指指针纹理
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
     private static bool ifUI;
    private void Start()
    {
        // 获取 SpriteRenderer 组件
        spriteRenderer = GetComponent<SpriteRenderer>();

        // 将图像附加到 SpriteRenderer 组件
        spriteRenderer.sprite = imageToShow;

        // 隐藏图像
        spriteRenderer.enabled = false;
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
                ifUI=true;
            }
        }
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