using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIButtonEffect : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField, Header("按下时移动的距离")]
    private float _downDistance = 5f;
    [SerializeField, Header("移动的持续时间：按下过程")]
    private float _downDuration = 0.2f;
    [SerializeField, Header("移动的持续时间：抬起过程")]
    private float _upDuration = 0.15f;

    private RectTransform _rectTransform;
    private Vector2 _originalPosition;

    void Start() {
        _originalPosition = GetComponent<RectTransform>().anchoredPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(MoveButtonCoroutine(-_downDistance, _downDuration));
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(MoveButtonCoroutine(_downDistance, _upDuration));
    }

    private IEnumerator MoveButtonCoroutine(float distance, float duration)
    {
        float timer = 0f;
        Vector2 targetPosition = _originalPosition + new Vector2(0,-distance);
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

    private void Awake() {
        _rectTransform = GetComponent<RectTransform>();
    }
}