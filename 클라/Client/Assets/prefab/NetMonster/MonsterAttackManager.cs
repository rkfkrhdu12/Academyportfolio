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

    public Dictionary<string, GameObject> Effects = new Dictionary<string, GameObject>();


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<oCreature>() && isAttackAble && other.GetComponent<oNetworkIdentity>().type != oNetworkIdentity.ObjType.monster)
        {
            isAttackAble = false;
            AttackRange.SetActive(false);
            // ======== 스킬.
            var skill = new AttackObj();
            CurrentAtk = skill;
            skill.col = new GameObject[1];
            skill.col[0] = col;
            skill.isTargetOnce = true;

            skill.StartTime = 0.6f;
            skill.EndTime = 2.1f;
            skill.AttackTime = 0.25f;
            skill.EffectName = "Blood";
            skill.AniCode = 0.2f;

            skill.Damage = 10;

            skill.HitCallBack = (data,data2) =>
            {
                if (data.gameObject == NetworkObject.mainPlayer)
                {
                    data.gameObject.GetComponent<SendStateManager>().SendDamage(10);
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
        Effects["Blood"] = Resources.Load<GameObject>("BulletImpactFleshBigEffect");
    }


   

    IEnumerator Wait(Action action, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
}