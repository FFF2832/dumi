using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonPress : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField, Header("按下时移动的距离")]
    private float _downDistance = 5f;
    [SerializeField, Header("移动的持续时间：按下过程")]
    private float _downDuration = 0.2f;
    [SerializeField, Header("移动的持续时间：抬起过程")]
    private float _upDuration = 0.15f;

    [SerializeField, Header("Audio Clip")]
    private AudioClip buttonPressSound;
    private AudioSource audioSource;

    private RectTransform _rectTransform;
    private Vector2 _originalPosition;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        audioSource = GetComponent<AudioSource>();
        // Ensure the AudioSource is not null and set to play on awake
        if (audioSource != null)
        {
            audioSource.playOnAwake = false;
            Debug.Log("去看吧");
        }
    }

    void Start()
    {
        _originalPosition = _rectTransform.anchoredPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(MoveButtonCoroutine(-_downDistance, _downDuration));

        if (audioSource != null && buttonPressSound != null)
        {
            audioSource.PlayOneShot(buttonPressSound);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(MoveButtonCoroutine(_downDistance, _upDuration));
    }

    private IEnumerator MoveButtonCoroutine(float distance, float duration)
    {
        float timer = 0f;
        Vector2 targetPosition = _originalPosition + new Vector2(0, distance);
        while (timer < duration)
        {
            _rectTransform.anchoredPosition = Vector2.Lerp(_originalPosition, targetPosition, timer / duration);
            timer += Time.deltaTime;
            yield return null;
        }
        _rectTransform.anchoredPosition = targetPosition;
    }

    private void OnDisable()
    {
        _rectTransform.anchoredPosition = _originalPosition;
    }
}
