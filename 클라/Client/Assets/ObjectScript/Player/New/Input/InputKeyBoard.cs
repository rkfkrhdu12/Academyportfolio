using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKeyBoard
{
    //private eState _PlayerState;
    //public behavior prevBehavior;

    //public void Start()
    //{
    //    _PlayerState = player.GetInstance().curState;
    //    _InputMgrMove = InputKeyManager.GetInstance().playerMove;
    //    _PlayerSpeed = player.GetInstance().speed;
    //}

    //public void MoveUpdate()
    //{
    //    if (_PlayerState != eState.ATTACK)
    //    {
    //        MoveDataInit();

    //        Run();
    //        Move();
    //        Jump();
    //    }
    //}
    //#region MoveFuc

    //private eMove _InputMgrMove;
    //private behavior _PlayerSpeed;

    //void MoveDataInit()
    //{
    //    prevBehavior = _PlayerSpeed;
    //}

    //void Run()
    //{
    //    if (Input.GetKeyDown(KeyCode.LeftShift) && _InputMgrMove != eMove.RUN)
    //    {
    //        _InputMgrMove = eMove.RUN;
    //    }
    //}
    //void Jump()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space) && _InputMgrMove != eMove.JUMP)
    //    {
    //        _InputMgrMove = eMove.JUMP;
    //        _PlayerSpeed.gravityPower = 2;
    //    }
    //}

    //void Move()
    //{
    //    _PlayerSpeed.forward = Input.GetAxis("Vertical");
    //    _PlayerSpeed.forward = Mathf.Clamp(_PlayerSpeed.forward, -_PlayerSpeed.maxForward, _PlayerSpeed.maxForward);
        
    //    _PlayerSpeed.side = Input.GetAxis("Horizontal");
    //    _PlayerSpeed.side = Mathf.Clamp(_PlayerSpeed.side, -_PlayerSpeed.maxSide, _PlayerSpeed.maxSide);

    //    if (_InputMgrMove != eMove.RUN && _PlayerSpeed != prevBehavior)
    //        _InputMgrMove = eMove.MOVE;
    //}

    
    //#endregion

}