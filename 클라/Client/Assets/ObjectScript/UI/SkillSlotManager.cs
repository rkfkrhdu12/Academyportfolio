using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSlotManager : UIManager
{
    void Awake()
    {
        _Object = GameObject.Find("Skill");

        // Slot
        GameObject SlotBox = _Object.transform.GetChild(1).gameObject;

        for (int i = 0; i < SlotBox.transform.childCount; i++)
            _SlotBox.Add(SlotBox.transform.GetChild(i).GetComponent<SkillSlot>());
        
    }

    // EventTrigger
    public override void evExit()
    {
        _Object.SetActive(false);
    }
}
