using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Module
{
    public override void Update()
    {
        AttackUpdate();
    }
    
    float _currentTime = 0;
    void AttackUpdate()
    {
        if (_player._isAttack)
        {
            _currentTime += Time.deltaTime;
            if (_currentTime >= _player._SkillProgressTime)
            {
                _currentTime = 0;
                _player._isAttack = false;
            }
        }
    }
}
