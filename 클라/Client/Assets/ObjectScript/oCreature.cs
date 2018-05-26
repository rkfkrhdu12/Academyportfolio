using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using FlatBuffers;


public class oCreature : oObject
{
    public ReAct<int> CurrentHP = new ReAct<int>();
    public ReAct<int> CurrentHPOtherEvent = new ReAct<int>();

    public int MaximumHP;

    public int CurrentSP;
    public int MaximumSP;
    
    public int Lv;
    
    GameObject[] Skill_col_obj;


    public bool isAttacked { get; set; }
    

    public void Data_Update(PlayerStat stat)
    {
        CurrentHP.NoEventSet(stat.HP);
        CurrentSP = stat.MP;
        MaximumHP = stat.HPLim;
        MaximumSP = stat.MPLim;
        Lv = stat.LV;
    }


    public void Hit(int HitDamage)
    {
        CurrentHP.Value -= HitDamage;
        Debug.Log("체력 " + HitDamage + "만큼 감소.\n남은 체력 : " + CurrentHP.Value);

    }

    public void SpReduction(int Value)
    {
        CurrentSP -= Value;
        Debug.Log("스테미나 " + Value + "만큼 감소.\n남은 스테미나 : " + CurrentSP);

    }

    void Start()
    {
    }



    public void StartSkill(GameObject[] obj, float time)
    {
        Skill_col_obj = obj;
        Invoke("StartSkillProcess", time);
    }
    void StartSkillProcess()
    {
        foreach (GameObject i in Skill_col_obj)
            i.SetActive(true);
    }

}
