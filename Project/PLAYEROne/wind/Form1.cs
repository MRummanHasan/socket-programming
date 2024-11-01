using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wind
{
    public partial class Form1 : Form
    {
        // Blue Player
        public Form1()
        {
            InitializeComponent();
        }
        UdpClient s;
        IPEndPoint to;
        public PictureBox p1;
        bool scb = true;
        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Hide();
            s = new UdpClient(new IPEndPoint(IPAddress.Loopback, 9090));
            to = new IPEndPoint(IPAddress.Loopback, 8080);
            IPEndPoint d = null;
            p1 = pictureBox1;
            object[] ab = { d, s, p1 };
            Thread a = new Thread(new ParameterizedThreadStart(Read));
            a.Start(ab);
            a.IsBackground = true;
            round();
            btnStart.Enabled = false;
        }
        delegate void setmove(string sm);
        public void move(string  sm)
        {
            if (this.pictureBox1.InvokeRequired && this.Ball.InvokeRequired)
            {
                setmove s = new setmove(move);
                this.Invoke(s, new object[] {sm});
            }
            else if (sm == "U" || sm == "D" || sm == "H" || sm == "S" || sm == "Win")
            {
                if (sm == "U")
                {
                    pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y - 4);
                }
                else if (sm == "D")
                {
                    pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y + 4);
                }
                else if (sm == "H")
                {
                    timer1.Stop();
                    timer2.Stop();
                }
                else if (sm == "S")
                {
                    btnStart.Enabled = true;
                }
                else
                {
                    label3.Show();
                    label3.Text = "YOU LOSE :/ \nCLICK TO EXIT GAME";
                }
              
            }
            else
            {
                string[] arr = sm.Split(':');
                int x = int.Parse(arr[0].ToString());
                int y = int.Parse(arr[1].ToString());
                Ball.Top = y;
                Ball.Left = x;

                if (Ball.Bounds.IntersectsWith(pictureBox2.Bounds) )
                {
                    byte[] aaa = ASCIIEncoding.ASCII.GetBytes("H");
                        s.Send(aaa, aaa.Length, to);
                        timer1.Stop();
                        timer2.Stop();
                        if (Ball.Location.Y >( pictureBox2.Location.Y +17 ))
                            timer2.Start();
                        else
                            timer1.Start();
                } 
                
                else if (Ball.Bounds.IntersectsWith(pic_rightwall.Bounds) == true)
                {
                    int sc = int.Parse(lbl_scblue.Text);
                    if (sc < 5 && scb == true)
                    {
                        sc = sc + 1;
                        lbl_scblue.Text = sc.ToString();
                        byte[] aaa = ASCIIEncoding.ASCII.GetBytes("S");
                        s.Send(aaa, aaa.Length, to);
                        scb = false;
                    }
                    else if (sc >= 5)
                    {
                        byte[] aaa = ASCIIEncoding.ASCII.GetBytes("Win");
                        s.Send(aaa, aaa.Length, to);
                        label3.Show();
                        label3.Text = "YOU WIN!!!!\nCLICK TO EXIT GAME";
                        Application.Exit();
                    }
                }
            }


        }
        private void round()
        {
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, Ball.Width - 3, Ball.Height - 3);
            Region rg = new Region(gp);
            Ball.Region = rg;
        }
        public  void Read(object b)
        {
            object[] a = (object[])b;
            IPEndPoint e = (IPEndPoint)a[0];
            UdpClient u = (UdpClient)a[1];
            PictureBox p = (PictureBox)a[2];
            byte[] aaa = u.Receive(ref e);
            string sm = ASCIIEncoding.ASCII.GetString(aaa);
            
          // p.Top = lo;
            move(sm);
            Read(a);

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            Ball.Top -= 3;
            Ball.Left -= 3;
            if (Ball.Bounds.IntersectsWith(pictureBox3.Bounds) == true)
            {
                timer1.Stop();
                timer2.Start();
            }
            if (Ball.Bounds.IntersectsWith(pictureBox1.Bounds) == true)
            {
                timer1.Stop();
            }
            if (Ball.Bounds.IntersectsWith(pic_leftwall.Bounds) == true)
            {
                timer1.Stop();
                int v = int.Parse(lbl_scblack.Text);
                v = v + 1;
                lbl_scblack.Text = v.ToString();
            }
            byte[] aaa = ASCIIEncoding.ASCII.GetBytes(Ball.Location.X + ":" + Ball.Location.Y);
            s.Send(aaa, aaa.Length, to);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up && pictureBox2.Bounds.IntersectsWith(pictureBox3.Bounds) != true)
            {
                pictureBox2.Top -= 4;
                byte[] aaa = ASCIIEncoding.ASCII.GetBytes("U");
                s.Send(aaa, aaa.Length, to);
            }
            if (e.KeyCode == Keys.Down && pictureBox2.Bounds.IntersectsWith(pictureBox4.Bounds) != true)
            {
                pictureBox2.Top += 4;
                byte[] aaa = ASCIIEncoding.ASCII.GetBytes("D");
                s.Send(aaa, aaa.Length, to);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Ball.Top += 3;
            Ball.Left -= 3;
            if (Ball.Bounds.IntersectsWith(pictureBox4.Bounds) == true)
            {
                timer2.Stop();
                timer1.Start();
            }
            if(Ball.Bounds.IntersectsWith(pictureBox1.Bounds) == true)
            {
                timer2.Stop();
            }
            if (Ball.Bounds.IntersectsWith(pic_leftwall.Bounds) == true)
            {
                timer2.Stop();
                int v = int.Parse(lbl_scblack.Text);
                v = v + 1;
                lbl_scblack.Text = v.ToString();
            }
            byte[] aaa = ASCIIEncoding.ASCII.GetBytes(Ball.Location.X + ":" + Ball.Location.Y);
            s.Send(aaa, aaa.Length, to);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            scb = true;
            Ball.Location = new Point(489, 196);
            byte[] aaa = ASCIIEncoding.ASCII.GetBytes(489 + " :" + 196);
            s.Send(aaa, aaa.Length, to);
            Random r = new Random();
            int v = r.Next(1, 2);
            if (v == 2)
            {
                timer1.Start();
            }
            else if (v == 1)
            {
                timer2.Start();
            }
            btnStart.Enabled = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
