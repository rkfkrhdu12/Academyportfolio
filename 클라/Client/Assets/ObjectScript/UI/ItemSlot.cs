using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : Slot
{
    public override void SlotStart()
    {
        base.SlotStart();

        _Slot = new BItem();

        _InfoBox = GameObject.Find("InventoryManager").GetComponent<Info>();
    }
    
}
