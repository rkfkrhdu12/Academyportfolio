using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttackManager : MonoBehaviour
{

    public GameObject AttackRange;
    public GameObject col;

    public AttackObj CurrentAtk;

    bool isAttack = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<oCreature>() && !isAttack)
        {
            AttackRange.SetActive(false);
            isAttack = true;
            // ======== 스킬.
            var skill = new AttackObj();
            CurrentAtk = skill;
            skill.col = new GameObject[1];
            skill.col[0] = col;
            skill.Time = 1f;
            skill.Damage = 10;
            skill.EndCallBack = () =>
            {
                AttackRange.SetActive(true);
                isAttack = false;
            };
            // ======= 임시 스킬 생성.
            GetComponent<AttackerManager>().CallAttack(skill);
        }
        else if(isAttack)
        {
            if(other.gameObject == NetworkObject.mainPlayer)
            {
                other.gameObject.GetComponent<NetworkObject>().m_CurrentHP.Value -= CurrentAtk.Damage;
            }
        }
    }
}