using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static Dictionary<string, System.Action> Event = new Dictionary<string, System.Action>();
}
