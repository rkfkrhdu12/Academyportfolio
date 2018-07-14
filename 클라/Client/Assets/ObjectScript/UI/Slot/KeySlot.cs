using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySlot : Slot {

    [SerializeField] KeyCode key;
    [SerializeField] bool Mouse;
    [SerializeField] int MousePoint;

    public override void OnMouseRCilck()
    {
        Item = null;
    }

    public override void SlotStart()
    {
        base.SlotStart();
        type = SlotType.Key;
        item.Event += () =>
        {
            if(Item == null) KeySet(() => { });
            else             KeySet(Item.process);
        };
    }

    void KeySet(System.Action act)
    {
        if (Mouse)
        {
            GetComponentInParent<KeySettingManager>().MouseButton[MousePoint] = act;
        }
        else
        {
            GetComponentInParent<KeySettingManager>().KeyEvent[key] = act;
        }
    }
}
