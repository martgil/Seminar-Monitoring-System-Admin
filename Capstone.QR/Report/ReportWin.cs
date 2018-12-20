using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Capstone.QR.Tools;

namespace Capstone.QR.Report
{
    public partial class ReportWin : UserControl
    {
        public ReportWin()
        {
            InitializeComponent();
    
            FromDate.Value = DateTime.Now;
            ToDate.Value = DateTime.Now;
        }
        // generate report

        int id;
        List<string> GlobalNameList = new List<string>();
        public void InitNameList(List<string> EventNames)
        {
            comboBox1.Items.Clear();
            GlobalNameList = EventNames;

            foreach (string name in EventNames)
            {
                comboBox1.Items.Add(Misc.StripColonRight(name));
            }
        }


        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            
            int ReportType = ReportCombo.selectedIndex;
            string type = "";
            int param = 0;
            if (ReportType == 1)
            {
                param = 1;
                type = "Open Events";

            }
            else if (ReportType == 2)
            {
                param = 0;
                type = "Closed Events";

            }
            else if (ReportType == 3)
            {
                param = -1;
                type = "Pending Events";

            }

            if (ReportType == 0)
                alert.Show("Invalid Report Type", alert.AlertType.error);
            else
            {
                if (ReportType == 1 || ReportType == 2 || ReportType == 3) {
                    try
                    {
                        CrystalView.ReportSource = null;
                        StatusReport rpt = new StatusReport();
                        rpt.SetParameterValue(0, FromDate.Value.ToShortDateString());
                        rpt.SetParameterValue(1, ToDate.Value.ToShortDateString());
                        rpt.SetParameterValue(2, param.ToString());
                        rpt.SetParameterValue("Type", type);
                        CrystalView.ReportSource = rpt;
                        //List<ReportParameter> rParam = new List<ReportParameter>();
                        //using (EVENTDBEntities db = new EVENTDBEntities())
                        //{
                        //    get
                        //    get= db.GetEventStatus();
                        //    rParam.Add(new ReportParameter("fromDate", FromDate.Value.ToString()));
                        //    rParam.Add(new ReportParameter("toDate", ToDate.Value.ToString()));
                        //    rParam.Add(new ReportParameter("statusCode", param.ToString()));
                        //};
                        //reportViewer1.LocalReport.SetParameters(rParam);
                        //reportViewer1.LocalReport.Refresh();
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message);}
                }
                else if(ReportType == 4)
                {
                    try
                    {
                        if (comboBox1.SelectedIndex != -1) {
                            // Extract data
                            var ind = comboBox1.SelectedIndex;
                            string value = GlobalNameList[ind];
                            int i = value.IndexOf(":");
                            string raw = value.Substring(0, i);
                            string ename = Misc.StripColonRight(value);
                            CrystalView.ReportSource = null;
                            AttendeePaid rpt1 = new AttendeePaid();
                            rpt1.SetParameterValue(0, raw);
                            rpt1.SetParameterValue("EventName", ename);
          
                            CrystalView.ReportSource = rpt1;
                        }
                        else
                        {
                            alert.Show("Invalid Event Name ", alert.AlertType.error);
                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message);  }
                }
                else if(ReportType == 5)
                {
                    try
                    {
                        if (comboBox1.SelectedIndex != -1)
                        {
                            // Extract data
                            var ind = comboBox1.SelectedIndex;
                            string value = GlobalNameList[ind];
                            int i = value.IndexOf(":");
                            string raw = value.Substring(0, i);
                            string ename = Misc.StripColonRight(value);
                            CrystalView.ReportSource = null;
                            AttendeeUnpaid rpt1 = new AttendeeUnpaid();
                            rpt1.SetParameterValue(0, raw);
                            rpt1.SetParameterValue("EventName", ename);

                            CrystalView.ReportSource = rpt1;
                        }
                        else
                        {
                            alert.Show("Invalid Event Name ", alert.AlertType.error);
                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }

            }

        }

        private void ReportCombo_onItemSelected(object sender, EventArgs e)
        {
            int i = ReportCombo.selectedIndex;
            if (i == 0 || i == 1 || i == 2 || i == 3)
                panel1.Visible = false;
            else
                panel1.Visible = true;
        }
    }
}

