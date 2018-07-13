using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveState : MonoBehaviour
{
    protected player _player;
    protected Animator _animator;

    public void Start()
    {
        _player = player.GetInstance();
        _animator = _player.transform.GetComponent<Animator>();
    }

    public void Update()
    {
        //JumpUpdate();
        MoveUpdate();

        Move();
    }

    float GroundTime = 1.0f;
    float currentGroundTime = 0.0f;
    float _gravityAccel = -10;
    float _gravityPower = -9.8f;

    //void JumpUpdate()
    //{
    //    if (_player.curMove != eMove.JUMP) return;

    //    _PlayerSpeed.IsJump = !_player.charCtrl.isGrounded;

    //    if (!_player.charCtrl.isGrounded)
    //    {
    //        _gravityPower += _gravityAccel * Time.deltaTime;
    //    }

    //    currentGroundTime += Time.deltaTime;
    //    if (currentGroundTime > GroundTime && _player.charCtrl.isGrounded)
    //    {
    //        currentGroundTime = 0.0f;
    //        _gravityPower = -10;
    //    }

    //}

    float _PlusSpeed = 3f;
    float _MovementSpeed = 5;
    private void MoveUpdate()
    {
        if (_player.forward > _player.maxForward / 2)
        {
            _player.forward += _player.maxForward;
            if (_player.side > _player.maxSide / 2)
            {
                _player.side += _player.maxSide;
            }
            // ani
            _animator.SetBool("Run", true);
        }
        else
            //ani
            _animator.SetBool("Run", false);

        if (_player.side != 0 && _player.forward != 0 && _player.IsJump)
        {
            _player.forward = _player.forward > 0 ?
                _player.maxForward / 2 : -_player.maxForward / 2;

            _player.side = _player.side > 0 ?
                _player.maxSide : -_player.maxSide; ;
        }
        else if (_player.side != 0 && _player.forward != 0)
        {
            _player.forward /= 2f;
            _player.side /= 2f;
        }
    }

    void Move()
    {
        Vector3 speed = Vector3.zero;

        speed.Set(_player.side * _MovementSpeed, _gravityPower, _player.forward * _MovementSpeed);
        speed = _player.transform.localRotation * speed * _PlusSpeed;

        _player.charCtrl.Move(speed * Time.deltaTime);
        
        //ani
        _animator.SetFloat("Vertical", _player.forward);
        _animator.SetFloat("Horizontal", _player.side);
        _animator.SetBool("Jump", _player.IsJump);
    }
}
