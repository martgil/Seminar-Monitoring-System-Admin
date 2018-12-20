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
using Capstone.QR;
using Capstone.QR.Tools;
using Capstone.QR.Events;

namespace Capstone.QR
{
    public partial class EventWinLoader : UserControl
    {

        public EventWinLoader()
        {
            InitializeComponent();
        }

        public static EventWinLoader _instance;

        public static EventWinLoader Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EventWinLoader();
                }
                return _instance;
            }
        }
        
       
   
      
        // Add event
        private void bunifuImageButton1_Click(object sender, EventArgs e) 
        {
            Control x = this.ParentForm.Controls["panel1"];
            x.Controls["navigation"].Text = "Create New Event";

            var AddManager = new uAddEvent();

            AddManager.GetProperDate();
            Controls.Add(AddManager);
            AddManager.Dock = DockStyle.Fill;
            AddManager.InitializeData();
            AddManager.BringToFront();
        }
        // Update event
        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            Control x = this.ParentForm.Controls["panel1"];
            x.Controls["navigation"].Text = "Update Event Information";

            int EventCount = 0;
            SqlDataReader reader = SqlUtils.ExecuteQueryReader("select count(*) from custom_event", false);
            while (reader.Read())
            {
                EventCount = reader.GetInt32(0);
            }
            reader.Close();
            if (EventCount <= 0)
            {
                MessageBox.Show("To continue, Please add an event", "Alert");
            }
            else
            {
                List<string> NameList = new List<string>();
                var readerz = SqlUtils.ExecuteQueryReader("select eventid,event_name from custom_event", false);
                while (readerz.Read())
                {
                    NameList.Add(Convert.ToInt32(readerz["eventid"]) + ":" + readerz["event_name"].ToString());
                }
                var updateEvent = uUpdateEvent.Instance();
                this.Controls.Add(updateEvent);
                updateEvent.InitNameList(NameList);
                updateEvent.Dock = DockStyle.Fill;
                updateEvent.BringToFront();
            }

          
        }
        // View Events
        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Control x = this.ParentForm.Controls["panel1"];
            x.Controls["navigation"].Text = "View All Events";

            int EventCount = 0;
            SqlDataReader reader = SqlUtils.ExecuteQueryReader("select count(*) from custom_event", false);
            while (reader.Read())
            {
                EventCount = reader.GetInt32(0);
            }
            if (EventCount <= 0)
            {
                MessageBox.Show("To continue, Please add an event", "Alert");
            }
            else
            {
                var viewEvent = uViewEvent.Instance();
                this.Controls.Add(viewEvent);
                viewEvent.Dock = DockStyle.Fill;
                viewEvent.Ctrl_Added(99);
                viewEvent.BringToFront();
            }
           
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            Control x = this.ParentForm.Controls["panel1"];
            x.Controls["navigation"].Text = "Additional Event Settings";
            var addOns = uEventAddOns.Instance();
            this.Controls.Add(addOns);
            addOns.Dock = DockStyle.Fill;
            addOns.Initializer();
            addOns.BringToFront();

        }
    }
}
