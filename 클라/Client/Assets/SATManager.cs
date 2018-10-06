using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SATManager : MonoBehaviour {
    [SerializeField] GameObject core;
    [SerializeField] string EffectName;

    public void AttackStart(int Damage)
    {
        core.GetComponent<SkillProcess>().HitCallBack = (Collider, mCollider) =>
        {
            var Player = BPlayer.MainPlayer.GetComponent<NetworkObject>();
            mCollider.GetComponent<SkillProcess>().EffectName = EffectName;
            Collider.gameObject.GetComponent<oCreature>().CurrentHP.Value -= Player.Final_ATK + Damage;

        };
        core.SetActive(true);
    }
    public void AttackEnd()
    {
        core.SetActive(false);
    }
}
