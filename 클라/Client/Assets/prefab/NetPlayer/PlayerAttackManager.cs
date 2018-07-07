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
                }, skill.EndTime - skill.StartTime + skill.AttackTime));
            };
            skill.HitCallBack = (hitObj, attackObj) =>
            {
                hitObj.gameObject.GetComponent<oCreature>().CurrentHP.Value -= skill.Damage; 
            };
            GetComponent<Animator>().SetBool("Attack", true);
            StartCoroutine(Wait(() => { GetComponent<AttackerManager>().CallAttack(skill); }, skill.StartTime));
        }
    }



    IEnumerator Wait(Action action, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }


}
