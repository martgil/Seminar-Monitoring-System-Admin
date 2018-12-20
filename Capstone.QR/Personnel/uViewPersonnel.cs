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
    public partial class uViewPersonnel : UserControl
    {
        public uViewPersonnel()
        {
            InitializeComponent();
        }
        private static uViewPersonnel _instance = null;

        public static uViewPersonnel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new uViewPersonnel();
                }

                return _instance;
            }
        }

        public void InitializeView()
        {
            try
            {
                TablePersonnel.Rows.Clear();
                TablePersonnel.Refresh();
                TablePersonnel.RowTemplate.Height = 30;
                TablePersonnel.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                TablePersonnel.ColumnHeadersDefaultCellStyle.Font = new Font("Roboto", 12F, FontStyle.Regular);

                // fetch all userid ex 1 2 3 4 1 2
                List<int> fakeId = new List<int>();
                List<int> realId = new List<int>();
                var fetchId = SqlUtils.ExecuteQueryReader("select userid from assigned_personnel", false);
                while (fetchId.Read())
                {
                    fakeId.Add(Convert.ToInt32(fetchId["userid"].ToString()));
                }

                foreach (int item in fakeId)
                {
                    if (realId.Contains(item) == false)
                        realId.Add(item);
                }

                foreach (int userid in realId)
                {
                    string fullname = "";
                    string username = "";
                    var fetchData = SqlUtils.ExecuteQueryReader("select given_name + ' ' + last_name as fullname,username from personnel where userid=" + userid, false);
                    while (fetchData.Read())
                    {
                        fullname = fetchData["fullname"].ToString();
                        username = fetchData["username"].ToString();
                    }
                    string eventname = "";
                    var reader = SqlUtils.ExecuteQueryReader("select eventid from assigned_personnel where userid=" + userid, false);
                    while (reader.Read())
                    {
                        var rd = SqlUtils.ExecuteQueryReader("select event_name from custom_event where eventid=" + reader["eventid"].ToString() + " and event_open=1", false);
                        while (rd.Read())
                        {
                            eventname += rd["event_name"].ToString() + ", ";
                        }
                    }
                    TablePersonnel.Rows.Add();
                    TablePersonnel.Rows[TablePersonnel.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
                    TablePersonnel.Rows[TablePersonnel.Rows.Count - 1].DefaultCellStyle.Font = new Font("Roboto", 9F, FontStyle.Regular);
                    TablePersonnel.Rows[TablePersonnel.RowCount - 1].Cells[0].Value = username;
                    TablePersonnel.Rows[TablePersonnel.RowCount - 1].Cells[1].Value = fullname;
                    TablePersonnel.Rows[TablePersonnel.RowCount - 1].Cells[2].Value = eventname.Substring(0,eventname.Trim().Length - 1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // extract to unique 1 2 3 4
            // select userinfo where userid = 1
            // eid = select eventid from assigned_personnel where userid=id;
            // select event_name from custom_event where eventid=eid;

            //var r = SqlUtils.ExecuteQueryReader("select * from assigned_personnel",false);
            //while (r.Read())
            //{
            //    string fullname = "";
            //    string eventname = "";
            //    string uname = "";

            //    // fetch in


            //    SqlDataReader rd = SqlUtils.ExecuteQueryReader(" select given_name + ' ' + last_name as fullname,username from personnel where userid=" + r["userid"].ToString(), false);
            //    while (rd.Read())
            //    {
            //        fullname = rd["fullname"].ToString();
            //        uname = rd["username"].ToString();
            //    }
            //    rd = SqlUtils.ExecuteQueryReader("select event_name from custom_event where eventid="+r["eventid"].ToString() ,false);
            //    while (rd.Read())
            //    {
            //        eventname = rd["event_name"].ToString();
            //    }
            //    TablePersonnel.Rows.Add();
            //    TablePersonnel.Rows[TablePersonnel.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            //    TablePersonnel.Rows[TablePersonnel.Rows.Count - 1].DefaultCellStyle.Font = new Font("Roboto", 9F, FontStyle.Regular);
            //    TablePersonnel.Rows[TablePersonnel.RowCount - 1].Cells[0].Value = uname;
            //    TablePersonnel.Rows[TablePersonnel.RowCount - 1].Cells[1].Value = fullname;
            //    TablePersonnel.Rows[TablePersonnel.RowCount - 1].Cells[2].Value = eventname;
            //}

        }
    }
}
