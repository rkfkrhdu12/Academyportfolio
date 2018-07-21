using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHUD : MonoBehaviour {


    GameObject player;
    [SerializeField] GameObject HPBar;

    Vector2 HPBar_Size;

    private void Start()
    {
        player = NetworkObject.mainPlayer;
        HPBar_Size = HPBar.GetComponent<RectTransform>().sizeDelta;

    }

    void Update () {


        if (player.GetComponent<oCreature>() != null)
        {
            Action action = () =>
            {
                float max = player.GetComponent<oCreature>().MaximumHP;
                float curr = player.GetComponent<oCreature>().CurrentHP.Value;
                float size = (curr / max);

                HPBar.GetComponent<RectTransform>().sizeDelta =  new Vector2((size * HPBar_Size.x), HPBar_Size.y);
            };

            player.GetComponent<oCreature>().CurrentHP.AddEvent(action);
            player.GetComponent<NetworkObject>().m_CurrentHP.OtherEvent(action);
            GetComponent<PlayerHUD>().enabled = false;
        }
    }
}
