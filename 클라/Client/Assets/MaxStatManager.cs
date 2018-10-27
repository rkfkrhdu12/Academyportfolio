using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxStatManager : MonoBehaviour {

    static int nomal_val = 100;
    static float nomal_tan = 0.2f;

    public static int MAX_HP {
        get { return (int)((NetworkObject.mainPlayer.GetComponent<NetworkObject>().m_CurrentHPLim.Value)); }
        set { MAX_HP = value; }
    }
    public static int MAX_MP
    {
        get { return (int)((NetworkObject.mainPlayer.GetComponent<NetworkObject>().m_CurrentMPLim.Value)); }
        set { MAX_MP = value; }
    }
    public static int MAX_EXP
    {
        get { return (int)((NetworkObject.mainPlayer.GetComponent<NetworkObject>().m_CurrentLV.Value * 30) + (NetworkObject.mainPlayer.GetComponent<NetworkObject>().m_CurrentLV.Value * NetworkObject.mainPlayer.GetComponent<NetworkObject>().m_CurrentLV.Value)); }
        set { MAX_EXP = value; }
    }
}
