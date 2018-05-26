using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GetPing : oNetworkManager
{

    public static ReAct<int> iping = new ReAct<int>();
    public static ReAct<int> MaxPing = new ReAct<int>();
    NetPingUpdater ping = new NetPingUpdater();

    private void Start()
    {
        NetDataReader.GetInstace().Reder[Class.ping] = (data) =>
        {
            long t = System.DateTime.Now.ToBinary() - (long)test.GetRootAstest(data.ByteBuffer).Num;
            iping.Value = (int)(t * (0.0001f));
        };

        iping.AddEvent(()=>
        {
            if(iping.Value > MaxPing.Value)
            {
                MaxPing.Value = iping.Value;
            }
        });

    }


    public override void NetworkStarting()
    {
        StartCoroutine(NetUpdate(() =>
        {
            NetworkSendManager.instance.actions.Enqueue(() =>
            {
                ping.Update();
            });
        }, SendRate));
    }
}
