using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSlot : Slot {

    public override void SlotStart()
    {
        base.SlotStart();

        _Slot = new BSkill();

        _InfoBox = GameObject.Find("SkillManager").GetComponent<Info>();
    }
    
}
