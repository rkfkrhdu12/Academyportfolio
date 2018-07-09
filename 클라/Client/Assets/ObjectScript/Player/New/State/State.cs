using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected player _player;
    protected Animator _animator;
    public void Init()
    {
        _player = player.GetInstance();
        _animator = _player.transform.GetComponent<Animator>();
    }

    virtual public void Start() { }
    virtual public void Update() { }
}
