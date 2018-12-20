using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;
using Capstone.QR.Tools;
using Capstone.QR.Properties;
using System.Xml;

namespace Capstone.QR
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        int attempt = 0;

        private void btnLogin_Click(object sender, EventArgs e)
        {


            string user = Uname.Text.Trim();
            string pass = Passwd.Text.Trim();
            try
            {
                if (attempt >= 3) { 
                    MessageBox.Show("You have reached the maximum login attempt, Exiting...", "Alert");
                    this.Close();
                }

                if (user == "" || pass == "")
                {
                    MessageBox.Show("Please fill-up the following fields to continue.", "Attention");
                }
                else if (SqlUtils.VerifyAccount(user, pass))
                {
                    var Panel = new AdminPanel();
                    Panel.Show();
                    Hide();
                    if (rememberBtn.Checked)
                    {
                        Windows.CreateSession(user, Cipher.Encrypt(pass, Cipher.secret));
                    }
                }
                else
                {
                    attempt += 1;
                    loginStatus.Text = "Invalid username or password!";
                }
                
            } catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void login_Activated(object sender, EventArgs e)
        {
            if (Windows.RememberUser())
            {
                new UserChecker().Show();
                Hide();
            }
            Uname.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (rememberBtn.Checked == false)
            {
                rememberBtn.Checked = true;
            }
            else
            {
                rememberBtn.Checked = false;
            }
        }

        public void SetLogo()
        {
            try
            {
                if (Misc.GetLogoPath() == "")
                    Logo.BackgroundImage = Resources.bulsu_default;
                else
                    Logo.BackgroundImage = Image.FromFile(Misc.GetLogoPath());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SetBrand()
        {
            if (Misc.GetBrand() == "")
                label1.Text = "Bulacan State University";
            else
                label1.Text = Misc.GetBrand();
        }

        private void Passwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnLogin_Click(btnLogin, EventArgs.Empty);
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
