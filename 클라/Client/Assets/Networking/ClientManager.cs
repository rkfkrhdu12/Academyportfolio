using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ClientManager : MonoBehaviour {
    public static ClientManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void Send( string data )
    {
        GetComponent<TCPClient>().Send(data);
    }


}
