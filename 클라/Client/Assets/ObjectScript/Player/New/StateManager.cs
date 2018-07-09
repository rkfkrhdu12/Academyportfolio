using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    #region singleton
    static StateManager instance = null;
    
    public static StateManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
    }
#endregion    
    player _player = player.GetInstance();

    private void Start()
    {
        _player = player.GetInstance();

        StateInit();
    }

    void StateInit()
    {
        State[] s = new State[3];
        s[(int)eState.IDLE] = new IdleState();
        s[(int)eState.MOVE] = new MoveState();
        s[(int)eState.ATTACK] = new AttackState();

        foreach (State i in s)
            _player.stateL.Add(i);

        foreach (State i in _player.stateL)
            i.Init();
    }

    private void Update()
    {
        _player.curState = eState.IDLE;

        if (_player.curMove != eMove.STOP)
        {
            _player.curState = eState.MOVE;
        }
    }
}
