using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public void Start()
    {
        BSkill skill1 = new BSkill();
        BSkill skill2 = new BSkill();
        BSkill skill3 = new BSkill();

        skill1._name = "스킬1";
        skill1._info = "스킬이다.";
        skill1.icon = Resources.Load<Sprite>("ex_Skill");

        skill1.AttackData = new AttackObj();
        skill1.AttackData.isTargetOnce = true;
        skill1.AttackData.StartTime = 0.3f;
        skill1.AttackData.EndTime = 0.7f;
        skill1.AttackData.AttackTime = 0.25f;
        skill1.AttackData.Damage = 10;
        skill1.AttackData.EffectName = "Blood";
        




        skill2._name = "스킬2";
        skill2._info = "스킬이다.";
        skill2.icon = Resources.Load<Sprite>("ex_Skill");

        skill3._name = "스킬3";
        skill3._info = "스킬이다.";
        skill3.icon = Resources.Load<Sprite>("ex_Skill");


        SkillsManager.AddSkill(skill1);
        SkillsManager.AddSkill(skill2);
        SkillsManager.AddSkill(skill3);
    }
}
