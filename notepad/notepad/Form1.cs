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

        public Form1()
        {
            InitializeComponent();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Only open RTF Files i.e Wordpad
            // Create an OpenFileDialog to request a file to open.
            OpenFileDialog openFile1 = new OpenFileDialog();

            // Initialize the OpenFileDialog to look for RTF files.
            openFile1.DefaultExt = "*.rtf";
            openFile1.Filter = "RTF Files|*.rtf";

            // Determine whether the user selected a file from the OpenFileDialog.
            if (openFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK && openFile1.FileName.Length > 0)
            {
                // Load the contents of the file into the RichTextBox.
                richTextBox1.LoadFile(openFile1.FileName);
            }
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentFileLoc != null)
            {
                using (StreamWriter writer = new StreamWriter(currentFileLoc))
                {
                    writer.WriteLine(richTextBox1.Text);
                }
            }
            else
                SaveFile();
        }
        private int SaveFile()
        {
            sfd.Filter = "Text Documents|*.txt";
            sfd.DefaultExt = "txt";
            if (sfd.ShowDialog() == DialogResult.Cancel)
            {
                richTextBox1.Focus();
                return 0;
            }
            else
            {
                contents = richTextBox1.Text;
                if (this.Text == "Untitled")
                    richTextBox1.SaveFile(sfd.FileName, RichTextBoxStreamType.PlainText);
                else
                {
                    sfd.FileName = this.Text;
                    richTextBox1.SaveFile(sfd.FileName, RichTextBoxStreamType.PlainText);
                }
                this.Text = sfd.FileName;
                //
                currentFileLoc = sfd.FileName;
                return 1;
            }
        }


        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
