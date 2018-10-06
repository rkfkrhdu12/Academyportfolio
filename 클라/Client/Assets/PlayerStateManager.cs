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

        if (Player.m_CurrentHP.Value > MaxStatManager.MAX_HP)
            Player.m_CurrentHP.Value = MaxStatManager.MAX_HP;

        if (Player.m_CurrentMP.Value > MaxStatManager.MAX_MP)
            Player.m_CurrentMP.Value = MaxStatManager.MAX_MP;


        if (Player.m_CurrentEXP.Value > MaxStatManager.MAX_EXP)
            Player.m_CurrentEXP.Value = MaxStatManager.MAX_EXP;
    }

}
