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
        originalScale = Vector3.one;
    }

    private void Update()
    {
        if (!bIsActive)
            return;
        
        if (bIsScaledUp && !IsPointerOver())
            OnPointerExit(null);
    }

    public void SetDuration(float _duration) => fDuration = _duration;
    
    public void Reset()
    {
        if (!rectTransform)
            return;
        
        rectTransform.localScale = originalScale;
    }

    public void ManualScale(Vector3 _from, Vector3 _to, float _duration, EEasing _easing)
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        originalScale = _to;
        
        if (rectTransform)
            rectTransform.TweenScale(_from, _to, _duration, _easing);
    }
    
    public void OnPointerEnter(PointerEventData _eventData)
    {
        if (!bIsActive || bIsTweening)
            return;

        if (TryGetComponent<Button>(out Button _button))
            if (!_button.interactable)
                return;
        
        rectTransform.TweenScale(originalScale, originalScale * fScale, fDuration, easingUp, () => bIsTweening = false);
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
        bIsTweening = true;
        rectTransform.TweenScale(originalScale * fScale, originalScale, fDuration, easingDown, () => bIsTweening = false);
    }

    public void SetActive(bool _status) => bIsActive = _status;
    
    private bool IsPointerOver()
    {
        Vector2 _pos = rectTransform.InverseTransformPoint(Input.mousePosition);
        return rectTransform.rect.Contains(_pos);
    }
    #endregion
}
