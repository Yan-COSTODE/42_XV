using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIMouseOverScale : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private EEasing easingUp = EEasing.EASE_OUT_QUAD;
    [SerializeField] private EEasing easingDown = EEasing.EASE_IN_QUAD;
    [SerializeField, Range(0.0f, 10.0f)] private float fDuration = 1.0f;
    [SerializeField, Range(0.0f, 2.0f)] private float fScale = 1.1f;
    [SerializeField] private bool bIsActive = true;
    private Vector3 originalScale;
    private bool bIsTweening = false;
    private bool bIsScaledUp = false;
    private RectTransform rectTransform;
    
    #region Methods
    private void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        originalScale = transform.localScale;
    }

    private void Update()
    {
        if (!bIsActive)
            return;
        
        if (bIsScaledUp && !IsPointerOver())
            OnPointerExit(null);
    }

    public void Reset()
    {
        if (!rectTransform)
            return;
        
        rectTransform.localScale = originalScale;
    }
    
    public void OnPointerEnter(PointerEventData _eventData)
    {
        if (!bIsActive || bIsTweening)
            return;

        if (TryGetComponent<Button>(out Button _button))
            if (!_button.interactable)
                return;
        
        StartCoroutine(Tween(originalScale, originalScale * fScale, fDuration, easingUp));
        bIsScaledUp = true;
    }

    public void OnPointerExit(PointerEventData _eventData)
    {
        if (!bIsActive || bIsTweening)
            return;

        if (TryGetComponent<Button>(out Button _button))
            if (!_button.interactable && !bIsScaledUp)
                return;
        
        bIsScaledUp = false;
        StartCoroutine(Tween(originalScale * fScale, originalScale, fDuration, easingDown));
    }

    public void SetActive(bool _status) => bIsActive = _status;
    
    private bool IsPointerOver()
    {
        Vector2 _pos = rectTransform.InverseTransformPoint(Input.mousePosition);
        return rectTransform.rect.Contains(_pos);
    }
    
    private IEnumerator Tween(Vector3 _start, Vector3 _end, float _time, EEasing _easing)
    {
        if (!rectTransform)
            yield break;
        
        bIsTweening = true;
        float _startTime = Time.unscaledTime;

        while (Time.unscaledTime - _startTime < _time)
        {
            float _ease = Easing.Ease((Time.unscaledTime - _startTime) / _time, _easing);
            rectTransform.localScale = Vector3.Lerp(_start, _end, _ease);
            yield return null;
        }
        
        rectTransform.localScale = _end;
        bIsTweening = false;
    }
    #endregion
}
