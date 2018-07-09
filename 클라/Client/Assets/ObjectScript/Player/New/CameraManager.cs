using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Camera mainCamera;
    private bool _isCamera;

    public void Update()
    {
        CameraUpdate();
    }

    float mouseSensitivity = 2;
    float rotationLeftRight;
    float verticalRotation;
    float verticalAngleLimit = 30;
    void CameraUpdate()
    {
        OnOffCamera();

        if (_isCamera)
        {
            mainCamera = Camera.main;

            rotationLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
            player.GetInstance().transform.transform.Rotate(0, rotationLeftRight, 0);

            verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            verticalRotation = Mathf.Clamp(verticalRotation, -verticalAngleLimit, verticalAngleLimit);
            mainCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
        }
    }

    void OnOffCamera()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _isCamera) { _isCamera = false; }
        else if (Input.GetKeyDown(KeyCode.Escape) && !_isCamera) { _isCamera = true; }
    }
}