using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAttackManager : MonoBehaviour {
    public GameObject col;
    
    
    public bool isAttackAble = true;
    
    public void Attacked(AttackObj skill)
    {

        if (isAttackAble && !BPlayer.MainPlayer._isMove)
        {
            isAttackAble = false;
            GetComponent<BPlayer>()._isMoveAble = false;
            skill.col = new GameObject[1];
            skill.col[0] = col;
            skill.EndCallBack = () =>
            {
                StartCoroutine(Wait(() => {
                    GetComponent<BPlayer>()._isMoveAble = true;
                    isAttackAble = true;
                    GetComponent<Animator>().SetBool("Attack", false);
                    GetComponent<Animator>().SetFloat("Skill_id", 0);

                }, skill.EndTime - skill.StartTime + skill.AttackTime));
            };
            skill.HitCallBack = (hitObj, attackObj) =>
            {
                Debug.Log("콜백 증가됨;;;;");

                var Player = BPlayer.MainPlayer.GetComponent<NetworkObject>();
                hitObj.gameObject.GetComponent<oCreature>().CurrentHP.Value -= skill.Damage + Player.Final_ATK;
            };
            GetComponent<Animator>().SetBool("Attack", true);
            GetComponent<Animator>().SetFloat("Skill_id", skill.AniCode);
            StartCoroutine(Wait(() => { GetComponent<AttackerManager>().CallAttack(skill); }, skill.StartTime));
        }
    }



    IEnumerator Wait(Action action, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }


}
