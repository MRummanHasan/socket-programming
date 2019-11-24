using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendEmailwithCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("mrummanhasan@gmail.com");
                mail.To.Add("misbahanwer129@gmail.com");
                mail.Subject = "Test Mail";
                mail.Body = "This is a lab task of Rumman-60661 for testing SMTP mail from GMAIL";

                SmtpServer.Port = 587;

                #region
                SmtpServer.Credentials = new System.Net.NetworkCredential("mrummanhasan@gmail.com", "password");
                #endregion


                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("mail Send");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
