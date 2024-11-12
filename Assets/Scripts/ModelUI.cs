using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ModelUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text modelName;
    private Model model;

    public void OnPointerClick(PointerEventData _eventData)
    {
        Generate();
    }
    
    public void Setup(Model _model)
    {
        model = _model;
        icon.sprite = _model.Sprite;
        modelName.text = _model.Name;
    }

    private void Generate()
    {
        if (model)
            Instantiate(model);
    }

    
}
