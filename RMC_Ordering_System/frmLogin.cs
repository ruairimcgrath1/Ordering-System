using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace RMC_Ordering_System
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            StreamReader oRead = null;
            oRead = File.OpenText(@"J:\Foundation Degree\Assignments\Year 2\Programming .NET\Assignment 1\RMC_Ordering_System\Documents\Login.txt");

            try
            {
                while (oRead.Peek() != -1)
                {
                    String data = oRead.ReadLine();
                    String[] ObjectData = data.Split(',');
                    if (txtUsername.Text.Equals(ObjectData[0]))
                    {
                        if(txtPassword.Text.Equals(ObjectData[1]))
                        {
                            frmMenu Menu = new frmMenu();
                            Menu.Show();
                            this.Hide();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Username or Password is incorrect");
                        txtUsername.Text = "";
                        txtPassword.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                oRead.Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtUsername.Text = "";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRegister Register = new frmRegister();
            Register.Show();
            this.Hide();
        }
    }
}
