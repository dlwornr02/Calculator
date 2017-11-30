////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        List<double> num = new List<double>(); //result버튼 누르기 전에 값들을 저장하는 List
        List<string> oper = new List<string>(); //result버튼 누르기 전에 연산자들을 저장하는 List
        string h_temp; // *연산과 /연산시 임시로 저장되는 문자열
        bool operclicked; //연산자클릭 전과 후의 동작을 다르게하기위한 변수
        bool first; //시작될때나 C버튼 클릭시 true로 만들어주어 동작을 구분한다.
        bool result_clicked; //result버튼 클릭 후 동작을 구분짓기위한 변수
        string bt_kind; //서버와의 통신을 위해 클릭된 버튼의 종류를 저장하는 변수
        double m_value; //메모리기능을 위해 사용되는 변수
        int count; //result클릭후 바로 문자를 추가할때 추가된 문자열에서 기존문자열을 remove하기위해 선언된 변수

        private Socket mainSocket; //Socket통신에 사용되는 변수
        private byte[] data = new byte[1024]; //고정길이로 데이터를 보내기위한 배열
        private int size = 1024; //고정길이 1024
        IPAddress thisAddress; //클라이언트(계산기)의 IP를 저장하기위한 변수

        public Form1()
        {
            InitializeComponent();
            result_window.ReadOnly = true;
            this.Size = new Size(685, 340);
            this.MinimumSize = new Size(685, 380);
            this.MaximumSize = new Size(685, 380);

            operclicked = false;
            first = true;
            result_clicked = false;
            result_window.Text = "0";
            h_temp = "";
            bt_kind = "";
            m_value = 0;
            count = 0;

            SetIp();
            mainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
        }

        private void num_click(object sender, EventArgs e)
        {
            if (operclicked == false && !first)
            {
                result_window.Text = result_window.Text + ((Button)sender).Text;
            }
            else
            {
                result_window.Text = ((Button)sender).Text;
                operclicked = false;
                first = false;
            }
        }

        private void oper_click(object sender, EventArgs e)
        {
            num.Add(double.Parse(result_window.Text));
            oper.Add(((Button)sender).Text);
            operclicked = true;

            if (!result_clicked)
            {
                if ((((Button)sender).Text == "+" || ((Button)sender).Text == "-"))
                {
                    history.AppendText(h_temp + result_window.Text + "\t\t" + ((Button)sender).Text + "\n");
                    h_temp = "";
                }
                else if (((Button)sender).Text == "/" || ((Button)sender).Text == "*")
                {
                    h_temp += (result_window.Text + ((Button)sender).Text);
                }
            }
            else
            {
                if (((Button)sender).Text == "+" || ((Button)sender).Text == "-")
                {
                    history.AppendText(result_window.Text.Remove(0,count) + "\t\t" + ((Button)sender).Text + "\n");
                    result_clicked = false;
                }
                else if (((Button)sender).Text == "/" || ((Button)sender).Text == "*")
                {
                    
                    h_temp += ((Button)sender).Text;
                    result_clicked = false;
                }
            }
        }

        private void bt_result_Click(object sender, EventArgs e)
        {
            if(result_clicked==true)
            {
                history.AppendText(result_window.Text.Remove(0, count));
                history.AppendText("\n-----------------------------------------------");
                history.AppendText("\n" + result_window.Text);

                count = result_window.Text.Length;
                return;
            }

            num.Add(double.Parse(result_window.Text));
            double result = num[0];

            history.AppendText(h_temp + result_window.Text + "\n");

            for (int i = 1; i <= oper.Count; i++)
            {
                if (oper[i - 1] == "+")
                {
                    result += num[i];
                }
                else if (oper[i - 1] == "-")
                {
                    result -= num[i];
                }
                else if (oper[i - 1] == "/")
                {
                    result /= num[i];
                }
                else if (oper[i - 1] == "*")
                {
                    result *= num[i];
                }
            }

            result_window.Text = result.ToString();
            count = result_window.Text.Length;
            num.Clear();
            oper.Clear();
            h_temp = "";
            history.AppendText("-----------------------------------------------");
            history.AppendText("\n" + result);
            result_clicked = true;
        }
        private void bt_c_Click(object sender, EventArgs e)
        {
            result_window.Text = "0";
            first = true;
            operclicked = false;
            result_clicked = false;
            num.Clear();
            oper.Clear();
            h_temp = "";
            history.AppendText("\n-----------------------------------------------\n");
        }
        private void bt_ce_Click(object sender, EventArgs e)
        {
            if(result_clicked)
            {
                result_window.Text = "0";
                first = true;
                operclicked = false;
                result_clicked = false;
                num.Clear();
                oper.Clear();
                h_temp = "";
                history.AppendText("\n-----------------------------------------------\n");

                return;
            }
            result_window.Text = "0";
            first = true;
        }
        private void bt_pm_Click(object sender, EventArgs e)
        {
            if (result_window.Text == "")
            {
                result_window.Text = "-";
            }
            else if (double.Parse(result_window.Text) > 0)
            {
                result_window.Text = "-" + result_window.Text;
            }
            else if (double.Parse(result_window.Text) < 0)
            {
                result_window.Text = result_window.Text.Replace('-', '\0');
            }
        }

        private void bt_dot_Click(object sender, EventArgs e)
        {
            if (!result_window.Text.Contains("."))
            {
                result_window.Text = result_window.Text + ((Button)sender).Text;
            }
            if (first)
                first = false;
        }


        private void bt_0_Click(object sender, EventArgs e)
        {
            double temp;

            if(double.TryParse(result_window.Text,out temp))
            {
                if(temp>0||temp<0)
                {
                    result_window.Text = result_window.Text + ((Button)sender).Text;
                }
                else if (result_window.Text.Contains("."))
                {
                    result_window.Text = result_window.Text + ((Button)sender).Text;
                }
            }
            
            
        }

        private void bt_MC_Click(object sender, EventArgs e)
        {
            m_value = 0;
        }

        private void bt_Mplus_Click(object sender, EventArgs e)
        {
            m_value += double.Parse(result_window.Text);
        }

        private void bt_Mminus_Click(object sender, EventArgs e)
        {
            m_value -= double.Parse(result_window.Text);
        }

        private void bt_Mread_Click(object sender, EventArgs e)
        {
            result_window.Text = "" + m_value;
        }


        /////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////
        //서버와 통신하기위한 코드

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mainSocket.Connected)
            {
                DisConnectServer();
            }
            //this.Close();
            //this.mainSocket.Close();
        }

        private void SetIp()
        {
            IPHostEntry he = Dns.GetHostEntry(Dns.GetHostName());
            // 처음으로 발견되는 ip 주소를 사용한다.
            foreach (IPAddress addr in he.AddressList)
            {
                if (addr.AddressFamily == AddressFamily.InterNetwork)
                {
                    thisAddress = addr;
                    break;
                }
            }
            // 주소가 없을때
            if (thisAddress == null)
                thisAddress = IPAddress.Loopback;// 로컬호스트 주소(Loop back주소)를 사용한다.
        }
        private void DisConnectServer()
        {
            if (this.mainSocket.Connected)
            {
                bt_kind = "close";
                SendMessaage();
                MessageBox.Show("접속종료");

                this.mainSocket.Shutdown(SocketShutdown.Both);
                //this.mainSocket.Close();
            }
        }
        private void DisConnectbyServer()
        {
            if (this.mainSocket.Connected)
            {
                //bt_kind = "close";
                //SendMessaage();
                //MessageBox.Show("접속종료");

                this.mainSocket.Shutdown(SocketShutdown.Both);
                //this.mainSocket.Close();
            }
        }
        private void ConnectServer(string i, string p)
        {
            string ip = i;
            string port = p; //시연을 위해 일단 서버의 80포트사용
            mainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            try { mainSocket.Connect(ip, Convert.ToInt32(port)); }
            catch (Exception ex)
            {
                MessageBox.Show("연결에 실패했습니다!");
                return;
            }
            mainSocket.BeginReceive(data, 0, size, 0, ReceiveData, mainSocket);
            MessageBox.Show("서버와 연결되었습니다.");
        }
        private void ReceiveData(IAsyncResult iar)
        {
            Socket remote = (Socket)iar.AsyncState;
            if (!remote.Connected)
            {
                return;
            }
            int recv = remote.EndReceive(iar);
            if (recv <= 0)
            {
                remote.Close();
                return;
            }
            string stringData = Encoding.UTF8.GetString(data, 0, recv);
            if(stringData == "Closed")
            {
                MessageBox.Show("서버가 종료되었습니다.");
                mainSocket.Close();
                return;
            }
            else if(stringData=="1")
            {
                num_click(bt_1,null);
            }
            else if (stringData == "2")
            {
                num_click(bt_2, null);
            }
            else if (stringData == "3")
            {
                num_click(bt_3, null);
            }
            else if (stringData == "4")
            {
                num_click(bt_4, null);
            }
            else if (stringData == "5")
            {
                num_click(bt_5, null);
            }
            else if (stringData == "6")
            {
                num_click(bt_6, null);
            }
            else if (stringData == "7")
            {
                num_click(bt_7, null);
            }
            else if (stringData == "8")
            {
                num_click(bt_8, null);
            }
            else if (stringData == "9")
            {
                num_click(bt_9, null);
            }
            else if (stringData == "0")
            {
                bt_0_Click(bt_0, null);
            }
            else if (stringData == "+")
            {
                oper_click(bt_add, null);
            }
            else if (stringData == "-")
            {
                oper_click(bt_sub, null);
            }
            else if (stringData == "/")
            {
                oper_click(bt_div, null);   
            }
            else if (stringData == "*")
            {
                oper_click(bt_mul, null);
            }
            else if (stringData == "=")
            {
                bt_result_Click(bt_result, null);
            }
            else if (stringData == "0")
            {
                bt_0_Click(bt_0, null);
            }
            else if (stringData == ".")
            {
                bt_dot_Click(bt_dot, null);
            }
            else if (stringData == "C")
            {
                bt_c_Click(bt_c, null);
            }
            else if (stringData == "MC")
            {
                bt_MC_Click(bt_MC, null);
            }
            else if (stringData == "M+")
            {
                bt_Mplus_Click(bt_Mplus, null);
            }
            else if (stringData == "M-")
            {
                bt_Mminus_Click(bt_Mminus, null);
            }
            else if (stringData == "MR")
            {
                bt_Mread_Click(bt_Mread, null);
            }

            mainSocket.BeginReceive(data, 0, size, 0, ReceiveData, mainSocket);
        }
        private void SendMessaage()
        {
            byte[] message = Encoding.UTF8.GetBytes(bt_kind);
            mainSocket.Send(message);
        }
        private void 서버연결ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 dlg = new Form2();
            dlg.ShowDialog();

            string ip = dlg.ip;
            string port = dlg.port;

            ConnectServer(ip, port);
        }

        private void 연결해제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisConnectServer();
        }
        private void bt_click(object sender, MouseEventArgs e)
        {
            bt_kind = ((Button)sender).Text;

            if (mainSocket.Connected)
            {
                SendMessaage();
            }
        }


    }
}