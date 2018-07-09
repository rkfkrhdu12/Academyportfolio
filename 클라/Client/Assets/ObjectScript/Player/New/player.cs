using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eState
{
    IDLE,
    MOVE,
    ATTACK,
}
public enum eMove
{
    STOP,
    MOVE,
    RUN,
}

public struct behavior
{
    public float forward;
    public float maxForward;// .3
    public float side;
    public float maxSide; // .2

    public bool IsJump;
    public float gravityPower;
    #region operator
    public static bool operator ==(behavior a, behavior b)
    {
        if (a.forward == b.forward && a.side == b.side) return true;
        else return false;
    }
    public static bool operator !=(behavior a, behavior b)
    {
        if (a.forward != b.forward && a.side != b.side) return true;
        else return false;
    }
    public override int GetHashCode() { return base.GetHashCode(); }
    public override bool Equals(object obj) { return base.Equals(obj); }
#endregion
    //public float jumpPower; // 2
}

public class player : MonoBehaviour
{
    #region singleton
    static player instance = null;
    public static player GetInstance()
    {
        return instance;
    }

    void Awake()
    {
        instance = this;
    }
    #endregion

    public List<State> stateL = new List<State>();
    public eState curState = eState.IDLE;
    public eMove curMove = eMove.STOP;
    public CharacterController charCtrl;

    public behavior speed;

    private void Start()
    {
        charCtrl = transform.GetComponent<CharacterController>();
    }
    
    private void Update()
    {
        stateL[(int)curState].Update();
    }
    
}