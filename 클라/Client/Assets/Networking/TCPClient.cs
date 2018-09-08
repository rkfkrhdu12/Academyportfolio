using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using FlatBuffers;
using System.Collections.Concurrent;

public class TCPClient : oNetworkManager
{
    public static TCPClient Instance;
    public string Url;
    public int port;



	public int MY_ID;
	public GetPing pingManager;

    ConcurrentQueue<Action> actions = new ConcurrentQueue<Action>();

    

    #region private members 	
    private TcpClient socketConnection;
    private Thread clientReceiveThread;
    #endregion
    // Use this for initialization 	
    void Start()
    {
        ConnectToTcpServer();
    }

    private void Awake()
    {
        Instance = this;
    }
    

    public void Send(byte[] str)
    {
        SendChat(str);
    }
    public void Send( string str )
    {
        SendChat(str);
    }
    private void OnDestroy()
    {
        socketConnection.Close();
        clientReceiveThread.Abort();
    }
    private void ConnectToTcpServer()
    {
        try
        {
            clientReceiveThread = new Thread(new ThreadStart(ListenForData));
            clientReceiveThread.IsBackground = true;
            clientReceiveThread.Start();
        }
        catch (Exception e)
        {
            Debug.Log("On client connect exception " + e);
        }
    }
    
    

    private void ListenForData()
    {
        try
        {
            socketConnection = new TcpClient(Url, port);
            socketConnection.NoDelay = true;
            Byte[] bytes = new Byte[1024];
            while (true)
            {
                using (NetworkStream stream = socketConnection.GetStream())
                {
                    int length;
                    while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        var incommingData = new byte[length];
                        Array.Copy(bytes, 0, incommingData, 0, length);
                        ByteBuffer bb = new ByteBuffer(incommingData);


                        Base ctype = Base.GetRootAsBase(bb);
                        //Debug.Log("받아온 데이터 수.");

                        var Data = ctype;
						long t = 1;

						if (Data.CType == Class.ping)
						{
							t = (System.DateTime.Now.ToBinary() - ((long)ping.GetRootAsping(ctype.ByteBuffer).Time));
						}

						var m_t = t;
                        actions.Enqueue(()=>
                        {

                            if (NetDataReader.GetInstace().Reder.ContainsKey(Data.CType))
                            {
								//Debug.Log("데이터 받음. [" + Data.CType + "]" + "[" + length + "]");	
								if (Data.CType == Class.ping)
								{
									pingManager.GetPings(m_t);
								}
								NetDataReader.GetInstace().Reder[Data.CType](Data);
                            }
                            else
                            {
                                Debug.Log("잘못된 데이터가 옴.\n[" + Data.CType + "]" + "[" + length + "]");
                            }
                        });
                    }
                }
            }
        }
        catch (SocketException socketException)
        {
            Debug.Log("Socket exception: " + socketException);
            Debug.Log("서버가 닫혀있습니다.");
        }
    }
    private void Update()
    {
        
        if (!actions.IsEmpty)
        {
            foreach (var i in actions)
            {
                Action act;
                actions.TryDequeue(out act);
                act();
            }
        }
    }




	void SendChat(byte[] str)
    {
        if (socketConnection == null)
        {
            Debug.Log("서버가 닫혀있음.");
            return;
        }
        try
        {
            NetworkStream stream = socketConnection.GetStream();
            if (stream.CanWrite)
            {
                byte[] clientMessageAsByteArray = str;
                stream.Write(clientMessageAsByteArray, 0, clientMessageAsByteArray.Length);
                Debug.Log("보낸 데이터 수 ---->");
            }
            else
            {
                Debug.Log("Notsend!");
            }
        }
        catch (SocketException socketException)
        { 
            Debug.Log("Socket exception: " + socketException);
        }
    }






    private void SendChat( string str )
    {
        if (socketConnection == null)
        {
            Debug.Log("null");
            return;
        }
        try
        {		
            NetworkStream stream = socketConnection.GetStream();
            Debug.Log("채팅보낼 준비.");
            if (stream.CanWrite)
            {
                Debug.Log("채팅 보냄.");
                byte[] clientMessageAsByteArray = Encoding.ASCII.GetBytes(str);
                stream.Write(clientMessageAsByteArray, 0, clientMessageAsByteArray.Length);
            }
        }
        catch (SocketException socketException)
        {
            Debug.Log("Socket exception: " + socketException);
        }
    }
}