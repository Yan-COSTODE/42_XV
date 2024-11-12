using System;
using System.Collections;
using UnityEngine;

public class CircleUI : MonoBehaviour
{
    [SerializeField] private GameObject circlePrefab;
    [SerializeField, Range(0, 500)] private float fRadius = 100.0f;
    private float fNormalDuration = 0.5f;
    private float fScaleDuration = 0.2f;
    private float fWaitDuration = 0.1f;
    private bool bOpened = false;
    private Model model;

    private void Update()
    {
        if (!bOpened)
            return;
        
        if (Input.GetMouseButtonDown(0))
            StartCoroutine(Close());
    }

    public void Open(Model _model)
    {
        ClearTransform();
        
        model = _model;
        int _count = 5;
        
        if (_model.Carryable)
            _count++;
        if (_model.CarryableDrive)
            _count++;
        if (_model.Drivable)
            _count++;
        
        StartCoroutine(Setup(_count, Input.mousePosition));
    }

    private IEnumerator Setup(int _circleCount, Vector2 _mouse)
    {
        float _angleStep = 360.0f / _circleCount;

        yield return new WaitForSeconds(fWaitDuration);
        GameObject _middle = Instantiate(circlePrefab, transform);
        _middle.transform.position = _mouse;
        UIMouseOverScale _middleScale = _middle.AddComponent<UIMouseOverScale>();
        _middleScale.ManualScale(Vector3.zero, Vector3.one, fScaleDuration, EEasing.EASE_IN_QUAD);
        _middleScale.SetActive(false);
        
        for (int i = 0; i < _circleCount; i++)
        {
            float _angle = _angleStep * -i;
            float _angleRad = _angle * Mathf.Deg2Rad;
            Vector2 _position = new Vector2(Mathf.Cos(_angleRad) * fRadius, Mathf.Sin(_angleRad) * fRadius);
            GameObject _circle = Instantiate(circlePrefab, transform);
            _circle.transform.position = _position + _mouse;
            UIMouseOverScale _scale = _circle.AddComponent<UIMouseOverScale>();
            _scale.ManualScale(Vector3.zero, Vector3.one, fScaleDuration, EEasing.EASE_IN_QUAD);
            _scale.SetDuration(fNormalDuration);
            yield return new WaitForSeconds(fWaitDuration);
        }

        bOpened = true;
    }
    
    private IEnumerator Close()
    {
        bOpened = false;
        
        for (int i = 1; i < transform.childCount; i++)
        {
            GameObject _circle = transform.GetChild(transform.childCount - 1).gameObject;
            _circle.GetComponent<UIMouseOverScale>().ManualScale(Vector3.one, Vector3.zero, fScaleDuration / 2.0f, EEasing.EASE_IN_QUAD);
            Destroy(_circle, fWaitDuration);
            yield return new WaitForSeconds(fWaitDuration / 2.0f);
        }

        if (transform.childCount > 0)
        {
            GameObject _middle = transform.GetChild(0).gameObject;
            _middle.GetComponent<UIMouseOverScale>().ManualScale(Vector3.one, Vector3.zero, fScaleDuration / 2.0f, EEasing.EASE_IN_QUAD);
            Destroy(_middle, fWaitDuration);
            yield return new WaitForSeconds(fWaitDuration / 2.0f);
        }
        
        ClearTransform();
        model = null;
    }

    private void ClearTransform()
    {
        for (int i = 0; i < transform.childCount; i++)
            Destroy(transform.GetChild(i).gameObject);
    }

    private void Rename()
    {
        
    }

    private void Move()
    {
        
    }

    private void Rotate()
    {
        
    }

    private void Destroy()
    {
        
    }

    private void Colorize()
    {
        
    }

    private void Carry()
    {
        
    }

    private void CarryDrive()
    {
        
    }
    
    private void Drive()
    {
        
    }
}
