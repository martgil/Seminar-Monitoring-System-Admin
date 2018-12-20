using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Security.Principal;
using Capstone.QR.Tools;
using Capstone.QR.Events;
using System.Text.RegularExpressions;

namespace Capstone.QR
{
    public partial class uDashboard : UserControl
    {
        private static uDashboard _instance;

        public static uDashboard Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uDashboard();
                return _instance;
            }
            set { _instance = value; }
        }

        public uDashboard()
        {
            InitializeComponent();
        }        

        // Refresh Pending

        public void Initializer()
        {
            string query2 = "SELECT count(*) from custom_event where event_open=-1";
            SqlDataReader rd2 = SqlUtils.ExecuteQueryReader(query2, false);
            while (rd2.Read())
            {
                pendingEvents.Text = rd2.GetInt32(0).ToString();
            }
            string query1 = "SELECT count(*) from custom_event where event_open=0";
            SqlDataReader rd1 = SqlUtils.ExecuteQueryReader(query1, false);
            while (rd1.Read())
            {
                closeEvents.Text = rd1.GetInt32(0).ToString();
            }
            string query = "SELECT count(*) from custom_event where event_open=1";
            SqlDataReader rd = SqlUtils.ExecuteQueryReader(query, false);
            while (rd.Read())
            {
                openEvents.Text = rd.GetInt32(0).ToString();
            }
            int c = 0;
            var reader = SqlUtils.ExecuteQueryReader("select top 5 eventid,event_name,event_cost from custom_event where event_open=1 and event_cost != '0' and event_date like '%" + DateTime.Now.Year + "%' order by event_cost desc", false);
            while (reader.Read())
            {
                c += 1;
                var x = 0;
                var r = SqlUtils.ExecuteQueryReader("select * from attendee where eventid=" + reader["eventid"].ToString() + " and balance=0", false);
                while (r.Read()) {
                    if (r["eventid"].ToString() == reader["eventid"].ToString())
                        x += Convert.ToInt32(r["payment"].ToString());
                }
                TopProfitedPie.Series["Event"].Points.AddXY(reader["event_name"], x);

            }
            TopProfitedPie.Titles[0].Text = "Most Profited Events of " + DateTime.Now.Year;
            TopProfitedPie.ChartAreas[0].AxisY.Title = "Price in Philippine Peso";
            AttendeeEventChart.Series[0]["PieLabelStyle"] = "Disabled";
            AttendeeEventChart.Titles[0].Text = "Most attended event of " + DateTime.Now.Year;
            reader = SqlUtils.ExecuteQueryReader("select event_name,event_attended from custom_event where event_open=1 and event_date like '%"+ DateTime.Now.Year +"%' and event_attended != 0 order by event_attended desc ", false);
          
            while (reader.Read())
            {
                AttendeeEventChart.Series["Attendees"].Points.AddXY(reader["event_name"], reader["event_attended"]);
            }
            reader.Close();
         
        }
        //open
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            viewEventsSummary(1);
        }
       
        public void viewEventsSummary(int code ) // Status Code for Status
        {
            var viewEvent = uViewEvent.Instance();
            displayPanel.Controls.Add(viewEvent);
            viewEvent.Dock = DockStyle.Fill;
            viewEvent.Ctrl_Added(code);
            viewEvent.BringToFront();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            viewEventsSummary(0);
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            viewEventsSummary(-1);
        }

        private void AttendeeEventChart_Click(object sender, EventArgs e)
        {

        }
    }
}
