using System.Collections;
using System.Collections.Generic;
using UnityScript;
using UnityEngine;

public class NetworkObject : oNetworkManager {

    public static GameObject mainPlayer;
    
    NetPlayerUpdater netPlayer;
    NetStatUpdater netplayerStat = new NetStatUpdater();

    public ReAct<int> m_CurrentHP = new ReAct<int>();
    
    void Awake()
    {
        mainPlayer = gameObject;
        OnServerStart.Event.Add(this);
    }

    void Start()
    { 
        m_CurrentHP.AddEvent(()=>
        {
            GetComponent<oCreature>().CurrentHP.Value = m_CurrentHP.Value;
            netplayerStat.Updater(gameObject);
        });
    }

    public override void NetworkStarting()
    {
        GetComponent<oNetworkIdentity>().id = id;

        netplayerStat.Updater(gameObject);

        netPlayer = new NetPlayerUpdater(id,GetComponent<Animator>());
       
        

        StartCoroutine(NetUpdate(()=>
        {
            NetworkSendManager.instance.actions.Enqueue(() =>
            {
                netPlayer.transform = transform;
                netPlayer.Vel = GetComponent<CharacterController>().velocity;
                netPlayer.Update();
            });
        }, SendRate));
    }
}