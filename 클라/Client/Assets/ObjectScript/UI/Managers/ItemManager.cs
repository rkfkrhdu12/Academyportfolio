using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    [SerializeField] Sprite icon_1;
    [SerializeField] Sprite icon_2;
    [SerializeField] Sprite icon_3;

    public void Start()
    {
        Weapon weapon = new Weapon();
        Armor armor = new Armor();
        Stuff stuff = new Stuff();
        Stuff stuff2 = new Stuff();

        weapon._name = "무기";
        weapon._info = "기본무기이다.";
        weapon.icon = icon_1;
        weapon.OffensePower = 100;



        armor._name = "방어구";
        armor._info = "기본방어구이다.";
        armor.icon = icon_2;
        armor.DefensePower = 50;



        stuff._name = "포션";
        stuff._info = "기본포션이다.";
        stuff.Number.Value = 5;
        stuff.Hp = 10;
        stuff.icon = icon_3;

        stuff2._name = "포션2";
        stuff2._info = "기본포션2이다.";
        stuff2.Number.Value = 5;
        stuff2.Hp = 5;
        stuff2.icon = icon_3;



        InventoryManager.AddItem(weapon);
        InventoryManager.AddItem(armor);
        InventoryManager.AddItem(stuff);
        InventoryManager.AddItem(stuff2);
    }
}