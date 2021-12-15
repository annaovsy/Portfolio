using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibraryUsers;

namespace MessengerClient
{
    public partial class MainForm : Form
    {
        TcpClient client;
        NetworkStream stream;
        User user = new User();

        public MainForm()
        {
            InitializeComponent();
            buttonSwitchOff.Enabled = false;
        }

        private void buttonSignIN_Click(object sender, EventArgs e)
        {
            client = new TcpClient();
            SignIn signIn = new SignIn(client, stream);
            if (signIn.ShowDialog() == DialogResult.OK)
            {
                this.user = signIn.user;
                this.stream = signIn.stream;
                this.client = signIn.client;
                buttonSwitchOff.Enabled = true;
                buttonSignUp.Enabled = false;
                buttonSignIN.Enabled = false;
                ThreadStart();
            }
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            client = new TcpClient();
            SignUp signUp = new SignUp(client, stream);
            if (signUp.ShowDialog() == DialogResult.OK)
            {
                this.user = signUp.user;
                this.stream = signUp.stream;
                this.client = signUp.client;
                buttonSwitchOff.Enabled = true;
                buttonSignIN.Enabled = false;
                buttonSignUp.Enabled = false;
                ThreadStart();
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void buttonSwitchOff_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        void ThreadStart()
        {
            // запускаем новый поток для получения данных
            Thread receiveThread = new Thread(new ThreadStart(ReceiveMessage));
            receiveThread.Start(); //старт потока
            textBoxMain.Text += $"\nДобро пожаловать, {user.UserName}";
        }

        void SendMessage()
        {
            string message = textBoxMsg.Text;
            byte[] data = Encoding.Unicode.GetBytes(message);
            stream.Write(data, 0, data.Length);
            textBoxMsg.Clear();
        }

        //получение сообщений
        void ReceiveMessage()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[64]; // буфер для получаемых данных
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);
                    string message2 = builder.ToString();
                    textBoxMain.Invoke((MethodInvoker)delegate
                    {
                        textBoxMain.Text += "\r\n" + message2;// вывод сообщения
                    });
                }
            }
            catch (Exception ex)
            {
                Disconnect();
            }

        }

        void Disconnect()
        {
            if (stream != null)
            {
                stream.Close();//отключение потока
            }
            if (client != null)
            {
                client.Close();//отключение клиента
            }
            buttonSwitchOff.Enabled = false;
            buttonSignIN.Enabled = true;
            buttonSignUp.Enabled = true;
            textBoxMain.Invoke((MethodInvoker)delegate
            {
                textBoxMain.Clear();
            });
        }
    }
}
