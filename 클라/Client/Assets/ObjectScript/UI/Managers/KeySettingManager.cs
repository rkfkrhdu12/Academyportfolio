using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KeySettingManager : SlotsManager
{
    public static KeySettingManager instance;

    public Dictionary<KeyCode, Action> KeyEvent = new Dictionary<KeyCode, Action>();
    public List<KeyCode> RemoveList = new List<KeyCode>();
    public List<int> mRemoveList = new List<int>();

    public Action[] MouseButton = new Action[2];

    private void Awake()
    {
        instance = this;
    }

    public static void AddKey(PlayerSystem act)
    {
        instance.Add(act);
    }

    private void Start()
    {
        MouseButton[0] = () => { };
        MouseButton[1] = () => { };


        for (int i = 0; i < SlotParent.transform.childCount; i++)
            Slots[i] = SlotParent.transform.GetChild(i).GetComponent<KeySlot>();
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
