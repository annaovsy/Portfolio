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
    public partial class SignUp : Form
    {
        public TcpClient client { get; set; }
        public NetworkStream stream { get; set; }
        public User user { get; set; }
        ActionWithClient action;

        public SignUp(TcpClient client, NetworkStream stream)
        {
            action = new ActionWithClient(client, stream);
            this.stream = stream;
            this.client = client;
            InitializeComponent();
        }

        private void buttonReg_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == ""
              || textBoxPassword.Text == ""
              || textBoxName.Text == "")
            {
                MessageBox.Show("Все поля должны быть заполнены!");
            }
            else
            {
                user = new User
                {
                    UserName = textBoxName.Text,
                    Login = textBoxLogin.Text,
                    Password = textBoxPassword.Text,
                    Action = "SignUp"
                };

                try
                {
                    user = action.ClientConnection(user);
                    this.stream = action.stream;
                    DialogResult = DialogResult.OK;
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
