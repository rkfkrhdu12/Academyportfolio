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

    private void Start()
    {
        inputkey = new InputKeyBoard();

        inputkey.Start();
    }

    void Update()
    {
        inputkey.Update();
    }
}