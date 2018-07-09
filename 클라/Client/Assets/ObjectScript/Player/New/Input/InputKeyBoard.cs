using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKeyBoard
{
    private eState _PlayerState;
    public behavior prevBehavior;

    public void Start()
    {
        _PlayerState = player.GetInstance().curState;
        _PlayerMove = player.GetInstance().curMove;
        _PlayerSpeed = player.GetInstance().speed;
    }

    public void Update()
    {
        MoveUpdate();
    }

    public void MoveUpdate()
    {
        if (_PlayerState != eState.ATTACK)
        {
            MoveDataInit();

            Run();
            Move();
            Jump();
        }
    }
    #region MoveFuc

    private eMove _PlayerMove;
    private behavior _PlayerSpeed;

    void MoveDataInit()
    {
        prevBehavior = _PlayerSpeed;
        _PlayerMove = eMove.STOP;
    }

    void Run()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && _PlayerMove != eMove.RUN)
        {
            _PlayerMove = eMove.RUN;
        }
    }

    void Move()
    {
        _PlayerSpeed.forward = Input.GetAxis("Vertical");
        _PlayerSpeed.forward = Mathf.Clamp(_PlayerSpeed.forward, -_PlayerSpeed.maxForward, _PlayerSpeed.maxForward);
        
        _PlayerSpeed.side = Input.GetAxis("Horizontal");
        _PlayerSpeed.side = Mathf.Clamp(_PlayerSpeed.side, -_PlayerSpeed.maxSide, _PlayerSpeed.maxSide);

        if (_PlayerMove != eMove.RUN && _PlayerSpeed != prevBehavior)
            _PlayerMove = eMove.MOVE;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_PlayerSpeed.IsJump)
        {
            _PlayerSpeed.gravityPower = 2;
        }
    }
    #endregion
}