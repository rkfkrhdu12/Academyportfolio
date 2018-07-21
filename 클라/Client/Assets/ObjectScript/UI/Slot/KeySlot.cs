using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySlot : Slot {

    [SerializeField] KeyCode key;
    [SerializeField] bool Mouse;
    [SerializeField] int MousePoint;


    KeySettingManager settingManager;


    public override void OnMouseRCilck()
    {
        Item = null;
    }

    public override void SlotStart()
    {
        base.SlotStart();
        settingManager = GetComponentInParent<KeySettingManager>();
        type = SlotType.Key;
        item.Event += () =>
        {
            if(Item == null) KeySet(null);
            else             KeySet(Item.process);
        };
    }
    

    void KeySet(System.Action act)
    {

        if (Mouse)
        {
            if (act == null) settingManager.mRemoveList.Add(MousePoint);
            else settingManager.MouseButton[MousePoint] = act;
        }
        else
        {
            if (act == null) settingManager.RemoveList.Add(key);
            else settingManager.KeyEvent[key] = act;
        }
    }
}
