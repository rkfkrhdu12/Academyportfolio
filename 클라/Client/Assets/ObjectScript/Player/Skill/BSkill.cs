using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSkill : PlayerSystem
{
    public override void process()
    {
        NetworkObject.mainPlayer.GetComponent<PlayerAttackManager>().Attacked(AttackData);
    }

    public AttackObj AttackData { get; set; }
}
