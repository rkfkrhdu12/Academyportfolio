using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NOUI_HPBar : MonoBehaviour
{
    public static Dictionary<oCreature, float> ShowingTime =new Dictionary<oCreature, float>();
    public static Queue<NOUI_HPBar> nOUI_HPBars = new Queue<NOUI_HPBar>();
    public oCreature mTarget;
    public Text mname;



    private void Update()
    {
        if (mTarget != null)
        {
            mname.text = mTarget.name;
            var screenPos = Camera.main.WorldToScreenPoint(mTarget.transform.position + new Vector3(0.0f, 4f, 0.0f));

            transform.parent.position = screenPos;

            float max = mTarget.MaximumHP;
            float curr = mTarget.CurrentHP.Value;
            float size = (curr / max);

            GetComponent<RectTransform>().sizeDelta = new Vector2(size * 200f, GetComponent<RectTransform>().sizeDelta.y);

            ShowingTime[mTarget] -= Time.deltaTime;
            if ((ShowingTime[mTarget] < 0) || mTarget.isDead)
            {
                ShowingTime[mTarget] = -1;
                transform.parent.gameObject.SetActive(false);
                nOUI_HPBars.Enqueue(this);
                mTarget = null;
            }
        }
    }

    public static void ShowHPBar(oCreature target, float time = 3f)
    {
        System.Action act = ()=>
        {
            GameObject newHPBar;

            if (nOUI_HPBars.Count > 0)
            {
                newHPBar = nOUI_HPBars.Dequeue().gameObject;
                newHPBar.transform.parent.gameObject.SetActive(true);
            }
            else
            {
                newHPBar = NOUI_Manager.instance.NewHPBar();
            }

            newHPBar.GetComponentInChildren<NOUI_HPBar>().mTarget = target;
        };


        if(ShowingTime.ContainsKey(target))
        {
            if((ShowingTime[target] < 0))
            {
                act();
            }
        }
        else
        {
            act();
        }




        ShowingTime[target] = time;
    }


}