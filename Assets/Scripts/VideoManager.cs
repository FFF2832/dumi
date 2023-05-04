using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
public VideoPlayer videoPlayer1;
    public VideoPlayer videoPlayer2;

    void Start()
    {
        // 播放第一個MP4
        videoPlayer1.Play();
    }

    void Update()
    {
        // 檢查第一個MP4是否已經播放完畢
        if (videoPlayer1.isPlaying && videoPlayer1.time >= videoPlayer1.length)
        {
            // 停止第一個MP4的播放
            videoPlayer1.Stop();
            
            // // 設置第二個MP4的URL
            // videoPlayer2.url = "file://path/to/second/video.mp4";
            
            // 循環播放第二個MP4
            videoPlayer2.isLooping = true;
            videoPlayer2.Play();
        }
    }
}
