using System;
using System.IO;
using System.Windows.Forms;
using Capstone.QR.Personnel;
using Capstone.QR.Tools;
using Capstone.QR.Dashboard;
using Capstone.QR.College;
using Capstone.QR.Report;
using System.Collections.Generic;

namespace Capstone.QR
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            this.Load += Form_Load;
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            dashBtn.selected = true;
            Load_Dashboard();
        }

        private void dashBtn_Click(object sender, EventArgs e)
        {
           Load_Dashboard();
        }

        private void EventBtn_Click(object sender, EventArgs e)
        {
            navigation.Text = "Events";
            var eventWinLoader = new EventWinLoader();
            MainPanel.Controls.Add(eventWinLoader);
            eventWinLoader.Dock = DockStyle.Fill;
            eventWinLoader.BringToFront();
        }

        private void PersonnelBtn_Click(object sender, EventArgs e)
        {
            navigation.Text = "Personnel";
            var personnelWinLoader = new PersonnelWinLoader();
            MainPanel.Controls.Add(personnelWinLoader);
            personnelWinLoader.Dock = DockStyle.Fill;
            personnelWinLoader.BringToFront();
        }

     

        private void Load_Dashboard()
        {
            navigation.Text = "Dashboard";
            
            MainPanel.Controls.Add(uDashboard.Instance);
            uDashboard.Instance.Dock = DockStyle.Fill;
            uDashboard.Instance.Initializer();
            uDashboard.Instance.BringToFront();
            uDashboard.Instance = null;

        }

        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            navigation.Text = "Profile";

            MainPanel.Controls.Add(uAdminProfile.Instance);
            uAdminProfile.Instance.Dock = DockStyle.None;
            uAdminProfile.Instance.BringToFront();
            uAdminProfile.Instance = null;
        }

 

        private void ExitBtn_Click(object sender, EventArgs e)
        {

            var action = MessageBox.Show("Are you sure you want to logout?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (action.Equals(DialogResult.Yes))
            {
                if (File.Exists(Directory.GetCurrentDirectory() + "/session/user.session"))
                {
                    DialogResult response = MessageBox.Show("Do you want to reserved your session?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (response == DialogResult.No)
                        Windows.RemoveSession();
                    this.Close();
                    new login().Show();

                }
                else
                {
                    this.Close();
                    new login().Show();
                }
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            var CollegeLoader = new uCollegeWinLoader();
            MainPanel.Controls.Add(CollegeLoader);
            CollegeLoader.Dock = DockStyle.Fill;
            CollegeLoader.BringToFront();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.MainPanel.Size.ToString());
        }

        private void Reports_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> NameList = new List<string>();
                var readerz = SqlUtils.ExecuteQueryReader("select eventid,event_name from custom_event", false);
                while (readerz.Read())
                {
                    NameList.Add(Convert.ToInt32(readerz["eventid"]) + ":" + readerz["event_name"].ToString());
                }
                var report = new ReportWin();
                report.InitNameList(NameList);
                MainPanel.Controls.Add(report);
                report.Dock = DockStyle.Fill;
                report.BringToFront();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message);}
        }
    }
}
