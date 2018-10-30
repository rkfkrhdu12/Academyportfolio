using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour {

    [SerializeField] float t;

	void Start () {
        Destroy(gameObject,t);
	}
	
}
