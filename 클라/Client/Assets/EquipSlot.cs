using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSlot : MonoBehaviour
{
    List<ItemSlot> mslot = new List<ItemSlot>();

    private void Start()
    {
        foreach (var Slot in GetComponentsInChildren<ItemSlot>())
        {
            mslot.Add(Slot);
        }
    }
    
    public void Add(PlayerSystem Item, int SlotNum)
    {
        mslot[SlotNum].Item = Item;
    }

}
