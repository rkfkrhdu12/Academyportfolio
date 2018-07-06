using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : SlotsManager
{
    static InventoryManager instance;

    void Awake()
    {
        instance = this;

        for (int i = 0; i < SlotParent.transform.childCount; i++)
            Slots[i] = SlotParent.transform.GetChild(i).GetComponent<ItemSlot>();
    }

    public static void AddItem(PlayerSystem Item)
    {
        instance.Add(Item);
    }
}