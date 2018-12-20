using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstone.QR.Tools;
using Newtonsoft.Json;

namespace Capstone.QR.Dashboard
{
    public partial class uAdminProfile : UserControl
    {
        public uAdminProfile()
        {
            InitializeComponent();
        }

        private static uAdminProfile _instance = null;

        public static uAdminProfile Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new uAdminProfile();
                return _instance;
            }
            set { _instance = value; }
        }
        // Change Pass

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(oldPass.Text) || String.IsNullOrEmpty(newPass.Text) || String.IsNullOrEmpty(confirmPass.Text))
                alert.Show("Empty fields, not accepted.",alert.AlertType.error);
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
                    alert.Show("New Password Do not match!", alert.AlertType.info);
                else if (Cipher.Decrypt(OldPass, Cipher.secret) != oldPass.Text)
                    alert.Show("Old Password Do not match!", alert.AlertType.warnig);
                else
                {
                    string updateQuery = "UPDATE auth SET passwd=@password WHERE uname='admin'";
                    try
                    {
                        if (newPass.Text.Length < 8)
                            alert.Show("Weak Password Length.", alert.AlertType.warnig);
                        else
                        {
                            SqlUtils.ExecuteInsert(updateQuery, new string[] { "@password" }, new string[] { Cipher.Encrypt(newPass.Text, Cipher.secret) });
                            alert.Show("Password Changed successfully", alert.AlertType.success);
                        }
                        oldPass.Text = "";
                        newPass.Text = "";
                        confirmPass.Text = "";
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Unknown SQL Error");
                    }
                }
            }
        }
        // Export Database Configuration
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            try
            {
                string configPath = Path.Combine(Directory.GetCurrentDirectory(), "configs/config.json");
                var Configuration = new Config();
                Configuration._host = Windows.Host;
                Configuration._user = "sa";
                Configuration._password = "root";
                Configuration._initCatalog = "EVENTDB";

                JsonSerializer js = new JsonSerializer();
                using (StreamWriter sw = new StreamWriter(configPath))
                using (JsonWriter jw = new JsonTextWriter(sw))
                {
                    js.Serialize(jw, Configuration);
                }

                MessageBox.Show("Configuration saved at " + configPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }
        // Bugs in Backup and Restore Database
        
        // Backup Click
        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            try
            {
                // fix this unknown issue about backing up to the drive c
                
                var backup = new FolderBrowserDialog();
                var action = backup.ShowDialog();
                if (action.Equals(DialogResult.OK))
                    SqlUtils.ExecuteQuery("BACKUP DATABASE [EVENTDB] TO DISK='" + backup.SelectedPath + "'", true);
            }
            catch (Exception)
            {
                MessageBox.Show("You may use a flash drive or different drive to continue.");
            }
        }
        // Restore Database - Status = ok
        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            try
            {
                var restore = new OpenFileDialog();
                restore.Filter = "Backup SQL File (*.bak)|*.bak";
                restore.Title = "Restore Database";
                var action = restore.ShowDialog();
                if (action.Equals(DialogResult.OK))
                {
                    SqlUtils.ExecuteQuery("ALTER DATABASE [EVENTDB] SET SINGLE_USER WITH ROLLBACK IMMEDIATE", true);
                    SqlUtils.ExecuteQuery("RESTORE DATABASE [EVENTDB] FROM DISK='" + restore.FileName + "' WITH REPLACE", true);
                    SqlUtils.ExecuteQuery("ALTER DATABASE [EVENTDB] SET MULTI_USER", true);

                }
                alert.Show("Database Restore Successfully", alert.AlertType.success);
            }
            catch (Exception)
            {
                MessageBox.Show("There's a problem restoring your database, this is either you load a different file that causes an error.");
            }
        }

    
    }
}
