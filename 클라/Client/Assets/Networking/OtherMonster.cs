using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class OtherMonster : MonoBehaviour
{
    MovePosLerp LerpManager = new MovePosLerp();

    Vector3 End = new Vector3();
    Vector3 StartPos = new Vector3();

    Vector3 lookpos = Vector3.zero;
    Quaternion currentRot = new Quaternion();


    NetStatUpdater netMonsterStat = new NetStatUpdater();

    bool TargetInRange = true;

    public void PosUpdate(Monster mon)
    {
        Vec3 pos = mon.Pos.Value;
        End.Set(pos.X,pos.Y,pos.Z);

        lookpos.Set( pos.X, transform.position.y, pos.Z);

        if (GetComponent<MonsterAttackManager>().AttackRange.activeSelf)
            GetComponentInChildren<Animator>().SetFloat("stat", mon.Ani);

        StartPos = transform.position;
        currentRot = transform.rotation;
        LerpManager.LerpPos(ref End, Vector3.zero);
    }
    public void SetStatEvent()
    {
        GetComponent<oCreature>().CurrentHP.AddEvent(() =>
        {
            netMonsterStat.Updater(gameObject);
        });
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10,10,200,100),"-HP"))
        {
            GetComponent<oCreature>().CurrentHP.Value -= 10;
        }
    }

    void Start()
    {
        var Ev = GetComponentInChildren<TriggerEvent>();
        Ev.triggerEnter.Add(() =>
        {
            TargetInRange = false;
        });
        Ev.triggerExit.Add(() =>
        {
            TargetInRange = true;
        });
    }

    void Update()
    {
        transform.GetChild(0).LookAt(lookpos);

        LerpManager.SyncT += Time.deltaTime;

        transform.position = Vector3.Lerp(StartPos, End, LerpManager.LerpT());
        if(TargetInRange)
            transform.rotation = Quaternion.Lerp(currentRot, transform.GetChild(0).rotation, LerpManager.LerpT());
        else
            transform.LookAt(lookpos);
    }
}
