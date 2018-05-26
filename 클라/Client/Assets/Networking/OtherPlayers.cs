using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherPlayers : MonoBehaviour {


    public GameObject PlayerPrifab;
    Dictionary<int, OtherPlayer> OPlayers = new Dictionary<int, OtherPlayer>();

    void Start () {
        NetDataReader.GetInstace().Reder[Class.Player] = (data) => {
            var m_player = Player.GetRootAsPlayer(data.ByteBuffer);

            if (m_player.ID != NetworkObject.mainPlayer.GetComponent<oNetworkManager>().id) {
                if (!OPlayers.ContainsKey(m_player.ID))
                {
                    var obj = Instantiate(PlayerPrifab, Vector3.zero, Quaternion.identity);
                    obj.AddComponent<OtherPlayer>();
                    obj.AddComponent<oNetworkIdentity>().id = m_player.ID;
                    OPlayers[m_player.ID] = obj.GetComponent<OtherPlayer>();
                    Debug.Log(m_player.ID);
                    SendToMe_PlayerStat.Send(m_player.ID);
                }

                OPlayers[m_player.ID].UpdateOtherObj(m_player);
            }
        };

        NetDataReader.GetInstace().Reder[Class.PlayerStat] = (data) => {
            var _PlayerStat = PlayerStat.GetRootAsPlayerStat(data.ByteBuffer);
           
            if (_PlayerStat.ID == NetworkObject.mainPlayer.GetComponent<oNetworkManager>().id)
            {
                NetworkObject.mainPlayer.GetComponent<oCreature>().Data_Update(_PlayerStat);
                NetworkObject.mainPlayer.GetComponent<NetworkObject>().m_CurrentHP.NoEventSet(_PlayerStat.HP);
            }
            else
            {
                if (OPlayers[_PlayerStat.ID].GetComponent<oCreature>() == null)
                {
                    OPlayers[_PlayerStat.ID].gameObject.AddComponent<oCreature>();
                    OPlayers[_PlayerStat.ID].gameObject.GetComponent<OtherPlayer>().SetStatEvent();
                }

                OPlayers[_PlayerStat.ID].gameObject.GetComponent<oCreature>().Data_Update(_PlayerStat);
            }
        };



    }
}
