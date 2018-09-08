using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections.Concurrent;

public class GetPing : oNetworkManager
{
	float dt = 0f;
	public static ReAct<int> iping = new ReAct<int>();
	public static ReAct<int> MaxPing = new ReAct<int>();
	NetPingUpdater ping = new NetPingUpdater();

	private void Start()
	{
		NetDataReader.GetInstace().Reder[Class.ping] = (data) =>
		{

		};

		iping.AddEvent(() =>
		{
			if (iping.Value > MaxPing.Value)
			{
				MaxPing.Value = iping.Value;
			}
		});
	}

	public void GetPings(long d)
	{
		iping.Value = (int)d;
	}


	private void Update()
	{
		dt += Time.deltaTime;
	}

	public override void NetworkStarting()
	{
		StartCoroutine(NetUpdate(() =>
		{
			NetworkSendManager.instance.actions.Enqueue(() =>
			{
				ping.Update();
			});
		}, SendRate));
	}
}
