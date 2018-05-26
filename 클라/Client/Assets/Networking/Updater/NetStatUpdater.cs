using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlatBuffers;

public class NetStatUpdater{
    
    public void Updater (GameObject Player) {


        int id = Player.GetComponent<oNetworkIdentity>().id;
        oCreature oCreature = Player.GetComponent<oCreature>();
        
        var fbb = new FlatBufferBuilder(1);
        fbb.Finish(PlayerStat.CreatePlayerStat(fbb, Class.PlayerStat, 
            oCreature.CurrentHP.Value, 
            oCreature.MaximumHP , 
            oCreature.CurrentSP , 
            oCreature.MaximumSP , 
            oCreature.Lv, id
            ).Value);

        TCPClient.Instance.Send(fbb.SizedByteArray());
    }
}