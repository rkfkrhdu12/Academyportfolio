using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MHA_Manager : MonoBehaviour
{
    Action<Collider, Collider> HitCallBack;

    // 몬스터 핸드 어택 왼쪽.
    public void MHA_Left()
    {

        HitCallBack = (data, data2) =>
        {
            if (data.gameObject == NetworkObject.mainPlayer)
            {
                data.gameObject.GetComponent<SendStateManager>().SendDamage(GetComponentInParent<MonsterAttackManager>().CurrentAtk.Damage+3);
            }
        };

        var Option = GetComponentInParent<MonsterAttackManager>().col[1].GetComponent<SkillProcess>();
        Option.HitCallBack = HitCallBack;
        Option.isOnce = GetComponentInParent<MonsterAttackManager>().CurrentAtk.isTargetOnce;
        Option.EffectName = GetComponentInParent<MonsterAttackManager>().CurrentAtk.EffectName;

        GetComponentInParent<MonsterAttackManager>().col[1].SetActive(true);
    }
    public void MHA_LeftEND()
    {
        GetComponentInParent<MonsterAttackManager>().col[1].SetActive(false);
        GetComponentInParent<MonsterAttackManager>().isAttackAble = true;
    }

    public void MHA_Right()
    {

        HitCallBack = (data, data2) =>
        {
            if (data.gameObject == NetworkObject.mainPlayer)
            {
                data.gameObject.GetComponent<SendStateManager>().SendDamage(GetComponentInParent<MonsterAttackManager>().CurrentAtk.Damage);
            }
        };

        var Option = GetComponentInParent<MonsterAttackManager>().col[0].GetComponent<SkillProcess>();
        Option.HitCallBack = HitCallBack;
        Option.isOnce = GetComponentInParent<MonsterAttackManager>().CurrentAtk.isTargetOnce;
        Option.EffectName = GetComponentInParent<MonsterAttackManager>().CurrentAtk.EffectName;

        GetComponentInParent<MonsterAttackManager>().col[0].SetActive(true);
    }
    public void MHA_RightEND()
    {
        GetComponentInParent<MonsterAttackManager>().col[0].SetActive(false);
    }
}
