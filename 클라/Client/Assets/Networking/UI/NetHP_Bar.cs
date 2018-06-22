using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class NetHP_Bar : MonoBehaviour {

    [SerializeField] GameObject HPBar;
    

    void Update()
    {
        if (GetComponentInParent<oCreature>() != null)
        {
            Action action = () =>
            {
                float max = GetComponentInParent<oCreature>().MaximumHP;
                float curr = GetComponentInParent<oCreature>().CurrentHP.Value;
                float size = (curr / max) * 100;

                HPBar.GetComponent<RectTransform>().sizeDelta = new Vector2(size * 0.02f, 0.14f);
            };
            action();
            GetComponentInParent<oCreature>().CurrentHP.AddEvent(action);
            GetComponentInParent<oCreature>().CurrentHP.OtherEvent(action);
            GetComponent<NetHP_Bar>().enabled = false;
        }
    }
}
