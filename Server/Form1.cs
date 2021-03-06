﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    public partial class Form1 : Form
    {
        private byte[] data = new byte[1024];
        private int size = 1024;
        private Socket mainSocket = null;
        List<Socket> connectedClients = new List<Socket> { }; //접속한 클라이언트들을 관리하기위한 List
        IPAddress thisAddress;
        delegate void AppendTextDelegate(Control ctrl, string s);
        AppendTextDelegate _textAppender;

        public Form1()
        {
            InitializeComponent();
            SetIp();

            mainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            _textAppender = new AppendTextDelegate(AppendText);
        }

        //초기 IP설정
        private void SetIp()
        {
            IPHostEntry he = Dns.GetHostEntry(Dns.GetHostName());
            // 처음으로 발견되는 ipv4 주소를 사용한다.
            foreach (IPAddress addr in he.AddressList)
            {
                if (addr.AddressFamily == AddressFamily.InterNetwork)
                {
                    thisAddress = addr;
                    break;
                }
            }
            // 주소가 없다면 로컬호스트 주소를 사용한다.
            if (thisAddress == null)
                thisAddress = IPAddress.Loopback;
            txtIp.Text = thisAddress.ToString();
        }

        
        public void startServer()
        {
            int port;
            if (!int.TryParse(txtPort.Text, out port))
            {
                MessageBox.Show("포트 번호가 잘못 입력되었거나 입력되지 않았습니다.");
                txtPort.Focus();
                txtPort.SelectAll();
                return;
            }
            IPEndPoint iep = new IPEndPoint(thisAddress, port);
            mainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            mainSocket.Bind(iep);
            mainSocket.Listen(5);
            mainSocket.BeginAccept(AcceptConn, null); //client 접속시 AcceptConn에서 처리
            txtServerLog.Text += "\nServer Start!";
        }

        public void StopServer()
        {
            if (this.mainSocket != null || this.mainSocket.Connected)
            {
                try
                {
                    string s = "Closed";
                    byte[] buff = Encoding.UTF8.GetBytes(s);
                   
                    //현재 연결되어있는 클라이언트에세 서버가 종료되었다는 사실을 알리고 Socket를 닫는다.
                    for (int i = 0; i < connectedClients.Count(); i++)
                    {
                        connectedClients[i].Send(buff);
                        connectedClients[i].Close();
                    }

                    mainSocket.Close();
                    txtServerLog.Text += "\nServer Stop";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("종료합니다.");
                }
            }
        }


        private void AcceptConn(IAsyncResult ar)
        {
            // 클라이언트의 연결 요청을 수락한다.
            try { 
                Socket client = mainSocket.EndAccept(ar);
                // 또 다른 클라이언트의 연결을 대기한다.
                mainSocket.BeginAccept(AcceptConn, null);

                // 연결된 클라이언트를 리스트에 추가해준다.
                connectedClients.Add(client);

                AppendText(txtServerLog, string.Format("클라이언트 (@ {0})가 연결되었습니다.", client.RemoteEndPoint));
                // 클라이언트의 데이터를 받는다.
                client.BeginReceive(data, 0, size, 0, ReceiveData, client);
            }
            catch(Exception ex)
            {
            }
            
        }

        //클라이언트에게 데이터를 전송하는 메소드
        private void SendData(IAsyncResult iar)
        {
            Socket client = (Socket)iar.AsyncState;
            int sent = client.EndSend(iar);
            client.BeginReceive(data, 0, size, SocketFlags.None, ReceiveData, client);
        }

        private void SendMessaage()
        {
            byte[] message = Encoding.UTF8.GetBytes(txtSend.Text.Trim());
            foreach (var client in this.connectedClients)
            {
                client.Send(message);
            }
            AppendText(this.txtServerLog, txtSend.Text.Trim());
            txtSend.Clear();
        }

        //client에서 데이터가 들어왔을 때 실행한다.
        private void ReceiveData(IAsyncResult iar)
        {
            Socket client = (Socket)iar.AsyncState;
            if (!client.Connected)
                return;
            int recv = client.EndReceive(iar);
            if (recv <= 0)
            {
                client.Shutdown(SocketShutdown.Both);
                client.Close();
                return;
            }
            string recvData = Encoding.UTF8.GetString(data, 0, recv);
            AppendText(this.txtServerLog, client.RemoteEndPoint +  " : " + recvData);

            if (recvData == "close") //클라이언트에게 close데이터를 받을경우 해당 client의 socket을 제거한다.
            {
                connectedClients.Remove(client);
                return;
            }
            int client_n = connectedClients.IndexOf(client)+1;

            byte[] message2 = Encoding.UTF8.GetBytes(recvData);
            foreach (var clients in this.connectedClients)
            {
                if (clients != client) //데이터가 들어온 Socket을 제외하고 데이터를 보내줌
                {
                    clients.Send(message2);
                }
            }

            message2 = Encoding.UTF8.GetBytes("");
            client.BeginSend(message2, 0, message2.Length, SocketFlags.None, SendData, client);
        }

        ///////////////////////////////////////////////////////////////////////////////////

        void AppendText(Control ctrl, string s) //control에 text를 붙여주는 메소드
        {
            if (ctrl.InvokeRequired) ctrl.Invoke(_textAppender, ctrl, s);
            else
            {
                string source = ctrl.Text;
                ctrl.Text = source + Environment.NewLine + s;
            }
        }
        private void txtSend_KeyUp(object sender, KeyEventArgs e)

        {
            if (e.KeyCode == Keys.Enter) //txtSend에서 엔터키를 눌렀을 때 발생하는 이벤트 처리
            {
                SendMessaage();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////
        //버튼 이벤트 처리부분
        private void btStart_Click(object sender, EventArgs e)
        {
            startServer();
        }
        private void btStop_Click(object sender, EventArgs e)
        {
            StopServer();
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            SendMessaage();
        }


        //Form이 종료될 때 발생하는 이벤트처리
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopServer();
        }
    }
}
