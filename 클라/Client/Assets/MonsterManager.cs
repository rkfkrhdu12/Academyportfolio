using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour {

    void Start () {
        GetComponent<oCreature>().CurrentHP.OtherEvent(()=>
        {
            if (GetComponent<oCreature>().CurrentHP.Value <= 0)
            {

            }
        });
	}
}
