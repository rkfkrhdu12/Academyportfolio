using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour {
    [SerializeField] GameObject body;
    [SerializeField] GameObject body2;
    void Start () {

    }

    public void SetMonsterDead()
    {
        body.SetActive(false);
        body2.SetActive(false);
        GetComponent<oCreature>().enabled = false;
        GetComponent<MonsterAttackManager>().enabled = false;
        GetComponent<AttackerManager>().enabled = false;
        GetComponent<CharacterController>().enabled = false;
    }

    public void SetMonster()
    {
        body.SetActive(true);
        body2.SetActive(true);
        GetComponent<oCreature>().enabled = true;
        GetComponent<MonsterAttackManager>().enabled = true;
        GetComponent<MonsterAttackManager>().isAttackAble = true;
        GetComponent<MonsterAttackManager>().AttackRange.SetActive(true);
        GetComponent<AttackerManager>().enabled = true;
        GetComponent<CharacterController>().enabled = true;
    }
}
