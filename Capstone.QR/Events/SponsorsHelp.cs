using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstone.QR.Tools;

namespace Capstone.QR.Events
{
    public partial class SponsorsHelp : UserControl
    {
        public SponsorsHelp()
        {
            InitializeComponent();
            SponsorGrid.RowTemplate.Height = 50;
        }
        bool Update = false;
        string EventName = "";
        string EventLocation = "";
        string EventSTime = "";
        string EventETime = "";
        string EventDate = "";
        string EventPartial = "";
        string EventCost = "";
        string EventOpen = "";
        string EventRegistered = "";
        string EventAttended = "";
        string Strict = "";

        List<string> Sponsor = new List<string>();

        string IdToUpdate = "";
        
        public void FetchData()
        {
            SponsorGrid.Rows.Clear();
            SponsorGrid.Refresh();
            SponsorGrid.RowTemplate.Height = 60;
            SponsorGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Roboto", 12F, FontStyle.Regular);

            var reader = SqlUtils.ExecuteQueryReader("select * from valid_sponsor", false);
            while (reader.Read())
            {
                SponsorGrid.Rows.Add();
                SponsorGrid.Rows[SponsorGrid.Rows.Count - 1].DefaultCellStyle.Font = new Font("Roboto", 9F, FontStyle.Regular);
                SponsorGrid.Rows[SponsorGrid.Rows.Count - 1].Cells[1].Value = reader["sponsor"].ToString();
            }
        }
        List<string> ImportedSponsor = new List<string>();
        private void SponsorGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var obj = (DataGridView)sender;
                string query = "";
                if (obj.Rows.Count > 0 && obj.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                {
                    string sponsor = obj.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value.ToString();
                    if (!ImportedSponsor.Contains(sponsor))
                        ImportedSponsor.Add(sponsor);
                    else
                        ImportedSponsor.Remove(sponsor);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SetUpFromUpdate(string eventName, string eventLocation, string eventStime, string eventETime, string eventDate, string eventCost, string strict, string whichEvent)
        {
            Update = true;

            EventName = eventName;
            EventLocation = eventLocation;
            EventSTime = eventStime;
            EventETime = eventETime;
            EventDate = eventDate;
            EventCost = eventCost;
            Strict = strict;

            IdToUpdate = whichEvent;

            bunifuFlatButton1.Text = "UPDATE";
            Retry.Text = "Update NEW EVENT";
            // No Partial Payment
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //foreach (string item in ImportedSponsor)
                //{
                //    MessageBox.Show(item);
                //}
                if (Update)
                {
                    string importedSponsor = "";
                    if (ImportedSponsor.Count <= 0)
                        importedSponsor = "";
                    else
                    {
                        foreach (string sponsor in ImportedSponsor)
                        {
                            importedSponsor = sponsor + ",";
                        }
                    }
                    importedSponsor = importedSponsor.Substring(0, importedSponsor.Length - 1); // remove last `,`

                    SqlUtils.ExecuteQuery("update custom_event set event_name='"+EventName+ "',event_location='"+EventLocation+"',event_stime='"+EventSTime+"',event_etime='"+EventETime+"',event_date='"+EventDate+"',event_cost='"+EventCost+"',sponsor='"+importedSponsor +"',strict=" +Strict+"where eventid="+IdToUpdate,false);
                    alert.Show("Event Updated Successfully", alert.AlertType.success);
                    bunifuFlatButton1.Visible = false;
                    SponsorGrid.Rows.Clear();
                    SponsorGrid.Visible = false;
                    Retry.Visible = true;
                }
                else
                {
                    string importedSponsor = "";
                    if (ImportedSponsor.Count <= 0)
                        importedSponsor = "";
                    else
                    {
                        foreach (string sponsor in ImportedSponsor)
                        {
                            importedSponsor = sponsor + ",";
                        }
                    }
                    importedSponsor = importedSponsor.Substring(0, importedSponsor.Length - 1); // remove last `,`

                    string query = "insert into custom_event(event_name,event_location,event_stime,event_etime,event_date,event_cost,event_partial,event_open,event_registered,event_attended,sponsor,strict) values(@name,@loc,@time,@endtime,@date,@cost,@partial,@open,@registered,@attended,@sponsor,@strict)";

                    SqlUtils.ExecuteInsert(query, new string[] { "@name", "@loc", "@time", "@endtime", "@date", "@cost", "@partial", "@open", "registered", "@attended", "@sponsor", "@strict" }, new string[] { EventName, EventLocation, EventSTime, EventETime, EventDate, EventCost, EventPartial, EventOpen, EventRegistered, EventAttended, importedSponsor, Strict });
                    alert.Show("Event Added Successfully", alert.AlertType.success);
                    bunifuFlatButton1.Visible = false;
                    SponsorGrid.Rows.Clear();
                    SponsorGrid.Visible = false;
                    Retry.Visible = true;
                }
                
                // hide clear then hide data then change button add certain acction;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void SetUpEvent(string eventName,string eventLocation,string eventStime, string eventETime, string eventDate, string eventCost, string eventPartial, string eventOpen, string eventRegistered, string eventAttended, string strict)
        {
            EventName = eventName;
            EventLocation = eventLocation;
            EventSTime = eventStime;
            EventETime = eventETime;
            EventDate = eventDate;
            EventCost = eventCost;
            EventPartial = eventPartial;
            EventOpen = eventOpen;
            EventRegistered = eventRegistered;
            EventAttended = eventAttended;
            Strict = strict;
        }

        private void Retry_Click(object sender, EventArgs e)
        {
            try
            {
                if (Update)
                {
                    var updateEvent = new uUpdateEvent();
                    panel1.Controls.Add(updateEvent);
                    updateEvent.Dock = DockStyle.Fill;
                    updateEvent.BringToFront();
                }
                else
                {
                    var addEvent = new uAddEvent();
                    addEvent.InitializeData();
                    panel1.Controls.Add(addEvent);
                    addEvent.Dock = DockStyle.Fill;
                    addEvent.BringToFront();
                }
         
            }catch  (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
