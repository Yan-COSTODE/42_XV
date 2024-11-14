using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CircleUI : MonoBehaviour
{
    [SerializeField] private GameObject circlePrefab;
    [SerializeField, Range(0, 500)] private float fRadius = 100.0f;
    [SerializeField, Range(1.0f, 2.0f)] private float fOvalMultiplier = 1.2f;
    [SerializeField] private GameObject inputPrefab;
    [SerializeField] private UIColorPicker colorPickerPrefab;
    private float fScaleDuration = 0.2f;
    private float fWaitDuration = 0.1f;
    private bool bOpened = false;
    private Model model;
    private Vector2 mouse;
    private GameObject menu;

    private void Update()
    {
        if (!bOpened && !menu)
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
        
        StartCoroutine(Setup(_count));
    }

    private IEnumerator Setup(int _circleCount)
    {
        float _angleStep = 360.0f / _circleCount;
        mouse = Input.mousePosition;
        
        yield return SetupChild(0, mouse, mouse, model.Name);
        SetChildStatus(0, false);
        
        for (int i = 0; i < _circleCount; i++)
        {
            float _angle = _angleStep * -i + 45;
            float _angleRad = _angle * Mathf.Deg2Rad;
            Vector2 _position = new Vector2(Mathf.Cos(_angleRad) * fRadius * fOvalMultiplier, Mathf.Sin(_angleRad) * fRadius);

            switch (i)
            {
                case 0: yield return SetupChild(i + 1, mouse, _position + mouse, "Rename", Rename); 
                    break;
                case 1: yield return SetupChild(i + 1, mouse, _position + mouse, "Move", Move); 
                    break;
                case 2: yield return SetupChild(i + 1, mouse, _position + mouse, "Rotate", Rotate); 
                    break;
                case 3: yield return SetupChild(i + 1, mouse, _position + mouse, "Destroy", Destroy); 
                    break;
                case 4: yield return SetupChild(i + 1, mouse, _position + mouse, "Colorize", Colorize); 
                    break;
            }
        }

        bOpened = true;
    }

    private void SetChildStatus(int _index, bool _status)
    {
        if (_index >= transform.childCount)
            return;
        
        GameObject _circle = transform.GetChild(_index).gameObject;
        _circle.GetComponent<UIMouseOverScale>().SetActive(_status);
        _circle.GetComponentInChildren<Button>().interactable = _status;
    }
    
    private IEnumerator SetupChild(int _index, Vector3 _startPos, Vector3 _endPos, string _text, Action _onClicked = null)
    {
        GameObject _child = Instantiate(circlePrefab, transform);
        _child.name = _text;
        _child.transform.position = _startPos;
        _child.GetComponent<RectTransform>().TweenPosition(_startPos, _endPos, fScaleDuration, EEasing.EASE_OUT_QUAD);
        _child.GetComponentInChildren<TMP_Text>().text = _text;
        Button _button = _child.GetComponentInChildren<Button>();
        _button.onClick.RemoveAllListeners();
        _button.onClick.AddListener(() => _onClicked?.Invoke());
        UIMouseOverScale _childScale = _child.AddComponent<UIMouseOverScale>();
        _childScale.ManualScale(Vector3.zero, Vector3.one, fScaleDuration, EEasing.EASE_OUT_QUAD);
        SetChildStatus(_index, true);
        yield return new WaitForSeconds(fWaitDuration);
    }
    
    private IEnumerator Close()
    {
        bOpened = false;
        
        yield return new WaitForSeconds(fWaitDuration);
        
        if (transform.childCount == 0)
            yield return CloseMenu();
        
        for (int i = 1; i < transform.childCount; i++)
            yield return CloseChild(transform.childCount - 1);

        if (transform.childCount > 0)
            yield return CloseChild(0);
        
        ClearTransform();
        model = null;
    }

    private IEnumerator CloseChild(int _index)
    {
        GameObject _circle = transform.GetChild(_index).gameObject;
        _circle.GetComponent<RectTransform>().TweenPosition(_circle.transform.position, mouse, fScaleDuration, EEasing.EASE_IN_QUAD);
        _circle.GetComponent<UIMouseOverScale>().ManualScale(Vector3.one, Vector3.zero, fScaleDuration, EEasing.EASE_IN_QUAD);
        Destroy(_circle, fWaitDuration);
        yield return new WaitForSeconds(fWaitDuration);
    }

    private IEnumerator CloseMenu()
    {
        if (!menu)
            yield break;
        
        menu.GetComponent<RectTransform>().TweenPosition(menu.transform.position, mouse, fScaleDuration, EEasing.EASE_IN_QUAD);
        
        if (menu.TryGetComponent(out UIMouseOverScale _childScale))
            _childScale.ManualScale(Vector3.one, Vector3.zero, fScaleDuration, EEasing.EASE_IN_QUAD);
        
        Destroy(menu, fWaitDuration);
        menu = null;
        yield return new WaitForSeconds(fWaitDuration);
    }
    
    private void ClearTransform()
    {
        for (int i = 0; i < transform.childCount; i++)
            Destroy(transform.GetChild(i).gameObject);
    }

    private void Rename()
    {
        model.Rename(Random.Range(-1000, 1000).ToString());
    }

    private void Move()
    {
        model.transform.position += Vector3.right;
    }

    private void Rotate()
    {
        model.transform.rotation *= Quaternion.Euler(Vector3.up * Random.Range(-360, 360));
    }

    private void Destroy()
    {
        Destroy(model.gameObject);
    }

    private void Colorize()
    {
        UIColorPicker _colorPicker = Instantiate(colorPickerPrefab, mouse, Quaternion.identity, transform.parent);
        _colorPicker.Setup(model.gameObject);
        menu = _colorPicker.gameObject;
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