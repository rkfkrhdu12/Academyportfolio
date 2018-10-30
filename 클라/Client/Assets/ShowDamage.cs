using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDamage : MonoBehaviour {

    [SerializeField] GameObject mDamageText;


	void Start () {
        NetDataReader.GetInstace().Reder[Class.fDamage] = (data) =>
        {
            var dData = fDamage.GetRootAsfDamage(data.ByteBuffer);
            var v3 = dData.Pos.Value;
            Instantiate(mDamageText, new Vector3(v3.X, v3.Y, v3.Z), Quaternion.identity).GetComponent<DamageText>().Show(-dData.Damage,dData.BCri);
        };
    }
}
