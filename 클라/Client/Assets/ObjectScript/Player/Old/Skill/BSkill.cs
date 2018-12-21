using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSkill : PlayerSystem
{
    public int code;
    public AttackObj AttackData { get; set; }

    public override void process()
    {
        NetworkObject.mainPlayer.GetComponent<PlayerAttackManager>().Attacked(AttackData);
    }

}
