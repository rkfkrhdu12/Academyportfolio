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
    public GameObject bloodEffect;


    private void Start()
    {
        bloodEffect = Resources.Load<GameObject>("BulletImpactFleshBigEffect");
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


    public void Hit(int HitDamage, Collider col)
    {
        CurrentHP.Value -= HitDamage;
        Debug.Log("체력 " + HitDamage + "만큼 감소.\n남은 체력 : " + CurrentHP.Value);
        ShowBloodEffect(col);
    }

    public void SpReduction(int Value)
    {
        CurrentSP -= Value;
        Debug.Log("스테미나 " + Value + "만큼 감소.\n남은 스테미나 : " + CurrentSP);

    }

    void ShowBloodEffect(Collider collision)
    {
        // 총알이 충동한 지점 산출 
        Vector3 pos = transform.position;
        pos.y += 2.5f;
        // 총알 충돌한 지점의 법선 벡터
        Vector3 normal = transform.position;

        // 총알 충돌시 방향 벡터의 회전 정보
        Quaternion rot = Quaternion.FromToRotation(-Vector3.forward, normal);

        // 혈흔 효과 생성
        GameObject blood = Instantiate(bloodEffect, pos, rot);

        Destroy(blood, 1.0f);
    }
}
