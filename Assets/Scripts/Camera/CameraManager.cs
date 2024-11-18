using System;
using UnityEngine;

public class CameraManager : SingletonTemplate<CameraManager>
{
    [SerializeField] private CameraOverview overview;
    [SerializeField] private CameraPersonal personal;
    
    
    public bool CanMove => !Cursor.visible;

    private void Start()
    {
        ToggleCursor();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            ToggleCursor();
    }

    private void ToggleCursor()
    {
        if (Cursor.lockState == CursorLockMode.Confined)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }
    
    public void Toggle()
    {
        overview.gameObject.SetActive(!overview.gameObject.activeSelf);
        personal.gameObject.SetActive(!personal.gameObject.activeSelf);
        ToggleCursor();
    }
}