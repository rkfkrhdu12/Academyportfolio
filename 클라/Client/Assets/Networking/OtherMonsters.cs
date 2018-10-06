using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherMonsters : MonoBehaviour {

    public GameObject MonsterPrefab;
    Dictionary<int, OtherMonster> Monsters = new Dictionary<int, OtherMonster>();

    void Start () {
        NetDataReader.GetInstace().Reder[Class.Monster] = (data) =>
        {
            var m_Monster = Monster.GetRootAsMonster(data.ByteBuffer);

            if (!Monsters.ContainsKey(m_Monster.ID))
            {
                var Pos= m_Monster.Pos.Value;
                var obj = Instantiate(MonsterPrefab, new Vector3(Pos.X, Pos.Y, Pos.Z), Quaternion.identity);
                obj.AddComponent<oNetworkIdentity>().id = m_Monster.ID;
                obj.GetComponent<oNetworkIdentity>().type = oNetworkIdentity.ObjType.monster;
                Monsters[m_Monster.ID] = obj.AddComponent<OtherMonster>();
                SendToMe_MonsterStat.Send(m_Monster.ID);
            }

            Monsters[m_Monster.ID].PosUpdate(m_Monster);

        };

        NetDataReader.GetInstace().Reder[Class.MonsterStat] = (data) =>
        {
            var _MonsterStat = MonsterStat.GetRootAsMonsterStat(data.ByteBuffer);

            if (Monsters.ContainsKey(_MonsterStat.ID))
            {
                if (Monsters[_MonsterStat.ID].GetComponent<oCreature>() == null)
                {
                    Monsters[_MonsterStat.ID].gameObject.AddComponent<oCreature>();
                    Monsters[_MonsterStat.ID].gameObject.GetComponent<oCreature>().CurrentHP.NoEventSet(_MonsterStat.HP);
                    Monsters[_MonsterStat.ID].gameObject.GetComponent<oCreature>().MaximumHP = _MonsterStat.HP;
                    Monsters[_MonsterStat.ID].gameObject.GetComponent<OtherMonster>().SetStatEvent();
                }

                Monsters[_MonsterStat.ID].gameObject.GetComponent<oCreature>().Data_Update(_MonsterStat);
            }
        };

    }
    

}
