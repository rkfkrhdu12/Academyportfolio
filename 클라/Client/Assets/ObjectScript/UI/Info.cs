using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour
{
    public static Info info;

    public GameObject _InfoBox;
    
    // 싱글턴 선언 //
    void Awake(){ info = this; }

    public static void ViewThis(Slot slot)
    {
        On();
        if (!slot.Empty)
            info._InfoBox.GetComponentInChildren<Text>().text = 
                slot.Item._name + "\n\n" + slot.Item._info;
        else
            info._InfoBox.GetComponentInChildren<Text>().text = "빈슬롯.";
    }

    public static void On()
    {
        info._InfoBox.GetComponent<Transform>().position = Input.mousePosition;
        info._InfoBox.SetActive(true);
        info._InfoBox.transform.SetAsLastSibling();
    }
    public static void Off()
    {
        info._InfoBox.SetActive(false);
    }
}
