using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSlotsManager : MonoBehaviour
{

    [SerializeField] GameObject target;
    

    [SerializeField] int Max_index_X;
    [SerializeField] int Max_index_Y;

    [SerializeField] int interval_X;
    [SerializeField] int interval_Y;

    Vector2 startPos;


    void Start()
    {
        startPos = target.GetComponent<RectTransform>().localPosition;
        Vector2 size = target.GetComponent<RectTransform>().sizeDelta;


        int n = 0;
        for (int i = 0; i < Max_index_Y; ++i)
        {
            for (int j = 0; j < Max_index_X; ++j)
            {
                var obj = Instantiate(target,transform);
                var ObjTr = obj.GetComponent<RectTransform>();
                ObjTr.name = "" + ++n;
                ObjTr.localPosition = new Vector2(
                    startPos.x + (j * ((size.x / 2) + interval_X)),
                    startPos.y - (i*((size.y/2) + interval_Y)));
            }
        }
    }
}
