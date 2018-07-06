using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ReAct<T>{

    private T _Value = default(T);

    public T Value
    {
        get
        {
            return _Value;
        }
        set
        {
            _Value = value;
            foreach (var i in eList)
            {
                i();
            }
            Event();
        }

    }
    public Action Event = ()=>{ };

    List<Action> eList = new List<Action>();
    List<Action> OeList = new List<Action>();

    public ReAct(T value)
    {
        _Value = value;
    }
    public ReAct()
    {
        _Value = default(T);
    }
    public void AddEvent(Action a)
    {
        eList.Add(a);
    }
    public void OtherEvent(Action a)
    {
        OeList.Add(a);
    }





    public void NoEventSet(T val)
    {
        _Value = val;
        foreach (var i in OeList)
        {
            i();
        }
    }

}
