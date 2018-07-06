using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsManager : SlotsManager
{
    static SkillsManager instance;

    void Awake()
    {
        instance = this;

        for (int i = 0; i < SlotParent.transform.childCount; i++)
            Slots[i] = SlotParent.transform.GetChild(i).GetComponent<SkillSlot>();
    }

    public static void AddSkill(PlayerSystem Skill)
    {
        instance.Add(Skill);
    }
}
