using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateManager : MonoBehaviour {

    [SerializeField] [Range(.01f, 10f)] public float DateRate;


    void Update () {
        transform.Rotate(DateRate * Time.deltaTime, 0, 0);
	}
}
