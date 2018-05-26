using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRot : Module
{
    Camera mainCamera;
    
    public override void Update()
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

        if (_player._isCamera)
        {
            mainCamera = Camera.main;

            rotationLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
            _player.transform.transform.Rotate(0, rotationLeftRight, 0);
            
            verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            verticalRotation = Mathf.Clamp(verticalRotation, -verticalAngleLimit, verticalAngleLimit);
            mainCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
        }
    }

    void OnOffCamera()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _player._isCamera) { _player._isCamera = false; }
        else if (Input.GetKeyDown(KeyCode.Escape) && !_player._isCamera) { _player._isCamera = true; }
    }

}
