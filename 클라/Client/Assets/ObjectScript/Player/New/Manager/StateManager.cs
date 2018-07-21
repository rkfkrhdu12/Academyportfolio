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
    player _player;
    
    public List<State> stateList = new List<State>();

    public void Start()
    {
        _player = player.GetInstance();

        State[] s = new State[3];
        int count = 0;
        s[count++] = new IdleState();
        s[count++] = new MoveState();
        s[count++] = new AttackState();

        foreach (State i in s)
            stateList.Add(i);

        foreach (State i in stateList)
            i.statStart();
    }
    

    public void Update()
    {
        if (stateList == null) return;

        stateList[(int)_player.curState].Update();
    }
}
