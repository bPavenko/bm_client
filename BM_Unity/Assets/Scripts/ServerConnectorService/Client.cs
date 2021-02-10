using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using UnityEngine;

public class Client : MonoBehaviour
{
    public string clientName;
    
    private bool socketReady;
    private TcpClient socket;
    private NetworkStream stream;
    private StreamWriter writer;
    private StreamReader reader;

    private List<AppClient> connectedClients = new List<AppClient>();

    //If you will reconnect you should destroy previous Client gameObject
    public bool ConnectToServer(string name, string host, int port)
    {
        if (socketReady)
            return false;

        try
        {
            clientName = name;
            socket = new TcpClient(host, port);
            stream = socket.GetStream();
            writer = new StreamWriter(stream);
            reader = new StreamReader(stream);

            socketReady = true;
        }
        catch (Exception e)
        {
            Debug.Log($"Socket error : {e.Message}");
        }

        return socketReady;
    }

    //Sending messages to the server
    public void Send(string data)
    {
        if (!socketReady)
            return;
        
        writer.WriteLine(data);
        writer.Flush();
    }
    
    //Read messages from the server
    private void OnIncomingData(string data)
    {
        Debug.Log("Client: " + data);
        string[] aData = data.Split('|');
        switch (aData[0])
        {
            case "SWHO":
                for (int i = 1; i < aData.Length - 1; i++)
                {
                    UserConnected(aData[i]);
                }
                Send("CWHO|" + clientName);
                break;
            case "SCNN":
                UserConnected(aData[1]);
                break;
        }
    }

    private void UserConnected(string name)
    {
        AppClient c = new AppClient();
        c.name = name;
        connectedClients.Add(c);
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (socketReady)
        {
            if (stream.DataAvailable)
            {
                string data = reader.ReadLine();
                if(data != null)
                    OnIncomingData(data);
            }
        }
    }

    private void OnApplicationQuit()
    {
        CloseSocket();
    }

    private void OnDisable()
    {
        CloseSocket();
    }

    private void CloseSocket()
    {
        if(!socketReady)
            return;
        
        writer.Close();
        reader.Close();
        socket.Close();
        socketReady = false;
    }
}

public class AppClient
{
    public string name;
}
