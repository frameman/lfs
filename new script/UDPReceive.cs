using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.InteropServices;


public class UDPReceive : MonoBehaviour
{

    Thread receiveThread;
    UdpClient client; 

    public int port = 5052;
    public bool startRecieving = true;
    public bool[] boolist = new bool[] {false,false,false,false,false,false,false,false,false,false,false,false,false,false};

    public void Start()
    {

        receiveThread = new Thread(
            new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }
    
    private void ReceiveData()
    {
        IPAddress localAddr = IPAddress.Parse("127.0.0.1");
        Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        listener.Bind(new IPEndPoint(localAddr, port));
        while (startRecieving)
        {

            try
            {
                //接收數據
                EndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] buffer = new byte[1024];
                int bytesRead = listener.ReceiveFrom(buffer, ref anyIP);
                //解包數據成boolean值
                GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
                try
                {
                    IntPtr bufferPtr = handle.AddrOfPinnedObject();
                    for (int i = 0; i < bytesRead; i++)
                    {
                        boolist[i] = Marshal.ReadByte(bufferPtr, i) != 0;
                        //print("boollist["+i+"] = "+boolist[i]);
                    }
                }
                finally
                {
                    //print("finally");
                    handle.Free();
                }
                
                
            }
            catch (Exception err)
            {
                print(err.ToString());
            }
        }
        listener.Close();
    }
    
}