using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DelayManager : MonoBehaviour
{

    public static DelayManager instance;

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void DelayStart(Action act, float t)
    {
        instance.StartCoroutine(instance.Delay(act,t));
    }

    public IEnumerator Delay(Action action, float t)
    {
        yield return new WaitForSeconds(t);
        action();
    }
}
