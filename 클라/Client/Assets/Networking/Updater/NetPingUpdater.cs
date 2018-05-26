using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlatBuffers;

public class NetPingUpdater{
    public void Update()
    {
        var fbb = new FlatBufferBuilder(1);
        fbb.Finish(ping.Createping(fbb,Class.ping, System.DateTime.Now.ToBinary()).Value);
        TCPClient.Instance.Send(fbb.SizedByteArray());
    }
}
