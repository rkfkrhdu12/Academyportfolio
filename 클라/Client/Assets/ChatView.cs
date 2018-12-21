using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatView : MonoBehaviour
{
    [SerializeField] RectTransform chatView_;
    [SerializeField] Text text_;

    Queue<string> chat_ = new Queue<string>();

    public void Addchat(string chat)
    {
        if (chat_.Count < 20)
        {
            chat_.Enqueue(chat);
            if(chat_.Count > 7)
            {
                chatView_.sizeDelta = new Vector2(chatView_.sizeDelta.x, chatView_.sizeDelta.y + (text_.fontSize + 5));
            }
        }
        else
        {
            chat_.Dequeue();
            chat_.Enqueue(chat);
        }


        TextUpdate();
    }

    public void TextUpdate()
    {
        bool b = true;
        text_.text = "";
        foreach (var i in chat_)
        {
            if (b) { b = false; text_.text += i; continue; }
            text_.text += "\n" + i;
        }
    }
}
