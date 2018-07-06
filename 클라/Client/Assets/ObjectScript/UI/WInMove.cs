using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WInMove : MonoBehaviour {

    public void Drag()
    {
        transform.SetAsLastSibling();
        transform.position = Input.mousePosition;
    }
}