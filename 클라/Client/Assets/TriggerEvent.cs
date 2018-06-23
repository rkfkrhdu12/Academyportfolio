using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TriggerEvent : MonoBehaviour {

    public List<Action> triggerEnter = new List<Action>();
    public GameObject[] triggerStay;
    public List<Action> triggerExit = new List<Action>();


    void OnTriggerEnter(Collider other)
    {
        foreach(var i in triggerEnter)
        {
            i();
        }
    }
    void OnTriggerExit(Collider other)
    {
        foreach (var i in triggerExit)
        {
            i();
        }
    }
}
