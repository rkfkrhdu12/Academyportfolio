using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKeyManager : MonoBehaviour
{
    #region singleton
    static InputKeyManager instance;
    public static InputKeyManager GetInstance()
    {
        return instance;
    }
    private void Awake()
    {
        instance = this;
    }
    #endregion
    
    public InputKeyBoard inputkey;
    public Vector3 moveVec;
    public void Start()
    {
        Debug.Log("Inputkey On");

        inputkey = new InputKeyBoard();

        moveVec = Vector3.zero;

        inputkey.Start();
    }
   
    public void Update()
    {
        if (inputkey == null) return;

        inputkey.Update();
    }
}