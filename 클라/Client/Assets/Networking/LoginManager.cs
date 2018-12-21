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
    public Text[] suT = new Text[4];


    public string autoID;
    public string autoPASS;

    float dt;



    bool state_Login = true; // in : true, up : false

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
                if (state_Login)
                {
                    GetComponent<OnServerStart>().Started(int.Parse(LoginData.Id));
                    LoginUI.SetActive(false);
                    Destroy(GetComponent<LoginManager>());
                }
                else
                {
                    SendLoginData(true, suT[0].text, suT[1].text);
                    state_Login = true;
                }
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
            if (TCPClient.Instance.DEBUG_MODE)
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
        if (suT[1].text != suT[2].text)
        {
            suT[2].color = Color.red;
            DelayManager.DelayStart(()=> {
                suT[2].color = Color.black;
            },0.5f);
        }
        else
        {
            state_Login = false;
            SendLoginData(false, suT[0].text, suT[1].text, suT[3].text);
        }
    }



    void SendLoginData(bool isSignin, string _id, string _pass, string name = "")
    {
        var fbb = new FlatBufferBuilder(1);
        fbb.Finish(Login.CreateLogin(
            fbb, Class.LogIn,
            isSignin,
            fbb.CreateString(_id),
            fbb.CreateString(_pass),
            true,
            fbb.CreateString(name)
            ).Value);

        TCPClient.Instance.Send(fbb.SizedByteArray());
    }
}
