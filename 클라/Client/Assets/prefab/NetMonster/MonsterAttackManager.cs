using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MonsterAttackManager : MonoBehaviour
{

    public GameObject AttackRange;
    public GameObject col;

    public AttackObj CurrentAtk;


    public bool isAttackAble = true;

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<oCreature>() && isAttackAble)
        {
            isAttackAble = false;
            AttackRange.SetActive(false);
            // ======== 스킬.
            var skill = new AttackObj();
            CurrentAtk = skill;
            skill.col = new GameObject[1];
            skill.col[0] = col;
            skill.isTargetOnce = false;

            skill.StartTime = 0.6f;
            skill.EndTime = 2.1f;
            skill.AttackTime = 0.25f;

            skill.AniCode = 0.2f;

            skill.Damage = 10;

            skill.HitCallBack = (data) =>
            {
                if (data.gameObject == NetworkObject.mainPlayer)
                {
                    Debug.Log("Hit");
                    data.gameObject.GetComponent<NetworkObject>().m_CurrentHP.Value -= CurrentAtk.Damage;
                }
            };
            skill.EndCallBack = () =>
            {
                AttackRange.SetActive(true);
                StartCoroutine(Wait(() => {  isAttackAble = true; }, skill.EndTime - skill.StartTime + skill.AttackTime));
            };
            // ======= 임시 스킬 생성.
            
            GetComponentInChildren<Animator>().SetFloat("stat", skill.AniCode);
            StartCoroutine(Wait(() => { GetComponent<AttackerManager>().CallAttack(skill); }, skill.StartTime));
        }
    }

    void Start()
    {
        
    }


   

    IEnumerator Wait(Action action, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
}