using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkillProcess : MonoBehaviour {


    public float EndTime { get; set; }
    public bool isOnce { get; set; }
    public int Damage { get; set; }

    float dt=0f;

    oCreature ThisCreature;



    private void Update()
    {
        dt += Time.deltaTime;

        if (dt > EndTime) {
            gameObject.GetComponentInParent<oCreature>().isAttacked = false;
            gameObject.SetActive(false);
            Destroy(GetComponent<SkillProcess>());
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" || other.tag == "Monster")
        {
            if (other.gameObject.GetComponent<oCreature>() != GetComponentInParent<oCreature>())
            {
                if (other.gameObject.GetComponent<oCreature>() != ThisCreature)
                {
                    ThisCreature = other.gameObject.GetComponent<oCreature>();
                    other.gameObject.GetComponent<oCreature>().Hit(Damage);
                }
            }
            if (isOnce) gameObject.SetActive(false);
        }
    }
}
