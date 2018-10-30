using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour {

    public bool IS_ON_UI = true;
    public static System.Action MouseR_Callback = null;

	void Update () {
        if (IS_ON_UI)
        {
            if (Input.GetMouseButtonDown(1))
            {
                MouseR_Callback?.Invoke();
            }
        }
	}
}
