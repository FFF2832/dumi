using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class VideoManager : MonoBehaviour
{
 public VideoPlayer videoPlayer;
    public VideoClip[] videoClips; // 要播放的视频数组
    private int currentClipIndex = 0; // 当前要播放的视频的索引

    void Start()
    {
        videoPlayer.loopPointReached += LoopPointReached;

        // 初始化视频Player，并预加载第一个视频
        videoPlayer.source = VideoSource.VideoClip;
        videoPlayer.clip = videoClips[currentClipIndex];
        videoPlayer.Prepare();
    }

    void LoopPointReached(VideoPlayer vp)
    {
        // 判断是否为最后一个视频，如果不是则切换到下一个视频
        if (currentClipIndex < videoClips.Length - 1)
        {
            currentClipIndex++;
            vp.clip = videoClips[currentClipIndex];
            vp.Prepare(); // 预加载下一个视频
        }
         else
        {
            // If it's the last video, switch to the next scene
            SwitchToNextScene();
            return;
        }

        vp.Play(); // 继续播放
    }
    void SwitchToNextScene()
    {
        // You can modify "YourNextSceneName" to the name of your next scene
        SceneManager.LoadScene("Scene Start");
    }
   
}
