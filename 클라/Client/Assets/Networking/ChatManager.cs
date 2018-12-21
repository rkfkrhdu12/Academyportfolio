using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using FlatBuffers;


public class ChatManager : MonoBehaviour
{
    public static bool IsChatOn = false;

    [SerializeField] Text chatData_;
    [SerializeField] GameObject chatUI_;
    [SerializeField] InputField inf_;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (chatUI_.activeSelf)
            {
                if (chatData_.text.Length > 0)
                {
                    Send();
                    inf_.text = "";
                    inf_.ActivateInputField();
                }
                else
                {
                    IsChatOn = false;
                    chatUI_.SetActive(false);
                    inf_.text = "";
                }
            }
            else
            {
                IsChatOn = true;
                chatUI_.SetActive(true);
                inf_.ActivateInputField();
            }
        }

        if (chatUI_.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                inf_.text = "";
                chatUI_.SetActive(false);
            }
        }
    }

    private void Start()
    {
        NetDataReader.GetInstace().Reder[Class.fChat] = (data) =>
        {
            var chatD_ = fChat.GetRootAsfChat(data.ByteBuffer);
            chatUI_.GetComponent<ChatView>().Addchat(OtherPlayers.instance.GetName(chatD_.PID)+ " : " +  chatD_.Str );
        };
    }

    public void Send()
    {
        if (chatData_.text.Length > 0)
        {
            var fbb = new FlatBufferBuilder(1);
            fbb.Finish(fChat.CreatefChat(fbb, Class.fChat, BPlayer.MainPlayer.GetComponent<oNetworkIdentity>().id,fbb.CreateString(chatData_.text)).Value);
            TCPClient.Instance.Send(fbb.SizedByteArray());
        }
    }
}
