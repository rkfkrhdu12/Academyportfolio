using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public PlayerSystem _Slot;
    public string _name;
    public string _info;

    public Info _InfoBox;

    private void Start()
    {
        SlotStart();
    }

    public virtual void SlotStart() { }

    public void Set(PlayerSystem slot)
    {
        _Slot = slot;
        _name = slot._name;
        _info = slot._info;
    }

    public PlayerSystem Get()
    {
        return _Slot;
    }

    // EventTrigger
    public void evEnter()
    {
        if (_name != "")
        {
            _InfoBox._isActive = true;
            _InfoBox._Infotext.text = _name + "\n\n" + _info;
        }
    }

    public void evExit()
    {
        _InfoBox._isActive = false;
        _InfoBox._Infotext.text = "";
    }

}