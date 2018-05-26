using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Module
{
    public override void Update()
    {
        AttackUpdate();
    }
    
    float _currentTime = 0.0f;
    void AttackUpdate()
    {
        if (_player._isAttack)
        {
            _currentTime += Time.deltaTime;
            if (_currentTime >= 1f)
            {
                _currentTime = 0.0f;
                _player._isAttack = false;
            }
        }
    }
}
