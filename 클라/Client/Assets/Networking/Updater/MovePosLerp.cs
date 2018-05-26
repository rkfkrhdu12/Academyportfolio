using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePosLerp{

    public float SyncT = 0f;

    float dlt = 0f;
    float Last_dlt = 0f;


    public void LerpPos(ref Vector3 end , Vector3 Vel)
    {
        SyncT = 0f;
        dlt = Time.time - Last_dlt;
        Last_dlt = Time.time;
        
        end = end + Vel * dlt;
    }



    public float LerpT()
    {
        return SyncT / dlt;
    }
}
