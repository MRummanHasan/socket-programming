using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        TcpClient client = null;
        public Form1()
        {
            InitializeComponent();

            client = new TcpClient("127.0.0.1", 8888);
            NetworkStream ns = client.GetStream();
            StreamReader sr = new StreamReader(ns);

            txtboxServerMsg.Text = "Server >> " + sr.ReadLine();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtboxServerMsg.Text != "")
            {
                NetworkStream ns = client.GetStream();
                StreamWriter sw = new StreamWriter(ns);
                sw.WriteLine(txtBoxClientMsg.Text);

                sw.Flush();
                sw.Close();
                ns.Close();
            }

        }

        private void txtBoxClientMsg_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
