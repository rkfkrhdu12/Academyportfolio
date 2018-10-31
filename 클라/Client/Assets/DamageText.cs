using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageText : MonoBehaviour {
    public void Show(int damage, bool bCri)
    {
        transform.position = Camera.main.WorldToViewportPoint(transform.position);
        if (bCri)
        {
            GetComponent<GUIText>().color = Color.red;
        }
        else
        {
            GetComponent<GUIText>().color = Color.white;
        }
        GetComponent<GUIText>().text = ""+damage;
    }



    private void Update()
    {
        transform.Translate(0, 0.5f * Time.deltaTime, 0);
    }
}
