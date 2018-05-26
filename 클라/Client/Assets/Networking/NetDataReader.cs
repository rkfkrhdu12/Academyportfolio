using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NetDataReader{

    public Dictionary<Class, Action<Base>> Reder = new Dictionary<Class, Action<Base>>();

    static NetDataReader instace;

    public static NetDataReader GetInstace()
    {
        if (instace == null) {
            instace = new NetDataReader();
        }
        return instace;
    }
    
}
