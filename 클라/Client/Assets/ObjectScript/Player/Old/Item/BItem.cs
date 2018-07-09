using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BItem : PlayerSystem
{

}




public class Weapon : BItem
{
    public int OffensePower { get; set; }
}
public class Armor : BItem
{
    public int DefensePower { get; set; }
}

public class Stuff : BItem
{

}
