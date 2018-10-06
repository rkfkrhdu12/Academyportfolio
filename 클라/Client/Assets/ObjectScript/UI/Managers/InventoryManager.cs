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


            AItem aItem = new AItem();

            AddItem(aItem.GetfItemT(item).Get(), item.Val8);
            Debug.Log("item data recv name : " + item.Name);
        };

        NetDataReader.GetInstace().Reder[Class.fInventory] = (data) => {
            var iv = fInventory.GetRootAsfInventory(data.ByteBuffer);
        };
    }


    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 200, 50), "Item 추가!"))
        {
            AcquireItems(0, 1);
        }
        if (GUI.Button(new Rect(10, 70, 200, 50), "weapon 추가!"))
        {
            AcquireItems(3, 1);
        }
    }

    public static void AcquireItems(int itemCode, int count)
    {
        var fbb = new FlatBufferBuilder(1);
        fbb.Finish(fItem.CreatefItem(fbb, Class.fItem, itemCode, fbb.CreateString(""), -1, 0, 0, 0, 0, 0, 0, 0, 0, count).Value);
        TCPClient.Instance.Send(fbb.SizedByteArray());
    }
    

    public static void SwapItem()
    {
        int[] inv = new int[30];
        for(int i = 0; i < 30; i++)
        {
            if (instance.Slots[i].Item != null)
            {
                inv[i] = instance.Slots[i].Item.id;
            }
        }

        var fbb = new FlatBufferBuilder(1);
        fbb.Finish(fInventory.CreatefInventory(fbb, Class.fInventory, fInventory.CreateSlotVector(fbb, inv)).Value);
        TCPClient.Instance.Send(fbb.SizedByteArray());
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