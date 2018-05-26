using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlatBuffers;

public class NetPlayerUpdater : UpdaterEvent{

    public int id { get; set; }
    public Transform transform;
    public Vector3 Vel;
    Animator animator;


    public NetPlayerUpdater(int id, Animator _animator)
    {
        this.id = id;
        animator = _animator;
    }

    public override void Update () {
        base.Update();

        var fbb = new FlatBufferBuilder(1);
        fbb.Finish(CreatePlayer(ref fbb).Value);
        TCPClient.Instance.Send(fbb.SizedByteArray());
    }

    Offset<Player> CreatePlayer(ref FlatBufferBuilder fbb)
    {
        Player.StartPlayer(fbb);
        Player.AddCType(fbb, Class.Player);
        Player.AddPos(fbb, GetVec3(ref fbb, transform.position));
        Player.AddVel(fbb, GetVec3(ref fbb, Vel));
        Player.AddRot(fbb, GetVec3(ref fbb, transform.rotation));
        Player.AddW(fbb, transform.rotation.w);
        Player.AddVertical(fbb, animator.GetFloat("Vertical"));
        Player.AddHorizontal(fbb, animator.GetFloat("Horizontal"));
        Player.AddJump(fbb, animator.GetBool("Jump"));
        Player.AddAttack(fbb, animator.GetBool("Attack"));
        Player.AddRun(fbb, animator.GetBool("Run"));
        
        return Player.EndPlayer(fbb);
    }

    public Offset<Vec3> GetVec3(ref FlatBufferBuilder builder,Vector3 v3)
    {
        return Vec3.CreateVec3(builder, v3.x, v3.y, v3.z);
    }
    public Offset<Vec3> GetVec3(ref FlatBufferBuilder builder, Quaternion v3)
    {
        return Vec3.CreateVec3(builder, v3.x, v3.y, v3.z);
    }
}
