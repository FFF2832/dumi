using UnityEngine;
using UnityEngine.EventSystems;

public class Musicbtn : MonoBehaviour, IPointerDownHandler
{
    public MusicManager musicManager; // 连接到MusicManager脚本
    private Animator animMusic;
    public int musicNumber;

    private void Start()
    {
        animMusic = GetComponent<Animator>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("musicNumber"+musicNumber);
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out localPoint);

        if (musicNumber == 1)
        {
            animMusic.SetInteger("music1Anim", 1);
            // Debug.Log("Animator component: " + animMusic); // 检查获取到的 Animator 组件
            // Debug.Log("设置 music1Anim 为 1");
        }

        if (musicNumber == 2)
        {
            animMusic.SetInteger("music1Anim", 1);
        }

        // animMusic.SetInteger("animMusic2", 1);
        // 当音乐被点击时调用MusicManager的MusicClicked函数
        musicManager.MusicClicked(gameObject);

        if (musicNumber == 3)
        {
            animMusic.SetInteger("music1Anim", 1);
        }

        if (musicNumber == 4)
        {
            animMusic.SetInteger("music1Anim", 1);
        }
    }
}
