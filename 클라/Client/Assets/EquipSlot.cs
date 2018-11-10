using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlatBuffers;

public class EquipSlot : MonoBehaviour
{
    List<ItemSlot> mslot = new List<ItemSlot>();

    private void Start()
    {
        NetDataReader.GetInstace().Reder[Class.fEquipSlots] = (data) =>
        {
            var mitem = fItem.GetRootAsfItem(data.ByteBuffer);

            Add(new AItem().GetfItemT(mitem).Get(), mitem.Val8);
        };

        foreach (var Slot in GetComponentsInChildren<ItemSlot>())
        {
            mslot.Add(Slot);
            Slot.item.Event += UpdateSlot;
        }
    }

    public void Add(PlayerSystem Item, int SlotNum)
    {
        mslot[SlotNum].Item = Item;
    }

    void UpdateSlot()
    {
        int n = 0;
        int[] slot = new int[mslot.Count];
        foreach (var i in mslot)
        {
            slot[n] = 0;
            if (!i.Empty) slot[n] = i.Item.id;
            n++;
        }
        var fbb = new FlatBufferBuilder(1);
        fbb.Finish(fEquip.CreatefEquip(fbb, Class.fEquip, slot[0] , slot[1], slot[2], slot[3]).Value);
        TCPClient.Instance.Send(fbb.SizedByteArray());
    }
}
