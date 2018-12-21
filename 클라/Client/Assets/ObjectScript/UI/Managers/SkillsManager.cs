using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlatBuffers;

public class SkillsManager : SlotsManager
{
    static SkillsManager instance;
    public static List<PlayerSystem> mskills = new List<PlayerSystem>();


    void Awake()
    {
        instance = this;

        for (int i = 0; i < SlotParent.transform.childCount; i++)
            Slots[i] = SlotParent.transform.GetChild(i).GetComponent<SkillSlot>();
    }

    private void Start()
    {
        NetDataReader.GetInstace().Reder[Class.fSkillSlot] = (data) =>
        {
            var SkS = fSkillSlot.GetRootAsfSkillSlot(data.ByteBuffer);
            for (int i = 0; i < 30; i++)
            {
                var n = SkS.SlotNum(i);
                if (n != 0)
                {
                    AddSkill(n - 1);
                }
            }
        };
    }
    
    public static void AddSkill(PlayerSystem Skill)
    {
        instance.Add(Skill);
        instance.SkillDataUpdate();
    }

    public static void SetSkillCode()
    {
        for (int i = 0; i < mskills.Count; i++)
        {
            mskills[i].id = i + 1;
        }
    }

    public static void AddSkill(int SkillNum)
    {
        instance.Add(mskills[SkillNum]);
    }

    void SkillDataUpdate()
    {
        int[] Skills = new int[30];
        for (int i = 0; i < 16; i++)
        {
            if (Slots[i].Item != null)
                Skills[i] = Slots[i].Item.id;
            else
                Skills[i] = 0;
        }

        var fbb = new FlatBufferBuilder(1);
        fbb.Finish(fSkillSlot.CreatefSkillSlot(fbb, Class.fSkillSlot, fSkillSlot.CreateSlotNumVector(fbb, Skills)).Value);
        TCPClient.Instance.Send(fbb.SizedByteArray());
    }
}
