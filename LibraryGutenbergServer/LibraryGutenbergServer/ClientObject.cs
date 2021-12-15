using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ClassLibraryGutenbergLib;

namespace LibraryGutenbergServer
{
    public class ClientObject
    {
        protected internal NetworkStream Stream { get; private set; }
        TcpClient client;
        ServerObject server; // объект сервера
        protected internal string login;
        User user = new User();
        BinaryFormatter bFormatter = new BinaryFormatter();

        public ClientObject(TcpClient tcpClient, ServerObject serverObject)
        {
            client = tcpClient;
            server = serverObject;
            serverObject.AddConnection(this);
        }

        public void MessageForwarding()
        {
            string message;
            message = user.UserName + " connected";
            bFormatter.Serialize(Stream, user);
            // посылаем сообщение о входе в чат всем подключенным пользователям
            //server.BroadcastMessage(message, user.Login);
            //Console.WriteLine(message);
            // в бесконечном цикле получаем сообщения от клиента
            while (true)
            {
                try
                {
                    message = GetMessage();
                    message = String.Format("{0}: {1}", user.UserName, message);
                    Console.WriteLine(message);
                    //server.BroadcastMessage(message, user.Login);
                }
                catch
                {
                    message = String.Format("{0}: disconnected", user.UserName);
                    Console.WriteLine(message);
                    //server.BroadcastMessage(message, user.Login);
                    break;
                }
            }
        }

        public void Process()
        {
            try
            {
                Stream = client.GetStream();
                this.user = (User)this.bFormatter.Deserialize(Stream);

                if (user.Action == "SignUp")
                {
                    if (Registration("Users.xml", user))
                    {
                        //MessageForwarding();
                    }
                }
                else if (user.Action == "SignIn")
                {
                    if (SignIn("Users.xml", user))
                    {
                        MessageForwarding();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                // в случае выхода из цикла закрываем ресурсы
                server.RemoveConnection(user.Login);
                Close();
            }
        }

        // чтение входящего сообщения и преобразование в строку
        private string GetMessage()
        {
            byte[] data = new byte[64]; // буфер для получаемых данных
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = Stream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (Stream.DataAvailable);

            return builder.ToString();
        }

        public bool SignIn(string path, User user)
        {
            var xdoc = XDocument.Load(path);

            var res = xdoc.Element("Users")
                           .Elements("user").FirstOrDefault(el => el.Element("login").Value == user.Login && el.Element("password").Value == user.Password);

            if (res != null)
            {
                user.UserName = res.Element("name").Value;
                return true;
            }
            else
                return false;
        }

        public bool LoginVerification(string path, User user)
        {
            var xdoc = XDocument.Load(path);

            var res = xdoc.Element("Users")
                           .Elements("user")
                           .Select(el => el.Element("login").Value).ToList();

            foreach (var item in res)
            {
                if (item == user.Login)
                    return false;
            }
            return true;
        }

        public bool Registration(string path, User user)
        {
            if (LoginVerification(path, user))
            {
                var xdoc = XDocument.Load(path);
                XElement userElement = new XElement("user");
                XElement login = new XElement("login", user.Login);
                XElement password = new XElement("password", user.Password);
                XElement name = new XElement("name", user.UserName);

                userElement.Add(login);
                userElement.Add(password);
                userElement.Add(name);

                XElement usersElement = xdoc.Element("Users");
                usersElement.Add(userElement);
                xdoc.Save(path);
                return true;
            }
            else
            {
                return false;
            }
        }

        // закрытие подключения
        protected internal void Close()
        {
            if (Stream != null)
                Stream.Close();
            if (client != null)
                client.Close();
        }
    }
}
