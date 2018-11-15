using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlatBuffers;

public class IG_EffectManager : MonoBehaviour
{
    static IG_EffectManager instance;


    private void Start()
    {
        NetDataReader.GetInstace().Reder[Class.fIG_Effect] = (data) =>
        {
            var eftData = fIG_Effect.GetRootAsfIG_Effect(data.ByteBuffer);
            EftShow(new Vector3(eftData.X,eftData.Y,eftData.Z), eftData.EftName);
        };
    }

    private void Awake()
    {
        instance = this;
    }
    public static void Show(Vector3 pos, string EftName)
    {
        instance.CreatefIG_Effect(-1, pos, EftName);
    }
    public static void Show(GameObject player, string EftName)
    {
        instance.CreatefIG_Effect(player.GetComponent<oNetworkIdentity>().id, new Vector3(), EftName);
    }


    void CreatefIG_Effect(int playerID, Vector3 pos, string EftName)
    {
        FlatBufferBuilder fbb = new FlatBufferBuilder(1);
        fbb.Finish(fIG_Effect.CreatefIG_Effect(fbb, Class.fIG_Effect, playerID, pos.x, pos.y, pos.z, fbb.CreateString(EftName)).Value);
        TCPClient.Instance.Send(fbb.SizedByteArray());
    }

    void EftShow(Vector3 targetPos, string EftName)
    {
        Instantiate(Resources.Load<GameObject>(EftName), targetPos, Quaternion.identity);
    }


    void EftShow(Transform target, string EftName)
    {

    }
}
