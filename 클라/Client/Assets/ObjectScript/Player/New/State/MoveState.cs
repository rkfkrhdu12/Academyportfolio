using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveState : State
{
    protected behavior _PlayerSpeed;

    public override void Start()
    {
        _PlayerSpeed = _player.speed;
    }

    override public void Update()
    {
        JumpUpdate();
        MoveUpdate();

        Move();
    }

    float GroundTime = 1.0f;
    float currentGroundTime = 0.0f;
    float _gravityAccel = -10;
    float _gravityPower = -9.8f;
    void JumpUpdate()
    {
        _PlayerSpeed.IsJump = !_player.charCtrl.isGrounded;

        if (!_player.charCtrl.isGrounded)
        {
            _gravityPower += _gravityAccel * Time.deltaTime;
        }

        currentGroundTime += Time.deltaTime;
        if (currentGroundTime > GroundTime && _player.charCtrl.isGrounded)
        {
            currentGroundTime = 0.0f;
            _gravityPower = -10;
        }
        
    }

    float _PlusSpeed = 3f;
    float _MovementSpeed = 5;
    private void MoveUpdate()
    {

        if (_PlayerSpeed.forward > _PlayerSpeed.maxForward / 2 && player.GetInstance().curMove == eMove.RUN)
        {
            _PlayerSpeed.forward += _PlayerSpeed.maxForward;
            _animator.SetBool("Run", true);
        }
        else
            _animator.SetBool("Run", false);

        if (_PlayerSpeed.side != 0 && _PlayerSpeed.forward != 0 && _PlayerSpeed.IsJump)
        {
            _PlayerSpeed.forward = _PlayerSpeed.forward > 0 ? 
                _PlayerSpeed.maxForward / 2 : -_PlayerSpeed.maxForward / 2;

            _PlayerSpeed.side = _PlayerSpeed.side > 0 ? 
                _PlayerSpeed.maxSide : -_PlayerSpeed.maxSide; ;
        }
        else if (_PlayerSpeed.side != 0 && _PlayerSpeed.forward != 0)
        {
            _PlayerSpeed.forward /= 2f;
            _PlayerSpeed.side /= 2f;
        }
    }

    void Move()
    {
        Vector3 speed = Vector3.zero;

        speed.Set(_PlayerSpeed.side * _MovementSpeed, _gravityPower, _PlayerSpeed.forward * _MovementSpeed);
        speed = _player.transform.localRotation * speed * _PlusSpeed;

        _player.charCtrl.Move(speed * Time.deltaTime);

        _animator.SetFloat("Vertical", _PlayerSpeed.forward);
        _animator.SetFloat("Horizontal", _PlayerSpeed.side);
        _animator.SetBool("Jump", _PlayerSpeed.IsJump);
    }
}
