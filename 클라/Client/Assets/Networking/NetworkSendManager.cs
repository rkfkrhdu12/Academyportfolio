using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NetworkSendManager : MonoBehaviour {

    public static NetworkSendManager instance;
    public Queue<Action> actions = new Queue<Action>();
    [SerializeField] [Range(.01f, 1f)] float NetSendRate = 0.1f;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(NetUpdata(NetSendRate));
    }





    IEnumerator NetUpdata(float t)
    {
        while (true)
        {
            if(actions.Count != 0)
                actions.Dequeue()();
            yield return new WaitForSeconds(t);
        }
    }
}
