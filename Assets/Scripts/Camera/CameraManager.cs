using System;
using UnityEngine;

public class CameraManager : SingletonTemplate<CameraManager>
{
    [SerializeField] private CameraOverview overview;
    [SerializeField] private CameraPersonal personal;
    private Camera main;
    
    public Camera Main => main;
    
    public bool CanMove => !Cursor.visible;

    private void Start()
    {
        ToggleCursor();
        SetMain();
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

    private void SetMain()
    {
        main = overview.gameObject.activeSelf ? overview.GetComponent<Camera>() : personal.GetComponent<Camera>();
    }
    
    public void Toggle()
    {
        overview.gameObject.SetActive(!overview.gameObject.activeSelf);
        personal.gameObject.SetActive(!personal.gameObject.activeSelf);
        ToggleCursor();
        SetMain();
    }
}