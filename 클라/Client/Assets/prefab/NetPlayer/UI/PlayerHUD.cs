using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{


    GameObject player;
    [SerializeField] GameObject HPBar;
    [SerializeField] GameObject MPBar;
    [SerializeField] GameObject EXPBar;

    [SerializeField] Text Lv;
    [SerializeField] Text backLv;

    Vector2 HPMPBar_Size;
    Vector2 ExpBarSize;


    private void Start()
    {
        player = NetworkObject.mainPlayer;
        HPMPBar_Size = HPBar.GetComponent<RectTransform>().sizeDelta;
        ExpBarSize = EXPBar.GetComponent<RectTransform>().sizeDelta;

    }

    void Bar(float maxStat, float Stat, GameObject obj, Vector2 size)
    {
        obj.GetComponent<RectTransform>().sizeDelta = new Vector2(((Stat / maxStat) * size.x), size.y);
    }

    void HP_bar()
    {
        Bar(player.GetComponent<NetworkObject>().m_CurrentHPLim.Value,
            player.GetComponent<oCreature>().CurrentHP.Value,
            HPBar,
            HPMPBar_Size
            );
    }


    void MP_bar()
    {
        Bar(
            player.GetComponent<NetworkObject>().m_CurrentMPLim.Value,
            player.GetComponent<NetworkObject>().m_CurrentMP.Value,
            MPBar,
            HPMPBar_Size
            );
    }


    void EXP_bar()
    {
        Bar(
            ((player.GetComponent<NetworkObject>().m_CurrentLV.Value * 30) + (player.GetComponent<NetworkObject>().m_CurrentLV.Value * player.GetComponent<NetworkObject>().m_CurrentLV.Value)),
            player.GetComponent<NetworkObject>().m_CurrentEXP.Value,
            EXPBar,
            ExpBarSize
            );
    }



    void Update()
    {
        if (player.GetComponent<oCreature>() != null)
        {
            player.GetComponent<oCreature>().CurrentHP.AddEvent(HP_bar);
            player.GetComponent<NetworkObject>().m_CurrentHP.OtherEvent(HP_bar);
            player.GetComponent<NetworkObject>().m_CurrentHPLim.OtherEvent(HP_bar);
            player.GetComponent<NetworkObject>().m_CurrentMPLim.OtherEvent(MP_bar);
            player.GetComponent<NetworkObject>().m_CurrentHPLim.AddEvent(HP_bar);
            player.GetComponent<NetworkObject>().m_CurrentMPLim.AddEvent(MP_bar);
            player.GetComponent<NetworkObject>().m_CurrentMP.AddEvent(MP_bar);
            player.GetComponent<NetworkObject>().m_CurrentEXP.AddEvent(EXP_bar);
            player.GetComponent<NetworkObject>().m_CurrentMP.OtherEvent(MP_bar);
            player.GetComponent<NetworkObject>().m_CurrentEXP.OtherEvent(EXP_bar);

            player.GetComponent<NetworkObject>().m_CurrentLV.OtherEvent(()=> {
                Lv.text = ""+player.GetComponent<NetworkObject>().m_CurrentLV.Value;
                backLv.text = Lv.text;
            });
            GetComponent<PlayerHUD>().enabled = false;
        }
    }
}
