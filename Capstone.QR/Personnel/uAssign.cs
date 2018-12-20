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
    public partial class uAssign : UserControl
    {
        private static uAssign _instance;

        public static uAssign Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uAssign();
                return _instance;
            }
        }
        public uAssign()
        {
            InitializeComponent();
        }

        List<string> Personnel = new List<string>();
        List<string> Event = new List<string>();

        public void InitList()
        {
            List<string> personnelList = new List<string>();
            List<string> eventList = new List<string>();

            var reader = SqlUtils.ExecuteQueryReader("select userid,given_name + ' ' + last_name  as fullname from personnel",false);
            while (reader.Read())
            {
                personnelList.Add(reader["userid"].ToString() + ":" + reader["fullname"].ToString());
            }
            Personnel = personnelList;
            reader = SqlUtils.ExecuteQueryReader("select eventid,event_name from custom_event where event_open=1",false);
            while (reader.Read())
            {
                eventList.Add(reader["eventid"].ToString() + ":" + reader["event_name"].ToString());
            }
            Event = eventList;
            PersonnelLister.Items.Clear();
            foreach (string personnel in personnelList)
            {
                PersonnelLister.Items.Add(Misc.StripColonRight(personnel));
            }

            EventLister.Items.Clear();
            foreach (string eventItem in eventList )
            {
                EventLister.Items.Add(Misc.StripColonRight(eventItem));
            }

        }


        private void AssignBtn_Click(object sender, EventArgs e)
        {
            if (PersonnelLister.SelectedIndex == -1 || EventLister.SelectedIndex == -1)
                alert.Show("Invalid Selection", alert.AlertType.warnig);
            else
            {
                int index = PersonnelLister.SelectedIndex;
                string value = Personnel[index];

                int index0 = EventLister.SelectedIndex;
                string value0 = Event[index0];

                string eventId = Misc.StripColonLeft(value0);
                string personnelId = Misc.StripColonLeft(value);
                string personnelFullname = Misc.StripColonRight(value);

                // check if already exist
                // do insert if not
                bool found = false;
                int maximum = 0;
                var rd0 = SqlUtils.ExecuteQueryReader("select count(*) as assign_no from assigned_personnel where userid=" + personnelId, false);
                while (rd0.Read())
                {
                    maximum = Convert.ToInt32(rd0["assign_no"].ToString());
                }
                var reader = SqlUtils.ExecuteQueryReader("select eventid from assigned_personnel where userid=" + personnelId, false);
                while (reader.Read())
                {
                    if (reader["eventid"].ToString() == eventId)
                        found = true;
                }
                if (found == true)
                    MessageBox.Show("This personnel is already assigned in this event.");
                else
                {
                    SqlUtils.ExecuteQuery("insert into assigned_personnel(userid,eventid) values(" + personnelId + "," + eventId + ")", false);
                    alert.Show("Personnel assigned successfully.",alert.AlertType.success);
                    PersonnelLister.SelectedIndex = -1;
                    EventLister.SelectedIndex = -1;
                }
            }
        }
    }
}
