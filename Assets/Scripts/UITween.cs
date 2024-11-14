using System;
using System.Collections;
using UnityEngine;

public static class UITween
{
    public static void TweenScale(this RectTransform _rectTransform, Vector3 _start, Vector3 _end, float _time, EEasing _easing, Action _onComplete = null)
    {
        _rectTransform.GetComponent<MonoBehaviour>().StartCoroutine(TweenScaleCoroutine(_rectTransform, _start, _end, _time, _easing, _onComplete));
    }

    private static IEnumerator TweenScaleCoroutine(RectTransform _rectTransform, Vector3 _start, Vector3 _end, float _time, EEasing _easing, Action _onComplete = null)
    {
        float _startTime = 0.0f;
        _rectTransform.localScale = _start;

        while (_startTime < _time)
        {
            float _ease = Easing.Ease(_startTime / _time, _easing);
            _rectTransform.localScale = Vector3.Lerp(_start, _end, _ease);
            _startTime += Time.deltaTime;
            yield return null;
        }
        
        _rectTransform.localScale = _end;
        _onComplete?.Invoke();
    }
    
    public static void TweenPosition(this RectTransform _rectTransform, Vector3 _start, Vector3 _end, float _time, EEasing _easing, Action _onComplete = null)
    {
        _rectTransform.GetComponent<MonoBehaviour>().StartCoroutine(TweenPositionCoroutine(_rectTransform, _start, _end, _time, _easing, _onComplete));
    }

    private static IEnumerator TweenPositionCoroutine(RectTransform _rectTransform, Vector3 _start, Vector3 _end, float _time, EEasing _easing, Action _onComplete = null)
    {
        float _startTime = 0.0f;
        _rectTransform.position = _start;
        
        while (_startTime < _time)
        {
            float _ease = Easing.Ease(_startTime / _time, _easing);
            _rectTransform.position = Vector3.Lerp(_start, _end, _ease);
            _startTime += Time.deltaTime;
            yield return null;
        }
        
        _rectTransform.position = _end;
        _onComplete?.Invoke();
    }
}
