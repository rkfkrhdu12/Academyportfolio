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
    }

    void Update () {
        if (!Empty)
        {
            if (Mouse)
            {
                if (Input.GetMouseButtonDown(MousePoint))
                {
                    Item.process();
                }
            }
            else if (Input.GetKey(key))
            {
                Item.process();
            }
        }
    }
}
