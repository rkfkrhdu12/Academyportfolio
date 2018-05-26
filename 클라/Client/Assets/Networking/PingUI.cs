using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PingUI : MonoBehaviour {
    void Start()
    {
        GetPing.iping.AddEvent(pingShow);
        GetPing.MaxPing.AddEvent(pingShow);
    }



    void pingShow()
    {
        GetComponent<Text>().text = "" + GetPing.iping.Value + " ms\n최대 : " + GetPing.MaxPing.Value + " ms";
    }
}
