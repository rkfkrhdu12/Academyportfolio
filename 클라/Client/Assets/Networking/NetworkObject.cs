using System.Collections;
using System.Collections.Generic;
using UnityScript;
using UnityEngine;

public class NetworkObject : oNetworkManager {

    public static GameObject mainPlayer;
    
    NetPlayerUpdater netPlayer;
    NetStatUpdater netplayerStat = new NetStatUpdater();


    public ReAct<string> CharacterName = new ReAct<string>();

    public ReAct<int> m_CurrentHP = new ReAct<int>();
    public ReAct<int> m_CurrentHPLim = new ReAct<int>();
    public ReAct<int> m_CurrentMP = new ReAct<int>();
    public ReAct<int> m_CurrentMPLim = new ReAct<int>();
    public ReAct<int> m_CurrentEXP = new ReAct<int>();
    public ReAct<int> m_CurrentCRI = new ReAct<int>(1);
    public ReAct<int> m_CurrentATK = new ReAct<int>(5);
    public ReAct<int> m_CurrentLV = new ReAct<int>(1);







    public int m_WeaponATK = 0;
    public int Final_ATK {
        get {
            // % 계수나 뭐 다른것들 여기다 적용....
            return m_WeaponATK + m_CurrentATK.Value;
        }

        set {
            Final_ATK = value;
        }
    }

    void Awake()
    {
        mainPlayer = gameObject;
        OnServerStart.Event.Add(this);
    }


    void SetState()
    {
        //GetComponent<oCreature>().CurrentHP.Value = m_CurrentHP.Value;
        GetComponent<PlayerStateManager>().SetOverState();
        netplayerStat.Updater(gameObject);
    }

    void Start()
    {
        m_CurrentHP.AddEvent(SetState);
        m_CurrentMP.AddEvent(SetState);
        m_CurrentEXP.AddEvent(SetState);
        m_CurrentCRI.AddEvent(SetState);
        m_CurrentATK.AddEvent(SetState);
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