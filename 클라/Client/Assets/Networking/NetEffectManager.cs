using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetEffectManager : MonoBehaviour {


    public GameObject LavelUPEffect = Resources.Load<GameObject>("LVUP");




    private void Start()
    {
        NetDataReader.GetInstace().Reder[Class.Player] = (data) =>
        {
            var Effect = fNetEffect.GetRootAsfNetEffect(data.ByteBuffer);

            switch (Effect.EffectType)
            {
                // lv up
                case 1 :
                    Instantiate(LavelUPEffect,new Vector3(Effect.TargetPos.Value.X, Effect.TargetPos.Value.Y, Effect.TargetPos.Value.Z),Quaternion.identity);
                    break;
                default:
                    break;
            }

        };

    }
}
