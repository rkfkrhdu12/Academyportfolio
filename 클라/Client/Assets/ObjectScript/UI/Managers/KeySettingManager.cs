using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySettingManager : MonoBehaviour {

    public Dictionary<KeyCode, System.Action> KeyEvent = new Dictionary<KeyCode, System.Action>();

    public System.Action[] MouseButton = new System.Action[2];


    private void Start()
    {
        MouseButton[0] = () => { };
        MouseButton[1] = () => { };
    }

    void Update()
    {
        foreach (var i in KeyEvent)
        {
            if (Input.GetKeyDown(i.Key))
            {
                i.Value();
            }
        }
        if (Input.GetMouseButtonDown(0)) MouseButton[0]();
        if (Input.GetMouseButtonDown(1)) MouseButton[1]();
    }
}
