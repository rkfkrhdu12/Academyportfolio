using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlatBuffers;
using UnityEngine.UI;

public class SpeedTest_Send : oNetworkManager {

    Coroutine r;
    int i=0;

    // Use this for initialization
    void Start () {

		NetDataReader.GetInstace().Reder[Class.ping] = (data) =>
		{
			long t = System.DateTime.Now.ToBinary() - (long)test.GetRootAstest(data.ByteBuffer).Num;
			GetComponentInChildren<Text>().text = ""+(int)(t * (0.0001f));
		};

		r = StartCoroutine(NetUpdate(() =>
		{
			Send();
		}, SendRate));



	}

    private void OnGUI()
    {
        if(GUI.Button(new Rect(10, 10, 100, 20), "stop"))
        {
            StopCoroutine(r);
        }
    }



    void Send()
    {
		var fbb = new FlatBufferBuilder(1);
		fbb.Finish(ping.Createping(fbb, Class.ping, System.DateTime.Now.ToBinary()).Value);
		TCPClient.Instance.Send(fbb.SizedByteArray());
	}
	
	void Update ()
    {
    }

}
