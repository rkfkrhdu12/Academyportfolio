using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class oNetworkManager : MonoBehaviour {

    public int id { get; set; }
    [SerializeField] [Range(.01f, 1f)] public float SendRate;

    void Awake()
    {
        OnServerStart.Event.Add(this);
    }

    public virtual void NetworkStarting()
    {

    }

    public IEnumerator NetUpdate(Action action,float t)
    {
        while (true)
        {
            action();
            yield return new WaitForSeconds(t);
        }
    }
}
