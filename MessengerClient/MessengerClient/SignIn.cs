using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibraryUsers;

namespace MessengerClient
{
    public partial class SignIn : Form
    {
        public TcpClient client { get; set; }
        public NetworkStream stream { get; set; }
        public User user { get; set; }
        ActionWithClient action;

        public SignIn(TcpClient client, NetworkStream stream)
        {
            action = new ActionWithClient(client, stream);
            this.stream = stream;
            this.client = client;
            InitializeComponent();
        }

        private void buttonIN_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == "" || textBoxPassword.Text == "")
            {
                MessageBox.Show("Все поля должны быть заполнены!");
            }
            else
            {
                user = new User
                {
                    Login = textBoxLogin.Text,
                    Password = textBoxPassword.Text,
                    Action = "SignIn"
                };

                try
                {
                    user = action.ClientConnection(user);
                    this.stream = action.stream;
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Неверный Логин или Пароль!");
                    this.Close();
                }
            }
        }
    }
}
