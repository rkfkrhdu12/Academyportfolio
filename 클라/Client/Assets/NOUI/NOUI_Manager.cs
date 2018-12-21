using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NOUI_Manager : MonoBehaviour
{

    [SerializeField] GameObject mHPBar;

    public static NOUI_Manager instance;


    void Awake()
    {
        instance = this;
    }

    public GameObject NewHPBar()
    {
        return Instantiate(mHPBar,transform);
    }
}
