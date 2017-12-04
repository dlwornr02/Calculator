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

            //사용자의 IP설정
            SetIp();

            //서버와의 통신에 쓰일 Socket의 인스턴스를 생성해준다.
            mainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            
        }

        private void num_click(object sender, EventArgs e) 
            //1~9까지의 숫자가 클릭되었을 때 발생하는 이벤트를 처리해주는 이벤트핸들러
        {
            if (operclicked == false && !first) //첫실행이거나 연산자 또는 C가 클릭된 직후가 아니라면
            {
                result_window.Text = result_window.Text + ((Button)sender).Text;
            }
            else //첫실행 또는 Clear버튼이 눌렷거나 연산자 클릭 직후일 때 실행
            {
                result_window.Text = ((Button)sender).Text;
                operclicked = false;
                first = false;
            }
        }

        private void oper_click(object sender, EventArgs e) // +,-,*,/ 클릭시 이벤트를 처리하는 이벤트핸들러
        {
            num.Add(double.Parse(result_window.Text)); //number리스트에 추가해준다.
            oper.Add(((Button)sender).Text); //이벤트가 발생한 연산자버튼의 Text속성값을 가져온다.
            operclicked = true;

            if (!result_clicked) //일반적인상황
            {
                if ((((Button)sender).Text == "+" || ((Button)sender).Text == "-"))
                {
                    history.AppendText(h_temp + result_window.Text + "\t\t" + ((Button)sender).Text + "\n");
                    h_temp = "";
                }
                else if (((Button)sender).Text == "/" || ((Button)sender).Text == "*")
                {
                    // /or*연산자의 경우 저장했다가 한번에출력
                    h_temp += (result_window.Text + ((Button)sender).Text);
                }
            }
            else // =버튼이 클릭된 직후 연산자가 클릭되었을 경우(history에 남아있는 text와 더해진 text를 더해준다.)
            {
                if (((Button)sender).Text == "+" || ((Button)sender).Text == "-")
                {
                    //추가된 text가 있다면 추가되고 없다면 바로 연산
                    //count라는 변수로 bt_result가 클릭된 직후 결과창에 남아있는 텍스트 길이를 저장한다.
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

        private void bt_result_Click(object sender, EventArgs e) //bt_result(=)이 클릭되었을 때
        {
            if(result_clicked==true) //=버튼을 연산없이 두번누를 경우 실행
            {
                history.AppendText(result_window.Text.Remove(0, count)); //숫자가 추가되었을 경우 추가된 text만 append
                history.AppendText("\n-----------------------------------------------");
                history.AppendText("\n" + result_window.Text);

                count = result_window.Text.Length;
                return; //아래문장 실행X
            }

            num.Add(double.Parse(result_window.Text)); //마지막에 결과창에 남아있는 숫자추가

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
            count = result_window.Text.Length; //연산자나 결과를 바로 눌렀을 경우를 대비하여 미리 저장해준다.
            num.Clear(); 
            oper.Clear();
            h_temp = ""; 
            history.AppendText("-----------------------------------------------");
            history.AppendText("\n" + result);
            result_clicked = true;
        }
        private void bt_c_Click(object sender, EventArgs e) //모두초기화
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
        private void bt_ce_Click(object sender, EventArgs e) //현재 숫자만 초기화
        {
            if(result_clicked) //bt_result가 눌린후라면 bt_c와 동일하게 동작
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
        private void bt_pm_Click(object sender, EventArgs e) // +/-버튼이 클릭되었을 때 이벤트처리
        {
            //양수/음수의 경우 동작
            if (double.Parse(result_window.Text) > 0)
            {
                result_window.Text = "-" + result_window.Text;
            }
            else if (double.Parse(result_window.Text) < 0)
            {
                result_window.Text = result_window.Text.Replace("-", "");
            }
        }

        private void bt_dot_Click(object sender, EventArgs e) //bt_dot클릭시 이벤트처리
        {
            if (!result_window.Text.Contains("."))  // "."을 포함하지 않을때 붙여준다.
            {
                result_window.Text = result_window.Text + ((Button)sender).Text;
            }
            if (first) //0.으로 시작가능하게
                first = false;
        }


        private void bt_0_Click(object sender, EventArgs e)
        {
            double temp;

            if(double.TryParse(result_window.Text,out temp))
            {
                if(temp>0||temp<0) //00이나 000이 안되게
                {
                    result_window.Text = result_window.Text + ((Button)sender).Text;
                }
                else if (result_window.Text.Contains(".")) //.이 있다면 가능
                {
                    result_window.Text = result_window.Text + ((Button)sender).Text;
                }
            }
            
            
        }

        private void bt_MC_Click(object sender, EventArgs e) //bt_MC클릭시 이벤트 처리
        {
            m_value = 0; //저장하던 값을 초기화
        }

        private void bt_Mplus_Click(object sender, EventArgs e) 
        {
            m_value += double.Parse(result_window.Text); //저장변수에 현재 창의 값을 더해준다.
        }

        private void bt_Mminus_Click(object sender, EventArgs e)
        {
            m_value -= double.Parse(result_window.Text); //저장변수에 현재 창의 값을 빼준다.
        }

        private void bt_Mread_Click(object sender, EventArgs e)
        {
            result_window.Text = "" + m_value; //메모리에 있는값을 결과창에 display해준다.
        }


        /////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////
        //서버와 통신하기위한 코드

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) //Form이 종료될 때의 이벤트 처리
        {
            //계산기가 종료될 때 서버와 연결되어있다면 연결을 해제해줘야한다.
            if (mainSocket.Connected)
            {
                DisConnectServer();
            }
        }

        private void SetIp()
        {
            IPHostEntry he = Dns.GetHostEntry(Dns.GetHostName());
            // 처음으로 발견되는 ip 주소를 프로그램의 ip주소로 사용한다.
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

        //server와의 연결을 해제하는 메소드
        private void DisConnectServer()
        {
            if (this.mainSocket.Connected)
            {
                bt_kind = "close";
                SendMessaage();
                MessageBox.Show("접속종료");

                this.mainSocket.Shutdown(SocketShutdown.Both);
                this.mainSocket.Close();
            }
        }

        //서버와 연결하는 메소드
        private void ConnectServer(string i, string p)
        {
            string ip = i;
            string port = p; 

            //서버와 연결을 위한 socket생성
            mainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            //예외처리
            try { mainSocket.Connect(ip, Convert.ToInt32(port)); }
            catch (Exception ex)
            {
                MessageBox.Show("연결에 실패했습니다!");
                return;
            }
            mainSocket.BeginReceive(data, 0, size, 0, ReceiveData, mainSocket);
            MessageBox.Show("서버와 연결되었습니다.");
        }

        //서버에서 데이터를 받았을 때 발생하는 이벤트를 처리하는 부분(프로토콜)
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

            //서버가 종료되었다는 데이터를 받으면 소켓을 닫아준다.
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

        //Server로 데이터를 전송하는 부분
        private void SendMessaage()
        {
            byte[] message = Encoding.UTF8.GetBytes(bt_kind);
            mainSocket.Send(message);
        }

        //MenuItem클릭시 발생하는 이벤트처리하는 부분
        private void 서버연결ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 dlg = new Form2();
            //dlg의 DialogResult가 OK라면 연결해준다.
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string ip = dlg.ip;
                string port = dlg.port;
                ConnectServer(ip, port);
            }
        }

        private void 연결해제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisConnectServer();
        }

        //모든 버튼클릭시 발생하는 이벤트처리기로 버튼의 text를 저장한뒤 server와 연결되어있다면 데이터를 전송한다.
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