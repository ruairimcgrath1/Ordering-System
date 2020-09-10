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
    public partial class frmRegister : Form
    {        
        //Variables
        const int ArrayLimit = 30;
        String[] Username = new String[ArrayLimit];
        String[] password = new String[ArrayLimit];
        String[] Email = new String[ArrayLimit];
        int ArraySize = 0;

        public frmRegister()
        {
            InitializeComponent();
        }



        private void frmRegister_Load(object sender, EventArgs e)
        {
            StreamReader oRead = null;
            StreamWriter oWrite = null;
            oRead = File.OpenText(@"J:\Foundation Degree\Assignments\Year 2\Programming .NET\Assignment 1\RMC_Ordering_System\Documents\Login.txt");
            try
            {
                while (oRead.Peek() != -1)
                {
                    String data = oRead.ReadLine();
                    String[] objectData = data.Split(',');

                    Username[ArraySize] = objectData[0];
                    password[ArraySize] = objectData[1];
                    Email[ArraySize] = objectData[2];

                    ArraySize++;
                    Activate();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }

            try
            {
                oWrite = File.OpenText(@"J:\Foundation Degree\Assignments\Year 2\Programming .NET\Assignment 1\RMC_Ordering_System\Documents\Login.txt"); //Open for Writing
                for (int cnt = 0; cnt < ArraySize; cnt++)
                {
                    //get string
                    String strData = Username[cnt] + "," + password[cnt] + "," + Email[cnt];
                    oWrite.WriteLine(strData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
            try
            {
                while (oRead.Peek() != -1)
                {
                    String data = oRead.ReadLine();
                    String[] ObjectData = data.Split(',');
                    if (txtUsername.Text.Equals(ObjectData[0]))
                    {
                        picUsername.Visible = true;
                        lblErrorUsername.Visible = false;
                        picUsername.Image = Properties.Resources.Green_Tick;
                    }
                    else
                    {
                        picUsername.Visible = true;
                        lblErrorUsername.Visible = true;
                        picUsername.Image = Properties.Resources.Red_X;
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

            if (txtPassword.Text == txtConfirmPassword.Text)
            {
                picPassword.Visible = true;
                lblErrorPasswords.Visible = false;
                picPassword.Image = Properties.Resources.Green_Tick;
            }
            else
            {
                picPassword.Visible = true;
                lblErrorPasswords.Visible = true;
                picPassword.Image = Properties.Resources.Red_X;
            }

            if (txtEmail.Text == txtConfirmEmail.Text)
            {
                picEmail.Visible = true;
                lblErrorEmail.Visible = false;
                picEmail.Image = Properties.Resources.Green_Tick;
            }
            else
            {
                picEmail.Visible = true;
                lblErrorEmail.Visible = true;
                picEmail.Image = Properties.Resources.Red_X;
            }

        }        
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Username[ArraySize] = txtUsername.Text;
            password[ArraySize] = txtPassword.Text;
            Email[ArraySize] = txtEmail.Text;

            MessageBox.Show("Information saved");

            txtUsername.Text = "";
            txtPassword.Text = "";
            txtEmail.Text = "";
            txtConfirmPassword.Text = "";
            txtConfirmEmail.Text = "";


            ArraySize++;
        }
    }
}
