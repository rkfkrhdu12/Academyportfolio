using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public void Start()
    {
        BSkill[] skill = new BSkill[2];
        SystemSkill skill2 = new SystemSkill();
        SystemSkill skill3 = new SystemSkill();
        SystemSkill skill4 = new SystemSkill();


        int i = 0;

        // 평타.
        {
            skill[i] = new BSkill();
            skill[i]._name = "잽";
            skill[i]._info = "잽을 친다.";
            skill[i].icon = Resources.Load<Sprite>("atk");

            skill[i].AttackData = new AttackObj();
            skill[i].AttackData.AniCode = 0.1f;
            skill[i].AttackData.isTargetOnce = true;
            skill[i].AttackData.StartTime = 0.3f;
            skill[i].AttackData.EndTime = 0.7f;
            skill[i].AttackData.AttackTime = 0.25f;
            skill[i].AttackData.Damage = 10;
            skill[i++].AttackData.EffectName = "Blood";
        }

        // 검 평타.
        {
            skill[i] = new BSkill();
            skill[i]._name = "칼로 찍어버리기";
            skill[i]._info = "칼로 찍어버린다.";
            skill[i].icon = Resources.Load<Sprite>("swordblow");

            skill[i].AttackData = new AttackObj();
            skill[i].AttackData.AniCode = 0.2f;
            skill[i].AttackData.isTargetOnce = true;
            skill[i].AttackData.StartTime = 0.3f;
            skill[i].AttackData.EndTime = 0.79f;
            skill[i].AttackData.AttackTime = 0.25f;
            skill[i].AttackData.Damage = 20;
            skill[i++].AttackData.EffectName = "Blood";
        }
        


        skill2._name = "키셋팅 창 열기";
        skill2._info = "키셋팅 창을 열어재낀다.";
        skill2.icon = Resources.Load<Sprite>("keyset");
        
        skill2.SkillData = new AttackObj();
        skill2.SkillData.EndCallBack = () =>
        {
            GameObject win = BPlayer.MainPlayer.GetComponent<PlayerSystemManager>().KeySetting_WIN;
            win.SetActive(!win.activeSelf);
        };

        skill3._name = "인벤토리 열기";
        skill3._info = "인벤토리 창을 열어재껴버린다.";
        skill3.icon = Resources.Load<Sprite>("inv");

        skill3.SkillData = new AttackObj();
        skill3.SkillData.EndCallBack = () =>
        {
            GameObject win = BPlayer.MainPlayer.GetComponent<PlayerSystemManager>().Item_WIN;
            win.SetActive(!win.activeSelf);
        };

        skill4._name = "스텟창 열기";
        skill4._info = "스텟 창을 연다.";
        skill4.icon = Resources.Load<Sprite>("stat");

        skill4.SkillData = new AttackObj();
        skill4.SkillData.EndCallBack = () =>
        {
            GameObject win = BPlayer.MainPlayer.GetComponent<PlayerSystemManager>().State_WIN;
            win.SetActive(!win.activeSelf);
        };

        for (int j = 0; j < i; j++)
            SkillsManager.AddSkill(skill[j]);
        SkillsManager.AddSkill(skill2);
        SkillsManager.AddSkill(skill3);
        SkillsManager.AddSkill(skill4);
    }
}
