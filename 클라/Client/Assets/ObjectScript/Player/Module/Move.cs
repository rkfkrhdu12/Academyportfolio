using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : Module
{
    public override void Update()
    {
        JumpUpdate();
        MoveUpdate();
    }
    
    // Jump
    public override void Jump()
    {
        if (!_player._isJump)
        {
            _player._gravityPower = _player._jumpPower;
        }
    }

    float GroundTime = 1.0f;
    float currentGroundTime = 0.0f;
    
    void JumpUpdate()
    {
        _player._isJump = !_player._charcontrol.isGrounded;
        
        if(!_player._charcontrol.isGrounded)
        {
            _player._gravityPower += _player._gravityAccel * Time.deltaTime;
        }

        currentGroundTime += Time.deltaTime;
        if (currentGroundTime > GroundTime && _player._charcontrol.isGrounded) 
        {
            currentGroundTime = 0.0f;
            _player._gravityPower = -10;
        }
    }

    // Move
    float _PlusSpeed = 3f;
    float _MovementSpeed = 5;
    void MoveUpdate()
    {
        Vector3 speed = Vector3.zero;
        
        if (_player._sideSpeed != 0 && _player._forwardSpeed != 0 && _player._isJump)
        {
            _player._forwardSpeed = _player._forwardSpeed > 0 ? _player._MaxforwardSpeed / 2 : -_player._MaxforwardSpeed/2;
            _player._sideSpeed = _player._sideSpeed > 0 ? _player._MaxsideSpeed : -_player._MaxsideSpeed; ;
        }
        else if (_player._sideSpeed != 0 && _player._forwardSpeed != 0)
        {
            _player._forwardSpeed /= 2f;
            _player._sideSpeed /= 2f;
        }
        
        speed.Set(_player._sideSpeed * _MovementSpeed, _player._gravityPower + _player._jumpPower, _player._forwardSpeed * _MovementSpeed);
        speed = _player.transform.localRotation * speed * _PlusSpeed;
        
        _player._charcontrol.Move(speed * Time.deltaTime);
    }
}
