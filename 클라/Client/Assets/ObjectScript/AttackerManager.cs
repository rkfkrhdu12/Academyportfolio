using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



[Serializable]
public class AttackObj
{
    public GameObject[] col;

    public float StartTime;
    public float EndTime;
    public float AttackTime;
    public float TimeT = 0f;

    public float ColStartTime = 0.1f;

    public bool isTargetOnce = false;

    public float AniCode;
    public int Damage;
    public float CoolTime;

    public Action EndCallBack;
    public Action<Collider, Collider> HitCallBack;

    public void setCol(bool _s)
    {
        foreach (var i in col)
            i.SetActive(_s);
    }
    public void AttackStart()
    {
        foreach (var i in col)
        {
            var Option = i.GetComponent<SkillProcess>();
            Option.HitCallBack = HitCallBack;
            Option.isOnce = isTargetOnce;
        }
    }
}




public class AttackerManager : MonoBehaviour
{
    Dictionary<AttackObj, Action> objs = new Dictionary<AttackObj, Action>();
    Queue<AttackObj> RemoveManager = new Queue<AttackObj>();

    public void CallAttack(AttackObj obj)
    {
        var _obj = obj;
        _obj.TimeT = 0f;

        objs[_obj] = () =>
        {
            _obj.TimeT += Time.deltaTime;
            if (_obj.TimeT >= _obj.AttackTime)
            {
                RemoveManager.Enqueue(_obj);
                _obj.setCol(false);
                _obj.EndCallBack();
            }
        };


        _obj.setCol(true);
        _obj.AttackStart();
    }


    void Update()
    {
        foreach (var i in objs)
            i.Value();

        while (RemoveManager.Count > 0)
            objs.Remove(RemoveManager.Dequeue());
    }
}