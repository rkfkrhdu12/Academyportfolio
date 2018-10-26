using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour {
    [SerializeField] GameObject body;
    void Start () {

    }

    public void SetMonsterDead()
    {
        body.SetActive(false);
        GetComponent<oCreature>().enabled = false;
        GetComponent<MonsterAttackManager>().enabled = false;
        GetComponent<AttackerManager>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
    }

    public void SetMonster()
    {
        body.SetActive(true);
        GetComponent<oCreature>().enabled = true;
        GetComponent<MonsterAttackManager>().enabled = true;
        GetComponent<AttackerManager>().enabled = true;
        GetComponent<CapsuleCollider>().enabled = true;
    }
}
