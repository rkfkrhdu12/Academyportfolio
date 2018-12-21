using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : Slot
{
    public override void OnMouseRCilck()
    {
        base.OnMouseRCilck();
    }

    public override void SlotStart()
    {
        base.SlotStart();
        type = SlotType.Item;
    }
    public override void Equipment()
    {
        if (TargetSlot && TargetSlot.type == SlotType.Key)
        {
            TargetSlot.Item = Item;
            ((KeySlot)TargetSlot).mItemSlotType = type;
            KeySettingManager.KeySlotUpdate();
        }
        base.Equipment();
    }
}
