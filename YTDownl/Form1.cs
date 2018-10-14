using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YTDownl
{
    public partial class Form1 : Form
    {
        string dlscript;
        Boolean formatSelected = false;
        Boolean validVidID = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void bDownl_Click(object sender, EventArgs e)
        {
            string p1 = "-f ";
            string p2;
            string p3 = " https://www.youtube.com/watch?v=";
            string p3auto = "https://www.youtube.com/watch?v=";
            string p4;
            string args;
            dlscript = @"main.exe";
            if (cbFormat.SelectedItem == "auto")
            {
                p4 = tbAddr.Text;
                p3auto += p4;
                args = p3auto;
            }
            else
            {
                p2 = cbFormat.Text;
                p4 = tbAddr.Text;
                p1 += p2;
                p3 += p4;
                p1 += p3;
                args = p1;
            }
            System.Diagnostics.Process.Start(Application.StartupPath);
            System.Diagnostics.Process.Start(dlscript, args);
            Application.Exit();
        }

        private void cbFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            formatSelected = true;
            if (validVidID)
            {
                lStatus.Text = "Valid!";
                lStatus.ForeColor = Color.Green;
                bDownl.Enabled = true;
            }
            else
            {
                lStatus.Text = "Invalid!";
                lStatus.ForeColor = Color.Red;
                bDownl.Enabled = false;
            }
        }

        private void tbAddr_TextChanged(object sender, EventArgs e)
        {
            if (tbAddr.TextLength == 11)
            {
                validVidID = true;
            }
            else
            {
                validVidID = false;
            }

            if (validVidID && formatSelected)
            {
                lStatus.Text = "Valid!";
                lStatus.ForeColor = Color.Green;
                bDownl.Enabled = true;
            }
            else
            {
                lStatus.Text = "Invalid!";
                lStatus.ForeColor = Color.Red;
                bDownl.Enabled = false;
            }
        }
    }
}
