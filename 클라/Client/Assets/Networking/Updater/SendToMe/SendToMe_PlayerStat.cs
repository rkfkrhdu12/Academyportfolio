using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlatBuffers;

public class SendToMe_PlayerStat{
    public static void Send(int PlayerID)
    {
        NetworkSendManager.instance.actions.Enqueue(() =>
        {
            var fbb = new FlatBufferBuilder(1);
            fbb.Finish(SendMeStat.CreateSendMeStat(fbb, Class.SendMeStat, Class.PlayerStat, PlayerID).Value);
            TCPClient.Instance.Send(fbb.SizedByteArray());
        });
    }
}
