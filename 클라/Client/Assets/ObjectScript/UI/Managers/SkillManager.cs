using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public void Start()
    {
        BSkill skill1 = new BSkill();
        SystemSkill skill2 = new SystemSkill();
        SystemSkill skill3 = new SystemSkill();

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
        




        skill2._name = "KetSetting창 열기";
        skill2._info = "Open the KeySetting Window.";
        skill2.icon = Resources.Load<Sprite>("ex_Skill");

        skill2.SkillData = new AttackObj();
        skill2.SkillData.EndCallBack = ()=>{
            GameObject win = BPlayer.MainPlayer.GetComponent<PlayerSystemManager>().KeySetting_WIN;
            win.SetActive(!win.activeSelf);
        };

        skill3._name = "Item창 열기";
        skill3._info = "Open the Item Window.";
        skill3.icon = Resources.Load<Sprite>("ex_Skill");

        skill3.SkillData = new AttackObj();
        skill3.SkillData.EndCallBack = () => {
            GameObject win = BPlayer.MainPlayer.GetComponent<PlayerSystemManager>().Item_WIN;
            win.SetActive(!win.activeSelf);
        };


        SkillsManager.AddSkill(skill1);
        SkillsManager.AddSkill(skill2);
        SkillsManager.AddSkill(skill3);
    }
}
