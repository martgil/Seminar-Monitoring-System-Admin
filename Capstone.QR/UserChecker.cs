using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstone.QR.Tools;

namespace Capstone.QR
{
    public partial class UserChecker : Form
    {
        public UserChecker()
        {
            InitializeComponent();
        }

        int attempt = 0;

        private void VerifyUser()
        {
            if (attempt >= 3)
            {
                MessageBox.Show("You have reached the maximum login attempt, Exiting...", "Alert");
                this.Close();
            }

            if (SqlUtils.VerifyAccount("admin", PasswordVerify.Text.Trim()))
            {
                new AdminPanel().Show();
                Hide();
            }
            else
            {
                attempt += 1;
                MessageBox.Show("Wrong Credential!");
            }
        }

        private void PasswordVerify_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                VerifyUser();
        }

    }
}
