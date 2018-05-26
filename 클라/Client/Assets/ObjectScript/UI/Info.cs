using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour
{
    public GameObject _InfoBox;
    public Text _Infotext;

    public bool _isActive = false;
    
    void Update()
    {
        if (_isActive)
        {
            _InfoBox.SetActive(true);
            _InfoBox.GetComponent<Transform>().position = Input.mousePosition;
        }
        else
        {
            _InfoBox.SetActive(false);
        }
    }
}
