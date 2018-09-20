using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using FlatBuffers;

public class PlayerSystem
{
    public string _name;
    public int id;
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

        Number.Event += () =>
        {
            var fbb = new FlatBufferBuilder(1);
            fbb.Finish(fItem.CreatefItem(fbb, Class.fItem,id,fbb.CreateString(""),0,0,0,0,0,0,0,0,0,Number.Value).Value);
            TCPClient.Instance.Send(fbb.SizedByteArray());
        };
    }

    public ReAct<int> Number = new ReAct<int>(1);
    public Dictionary<Slot,Action> NumberCallback = new Dictionary<Slot, Action>();

    public virtual void process() {  }
}