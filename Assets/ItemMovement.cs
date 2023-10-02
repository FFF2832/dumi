using UnityEngine;

public class ItemMovement : MonoBehaviour
{
    public Transform targetPosition;  // 包包位置

    public float animationDuration = 1.0f;  // 动画持续时间

    private Vector3 initialPosition;  // 物品初始位置
    private float elapsedTime = 0.0f;  // 已经过的时间

    private bool isMoving = false;  // 是否正在移动

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        // 触发动画
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartAnimation();
        }

        // 执行动画
        if (isMoving)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime < animationDuration)
            {
                float t = elapsedTime / animationDuration;
                transform.position = Vector3.Lerp(initialPosition, targetPosition.position, t);
            }
            else
            {
                // 动画结束，将物品置于包包位置
                transform.position = targetPosition.position;
                isMoving = false;
            }
        }
    }

    void StartAnimation()
    {
        isMoving = true;
        elapsedTime = 0.0f;
    }
}
