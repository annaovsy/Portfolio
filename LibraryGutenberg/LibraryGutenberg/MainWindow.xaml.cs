using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClassLibraryGutenbergLib;

namespace LibraryGutenberg
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TcpClient client;
        NetworkStream stream;
        User user = new User();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            client = new TcpClient();
            SignIn signIn = new SignIn(client, stream);
            if (signIn.ShowDialog() == true)
            {
                this.user = signIn.user;
                this.stream = signIn.stream;
                this.client = signIn.client;
                SignInBtn.IsEnabled = false;
                SignUpBtn.IsEnabled = false;
                MessageBox.Show($"Добро пожаловать, {user.UserName}");

                //ThreadStart();
            }
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            client = new TcpClient();
            SignUp signUp = new SignUp(client, stream);
            if (signUp.ShowDialog() == true)
            {
                this.user = signUp.user;
                this.stream = signUp.stream;
                this.client = signUp.client;
                SignInBtn.IsEnabled = false;
                SignUpBtn.IsEnabled = false;
                MessageBox.Show($"Добро пожаловать, {user.UserName}");

                //ThreadStart();
            }

        }

        //void ThreadStart()
        //{
        //    // запускаем новый поток для получения данных
        //    Thread receiveThread = new Thread(new ThreadStart(ReceiveMessage));
        //    receiveThread.Start(); //старт потока
        //    MessageBox.Show("Добро пожаловать, {user.UserName}");
        //}

        //void SendMessage()
        //{
        //    string message = textBoxMsg.Text;
        //    byte[] data = Encoding.Unicode.GetBytes(message);
        //    stream.Write(data, 0, data.Length);
        //    textBoxMsg.Clear();
        //}

        //получение сообщений
        //void ReceiveMessage()
        //{
        //    try
        //    {
        //        while (true)
        //        {
        //            byte[] data = new byte[64]; // буфер для получаемых данных
        //            StringBuilder builder = new StringBuilder();
        //            int bytes = 0;
        //            do
        //            {
        //                bytes = stream.Read(data, 0, data.Length);
        //                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
        //            }
        //            while (stream.DataAvailable);
        //            string message2 = builder.ToString();
        //            textBoxMain.Invoke((MethodInvoker)delegate
        //            {
        //                textBoxMain.Text += "\r\n" + message2;// вывод сообщения
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Disconnect();
        //    }

        //}

        //void Disconnect()
        //{
        //    if (stream != null)
        //    {
        //        stream.Close();//отключение потока
        //    }
        //    if (client != null)
        //    {
        //        client.Close();//отключение клиента
        //    }
        //    buttonSwitchOff.Enabled = false;
        //    buttonSignIN.Enabled = true;
        //    buttonSignUp.Enabled = true;
        //    textBoxMain.Invoke((MethodInvoker)delegate
        //    {
        //        textBoxMain.Clear();
        //    });
        //}
    }
}
