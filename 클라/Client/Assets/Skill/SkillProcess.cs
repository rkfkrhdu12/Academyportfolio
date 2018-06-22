using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkillProcess : MonoBehaviour {
    public bool isOnce { get; set; }
    public Action<oCreature> HitCallBack { get; set; }
    
    oCreature ThisCreature;


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<oCreature>() != null)
        {
            if (other.gameObject.GetComponent<oCreature>() != GetComponentInParent<oCreature>())
            {
                if (other.gameObject.GetComponent<oCreature>() != ThisCreature)
                {
                    ThisCreature = other.gameObject.GetComponent<oCreature>();
                    HitCallBack(ThisCreature);
                }
            }
            if (isOnce) gameObject.SetActive(false);
        }
    }
}
