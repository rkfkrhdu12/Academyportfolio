using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : UIManager
{
    void Awake()
    {
        _Object = GameObject.Find("Inventory");

        // Slot
        GameObject SlotBox = _Object.transform.GetChild(1).gameObject;

        for (int i = 0; i < SlotBox.transform.childCount; i++)
            _SlotBox.Add(SlotBox.transform.GetChild(i).GetComponent<ItemSlot>());

        _Object.GetComponent<Transform>().localPosition = new Vector3(0, 180, 0);

        _Object.SetActive(false);
    }
    
    // EventTrigger
    public override void evExit()
    {
        GameObject.Find("Player").GetComponent<BPlayer>()._isCamera = true;
        _Object.SetActive(false);
    }

}