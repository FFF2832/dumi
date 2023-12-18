using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class carAnim : MonoBehaviour
{
    


     public VideoPlayer videoPlayer;
    public Canvas videoCanvas; // 引用Canvas对象

    private bool videoPlaying = false;

   

    private void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += OnVideoEnd;
        videoPlayer.Pause(); // 确保视频在开始时暂停
        videoCanvas.enabled = false; // 初始时禁用Canvas
    }

    private void Update()
    {
        // 在这里添加您的条件检查逻辑
        // if (ItemOndrag.checkmagicOk() && !videoPlaying)
        // {
        //     PlayVideo();
        //     Debug.Log("Video played");
        // }
          if ((click.UpdateclickCar()) && !videoPlaying)
        {
        PlayVideo();
        Debug.Log("Video played");
        }
        // else if (click.UpdateclickCar2() && !videoPlaying)
        // {
        // PlayVideo();
        // Debug.Log("Video played");
        // }

      
    }

    private void PlayVideo()
    {
        videoPlaying = true;
        videoPlayer.Play();
        videoCanvas.enabled = true; // 在播放视频时启用Canvas
    }
    

    private void OnVideoEnd(VideoPlayer vp)

    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        // 视频播放结束时的处理
          videoCanvas.enabled = false; 
          Application.LoadLevel(3);
          //if(currentSceneName == "Scene night"&&click.UpdateclickCar())Application.LoadLevel(1);
        //    else if(currentSceneName == "SampleScene 1"&&click.UpdateclickCar2())Application.LoadLevel(3);
            // if (bambooTalk.UpdatefinishTalk() )SceneManager.LoadScene("Scene Clear_1");
          ///  videoPlaying = false;
    }

    // 添加您的条件检查函数
    private bool YourConditionIsMet()
    {
        // 返回true或false，根据您的条件
        return true;
    }

    

}
