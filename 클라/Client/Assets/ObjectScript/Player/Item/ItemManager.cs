using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : PlayerManager
{
    public void Start()
    {
        _Manager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();

        BItem item = new BItem();

        item._name = "무기";
        item._info = "기본무기이다.";
        _PlayerSystem.Add(item);

        item = new BItem();
        item._name = "방어구";
        item._info = "기본방어구이다.";
        _PlayerSystem.Add(item);

        item = new BItem();
        item._name = "장신구";
        item._info = "기본장신구이다.";
        _PlayerSystem.Add(item);

        _Manager.SetItem(_PlayerSystem[0]); // 
        _Manager.SetItem(_PlayerSystem[1]); //
        _Manager.SetItem(_PlayerSystem[2]); //
    }
}