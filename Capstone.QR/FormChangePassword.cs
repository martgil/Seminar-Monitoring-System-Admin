using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstone.QR.Tools;

namespace Capstone.QR
{
    public partial class FormChangePassword : Form
    {
        public FormChangePassword()
        {
            InitializeComponent();
        }

        private void ChangePassBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(oldPass.Text) || String.IsNullOrEmpty(newPass.Text) || String.IsNullOrEmpty(confirmPass.Text))
            {
                MessageBox.Show("Please Fill-up the fields to continue");
            }
            else
            {
                string OldPass = "";
                try
                {
                    string query = "SELECT passwd from auth where uname='admin'";
                    
                    SqlDataReader rd = SqlUtils.ExecuteQueryReader(query, false);
                    while (rd.Read())
                    {
                        OldPass = rd.GetString(0);
                    }

                    rd.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (newPass.Text != confirmPass.Text)
                {
                    MessageBox.Show("New Password Do not Match");
                }
                else if (Cipher.Decrypt(OldPass,Cipher.secret) != oldPass.Text)
                {
                    MessageBox.Show("Old Password Do Not Match!");
                }
                else
                {
                    string updateQuery = "UPDATE auth SET passwd=@password WHERE uname='admin'";
                    try
                    {
                        if (newPass.Text.Length < 8)
                        {
                            MessageBox.Show("Password must be greater than 8 characters");
                        }
                        else
                        {
                            SqlUtils.ExecuteInsert(updateQuery, new string[] { "@password" }, new string[] { Cipher.Encrypt(newPass.Text,Cipher.secret) });
                        }
                        
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Unknown SQL Error");
                    }
                    finally
                    {
                        MessageBox.Show("Password Changed!");
                        Hide();
                    }
                }
            }
        }
    }
}
