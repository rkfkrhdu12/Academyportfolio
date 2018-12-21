using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlatBuffers;

public class KeySlot : Slot
{

    public KeyCode key;
    public bool Mouse;
    public int MousePoint;

    public SlotType mItemSlotType;

    KeySettingManager settingManager;


    public override void OnMouseRCilck()
    {
        Item = null;
        KeySettingManager.KeySlotUpdate();
    }

    public override void SlotStart()
    {
        base.SlotStart();
        settingManager = GetComponentInParent<KeySettingManager>();
        type = SlotType.Key;
        item.Event += () =>
        {
            if (Item == null) KeySet(null);
            else KeySet(Item.process);

        };
    }

    public override void Equipment()
    {
        base.Equipment();
        //if (TargetSlot)
            KeySettingManager.KeySlotUpdate();
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
