using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oNetworkIdentity : MonoBehaviour {
    public enum ObjType
    {
        player, monster
    }

    public int id;
    public ObjType type;
}
