using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct UIDATA
{
    public string name;
    public GameObject[] obj;
}


public class UImanager : MonoBehaviour {

    public static UImanager Instance;

    public Dictionary<string, GameObject> Data = new Dictionary<string, GameObject>();
    public UIDATA[] data;


    private void Awake()
    {
        Instance = this;
    }
    


	void Update () {
		
	}

    public void On(string Name)
    {

    }



}
