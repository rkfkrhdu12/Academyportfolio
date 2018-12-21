using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PingUI : MonoBehaviour {


    public static int ping;


    void Start()
    {
        GetPing.iping.AddEvent(pingShow);
        GetPing.MaxPing.AddEvent(pingShow);
    }


    private void Update()
    {
        GetPing.iping.Value = ping;
    }



    void pingShow()
    {
        GetComponent<Text>().text = "" + GetPing.iping.Value + " ms\n최대 : " + GetPing.MaxPing.Value + " ms";
    }
}
