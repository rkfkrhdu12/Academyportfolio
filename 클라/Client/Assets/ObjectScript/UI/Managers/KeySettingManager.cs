using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KeySettingManager : MonoBehaviour {

    public Dictionary<KeyCode, Action> KeyEvent = new Dictionary<KeyCode, Action>();
    public List<KeyCode> RemoveList = new List<KeyCode>();
    public List<int> mRemoveList = new List<int>();

    public Action[] MouseButton = new Action[2];


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


        foreach (var i in RemoveList)
        {
            KeyEvent.Remove(i);
        }
        foreach (var i in mRemoveList)
        {
            MouseButton[i] = ()=> { };
        }
        RemoveList.Clear();
        mRemoveList.Clear();
    }
}
