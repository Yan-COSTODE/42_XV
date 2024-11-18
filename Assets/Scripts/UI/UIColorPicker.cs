using UnityEngine;
using UnityEngine.UI;

public class UIColorPicker : MonoBehaviour
{
    [SerializeField] private Slider redSlider;
    [SerializeField] private Slider greenSlider;
    [SerializeField] private Slider blueSlider;
    [SerializeField] private Image colorPreview;
    [SerializeField] private Button applyButton;
    private Renderer targetRenderer;

    public void Setup(GameObject _target)
    {
        targetRenderer = _target.GetComponentInChildren<Renderer>();
        Color _initialColor = targetRenderer.material.color;
        redSlider.value = _initialColor.r;
        greenSlider.value = _initialColor.g;
        blueSlider.value = _initialColor.b;
        redSlider.onValueChanged.AddListener(UpdatePreview);
        greenSlider.onValueChanged.AddListener(UpdatePreview);
        blueSlider.onValueChanged.AddListener(UpdatePreview);
        applyButton.onClick.AddListener(ApplyColor);
        UpdatePreview();
    }

    private void UpdatePreview(float _value = 0.0f)
    {
        Color _color = new Color(redSlider.value, greenSlider.value, blueSlider.value); 
        colorPreview.color = _color; 
        ApplyColorPreview();
    }

    private void ApplyColorPreview()
    {
        for (int i = 0; i < targetRenderer.materials.Length; i++)
            targetRenderer.materials[i].color = colorPreview.color;
    }
    
    private void ApplyColor()
    {
        ApplyColorPreview();
        Destroy(gameObject);
    }
}
