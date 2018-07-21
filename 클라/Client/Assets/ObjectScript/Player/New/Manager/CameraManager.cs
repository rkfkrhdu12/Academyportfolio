using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    #region singleton
    static CameraManager instance;
    public static CameraManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
    }
    #endregion

    private Camera mainCamera = null;
    private bool _isCamera;
    public Transform cameraTrs;
    

    public void Start()
    {
        cameraTrs = GameObject.FindWithTag("CameraParent").transform;
        mainCamera = cameraTrs.GetChild(0).GetComponent<Camera>();

        _isCamera = true;
    }

    public void Update()
    {
        if (mainCamera == null) return;

        CameraUpdate();
    }

    float mouseSensitivity = 2;
    float rotationLeftRight;
    float verticalRotation;
    float verticalAngleLimit = 15;
    void CameraUpdate()
    {
        OnOffCamera();

        if (_isCamera)
        {
            mainCamera = Camera.main;

            rotationLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
            player.GetInstance().transform.Rotate(0, rotationLeftRight, 0);

            verticalRotation += Input.GetAxis("Mouse Y") * mouseSensitivity;
            verticalRotation = Mathf.Clamp(verticalRotation, -verticalAngleLimit, verticalAngleLimit);
            cameraTrs.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
        }
    }

    void OnOffCamera()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _isCamera) { _isCamera = false; }
        else if (Input.GetKeyDown(KeyCode.Escape) && !_isCamera) { _isCamera = true; }
    }
}