using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlatBuffers;

public class SendStateManager : MonoBehaviour {
    public virtual void SendDamage(int damage)
    {
        NetworkSendManager.instance.actions.Enqueue(() =>
        {
            int mid = GetComponent<oNetworkIdentity>().id;
            FlatBufferBuilder fbb = new FlatBufferBuilder(1);
            fbb.Finish(PlayerStat.CreatePlayerStat
            (fbb, Class.PlayerStat, -damage, 0, 0, 0, 0, 0, 0, mid).Value);
            TCPClient.Instance.Send(fbb.SizedByteArray());
        });
    }
}
