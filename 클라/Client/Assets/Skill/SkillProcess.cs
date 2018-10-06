using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkillProcess : MonoBehaviour {
    public bool isOnce { get; set; }
    public Action<Collider, Collider> HitCallBack { get; set; }
    public String EffectName;

    public static Dictionary<string, GameObject> Effects = new Dictionary<string, GameObject>();
    
    void ShowEffect(Collider collision, string EffectName)
    {
        if (Effects.ContainsKey(EffectName))
        {
            Vector3 pos = collision.transform.position;
            Vector3 normal = collision.transform.position;
            Quaternion rot = Quaternion.FromToRotation(-Vector3.forward, normal);
            GameObject Effect = Instantiate(Effects[EffectName], pos, rot);
            Destroy(Effect, 1.0f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.GetComponent<oCreature>() != null)
        {
            if (other.gameObject.GetComponent<oCreature>() != GetComponentInParent<oCreature>())
            {
                var col = gameObject.GetComponent<Collider>();
                HitCallBack(other, col);

                Debug.Log("setEffet\n" + EffectName);
                ShowEffect(col, EffectName);
            }
            if (isOnce) { gameObject.SetActive(false); }
        }
    }
}
