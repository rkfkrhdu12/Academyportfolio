using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FlatBuffers;

public class LoginManager : MonoBehaviour
{


    public Text[] t = new Text[2];


    private void Start()
    {
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
        FlatBufferBuilder fbb = new FlatBufferBuilder(1);
        var id = fbb.CreateString(_id);
        var pass = fbb.CreateString(_pass);

        fbb.Finish(LoginData.CreateLoginData(fbb, isSignin, id, pass, true).Value);

        TCPClient.Instance.Send(fbb.SizedByteArray());
    }
}
