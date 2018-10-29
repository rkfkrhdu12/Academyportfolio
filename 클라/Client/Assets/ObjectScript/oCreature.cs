using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using FlatBuffers;


public class oCreature : oObject
{
    public ReAct<int> CurrentHP = new ReAct<int>();

    public int MaximumHP;

    public int CurrentSP;
    public int MaximumSP;
    
    public int Lv;
    

    public bool isAttacked { get; set; }

    public void Data_Update(Vec3 pos)
    {
        transform.position = new Vector3(pos.X,pos.Y,pos.Z);
    }
    public void Data_Update(PlayerStat stat)
    {
        CurrentHP.NoEventSet(stat.HP);
        CurrentSP = stat.MP;
        MaximumHP = stat.HPLim;
        MaximumSP = stat.MPLim;
        Lv = stat.LV;
    }
    public void Data_Update(MonsterStat stat)
    {
        CurrentHP.NoEventSet(stat.HP);
    }
}
