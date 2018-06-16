using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



[Serializable]
public class AttackObj
{
    public GameObject[] col;
    public float Time;
    public float TimeT = 0f;

    public int Damage;
    public float CoolTime;

    public Action EndCallBack;

    public void setCol(bool _s)
    {
        foreach (var i in col)
            i.SetActive(_s);
    }
}




public class AttackerManager : MonoBehaviour
{
    Dictionary<AttackObj, Action> objs = new Dictionary<AttackObj, Action>();
    Queue<AttackObj> RemoveManager = new Queue<AttackObj>();

    public void CallAttack(AttackObj obj)
    {
        var _obj = obj;
        objs[_obj] = () =>
        {
            GetComponentInChildren<Animator>().SetFloat("stat", 0.2f);
            obj.TimeT += Time.deltaTime;
            if (_obj.TimeT >= _obj.Time)
            {
                RemoveManager.Enqueue(_obj);
                _obj.setCol(false);
                _obj.EndCallBack();
            }
        };

        obj.setCol(true);
    }


    void Update()
    {
        foreach (var i in objs)
            i.Value();

        while (RemoveManager.Count > 0)
            objs.Remove(RemoveManager.Dequeue());
    }
}