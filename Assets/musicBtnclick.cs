using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class musicBtnclick : MonoBehaviour
{
    public AudioClip musicClip; // 音樂文件
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = musicClip;
    }

    public void PlayMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        Debug.Log("撥放音樂");
    }
}
