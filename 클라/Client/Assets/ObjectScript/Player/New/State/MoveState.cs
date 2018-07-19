using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveState : State
{

    override protected void statUpdate()
    {
        base.statUpdate();
        
        Move();
    }
    
    private void Move()
    {
        Vector3 speed = Vector3.zero;
        speed.Set(_player.moveVec.x * _player._movementSpeed, _player.gravityPower, _player.moveVec.z * _player._movementSpeed);
        speed = _player.transform.localRotation * speed;

        _player.charCtrl.Move(speed * Time.deltaTime);
    }
    
    void MoveAni()
    {
        //ani
        if (_player.moveVec.x == 0)
            _animator.SetFloat("Vertical", _player.moveVec.z);
        else
            _animator.SetFloat("Vertical", 0);

        _animator.SetFloat("Horizontal", _player.moveVec.x);
    }
}
