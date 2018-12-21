using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using FlatBuffers;






enum EKeySlot
{
    q = 0,
    w,
    e,
    r,
    a,
    s,
    d,
    f,
    last
}




public class KeySettingManager : SlotsManager
{
    public static KeySettingManager instance;

    public Dictionary<KeyCode, Action> KeyEvent = new Dictionary<KeyCode, Action>();
    public List<KeyCode> RemoveList = new List<KeyCode>();
    public List<int> mRemoveList = new List<int>();
    public Dictionary<int, KeyCode> EKey = new Dictionary<int, KeyCode>();
    public KeySlot MouseL;

    public Action[] MouseButton = new Action[2];

    public Stack<Action> ESC_Event = new Stack<Action>();

    bool OnKey = true;

    private void Awake()
    {
        EKey[(int)EKeySlot.q] = KeyCode.I;
        EKey[(int)EKeySlot.w] = KeyCode.K;
        EKey[(int)EKeySlot.e] = KeyCode.E;
        EKey[(int)EKeySlot.r] = KeyCode.R;
        EKey[(int)EKeySlot.a] = KeyCode.A;
        EKey[(int)EKeySlot.s] = KeyCode.S;
        EKey[(int)EKeySlot.d] = KeyCode.D;
        EKey[(int)EKeySlot.f] = KeyCode.F;






        instance = this;
    }

    public static void AddKey(PlayerSystem act, KeyCode key, int Mouse = -1)
    {
        foreach (var slot in instance.Slots)
        {
            if (Mouse == -1)
            {
                if (key == slot.Value.GetComponent<KeySlot>().key)
                    slot.Value.Item = act;

                if (slot.Value.GetComponent<KeySlot>().Mouse && key == KeyCode.R)
                    if (slot.Value.GetComponent<KeySlot>().MousePoint == 0)
                        slot.Value.Item = act;
            }
            else
            {
                if (slot.Value.GetComponent<KeySlot>().Mouse)
                    if (slot.Value.GetComponent<KeySlot>().MousePoint == Mouse)
                        slot.Value.Item = act;

            }
        }
    }


    public static void KeySlotUpdate()
    {
        int[] m_kslot = new int[30];
        for (int i = 0; i < 4; i++)
        {
            if (instance.Slots[i].Item != null)
            {
                if (((KeySlot)instance.Slots[i]).mItemSlotType == Slot.SlotType.Skill)
                {
                    m_kslot[i] = -instance.Slots[i].Item.id;
                }
                else
                {
                    m_kslot[i] = instance.Slots[i].Item.id;
                }
            }
            else
                m_kslot[i] = 0;
        }

        var fbb = new FlatBufferBuilder(1);
        fbb.Finish(fKeySlot.CreatefKeySlot(fbb, Class.fKeySlot, fKeySlot.CreateSlotNumVector(fbb, m_kslot)).Value);
        TCPClient.Instance.Send(fbb.SizedByteArray());
    }


    private void Start()
    {
        NetDataReader.GetInstace().Reder[Class.fKeySlot] = (data) =>
        {
            var keySlot = fKeySlot.GetRootAsfKeySlot(data.ByteBuffer);

            for (int i = 0; i < (int)EKeySlot.last; i++)
            {
                var n = keySlot.SlotNum(i);
                if (n != 0)
                {
                    if (n < 0)
                    {
                        AddKey(SkillsManager.mskills[-n - 1], EKey[i]);
                    }
                    else
                    {
                        AddKey(InventoryManager.FindSlotOfItemID(n).Item, EKey[i]);
                    }
                }
            }
        };


        MouseButton[0] = () => { };
        MouseButton[1] = () => { };


        for (int i = 0; i < SlotParent.transform.childCount; i++)
            Slots[i] = SlotParent.transform.GetChild(i).GetComponent<KeySlot>();
        Slots[Slots.Count] = MouseL;
    }

    void Update()
    {
        if (OnKey) { OnKey = false; EventManager.Event["KeySlotStart"](); }
        if (!ChatManager.IsChatOn)
        {
            foreach (var i in KeyEvent)
            {
                if (Input.GetKeyDown(i.Key))
                {
                    i.Value();
                }
            }
            if (Input.GetMouseButtonDown(0)) MouseButton[0]();
            if (Input.GetMouseButtonDown(1)) MouseButton[1]();


            foreach (var i in RemoveList)
            {
                KeyEvent.Remove(i);
            }
            foreach (var i in mRemoveList)
            {
                MouseButton[i] = () => { };
            }
            RemoveList.Clear();
            mRemoveList.Clear();


            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (ESC_Event.Count > 0)
                    ESC_Event.Pop()();
            }
        }
    }
}
