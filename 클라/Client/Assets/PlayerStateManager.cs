using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{

    NetworkObject Player;


    private void Start()
    {
        Player = GetComponent < NetworkObject > ();
    }

    public void SetOverState()
    {

        if (Player.m_CurrentHP.Value > Player.m_CurrentHPLim.Value)
            Player.m_CurrentHP.Value = Player.m_CurrentHPLim.Value;

        if (Player.m_CurrentMP.Value > Player.m_CurrentMPLim.Value)
            Player.m_CurrentMP.Value = Player.m_CurrentMPLim.Value;


        if (Player.m_CurrentEXP.Value > MaxStatManager.MAX_EXP)
            Player.m_CurrentEXP.Value = MaxStatManager.MAX_EXP;
    }

}
