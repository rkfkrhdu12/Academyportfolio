using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlatBuffers;
using UnityEngine.UI;

public class SpeedTest_Send : oNetworkManager
{

    Coroutine r;
    int i = 0;

    public static int sm = 0;
    public static int rm = 0;

    // Use this for initialization
    void Start()
    {

        NetDataReader.GetInstace().Reder[Class.MonsterStat] = (data) =>
        {
            //long t = System.DateTime.Now.ToBinary() - (long)test.GetRootAstest(data.ByteBuffer).Num;
            //GetComponentInChildren<Text>().text = ""+(int)(t * (0.0001f));
            rm++;

        };

        //r = StartCoroutine(NetUpdate(() =>
        //{
        //          for (int i = 0; i < 10; i++)
        //          {
        //              Send();
        //              sm++;
        //          }

        //      }, SendRate));



    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 20), "stop"))
        {
            StopCoroutine(r);
        }
        if (GUI.Button(new Rect(120, 10, 100, 20), "start"))
        {
            for (int i = 0; i < 100; i++)
            {
                Send(i+1);
                sm++;
            }
        }



        GUI.Label(new Rect(10, 40, 100, 20), "sm : " + sm);
        GUI.Label(new Rect(10, 70, 100, 20), "rm : " + rm);
    }



    void Send(int n)
    {

            var fbb = new FlatBufferBuilder(1);
            fbb.Finish(SendMeStat.CreateSendMeStat(fbb, Class.SendMeStat, Class.MonsterStat, 1).Value);
            TCPClient.Instance.Send(fbb.SizedByteArray());
      
    }

    void Update()
    {
    }

}
