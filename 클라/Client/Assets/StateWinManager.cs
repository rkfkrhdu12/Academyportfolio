using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateWinManager : MonoBehaviour {

    [SerializeField] Text atk;
    [SerializeField] Text hp;
    [SerializeField] Text max_hp;
    [SerializeField] Text mp;
    [SerializeField] Text max_mp;
    [SerializeField] Text exp;
    [SerializeField] Text max_exp;
    [SerializeField] Text lv;

    [SerializeField] Text name;

    NetworkObject player;

    void Start () {
        name.text = "none";
        player = NetworkObject.mainPlayer.GetComponent<NetworkObject>();
        player.GetComponent<oCreature>().CurrentHP.AddEvent(HP_text);
        player.m_CurrentHP.OtherEvent(HP_text);

        player.m_CurrentMP.AddEvent(MP_text);
        player.m_CurrentMP.OtherEvent(MP_text);

        player.m_CurrentEXP.AddEvent(EXP_text);
        player.m_CurrentEXP.OtherEvent(EXP_text);

        player.m_CurrentATK.AddEvent(Attack_text);
        player.m_CurrentATK.OtherEvent(Attack_text);

        player.m_CurrentLV.AddEvent(Lv_text);
        player.m_CurrentLV.OtherEvent(Lv_text);
    }

    void HP_text()
    {
        hp.text = ""+player.m_CurrentHP.Value;
        max_hp.text = "" + MaxStatManager.MAX_HP;
    }


    void MP_text()
    {
        mp.text = "" + player.m_CurrentMP.Value;
        max_mp.text = "" + MaxStatManager.MAX_MP;
    }


    void EXP_text()
    {
        exp.text = "" + player.m_CurrentEXP.Value;
        max_exp.text = "" + MaxStatManager.MAX_EXP;
    }

    void Attack_text()
    {
        atk.text = "" + player.m_CurrentATK.Value;
    }
    void Lv_text()
    {
        lv.text = "" + player.m_CurrentLV.Value;
    }
}
