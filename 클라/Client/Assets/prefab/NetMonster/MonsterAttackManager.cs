using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MonsterAttackManager : MonoBehaviour
{

    public GameObject AttackRange;
    public GameObject col;

    public AttackObj CurrentAtk;


    public bool isAttackAble = true;

    public Dictionary<string, GameObject> Effects = new Dictionary<string, GameObject>();


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<oCreature>() && isAttackAble)
        {
            isAttackAble = false;
            AttackRange.SetActive(false);
            // ======== 스킬.
            var skill = new AttackObj();
            CurrentAtk = skill;
            skill.col = new GameObject[1];
            skill.col[0] = col;
            skill.isTargetOnce = true;

            skill.StartTime = 0.6f;
            skill.EndTime = 2.1f;
            skill.AttackTime = 0.25f;

            skill.AniCode = 0.2f;

            skill.Damage = 10;

            skill.HitCallBack = (data,data2) =>
            {
                if (data.gameObject == NetworkObject.mainPlayer)
                {
                    data.gameObject.GetComponent<NetworkObject>().m_CurrentHP.Value -= 10;
                    //ShowEffect(data2,"Blood");
                    // 주먹에서 피 나와야함, 바꾸자 hit함수 쓰지말고.
                    // 근데 함수 쓰긴 써야함 : 방어력 계산., 충돌 처리, 요망.
                }
                ShowEffect(data2, "Blood");
            };
            skill.EndCallBack = () =>
            {
                AttackRange.SetActive(true);
                StartCoroutine(Wait(() => {  isAttackAble = true; }, skill.EndTime - skill.StartTime + skill.AttackTime));
            };
            // ======= 임시 스킬 생성.
            
            GetComponentInChildren<Animator>().SetFloat("stat", skill.AniCode);
            StartCoroutine(Wait(() => { GetComponent<AttackerManager>().CallAttack(skill); }, skill.StartTime));
        }
    }

    void Start()
    {
        Effects["Blood"] = Resources.Load<GameObject>("BulletImpactFleshBigEffect");
    }


   

    IEnumerator Wait(Action action, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }


    void ShowEffect(Collider collision, string EffectName)
    {
        // 총알이 충동한 지점 산출 
        Vector3 pos = collision.transform.position;
        // 총알 충돌한 지점의 법선 벡터
        Vector3 normal = collision.transform.position;

        // 총알 충돌시 방향 벡터의 회전 정보
        Quaternion rot = Quaternion.FromToRotation(Vector3.forward, normal);

        // 혈흔 효과 생성
        GameObject blood = Instantiate(Effects[EffectName], pos, rot);

        Destroy(blood, 1.0f);
    }
}