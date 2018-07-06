using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {

        SkillProcess.Effects["Blood"] = Resources.Load<GameObject>("BulletImpactFleshBigEffect");
        Destroy(gameObject);
    }
}
