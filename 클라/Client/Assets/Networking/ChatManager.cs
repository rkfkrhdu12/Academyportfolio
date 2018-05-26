using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;








class chatListQueueData
{
    public chatListQueueData(Action<string> func, string data)
    {
        this.func = func;
        this.data = data;
    }


    public Action<string> func;
    public string data;
}

public class ChatManager : MonoBehaviour
{
    public static ChatManager instance;

    LinkedList<chatListQueueData> chatListQueue = new LinkedList<chatListQueueData>();

    [SerializeField]
    Text chatList;


    private void Awake()
    {
        instance = this;
    }

    void OnChat(string text)
    {
        chatList.text += "\n" + text;
    }


    public void OnChatList(string text)
    {
        chatListQueue.AddLast(new chatListQueueData(OnChat, text));
    }
    public void OnChatList(Text text)
    {
        OnChatList(text.text);
    }


    private void Update()
    {
        var it = chatListQueue.First;
        while (it != null)
        {
            var thisIt = it;
            it = it.Next;
            thisIt.Value.func(thisIt.Value.data);
            chatListQueue.Remove(thisIt);
        }
    }

    public void Send(string text)
    {
        ClientManager.instance.Send(text);
    }

    public void Send(Text text)
    {
        Send(text.text);
    }
}
