using UnityEngine;

public class ModelManager : SingletonTemplate<ModelManager>
{
    [SerializeField] private Model[] modelPrefab;
    [SerializeField] private Transform modelContainer;
    [SerializeField] private ModelUI modelUIPrefab;
    
    private void Start()
    {
        InitializeContainer();
    }

    private void InitializeContainer()
    {
        CleanTransform();
        for (int i = 0; i < modelPrefab.Length; i++)
        {
            ModelUI _modelUI = Instantiate(modelUIPrefab, modelContainer);
            _modelUI.Setup(modelPrefab[i]);
        }
    }
    
    private void CleanTransform()
    {
        for (int i = 0; i < modelContainer.childCount; i++)
            Destroy(modelContainer.GetChild(i).gameObject);
    }
}
