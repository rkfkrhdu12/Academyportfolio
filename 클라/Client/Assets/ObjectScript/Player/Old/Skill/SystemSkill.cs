using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemSkill : PlayerSystem
{
    public AttackObj SkillData { get; set; }

    public override void process()
    {
        SkillData.EndCallBack();
    }
}
