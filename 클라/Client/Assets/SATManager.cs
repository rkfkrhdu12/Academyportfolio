using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SATManager : MonoBehaviour {
    [SerializeField] GameObject core;
    [SerializeField] GameObject Effect;
    [SerializeField] string EffectName;

    public void AttackStart(int Damage)
    {
        core.GetComponent<SkillProcess>().HitCallBack = (Collider, mCollider) =>
        {
            var Player = BPlayer.MainPlayer.GetComponent<NetworkObject>();
            mCollider.GetComponent<SkillProcess>().EffectName = EffectName;
            Collider.gameObject.GetComponent<oCreature>().CurrentHP.Value -= Player.Final_ATK + Damage;
            NOUI_HPBar.ShowHPBar(Collider.gameObject.GetComponent<oCreature>());
            Collider.gameObject.GetComponent<SendStateManager>().SendDamage(Player.Final_ATK + Damage);
        };
        Effect.SetActive(true);
        core.SetActive(true);
    }
    public void AttackEnd()
    {
        Effect.SetActive(false);
        core.SetActive(false);
    }
}
