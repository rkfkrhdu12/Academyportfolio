using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxStatManager : MonoBehaviour {

    static int nomal_val = 100;
    static float nomal_tan = 0.2f;

    public static int MAX_HP {
        get { return (int)(nomal_val * (NetworkObject.mainPlayer.GetComponent<NetworkObject>().m_CurrentLV.Value * nomal_tan * 3)); }
        set { MAX_HP = value; }
    }
    public static int MAX_MP
    {
        get { return (int)(nomal_val * (NetworkObject.mainPlayer.GetComponent<NetworkObject>().m_CurrentLV.Value * nomal_tan * 2)); }
        set { MAX_MP = value; }
    }
    public static int MAX_EXP
    {
        get { return (int)( Mathf.Pow(nomal_val * NetworkObject.mainPlayer.GetComponent<NetworkObject>().m_CurrentLV.Value * nomal_tan , 3)); }
        set { MAX_EXP = value; }
    }
}
