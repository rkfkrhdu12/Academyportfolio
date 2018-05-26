using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ani : Module
{
    Animator animator;
    public override void Start()
    {
        animator = _player.transform.GetComponent<Animator>();
    }

    override public void Update()
    {
        RunUpdate();
        JumpUpdate();
        MoveUpdate();
        AttackUpdate();
    }
    
    public void MoveUpdate()
    {
            animator.SetFloat("Vertical", _player._forwardSpeed);
            animator.SetFloat("Horizontal", _player._sideSpeed);
    }

    public void JumpUpdate()
    {
        animator.SetBool("Jump", _player._isJump);
    }

    public void AttackUpdate()
    {
        animator.SetBool("Attack", _player._isAttack);
    }

    public void RunUpdate()
    {
        animator.SetBool("Run", _player._isRun);
    }
}
