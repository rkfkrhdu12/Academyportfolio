using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UpdaterEvent{

    public List<Action> actions = new List<Action>();

	public virtual void Update (){
		foreach(var i in actions)
        {
            i();
        }
	}
}
