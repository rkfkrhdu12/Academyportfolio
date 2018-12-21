using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSlot : Slot {
    public override void SlotStart()
    {
        base.SlotStart();
        type = SlotType.Skill;
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
