using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlatBuffers;

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
    public override void process()
    {
        BPlayer.MainPlayer.GetComponent<NetworkObject>().m_CurrentHP.Value += Hp;
        Number.Value -= 1;

        var fbb = new FlatBufferBuilder(1);
        fbb.Finish(fItem.CreatefItem(fbb, Class.fItem, id, fbb.CreateString(""), 0, 0, 0, 0, 0, 0, 0, 0, 0, 1).Value);
        TCPClient.Instance.Send(fbb.SizedByteArray());
    }
    public int Hp { get; set; }
}