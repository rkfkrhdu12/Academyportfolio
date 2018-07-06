using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem
{
    public string _name;
    public string _info;
    public Sprite icon;

    public ReAct<int> Number = new ReAct<int>(1);

    public virtual void process() {  }
}