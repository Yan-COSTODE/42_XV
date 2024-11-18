using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UINamePicker : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button apply;
    private Model model;

    public void Setup(Model _model)
    {
        model = _model;
        inputField.text = model.Name;
        inputField.onValueChanged.AddListener(CheckInput);
        apply.onClick.AddListener(Apply);
    }

    private void CheckInput(string _str)
    {
        apply.interactable = _str.Length > 0;
    }
    
    private void Apply()
    {
        model.Rename(inputField.text);
        Destroy(gameObject);
    }
}
