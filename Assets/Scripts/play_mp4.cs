using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class play_mp4 : MonoBehaviour
{
    public RawImage videoScreen; // 您的RawImage组件
    public VideoPlayer videoPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.Prepare();
        videoScreen.enabled = false;
        videoPlayer.loopPointReached += OnVideoEnd;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (additemChangeImage.isok())
    {
       videoScreen.enabled = true;
       videoPlayer.Play();
       Debug.Log("成功");
    }
    }
    void OnVideoEnd(VideoPlayer vp)
    {
        // 视频播放完成后的回调
        videoScreen.gameObject.SetActive(false); // 禁用RawImage
        // Destroy(videoScreen.gameObject); // 或者销毁RawImage游戏对象
    }
}
