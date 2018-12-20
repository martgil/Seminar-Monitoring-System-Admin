using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;
using Capstone.QR.Tools;

namespace Capstone.QR
{
    public partial class uAddPersonnel : UserControl
    {
        private static uAddPersonnel _instance;
        public static uAddPersonnel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uAddPersonnel();
                return _instance;
            }
        }

        public uAddPersonnel()
        {
            InitializeComponent();
        }

        private List<string> GenerateAccount(string firstname, string lastname)
        {
            List<string> account = new List<string>();
            string random = "";
            string password = "";
            Random randomizer = new Random();
            
            for (int n = 0; n < 4; n++)
            {
                random += randomizer.Next(0,9);
            }

            for (int n = 1; n <= 6; n++) {
                password += randomizer.Next(9);
            }

            string modedName = "";

            foreach (char letter in firstname)
            {
                if (letter != ' ')
                    modedName += letter;
            }

            account.Add(modedName.ToLower() + random);
            account.Add(password);

            return account;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            string givenn, lname;
            givenn = givennametb.Text.Trim();
            lname = lnametb.Text.Trim();

            if (String.IsNullOrEmpty(givenn) || String.IsNullOrEmpty(lname))
            {
                MessageBox.Show("Fields are empty!");
            }
            else if (givenn.Length < 2 || lname.Length < 2)
            {
                const string caption = "Attention";
                if (givenn.Length < 2)
                {
                    MessageBox.Show("Given name must be atleast 2 characters", caption);
                }
                else if (lname.Length < 2)
                {
                    MessageBox.Show("Last name must be atleast 2 characters", caption);
                }
            }
            else if (affiliation.Text.Length < 5)
                alert.Show("Affiliation is Too short",alert.AlertType.info);
            else if (contact_no.Text.Length < 5)
                alert.Show("Contact is Too short", alert.AlertType.info);
            else
            {
                try
                {
                    List<string> account = new List<string>();
                    account = GenerateAccount(givenn, lname);

                    bool exist = false;

                    var reader = SqlUtils.ExecuteQueryReader("select username from personnel", false);
                    while (reader.Read())
                    {
                        while (reader["username"].ToString() == account[1])
                        {
                            exist = true;
                            GenerateAccount(givenn, lname);
                        }
                    }
                    if (exist == false)
                    {
                        SqlUtils.ExecuteInsert("insert into personnel (given_name,last_name,contact_no,affiliation,username,passwd) values(@gname,@lname,@contact,@affiliation,@user,@pass)", new string[] { "@gname", "@lname","contact","@affiliation", "@user", "@pass" }, new string[] { givenn, lname,contact_no.Text.Trim(),affiliation.Text.Trim(), account[0], account[1] });
                        alert.Show("New Personnel Added", alert.AlertType.success);
                        username.Text = account[0].ToString();
                        password.Text = account[1].ToString();

                        givennametb.Text = "";
                        lnametb.Text = "";
                        contact_no.Text = "";
                        affiliation.Text = "";
                        givennametb.Focus();
                    }


                }
                catch (Exception exs)
                {
                    MessageBox.Show(exs.Message);
                }
            }         
        }


    }
}