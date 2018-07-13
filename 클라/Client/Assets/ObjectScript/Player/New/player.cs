using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum eState
//{
//    IDLE,
//    MOVE,
//    ATTACK,
//}
//public enum eMove
//{
//    STOP,
//    MOVE,
//    RUN,
//    JUMP,
//}

   

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

    //public List<State> stateL = new List<State>();
    //public eState curState = eState.IDLE;
    //public eMove curMove = eMove.STOP;

    //public behavior speed;

    

    //private void Update()
    //{
    //    stateL[(int)curState].Update();
    //}

    public float forward;
    public float side;
    public float maxForward;// .3
    public float maxSide; // .2

    public bool IsJump;
    public float gravityPower;
    
    public float jumpPower; // 2

    public CharacterController charCtrl;
    private void Start()
    {
        // Behavior Init
        maxForward = .3f;
        maxSide = .2f;
        jumpPower = 2;
        
        // CharacterController Init
        charCtrl = transform.GetComponent<CharacterController>();
    }

    private void Update()
    {
        
    }

}