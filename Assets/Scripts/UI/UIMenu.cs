using System;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private Button cameraButton;
    [SerializeField] private Button sceneButton;
    [SerializeField] private Button modelButton;
    [SerializeField] private Button recordButton;
    [SerializeField] private RectTransform bar;
    [SerializeField] private GameObject modelBar;
    private float fOpeningTime = 0.5f;
    private GameObject templateBar;

    private void Start()
    {
        cameraButton.onClick.AddListener(CameraClick);
        sceneButton.onClick.AddListener(SceneClick);
        modelButton.onClick.AddListener(ModelClick);
        recordButton.onClick.AddListener(RecordClick);
    }

    private void CameraClick()
    {
        CameraManager.Instance.Toggle();
    }

    private void SceneClick()
    {
        ToggleBar();
    }

    private void ModelClick()
    {
        ToggleBar(modelBar);
    }

    private void RecordClick()
    {
        ToggleBar();
    }

    private void ToggleBar(GameObject _templateBar = null)
    {
        if (templateBar)
            templateBar.SetActive(false);

        if (templateBar != _templateBar)
        {
            templateBar = _templateBar;
            
            if (templateBar)
                templateBar.SetActive(true);
            
            return;
        }
        
        templateBar = _templateBar;
        Vector3 _final = Vector3.one;
        _final.x = 0;
        
        switch (bar.localScale.x)
        {
            case 0: bar.TweenScale(_final, Vector3.one, fOpeningTime, EEasing.EASE_OUT_QUAD, SetTemplateBar);
                break;
            case 1: bar.TweenScale(Vector3.one, _final, fOpeningTime, EEasing.EASE_IN_QUAD, SetTemplateBar);
                break;
        }
    }

    private void SetTemplateBar()
    {
        if (templateBar)
            templateBar.SetActive(bar.localScale.x == 1);
    }
}
