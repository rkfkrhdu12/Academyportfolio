using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    override protected void statUpdate()
    {
        base.statUpdate();

        Idle();
    }

    private void Idle()
    {
        Vector3 speed = Vector3.zero;
        speed.Set(0, _player.gravityPower,0);
        speed = _player.transform.localRotation * speed;

        _player.charCtrl.Move(speed * Time.deltaTime);
    }
}
