using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OtherMonster : MonoBehaviour {

    MovePosLerp LerpManager = new MovePosLerp();
    public int MonsterID;

    Vector3 End = new Vector3();
    Vector3 StartPos = new Vector3();
    
    Vector3 lookpos = Vector3.zero;
    public void PosUpdate(Monster mon)
    {
        Vec3 pos = mon.Pos.Value;
        End.Set(pos.X,pos.Y,pos.Z);
        lookpos.Set(mon.TargetPos.Value.X, transform.position.y, mon.TargetPos.Value.Z);
        StartPos = transform.position;
        LerpManager.LerpPos(ref End, Vector3.zero);
    }

    void Update()
    {
        transform.LookAt(lookpos);

        LerpManager.SyncT += Time.deltaTime;

        transform.position = Vector3.Lerp(StartPos, End, LerpManager.LerpT());
    }
}
