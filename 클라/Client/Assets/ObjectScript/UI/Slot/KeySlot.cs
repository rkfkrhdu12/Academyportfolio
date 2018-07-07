using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySlot : Slot {

    [SerializeField] KeyCode key;
    [SerializeField] bool Mouse;
    [SerializeField] int MousePoint;
    

    public override void SlotStart()
    {
        base.SlotStart();
        type = SlotType.Key;
        item.Event += () =>
        {
            if (Mouse)
            {
                GetComponentInParent<KeySettingManager>().MouseButton[MousePoint] =  Item.process;
            }
            else{
                GetComponentInParent<KeySettingManager>().KeyEvent[key] = Item.process;
            }
        };
    }
}
