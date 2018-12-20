using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstone.QR.Tools;

namespace Capstone.QR.Personnel
{
    public partial class PersonnelWinLoader : UserControl
    {
        public PersonnelWinLoader()
        {
            InitializeComponent();
        }

        private static PersonnelWinLoader _instance = null;

        public static PersonnelWinLoader Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PersonnelWinLoader();
                }

                return _instance;
            }
            set { _instance = value; }
        }      
        // Add personnel
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Control x = this.ParentForm.Controls["panel1"];
            x.Controls["navigation"].Text = "Create Personnel Account";

            int eventCount = 0;
            var reader = SqlUtils.ExecuteQueryReader("select count(*) as open_event from custom_event where event_open=1", false);
            while (reader.Read())
            {
                eventCount = (int)reader["open_event"];
            }
            if (eventCount <= 0)
                MessageBox.Show("Sorry, you must open at least 1 event to start adding personel");
            else
            {
                var uadd= uAddPersonnel.Instance;
                Controls.Add(uadd);
                uadd.Dock = DockStyle.Fill;
                uadd.BringToFront();
            }

        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            Control x = this.ParentForm.Controls["panel1"];
            x.Controls["navigation"].Text = "View Personnel Informations";

            SqlDataReader rd = SqlUtils.ExecuteQueryReader("select * from assigned_personnel", false);

            if (!rd.HasRows)
            {
                MessageBox.Show("To proceed, please assigned a personnel.");
            }
            else
            {
                // Display Panel
                var uview = uViewPersonnel.Instance;
                Controls.Add(uview);
                uview.Dock = DockStyle.Fill;
                uview.InitializeView();
                uview.BringToFront();
            }
        }

        

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            Control x = this.ParentForm.Controls["panel1"];
            x.Controls["navigation"].Text = "Assign Personnel";

            int count = 0;
            SqlDataReader rd = SqlUtils.ExecuteQueryReader("select count(*) from personnel", false);
            while (rd.Read())
            {
                count = (Int32)rd.GetValue(0);
            }

            if (count <= 0)
            {
                MessageBox.Show("To proceed, please add a personnel.");
            }
            else
            {
                var uassign = uAssign.Instance;
                Controls.Add(uassign);
                uassign.InitList();
                uassign.Dock = DockStyle.Fill;
                uassign.BringToFront();
            }
        }
    }
}
