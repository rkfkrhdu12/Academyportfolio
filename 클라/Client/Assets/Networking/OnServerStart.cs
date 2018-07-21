using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OnServerStart : MonoBehaviour
{

    public static List<oNetworkManager> Event = new List<oNetworkManager>();




    public void Started(int id)
    {
        foreach (var i in Event)
        {
            i.id = id;
            i.NetworkStarting();
        }

        Destroy(GetComponent<OnServerStart>());
    }
}
