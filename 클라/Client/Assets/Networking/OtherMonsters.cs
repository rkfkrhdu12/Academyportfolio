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
                var obj = Instantiate(MonsterPrefab, Vector3.zero, Quaternion.identity);
                obj.AddComponent<OtherMonster>().MonsterID = m_Monster.ID;
                Monsters[m_Monster.ID] = obj.GetComponent<OtherMonster>();
                Debug.Log(m_Monster.ID);
            }

            Monsters[m_Monster.ID].PosUpdate(m_Monster);

        };
    }
}
