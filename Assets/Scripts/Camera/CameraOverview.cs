using System;
using UnityEngine;

public class CameraOverview : MonoBehaviour
{
    [SerializeField] private float fMoveSpeed = 10.0f;
    [SerializeField] private float fRotateSpeed = 10.0f;
    [SerializeField] private Vector3 maxBounds;
    [SerializeField] private Vector3 minBounds;

    private void Update()
    {
        if (!CameraManager.Instance.CanMove)
            return;
        
        MoveForward(Input.GetAxis("Vertical"));
        MoveLeft(Input.GetAxis("Horizontal"));
        StayInBounds();
        RotateUp(Input.GetAxis("Mouse X"));
        RotateLeft(Input.GetAxis("Mouse Y"));
        LockRotation();
    }

    private void MoveForward(float _axis)
    {
        transform.Translate(Vector3.forward * (_axis * fMoveSpeed * Time.deltaTime));
    }

    private void MoveLeft(float _axis)
    {
        transform.Translate(Vector3.right * (_axis * fMoveSpeed * Time.deltaTime));
    }

    private void RotateUp(float _axis)
    {
        transform.Rotate(Vector3.up * (_axis * fRotateSpeed * Time.deltaTime));
    }
    
    private void RotateLeft(float _axis)
    {
        transform.Rotate(Vector3.left * (_axis * fRotateSpeed * Time.deltaTime));
    }

    private void LockRotation()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0); 
    }
    
    private void StayInBounds()
    {
        if (transform.position.x < minBounds.x)
            transform.position = new Vector3(minBounds.x, transform.position.y, transform.position.z);
        else if (transform.position.x > maxBounds.x)
            transform.position = new Vector3(maxBounds.x, transform.position.y, transform.position.z);
        
        if (transform.position.y < minBounds.y)
            transform.position = new Vector3(transform.position.x, minBounds.y, transform.position.z);
        else if (transform.position.y > maxBounds.y)
            transform.position = new Vector3(transform.position.x, maxBounds.y, transform.position.z);
        
        if (transform.position.z < minBounds.z)
            transform.position = new Vector3(transform.position.x, transform.position.y, minBounds.z);
        else if (transform.position.z > maxBounds.z)
            transform.position = new Vector3(transform.position.x, transform.position.y, maxBounds.z);
    }
}
