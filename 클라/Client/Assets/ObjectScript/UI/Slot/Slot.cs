using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Slot : MonoBehaviour
{
    public enum SlotType
    {
        Skill, Item, Key
    }

    public ReAct<PlayerSystem> item = new ReAct<PlayerSystem>();
    [SerializeField] Text number_text;

    public PlayerSystem Item
    {
        get { return item.Value; }
        set { item.Value = value; }
    }

    public int number
    {
        get { return item.Value.Number.Value; }
        set { item.Value.Number.Value = value; }
    }
    public bool Empty
    {
        get
        {
            if (item.Value == null) return true;
            else return false;
        }
    }

    public GameObject icon_Obj;
    public SlotType type;

    static bool IsMouseOn;

    public Slot TargetSlot;


    void Start()
    {
        SlotStart();
    }

    

    public void SetItemNumber()
    {
        if (number == 0)
        {
            Item = null;
            return;
        }

        if (number > 1) number_text.text = "" + number;
        else number_text.text = "";
    }

    void ShowIcon(float a)
    {
        icon_Obj.GetComponent<Image>().color = new Color(255, 255, 255, a);
    }

    void SetSlot()
    {
        if (!Empty)
        {
            ShowIcon(0.6f);
            SetItemNumber();
            Item.NumberCallback[this] = SetItemNumber;
            icon_Obj.GetComponent<Image>().sprite = Item.icon;
        }
        else
        {
            number_text.text = "";
            ShowIcon(0);
        }
    }

    public void EvEnter()
    {
        if (!IsMouseOn)
            Info.ViewThis(this);
        UI_Manager.MouseR_Callback = () => { OnMouseRCilck(); };
    }
    public void EvExit()
    {
        Info.Off();
        UI_Manager.MouseR_Callback = null;
    }

    public void MouseOn(bool OnOff)
    {
        IsMouseOn = OnOff;
        if (IsMouseOn)
        {
            transform.SetAsLastSibling();
            Info.Off();
        }
        else
        {
            Info.ViewThis(this);
        }
    }

    public void Drag()
    {
        if (!Empty)
        {
            ShowIcon(0.3f);
            icon_Obj.transform.position = Input.mousePosition;
            GetComponent<BoxCollider2D>().offset = icon_Obj.transform.localPosition;
        }
    }

    public virtual void Equipment()
    {
        if (TargetSlot && (TargetSlot.type == type))
        {
            ItemSwap();
            InventoryManager.SwapItem();
        }
        Return();
    }

    public virtual void SlotStart()
    {
        SetSlot();
        item.Event += SetSlot;
    }

    void Return()
    {
        icon_Obj.transform.localPosition = Vector2.zero;
        GetComponent<BoxCollider2D>().offset = Vector2.zero;
        TargetSlot = null;
        SetSlot();
        Info.Off();
    }
    void ItemSwap()
    {
        Item.NumberCallback.Remove(this);
        if(TargetSlot.Item != null)
            TargetSlot.Item.NumberCallback.Remove(TargetSlot);

        PlayerSystem ps = TargetSlot.Item;
        TargetSlot.Item = Item;
        Item = ps;
    }



    public virtual void OnMouseRCilck()
    {
        if (Item != null) Item.process();
    }

    void OnDisable()
    {
        Return();
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Slot>() && IsMouseOn)
            TargetSlot = collision.GetComponent<Slot>();
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        TargetSlot = null;
    }
}