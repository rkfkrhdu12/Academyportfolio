using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotsManager : MonoBehaviour
{
    [SerializeField] protected GameObject SlotParent;
    protected Dictionary<int, Slot> Slots = new Dictionary<int, Slot>();

    public void Add(PlayerSystem item)
    {
        foreach(var i in Slots)
        {
            if (i.Value.Empty)
            {
                i.Value.Item = item;
                break;
            }
        }
    }


    public void Add(PlayerSystem item,int n)
    {
        Slots[n].Item = item;
    }

    void OnDisable()
    {
        BPlayer.MainPlayer._isCamera = true;
        gameObject.SetActive(false);
    }
}
