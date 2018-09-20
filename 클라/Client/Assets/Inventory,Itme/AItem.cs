using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlatBuffers;

public class fItemT
{
    public void init(fItem item)
    {
        name = item.Name;
        type = item.Type;

        val[0] = item.Val1;
        val[1] = item.Val2;
        val[2] = item.Val3;
        val[3] = item.Val4;
        val[4] = item.Val5;
        val[5] = item.Val6;
        val[6] = item.Val7;
        val[7] = item.Val8;

        count = item.Count;

        id = item.Id;
    }

    string name;
    int type;
    int id;
    int[] val = new int[8];
    int count;

    public BItem Get()
    {
        BItem item = new BItem();

        switch (type)
        {
            case 3:
                item = new Stuff();
                item._name = name;
                item.id = id;
                item.Number.Value = count;
                ((Stuff)item).Hp = val[0];
                break;
            default :
                break;
        }
        return item;
    }
}

public class AItem{

    public fItemT GetfItemT(fItem item)
    {
        fItemT fItemt = new fItemT();
        fItemt.init(item);

        return fItemt;
    }

}
