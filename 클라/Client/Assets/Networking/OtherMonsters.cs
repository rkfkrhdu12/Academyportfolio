using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherMonsters : MonoBehaviour
{

    public GameObject MonsterPrefab;
    Dictionary<int, OtherMonster> Monsters = new Dictionary<int, OtherMonster>();

    Dictionary<int, System.Action<string>> GetMonsters = new Dictionary<int, System.Action<string>>();
    Dictionary<string, string> GetMonsNameKR = new Dictionary<string, string>();


    void Start()
    {
        GetMonsNameKR["hobgoblin"] = "홉고블린";
        GetMonsNameKR["Goblin"] = "고블린";






        NetDataReader.GetInstace().Reder[Class.Monster] = (data) =>
        {
            var m_Monster = Monster.GetRootAsMonster(data.ByteBuffer);

            if (!Monsters.ContainsKey(m_Monster.ID) && !GetMonsters.ContainsKey(m_Monster.ID))
            {
                GetMonsters[m_Monster.ID] = (MonName) =>
                {
                    var Pos = m_Monster.Pos.Value;
                    var obj = Instantiate(Resources.Load<GameObject>(MonName), new Vector3(Pos.X, Pos.Y, Pos.Z), Quaternion.identity);
                    obj.AddComponent<oNetworkIdentity>().id = m_Monster.ID;
                    obj.GetComponent<oNetworkIdentity>().type = oNetworkIdentity.ObjType.monster;
                    Monsters[m_Monster.ID] = obj.AddComponent<OtherMonster>();
                    Monsters[m_Monster.ID].PosUpdate(m_Monster);
                };
                SendToMe_MonsterStat.Send(m_Monster.ID);

            }



            if (Monsters.ContainsKey(m_Monster.ID))
            {
                if (m_Monster.Ani == 0.2f)
                {
                    Transform lookPos;
                    if(m_Monster.TargetID == BPlayer.MainPlayer.GetComponent<oNetworkIdentity>().id)
                    {
                        lookPos = BPlayer.MainPlayer.transform;
                    }
                    else
                    {
                        lookPos = OtherPlayers.instance.OPlayers[m_Monster.TargetID].gameObject.transform;
                    }
                    
                    Monsters[m_Monster.ID].gameObject.transform.LookAt(new Vector3(lookPos.position.x, Monsters[m_Monster.ID].gameObject.transform.position.y, lookPos.position.z),Vector3.up);
                }
                Monsters[m_Monster.ID].PosUpdate(m_Monster);
            }

        };

        NetDataReader.GetInstace().Reder[Class.MonsterStat] = (data) =>
        {
            var _MonsterStat = MonsterStat.GetRootAsMonsterStat(data.ByteBuffer);

            if (GetMonsters.ContainsKey(_MonsterStat.ID))
            {
                GetMonsters[_MonsterStat.ID](_MonsterStat.MonName);
                GetMonsters.Remove(_MonsterStat.ID);
            }
            if (Monsters.ContainsKey(_MonsterStat.ID))
            {

                if (Monsters[_MonsterStat.ID].GetComponent<oCreature>() == null)
                {
                    Monsters[_MonsterStat.ID].name = GetMonsNameKR[_MonsterStat.MonName];
                    
                    Monsters[_MonsterStat.ID].gameObject.AddComponent<oCreature>();
                    Monsters[_MonsterStat.ID].gameObject.GetComponent<oCreature>().CurrentHP.NoEventSet(_MonsterStat.HP);
                    Monsters[_MonsterStat.ID].gameObject.GetComponent<oCreature>().MaximumHP = _MonsterStat.MAXHP;
                    Monsters[_MonsterStat.ID].gameObject.GetComponent<OtherMonster>().SetStatEvent();
                }

                Monsters[_MonsterStat.ID].gameObject.GetComponent<oCreature>().Data_Update(_MonsterStat);
            }
        };

    }


}
