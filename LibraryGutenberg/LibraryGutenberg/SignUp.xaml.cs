using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ClassLibraryGutenbergLib;

namespace LibraryGutenberg
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public TcpClient client { get; set; }
        public NetworkStream stream { get; set; }
        public User user { get; set; }
        ActionWithClient action;

        public SignUp(TcpClient client, NetworkStream stream)
        {
            InitializeComponent();

            action = new ActionWithClient(client, stream);
            this.stream = stream;
            this.client = client;
        }

        private void SignUpBtn_Click(object sender, RoutedEventArgs e)
        {
            if (tboxLogin.Text == ""
                || tboxPassword.Text == ""
                || tboxName.Text == "")
            {
                MessageBox.Show("Все поля должны быть заполнены!");
            }
            else
            {
                user = new User
                {
                    UserName = tboxName.Text,
                    Login = tboxLogin.Text,
                    Password = tboxPassword.Text,
                    Action = "SignUp"
                };

                try
                {
                    user = action.ClientConnection(user);
                    this.stream = action.stream;
                    DialogResult = true;
                    MessageBox.Show("Пользователь успешно зарегистрирован!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Такой Логин уже существует!");
                    this.Close();
                }
            }

        }
    }
}
