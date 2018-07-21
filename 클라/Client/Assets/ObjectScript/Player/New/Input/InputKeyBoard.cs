using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKeyBoard
{
    private player _player;
    private eState _playerState;

    private InputKeyManager Mgr;
    private Vector3 _moveVec;

    public void Start()
    {
        _player = player.GetInstance();
        _playerState = player.GetInstance().curState;
        Mgr = InputKeyManager.GetInstance();
    }

    public void Update()
    {
        DataInit();

        if (_playerState != eState.ATTACK)
        {
            inputMove();

            DataSend();
        }
    }
    #region MoveFuc

    void DataInit()
    {
        _player.curState = eState.IDLE;
    }

    void DataSend()
    {
        Mgr.moveVec = _moveVec;
    }

    void inputMove()
    {

        // Move
        _player.moveVec.z = Input.GetAxis("Vertical");
        _player.moveVec.z = Mathf.Clamp(_player.moveVec.z, -_player.maxForward, _player.maxForward);

        _player.moveVec.x = Input.GetAxis("Horizontal");
        _player.moveVec.x = Mathf.Clamp(_player.moveVec.x, -_player.maxSide, _player.maxSide);

        if (_player.moveVec.z != 0 || _player.moveVec.x != 0)
        {
            _player.curState = eState.MOVE;
        }

        // Run
        if (Input.GetKeyDown(KeyCode.LeftShift) && _player.curState == eState.MOVE)
            _player._movementSpeed *= 2;
        else if (Input.GetKeyUp(KeyCode.LeftShift))
            _player._movementSpeed /= 2;

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && _player.isJump)
        {
            _player.isJump = false;
            _player.gravityPower = 6;
        }

        _player.moveVec.Normalize();
    }
    #endregion

}