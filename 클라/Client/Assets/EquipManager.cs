using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipManager : MonoBehaviour
{
    public GameObject[] mEquipKey;

    public void Equip(int key, int slotNum)
    {
        //if (key == 0) return;
        if (slotNum != -1)
        {
            if (key < 0)
                EquipSlot.instance.Add(null ,slotNum);
        }

        if (key < 0)
            mEquipKey[-key].SetActive(false);
        else
            mEquipKey[key].SetActive(true);
    }
}
