using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using SimpleTCP;

namespace TCPListener
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SimpleTcpServer server;
       /* void ps()
        {
            IPAddress ipAddr = IPAddress.Parse("192.168.1.0");
            TcpListener myList = new TcpListener(ipAddr, 8000);
        }
        */
        private void Form1_Load(object sender, EventArgs e)
        {
            server = new SimpleTcpServer();
            server.Delimiter = 0x13; //enter
            server.StringEncoder = Encoding.UTF8;
            server.DataReceived += Server_DataReceived;

        }

        private void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            textBox1.Text += e.MessageString;
            e.ReplyLine(string.Format("You said: {0} ", e.MessageString));
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            IPAddress ip = IPAddress.Parse("192.168.1.100");
            server.Start(ip,8000);
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            if (server.IsStarted)
            {
                server.Stop();
            }
        }

    }
}
