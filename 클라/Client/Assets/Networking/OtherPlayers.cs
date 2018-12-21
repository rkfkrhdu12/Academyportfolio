using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherPlayers : MonoBehaviour
{

    public static OtherPlayers instance;

    public GameObject PlayerPrifab;
    public Dictionary<int, OtherPlayer> OPlayers = new Dictionary<int, OtherPlayer>();

    private void Awake()
    {
        instance = this;
    }

    public string GetName(int id)
    {
        if (BPlayer.MainPlayer.GetComponent<oNetworkIdentity>().id == id)
        {
            return "나";
        }

        return OPlayers[id].gameObject.name;
    }

    void Start () {
        oNetworkManager MainPlayer = NetworkObject.mainPlayer.GetComponent<oNetworkManager>();

        NetDataReader.GetInstace().Reder[Class.Player] = (data) => {
            var m_player = Player.GetRootAsPlayer(data.ByteBuffer);

            if (m_player.ID != MainPlayer.id) {
                if (!OPlayers.ContainsKey(m_player.ID))
                {
                    var obj = Instantiate(PlayerPrifab, Vector3.zero, Quaternion.identity);
                    obj.AddComponent<OtherPlayer>();
                    obj.AddComponent<oNetworkIdentity>().id = m_player.ID;
                    obj.GetComponent<oNetworkIdentity>().type = oNetworkIdentity.ObjType.player;
                    OPlayers[m_player.ID] = obj.GetComponent<OtherPlayer>();
                    SendToMe_PlayerStat.Send(m_player.ID);
                }

                OPlayers[m_player.ID].UpdateOtherObj(m_player);
            }
            else if (m_player.ID == MainPlayer.id)
            {
                var pos = m_player.Pos.Value;
                MainPlayer.transform.position.Set(pos.X, pos.Y, pos.Z);
            }
        };






        NetDataReader.GetInstace().Reder[Class.FirstCharacterData] = (data) =>
        {
            var FirstPlayerData = FirstCharacterData.GetRootAsFirstCharacterData(data.ByteBuffer);


            var fbb = new FlatBuffers.FlatBufferBuilder(1);

            fbb.Finish(PlayerStat.CreatePlayerStat(
                fbb,
                Class.PlayerStat,
                FirstPlayerData.HP,
                FirstPlayerData.HPLim,
                FirstPlayerData.MP,
                FirstPlayerData.MPLim,
                FirstPlayerData.EXP,
                FirstPlayerData.Attack,
                FirstPlayerData.LV,
                FirstPlayerData.ID
            ).Value);
            
            var buf = new FlatBuffers.ByteBuffer(fbb.SizedByteArray());

            var _PlayerStat = PlayerStat.GetRootAsPlayerStat(buf);

            var pos = FirstPlayerData.Pos.Value;
            MainPlayer.GetComponent<oCreature>().Data_Update(_PlayerStat);
            MainPlayer.GetComponent<oCreature>().Data_Update(pos);
            MainPlayer.GetComponent<NetworkObject>().m_CurrentHP.NoEventSet(_PlayerStat.HP);
            MainPlayer.GetComponent<NetworkObject>().m_CurrentMP.NoEventSet(_PlayerStat.MP);
            MainPlayer.GetComponent<NetworkObject>().m_CurrentHPLim.NoEventSet(_PlayerStat.HPLim);
            MainPlayer.GetComponent<NetworkObject>().m_CurrentMPLim.NoEventSet(_PlayerStat.MPLim);
            MainPlayer.GetComponent<NetworkObject>().m_CurrentLV.NoEventSet(_PlayerStat.LV);
            MainPlayer.GetComponent<NetworkObject>().m_CurrentEXP.NoEventSet(_PlayerStat.EXP);
            MainPlayer.GetComponent<NetworkObject>().m_CurrentATK.NoEventSet(_PlayerStat.Attack);
            
            MainPlayer.GetComponent<NetworkObject>().CharacterName.NoEventSet(FirstPlayerData.Name);
            Vector3 v3 = new Vector3();
            v3.Set(pos.X, pos.Y, pos.Z);
        };




        NetDataReader.GetInstace().Reder[Class.fEquipSome] = (data) =>
        {
            var equipSome = fEquipSome.GetRootAsfEquipSome(data.ByteBuffer);
            Debug.Log(MainPlayer.GetComponent<oNetworkIdentity>().id +":"+ equipSome.PID + ":"+ equipSome.SlotNum + ":" + equipSome.ObjNum);
            if (MainPlayer.GetComponent<oNetworkIdentity>().id == equipSome.PID)
            {
                MainPlayer.GetComponent<EquipManager>().Equip(equipSome.ObjNum, equipSome.SlotNum);
            }
            else
            {
                OPlayers[equipSome.PID].GetComponent<EquipManager>().Equip(equipSome.ObjNum,-1);
            }
        };


        NetDataReader.GetInstace().Reder[Class.PlayerStat] = (data) => {
            var _PlayerStat = PlayerStat.GetRootAsPlayerStat(data.ByteBuffer);
            var player = MainPlayer.GetComponent<NetworkObject>();

            if (_PlayerStat.ID == MainPlayer.id)
            {
                MainPlayer.GetComponent<oCreature>().Data_Update(_PlayerStat);
                player.m_CurrentHP.NoEventSet(_PlayerStat.HP);
                player.m_CurrentMP.NoEventSet(_PlayerStat.MP);
                player.m_CurrentHPLim.NoEventSet(_PlayerStat.HPLim);
                player.m_CurrentMPLim.NoEventSet(_PlayerStat.MPLim);
                player.m_CurrentEXP.NoEventSet(_PlayerStat.EXP);
                player.m_CurrentATK.NoEventSet(_PlayerStat.Attack);
                if (_PlayerStat.LV > player.m_CurrentLV.Value)
                {
                    IG_EffectManager.Show(player.gameObject.transform.position, "LVUP");
                }
                player.m_CurrentLV.NoEventSet(_PlayerStat.LV);


            }
            else if(OPlayers.ContainsKey(_PlayerStat.ID))
            {
                if (OPlayers[_PlayerStat.ID].GetComponent<oCreature>() == null)
                {
                    OPlayers[_PlayerStat.ID].gameObject.AddComponent<oCreature>();
                    OPlayers[_PlayerStat.ID].gameObject.AddComponent<SendStateManager>();
                    OPlayers[_PlayerStat.ID].gameObject.GetComponent<OtherPlayer>().SetStatEvent();
                    OPlayers[_PlayerStat.ID].gameObject.name = _PlayerStat.NikName;
                }

                OPlayers[_PlayerStat.ID].gameObject.GetComponent<oCreature>().Data_Update(_PlayerStat);
            }
        };
    }


}



