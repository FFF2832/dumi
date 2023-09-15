using UnityEngine;

public class BackgroundMusic: MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // 播放音樂
        audioSource.Play();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (audioSource.isPlaying)
            {
                // 暫停音樂
                audioSource.Pause();
            }
            else
            {
                // 繼續播放音樂
                audioSource.UnPause();
            }
        }
    }
}
