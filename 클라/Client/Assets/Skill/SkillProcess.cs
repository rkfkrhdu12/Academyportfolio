﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkillProcess : MonoBehaviour {
    public bool isOnce { get; set; }
    public Action<Collider> HitCallBack { get; set; }
    

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<oCreature>() != null)
        {
            if (other.gameObject.GetComponent<oCreature>() != GetComponentInParent<oCreature>())
            {
                HitCallBack(other);
            }
            if (isOnce) { gameObject.SetActive(false); }
        }
    }
}
