using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FlatBuffers;

public class InventoryManager : SlotsManager
{
    static InventoryManager instance;

    void Awake()
    {
        instance = this;

        for (int i = 0; i < SlotParent.transform.childCount; i++)
            Slots[i] = SlotParent.transform.GetChild(i).GetComponent<ItemSlot>();
    }

    private void Start()
    {
        NetDataReader.GetInstace().Reder[Class.fItem] = (data) => {
            var item = fItem.GetRootAsfItem(data.ByteBuffer);
			Debug.Log("item data recv name : "+item.Name);
        };

        NetDataReader.GetInstace().Reder[Class.fInventory] = (data) => {
            var iv = fInventory.GetRootAsfInventory(data.ByteBuffer);
        };
    }







    public static void AddItem(PlayerSystem Item)
    {
        instance.Add(Item);
    }
}