using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : PlayerManager
{
    public void Start()
    {
        _Manager = GameObject.Find("SkillManager").GetComponent<SkillSlotManager>();

        BSkill skill = new BSkill();

        skill._name = "스킬1";
        skill._info = "스킬이다.";
        _PlayerSystem.Add(skill);

        skill = new BSkill();
        skill._name = "스킬2";
        skill._info = "스킬이다.";
        _PlayerSystem.Add(skill);

        skill = new BSkill();
        skill._name = "스킬3";
        skill._info = "스킬이다.";
        _PlayerSystem.Add(skill);

        _Manager.SetItem(_PlayerSystem[0]); // 
        _Manager.SetItem(_PlayerSystem[1]); //
        _Manager.SetItem(_PlayerSystem[2]); //
    }
}
