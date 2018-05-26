using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject _Object;
    public List<Slot> _SlotBox = new List<Slot>();

    // fuc
    public void SetItem(PlayerSystem item)
    {
        foreach (Slot i in _SlotBox)
        {
            if (i._name == "")
            {
                i.Set(item);
                break;
            }
        }
    }

    // EventTrigger
    public virtual void evExit()
    {
    }

    public void evPardon()
    {
        _Object.GetComponent<Transform>().position = Input.mousePosition;
    }
}
