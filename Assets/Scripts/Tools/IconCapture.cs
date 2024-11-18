#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.IO;

public class IconCapture : MonoBehaviour
{
    [SerializeField] private GameObject[] targetObject;

    private void Start()
    {
        foreach (GameObject target in targetObject)
            CaptureDefaultPreview(target);
    }
    
    private void CaptureDefaultPreview(GameObject _target)
    {
        if (_target == null)
        {
            Debug.LogError("No target object assigned.");
            return;
        }

        Texture2D previewTexture = AssetPreview.GetAssetPreview(_target);
        
        if (previewTexture == null)
        {
            Debug.LogError("Preview generation failed. Try selecting the object in the Editor to generate a preview.");
            return;
        }

        byte[] pngData = previewTexture.EncodeToPNG();
        
        if (pngData != null)
        {
            string path = Path.Combine(Application.dataPath + "/Sprites/Model", _target.name + ".png");
            File.WriteAllBytes(path, pngData);
            Debug.Log($"Preview icon saved to {path}");
        }
    }
}
#endif