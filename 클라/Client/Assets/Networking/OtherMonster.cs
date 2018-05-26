using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherMonster : MonoBehaviour {

    MovePosLerp LerpManager = new MovePosLerp();
    public int MonsterID;

    Vector3 End = new Vector3();
    Vector3 StartPos = new Vector3();

    public void PosUpdate(Monster mon)
    {
        LerpManager.LerpPos(ref End, Vector3.zero);
    }

    void Update()
    {
        LerpManager.SyncT += Time.deltaTime;

        transform.position = Vector3.Lerp(StartPos, End, LerpManager.LerpT());
    }
}
