using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module //: MonoBehaviour
{
    protected BPlayer _player;

    public void Init(BPlayer player)
    {
        _player = player;
    }

    virtual public void Start() { }
    virtual public void Update() { }
    virtual public void Jump() { }
}
