using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerSystem
{
    public string _name;
    public string _info;
    public Sprite icon;

    public PlayerSystem()
    {
        Number.Event = () =>
        {
            foreach (var i in NumberCallback)
            {
                i.Value();
            }
        };
    }

    public ReAct<int> Number = new ReAct<int>(1);
    public Dictionary<Slot,Action> NumberCallback = new Dictionary<Slot, Action>();

    public virtual void process() {  }
}