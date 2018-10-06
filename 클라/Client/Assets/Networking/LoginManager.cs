using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FlatBuffers;

public class LoginManager : oNetworkManager
{
    public static bool IsLogIN = false;

    public static LoginManager instance;
    [SerializeField] GameObject LoginUI;
    public Text[] t = new Text[2];

    public string autoID;
    public string autoPASS;

    float dt;

    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        NetDataReader.GetInstace().Reder[Class.LogIn] = (data) =>
        {
            var LoginData = Login.GetRootAsLogin(data.ByteBuffer);
            if (LoginData.IsSuccess)
            {
                Debug.Log(LoginData.Id);
                GetComponent<OnServerStart>().Started(int.Parse(LoginData.Id));
                LoginUI.SetActive(false);
                Destroy(GetComponent<LoginManager>());
            }
            else
            {
                Debug.Log("로그인 실패.");
            }
        };
    }
    bool stop =false;
    private void Update()
    {
        dt += Time.deltaTime;
        if (dt > 1f && !stop)
        {
            autoLogin();
            stop = true;
        }
    }

    public void autoLogin()
    {
        NetworkSendManager.instance.actions.Enqueue(()=> {
            if (autoID != "")
            {
                SendLoginData(true, autoID, autoPASS);
            }
        });

    }

    public void login()
    {
        SendLoginData(true, t[0].text, t[1].text);
    }
    public void logUp()
    {
        SendLoginData(false, t[0].text, t[1].text);
    }



    void SendLoginData(bool isSignin, string _id, string _pass)
    {
        var fbb = new FlatBufferBuilder(1);
        fbb.Finish(Login.CreateLogin(
            fbb, Class.LogIn,
            isSignin,
            fbb.CreateString(_id),
            fbb.CreateString(_pass)
            ).Value);

        TCPClient.Instance.Send(fbb.SizedByteArray());
    }
}
