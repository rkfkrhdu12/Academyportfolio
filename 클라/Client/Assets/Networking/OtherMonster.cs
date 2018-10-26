using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class OtherMonster : MonoBehaviour
{
    public bool _isDead = false;


    MovePosLerp LerpManager = new MovePosLerp();

    Vector3 End = new Vector3();
    Vector3 StartPos = new Vector3();

    Vector3 lookpos = Vector3.zero;

    Vector3 dirToTarget;
    NetStatUpdater netMonsterStat = new NetStatUpdater();

    //bool TargetInRange = true;

    public void PosUpdate(Monster mon)
    {
        Vec3 pos = mon.Pos.Value;
        End.Set(pos.X,pos.Y,pos.Z);

        lookpos.Set( pos.X, transform.position.y, pos.Z);

        if (GetComponent<MonsterAttackManager>().AttackRange.activeSelf)
            GetComponentInChildren<Animator>().SetFloat("stat", mon.Ani);

        dirToTarget = lookpos - transform.position;
        StartPos = transform.position;
        LerpManager.LerpPos(ref End, Vector3.zero);
    }
    public void SetStatEvent()
    {
        GetComponent<oCreature>().CurrentHP.OtherEvent(isDead);
        GetComponent<oCreature>().CurrentHP.AddEvent(isDead);

        GetComponent<oCreature>().CurrentHP.AddEvent(() =>
        {
            netMonsterStat.Updater(gameObject);
        });
    }

    void isDead()
    {
        if((GetComponent<oCreature>().CurrentHP.Value < 1) && !_isDead)
        {
            _isDead = true;
            GetComponent<MonsterManager>().SetMonsterDead();
        }
        else if(_isDead)
        {
            _isDead = false;
            GetComponent<MonsterManager>().SetMonster();
        }
    }


    void Start()
    {
        //var Ev = GetComponentInChildren<TriggerEvent>();
        //Ev.triggerEnter.Add(() =>
        //{
        //    TargetInRange = false;
        //});
        //Ev.triggerExit.Add(() =>
        //{
        //    TargetInRange = true;
        //});
    }

    void Update()
    {
        LerpManager.SyncT += Time.deltaTime;
        

        transform.position = Vector3.Lerp(StartPos, End, LerpManager.LerpT());
        
        Vector3 look = Vector3.Slerp(transform.forward, dirToTarget.normalized, LerpManager.LerpT());

        if (transform.position != lookpos) {
            transform.rotation = Quaternion.LookRotation(look, Vector3.up);
        }
    }
}
