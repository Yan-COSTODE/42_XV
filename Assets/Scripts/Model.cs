using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Model : MonoBehaviour
{
    [SerializeField] private string modelName;
    [SerializeField] private Sprite sprite;
    [SerializeField] private bool bCarryable;
    [SerializeField] private Transform carryPoint;
    [SerializeField] private bool bCarryableDrive;
    [SerializeField] private Transform carryDrivePoint;
    [SerializeField] private bool bDrivable;
    [SerializeField] private Transform drivePoint;
    private Renderer modelRenderer;
    
    public Sprite Sprite => sprite;
    public string Name => modelName;
    public bool Carryable => bCarryable;
    public bool CarryableDrive => bCarryableDrive;
    public bool Drivable => bDrivable;

    private void Start()
    {
        modelRenderer = GetComponentInChildren<Renderer>();
    }

    private void OnMouseDown()
    {
        if (Cursor.visible == false)
            return;
        
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        UIManager.Instance.CircleUI.Open(this);
    }

    public void Rename(string _name)
    {
        modelName = _name;
        name = _name;
    }
}