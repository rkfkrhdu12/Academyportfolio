using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlatBuffers;

public class NetStatUpdater{
    
    public void Updater (GameObject Obj) {
        int id = Obj.GetComponent<oNetworkIdentity>().id;
        oCreature oCreature = Obj.GetComponent<oCreature>();

        var fbb = new FlatBufferBuilder(1);

        if (Obj.GetComponent<oNetworkIdentity>().type == oNetworkIdentity.ObjType.monster)
        {
            fbb.Finish(MonsterStat.CreateMonsterStat(fbb,Class.MonsterStat,
                oCreature.CurrentHP.Value,
                id
                ).Value);
        }
        else if (Obj.GetComponent<oNetworkIdentity>().type == oNetworkIdentity.ObjType.player)
        {
            fbb.Finish(PlayerStat.CreatePlayerStat(fbb, Class.PlayerStat,
                oCreature.CurrentHP.Value,
                oCreature.MaximumHP,
                oCreature.CurrentSP,
                oCreature.MaximumSP,
                oCreature.Lv, id
                ).Value);
        } 

        TCPClient.Instance.Send(fbb.SizedByteArray());

    }
}