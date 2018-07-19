using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behaviour
{
    protected player _player;

    public void behaviourStart()
    {
        _player = player.GetInstance();
    }

    virtual public void behaviourUpdate() { }

}