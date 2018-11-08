using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlatBuffers;

public class OtherPlayer : oNetworkManager
{
    Quaternion Rot = new Quaternion();
    NetStatUpdater netplayerStat = new NetStatUpdater();
    MovePosLerp LerpManager = new MovePosLerp();

    Vector3 Vel = new Vector3();
    Vector3 StartPos = new Vector3();
    Vector3 EndPos = new Vector3();


    public void SetStatEvent()
    {


        //netplayerStat.Updater(gameObject);

    }


    



    public void UpdateOtherObj(Player tr)
    {
        EndPos.Set(tr.Pos.Value.X, tr.Pos.Value.Y, tr.Pos.Value.Z);

        Vel.Set(tr.Vel.Value.X, tr.Vel.Value.Y, tr.Vel.Value.Z);
        Rot.Set(tr.Rot.Value.X, tr.Rot.Value.Y, tr.Rot.Value.Z, tr.W);
        GetComponent<Animator>().SetFloat("Vertical", tr.Vertical);
        GetComponent<Animator>().SetFloat("Horizontal", tr.Horizontal);
        GetComponent<Animator>().SetBool("Jump", tr.Jump);
        GetComponent<Animator>().SetBool("Attack", tr.Attack);
        GetComponent<Animator>().SetFloat("Skill_id", tr.Anicode);
        GetComponent<Animator>().SetBool("Run", tr.Run);

        LerpManager.LerpPos(ref EndPos, Vel);
        StartPos = transform.position;
    }

    void Update()
    {
        LerpManager.SyncT += Time.deltaTime;

        transform.position = Vector3.Lerp(StartPos, EndPos, LerpManager.LerpT());
        transform.rotation = Quaternion.Lerp(transform.rotation, Rot, Time.deltaTime);
    }
}