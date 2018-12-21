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
            fbb.Finish(MonsterStat.CreateMonsterStat(fbb, Class.MonsterStat, fbb.CreateString(""),
                oCreature.CurrentHP.Value,0,
                id
                ).Value);
        }
        else if (Obj.GetComponent<oNetworkIdentity>().type == oNetworkIdentity.ObjType.player)
        {
            if (id != BPlayer.MainPlayer.GetComponent<NetworkObject>().id)
            {
                fbb.Finish(PlayerStat.CreatePlayerStat(fbb, Class.PlayerStat,
                    oCreature.CurrentHP.Value,
                    oCreature.MaximumHP,
                    oCreature.CurrentSP,
                    oCreature.MaximumSP,
                    0,
                    0,
                    oCreature.Lv, 
                    id
                    ).Value);
            }
            else
            {
                var player = BPlayer.MainPlayer.GetComponent<NetworkObject>();

                fbb.Finish(PlayerStat.CreatePlayerStat(
                    fbb, 
                    Class.PlayerStat,
                    player.m_CurrentHP.Value,
                    MaxStatManager.MAX_HP,
                    player.m_CurrentMP.Value,
                    MaxStatManager.MAX_MP,
                    player.m_CurrentEXP.Value,
                    player.m_CurrentATK.Value,
                    oCreature.Lv,
                    id
                    ).Value);
                }
        } 

        TCPClient.Instance.Send(fbb.SizedByteArray());

    }
}