using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FlatBuffers;

public class InventoryManager : SlotsManager
{
    static InventoryManager instance;
    Queue<int> slotNumber;

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

            AItem aItem = new AItem();

            InventoryManager.AddItem(aItem.GetfItemT(item).Get(), item.Id);

			Debug.Log("item data recv name : "+item.Name);
        };

        NetDataReader.GetInstace().Reder[Class.fInventory] = (data) => {
            var iv = fInventory.GetRootAsfInventory(data.ByteBuffer);
        };
    }





    public static void AddItem(PlayerSystem Item, int S_n)
    {
        instance.Add(Item, S_n);
    }

    public static void AddItem(PlayerSystem Item)
    {
        instance.Add(Item);
    }
}