using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryGutenbergLib;

namespace LibraryGutenberg
{
    public class ActionWithClient
    {
        private const string host = "127.0.0.1";
        private const int port = 8888;
        private BinaryFormatter bFormatter = new BinaryFormatter();
        public TcpClient client { get; set; }
        public NetworkStream stream { get; set; }

        public ActionWithClient(TcpClient client, NetworkStream stream)
        {
            this.stream = stream;
            this.client = client;
        }

        public User ClientConnection(User user)
        {
            if (!client.Connected)
            {
                client.Connect(host, port);
            }
            stream = client.GetStream();
            bFormatter.Serialize(stream, user);
            user = (User)this.bFormatter.Deserialize(stream);
            return user;
        }
    }
}
