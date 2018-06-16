using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class OtherMonster : MonoBehaviour {

    MovePosLerp LerpManager = new MovePosLerp();
    public int MonsterID;

    Vector3 End = new Vector3();
    Vector3 StartPos = new Vector3();
    
    Vector3 lookpos = Vector3.zero;

    

    public void PosUpdate(Monster mon)
    {
        Vec3 pos = mon.Pos.Value;
        //End.Set(pos.X,pos.Y,pos.Z);
        lookpos.Set(pos.X, transform.position.y, pos.Z);

        GetComponentInChildren<Animator>().SetFloat("stat",0.1f);

        //StartPos = transform.position;



        //LerpManager.LerpPos(ref End, Vector3.zero);
    }

    void Update()
    {
        //transform.LookAt(lookpos);

        //LerpManager.SyncT += Time.deltaTime;

        //transform.position = Vector3.Lerp(StartPos, End, LerpManager.LerpT());
       
        transform.GetComponent<NavMeshAgent>().SetDestination(lookpos);
    }
}
