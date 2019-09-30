using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace notepad
{
    public partial class Form1 : Form
    {
        SaveFileDialog sfd = new SaveFileDialog();
        OpenFileDialog ofd = new OpenFileDialog();
        public string contents = string.Empty;
        string currentFileLoc;

        string path = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult openResult = openFileDialog1.ShowDialog();
            if (openResult == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
                try
                {
                    StreamReader fileOpen = new StreamReader(path);
                    String contents = fileOpen.ReadToEnd();
                    fileOpen.Close();

                    richTextBox1.Text = contents;
                }
                catch (IOException ioe)
                {
                    MessageBox.Show("Error opening file: "+ioe.Message);
                }
            }

        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (path == String.Empty)
            {
                DialogResult saveResult = saveFileDialog1.ShowDialog();

                if (saveResult == DialogResult.OK)
                {
                    path = saveFileDialog1.FileName;

                    try
                    {
                        StreamWriter sw = new StreamWriter(path);
                        sw.Write(richTextBox1.Text);
                        sw.Close();
                    }
                    catch (IOException ioe)
                    {

                        MessageBox.Show("Error saving file: " + ioe.Message);
                    }
                }
            }
            else
            {
                try
                {
                    StreamWriter sw = new StreamWriter(path);
                    sw.Write(richTextBox1.Text);
                    sw.Close();
                }
                catch (IOException ioe)
                {

                    MessageBox.Show("Error saving file: " + ioe.Message);
                }
            }
            //if (currentFileLoc != null)
            //{
            //    using (StreamWriter writer = new StreamWriter(currentFileLoc))
            //    {
            //        writer.WriteLine(richTextBox1.Text);
            //    }
            //}
            //else
            //    SaveFile();
        }


        //private int SaveFile()
        //{
        //    sfd.Filter = "Text Documents|*.txt";
        //    sfd.DefaultExt = "txt";
        //    if (sfd.ShowDialog() == DialogResult.Cancel)
        //    {
        //        richTextBox1.Focus();
        //        return 0;
        //    }
        //    else
        //    {
        //        contents = richTextBox1.Text;
        //        if (this.Text == "Untitled")
        //            richTextBox1.SaveFile(sfd.FileName, RichTextBoxStreamType.PlainText);
        //        else
        //        {
        //            sfd.FileName = this.Text;
        //            richTextBox1.SaveFile(sfd.FileName, RichTextBoxStreamType.PlainText);
        //        }
        //        this.Text = sfd.FileName;
        //        //
        //        currentFileLoc = sfd.FileName;
        //        return 1;
        //    }
        //}


        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog1 = new FontDialog();
            DialogResult result = fontDialog1.ShowDialog();

            // Get Font.
            Font font = fontDialog1.Font;
            // Set TextBox properties.
            this.richTextBox1.Font = font;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

 

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
       
            MessageBox.Show("Developed & Design by: Rumman\nCode: https://github.com/MRummanHasan/socket-programming \nConcept by: Microsoft Notepad");
       
        }

        private void wrapTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wrapTextToolStripMenuItem.Checked == true)
            {
                richTextBox1.WordWrap = true;
            }
            else
            {
                richTextBox1.WordWrap = false;
            }
        }
 
    }
}
