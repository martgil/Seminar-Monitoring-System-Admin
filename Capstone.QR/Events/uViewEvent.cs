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
using System.Data.SqlClient;

namespace Capstone.QR.Events
{
    public partial class uViewEvent : UserControl
    {
        public uViewEvent()
        {
            InitializeComponent();
        }
        public static uViewEvent Instance()
        {
            return new uViewEvent();
        }
        private int ViewCode = 99;
        public void Ctrl_Added(int Code)
        {
            ViewCode = Code;
            EventData.Rows.Clear();
            EventData.Refresh();
            EventData.RowTemplate.Height = 30;
            EventData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            EventData.ColumnHeadersDefaultCellStyle.Font = new Font("Roboto", 11F, FontStyle.Regular);

            string status = "";
            string query = "";
            if (Code.Equals(99))
                query = "select * from custom_event";
            else
                query = "select * from custom_event where event_open=" + Code; 
            SqlDataReader rd = SqlUtils.ExecuteQueryReader( query, false);
            while (rd.Read())
            {
                var open = rd["event_open"];
                int Ropen = (Int32)open;

                if (Ropen == -1)
                {
                    status = "Pending";
                }
                else if (Ropen == 1)
                {
                    status = "Open";
                }
                else
                {
                    status = "Closed";
                }
                EventData.Rows.Add();

                var event_date = (DateTime) rd["event_date"];
                var event_time = (TimeSpan) rd["event_stime"];

                EventData.Rows[EventData.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(240,240,240);
                EventData.Rows[EventData.Rows.Count - 1].DefaultCellStyle.Font = new Font("Roboto",9F,FontStyle.Regular);
                EventData.Rows[EventData.Rows.Count - 1].Cells[0].Value = rd["eventid"];
                EventData.Rows[EventData.Rows.Count - 1].Cells[1].Value = rd["event_name"];
                EventData.Rows[EventData.Rows.Count - 1].Cells[2].Value = rd["event_location"];
                EventData.Rows[EventData.Rows.Count - 1].Cells[3].Value = event_date.ToShortDateString();
                EventData.Rows[EventData.Rows.Count - 1].Cells[4].Value = Misc.To12HourFormat(event_time);
                EventData.Rows[EventData.Rows.Count - 1].Cells[5].Value = rd["event_cost"];
                EventData.Rows[EventData.Rows.Count - 1].Cells[6].Value = rd["event_registered"];
                EventData.Rows[EventData.Rows.Count - 1].Cells[7].Value = rd["event_attended"];
                EventData.Rows[EventData.Rows.Count - 1].Cells[8].Value = status;
            }
            rd.Close();
        }

        private void EventData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var obj = (DataGridView) sender;
                string query = "";
                if (obj.Rows.Count > 0 && obj.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    if (obj.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.Equals("Pending"))
                    {
                        var result = MessageBox.Show("Do you want to open this event for registration?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                        if (result.Equals(DialogResult.Yes))
                        {

                            int x = (Int32)obj.Rows[e.RowIndex].Cells[e.ColumnIndex - 8].Value;
                            query = "UPDATE custom_event SET event_open=1 where eventid=@id";
                            SqlUtils.ExecuteInsert(query, new string[] { "@id" }, new string[] { x.ToString() });
                            alert.Show("Status Changed Successfully", alert.AlertType.success);
                        }
                    }
                    else if (obj.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.Equals("Open"))
                    {
                        var result = MessageBox.Show("Do you want to close this event for registration?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                        if (result.Equals(DialogResult.Yes))
                        {
                            int x = (Int32)obj.Rows[e.RowIndex].Cells[e.ColumnIndex - 8].Value;
                            query = "UPDATE custom_event SET event_open=0 where eventid=@id";
                            SqlUtils.ExecuteInsert(query, new string[] { "@id" }, new string[] { x.ToString() });
                            alert.Show("Status Changed Successfully", alert.AlertType.success);
                        }
                    }
                    else
                        alert.Show("This event is closed.", alert.AlertType.warnig);
                    EventData.Rows.Clear();
                    Ctrl_Added(ViewCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }
    }
}
