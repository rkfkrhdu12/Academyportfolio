using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void GetObject(GameObject gameObject);


[RequireComponent(typeof(Rigidbody))]
public class oObject : MonoBehaviour {
    List<GetObject> Enter = new List<GetObject>();
    List<GetObject> Stay = new List<GetObject>();
    List<GetObject> Exit = new List<GetObject>();
    
    private void OnTriggerStay(Collider other)
    {
        foreach (GetObject i in Stay)
        {
            i(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        foreach (GetObject i in Exit)
        {
            i(other.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        foreach(GetObject i in Enter)
        {
            i(other.gameObject);
        }
    }
}
