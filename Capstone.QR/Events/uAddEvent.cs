using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Capstone.QR.Tools;
using System.Globalization;
using Capstone.QR.Events;

namespace Capstone.QR
{
    public partial class uAddEvent : UserControl
    {
        private static uAddEvent _instance;
        public static uAddEvent Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uAddEvent();
                return _instance;
            }
        }

        public uAddEvent()
        {
            InitializeComponent();
            eventDate.MinDate = DateTime.Now;
        }
        // modifier = 0 payment / 1 sponsor
        List<Bunifu.Framework.UI.BunifuCards> GlobalCards = new List<Bunifu.Framework.UI.BunifuCards>();
        List<string> ValidPayments = new List<string>();
        List<Bunifu.Framework.UI.BunifuCards> SponsorCards = new List<Bunifu.Framework.UI.BunifuCards>();
        List<string> ValidSponsors = new List<string>();

        public void InitializeData() 
        {
            GetValidPayment();
            GetValidLocation();
        }


        private void GetValidLocation()
        {
            LocationCombo.Clear();
            var reader = SqlUtils.ExecuteQueryReader("select * from valid_location", false);
            while (reader.Read())
            {
                LocationCombo.AddItem(reader["location"].ToString());
            }
        }

        private void GetValidPayment()
        {
            PaymentCombo.Clear();
            var reader = SqlUtils.ExecuteQueryReader("select * from valid_payment", false);
            while (reader.Read())
            {
                PaymentCombo.AddItem(reader["payment"].ToString());
            }
        }

        public void GetProperDate()
        {
            eventDate.Value = DateTime.Now;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            //var sponsorHelper = new SponsorsHelp();
            
            //try
            //{
            //    string strict = Strict.Checked == false ? "0" : "1";
            //    string eventAmount = freeSwitch.Value == false ? ParseMultiPayment() : "0";
            //    string eventName = txtEventName.Text.Trim().Length > 8 && txtEventName.Text.Trim().Length < 50 ? txtEventName.Text.Trim() : null;
            //    string ceventDate = eventDate.Value.ToString() != "" ? eventDate.Value.ToShortDateString() : null;
            //    string eventOpen = "-1";

            //    DateTime date;

            //    if (TimePicker.selectedIndex == 0)
            //        date = eventDate.Value + new TimeSpan(Convert.ToInt32(DropTime.selectedValue), 0, 0);
            //    else
            //        date = eventDate.Value - new TimeSpan(Convert.ToInt32(DropTime.selectedValue), 0, 0);

            //    if (eventName == null)
            //        alert.Show("Invalid Name", alert.AlertType.info);
            //    else if (LocationCombo.selectedIndex == -1)
            //        alert.Show("Invalid Location", alert.AlertType.info);
            //    else if (date.CompareTo(DateTime.Now) == -1)
            //        alert.Show("Past date/hour not accepted",alert.AlertType.info);
            //    else if (ValidateEvent())
            //        alert.Show("Time/Location already used.",alert.AlertType.info);
            //    else if (ValidateEvent(1))
            //    {
            //        var result = MessageBox.Show("The same event has already exist, would you still want to try to create this event?","Confirmation",MessageBoxButtons.YesNo);
            //        if (result == DialogResult.Yes)
            //        {
            //            if (ValidateEvent())
            //                alert.Show("Time/Location already used.",alert.AlertType.info);
            //            else
            //            {
            //                string query = "insert into custom_event(event_name,event_location,event_stime,event_date,event_cost,event_open,event_registered,event_attended,sponsor,strict) values(@name,@loc,@time,@date,@cost,@open,@registered,@attended,@sponsor,@strict)";
            //                SqlUtils.ExecuteInsert(query, new string[] { "@name", "@loc", "@time", "@date", "@cost", "@open", "registered", "@attended", "@sponsor", "@strict" }, new string[] { eventName, LocationCombo.selectedValue.Trim(), DropTime.selectedValue + TimePicker.selectedValue, ceventDate, eventAmount, eventOpen, "0", "0", ParseMultiPayment(1), strict });
            //                alert.Show("Success", alert.AlertType.success);

            //                freeSwitch.Value = true;
            //                freeSwitch_OnValueChange(bunifuFlatButton1, EventArgs.Empty);
            //                PaymentCombo.selectedIndex = -1;
            //                LocationCombo.selectedIndex = -1;
            //                txtEventName.Text = "";
            //                SponsorCombo.selectedIndex = -1;
            //                Strict.Checked = false;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        string query = "insert into custom_event(event_name,event_location,event_stime,event_date,event_cost,event_open,event_registered,event_attended,sponsor,strict) values(@name,@loc,@time,@date,@cost,@open,@registered,@attended,@sponsor,@strict)";
            //        SqlUtils.ExecuteInsert(query, new string[] { "@name", "@loc", "@time", "@date", "@cost", "@open", "registered", "@attended","@sponsor","@strict" }, new string[] { eventName, LocationCombo.selectedValue.Trim(), DropTime.selectedValue + TimePicker.selectedValue, ceventDate, eventAmount, eventOpen, "0", "0", ParseMultiPayment(1), strict});
            //        alert.Show("Success", alert.AlertType.success);

            //        freeSwitch.Value = true;
            //        freeSwitch_OnValueChange(bunifuFlatButton1, EventArgs.Empty);
            //        PaymentCombo.selectedIndex = -1;
            //        LocationCombo.selectedIndex = -1;
            //        txtEventName.Text = "";
            //        SponsorCombo.selectedIndex = -1;
            //        Strict.Checked = false;

            //    }
            //}
            //catch (Exception ex)
            //{ 
            //    MessageBox.Show(ex.Message);
            //}
            
        }

        private bool ValidateEvent(int options = 0)
        {
            // 0 = time and location
            // 1 = name

            bool invalid = false;
            if (options == 0)
            {
                var reader = SqlUtils.ExecuteQueryReader("select * from custom_event where event_date='" + eventDate.Value.ToShortDateString() + "' and event_location='" + LocationCombo.selectedValue.Trim() + "' and event_stime between '" + DropTime.selectedValue + TimePicker.selectedValue + "' and '" + EndTime.selectedValue + EndAM.selectedValue + "'", false);
                if (reader.HasRows)
                {
                    invalid = true;
                }
            }
            else if (options == 1)
            {
                var reader = SqlUtils.ExecuteQueryReader("select * from custom_event where event_name='" + txtEventName.Text.Trim() + "'", false);
                if (reader.HasRows)
                {
                    invalid = true;
                }
            }

            return invalid;
        }

      
        private void bunifuCards1_Click(object sender, EventArgs e)
        {
            ValidPayments.Remove(bunifuCards1.Controls[4].Text);
            bunifuCards1.Controls[4].Text = "default";
            bunifuCards1.Visible = false;
        }

        private void bunifuCards2_Click(object sender, EventArgs e)
        {
            ValidPayments.Remove(bunifuCards2.Controls[4].Text);
            bunifuCards2.Controls[4].Text = "default";
            bunifuCards2.Visible = false;
        }

        private void bunifuCards3_Click(object sender, EventArgs e)
        {
            ValidPayments.Remove(bunifuCards3.Controls[4].Text);
            bunifuCards3.Controls[4].Text = "default";
            bunifuCards3.Visible = false;
        }

        private void bunifuCards4_Click(object sender, EventArgs e)
        {
            ValidPayments.Remove(bunifuCards4.Controls[4].Text);
            bunifuCards4.Controls[4].Text = "default";
            bunifuCards4.Visible = false;
        }

        private void bunifuCards5_Click(object sender, EventArgs e)
        {
            ValidPayments.Remove(bunifuCards5.Controls[4].Text);
            bunifuCards5.Controls[4].Text = "default";
            bunifuCards5.Visible = false;
        }

        private bool IsPaymentExist(int modifier)
        {
            bool exist = false;
            if (modifier == 0) //payment
            {
                foreach (var item in GlobalCards)
                {

                    if (item.Controls[4].Text == PaymentCombo.selectedValue)
                        exist = true;
                }
            }
            
            return exist;
        }

        private string ParseMultiPayment(int modifier = 0)
        {
            
            string moded = "";
            if (modifier == 0)
            {
                string payments = "";
                foreach (var payment in ValidPayments)
                {
                    payments += "," + payment;
                }
                moded = payments.Substring(1, payments.Length - 1);
            }
            else
            {
                string sponsors = "";
                try
                {
                    foreach (var sponsor in ValidSponsors)
                    {
                        sponsors += "," + sponsor;
                    }
                    moded = sponsors.Substring(1, sponsors.Length - 1);
                }
                catch (Exception)
                {

                }
                finally
                {
                    moded = "";
                }
            }

            return moded ;
        }

    

       

        

        private void bunifuiOSSwitch1_OnValueChange(object sender, EventArgs e)
        {
            
        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string strict = Strict.Checked == false ? "0" : "1";
                string eventAmount = freeSwitch.Value == false ? ParseMultiPayment() : "0";
                string eventName = txtEventName.Text.Trim().Length > 8 && txtEventName.Text.Trim().Length < 50 ? txtEventName.Text.Trim() : null;
                string ceventDate = eventDate.Value.ToString() != "" ? eventDate.Value.ToShortDateString() : null;
                string eventOpen = "-1";
                string partial = minimum.Text.Trim().Length <= 0 ? "0" : minimum.Text.Trim();

                DateTime date;

                if (TimePicker.selectedIndex == 0)
                    date = eventDate.Value + new TimeSpan(Convert.ToInt32(DropTime.selectedValue), 0, 0);
                else
                    date = eventDate.Value - new TimeSpan(Convert.ToInt32(DropTime.selectedValue), 0, 0);

                if (eventName == null)
                    alert.Show("Invalid Name", alert.AlertType.info);
                else if (LocationCombo.selectedIndex == -1)
                    alert.Show("Invalid Location", alert.AlertType.info);
                else if (date.CompareTo(DateTime.Now) == -1)
                    alert.Show("Past date/hour not accepted", alert.AlertType.info);
                else if (ValidateEvent())
                    alert.Show("Time/Location already used.", alert.AlertType.info);
                else if (ValidateEvent(1))
                {
                    var result = MessageBox.Show("The same event has already exist, would you still want to try to create this event?", "Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (ValidateEvent())
                            alert.Show("Time/Location already used.", alert.AlertType.info);
                        else
                        {
                            //string query = "insert into custom_event(event_name,event_location,event_stime,event_date,event_cost,event_open,event_registered,event_attended,sponsor,strict) values(@name,@loc,@time,@date,@cost,@open,@registered,@attended,@sponsor,@strict)";
                            //SqlUtils.ExecuteInsert(query, new string[] { "@name", "@loc", "@time", "@date", "@cost", "@open", "registered", "@attended", "@sponsor", "@strict" }, new string[] { eventName, LocationCombo.selectedValue.Trim(), DropTime.selectedValue + TimePicker.selectedValue, ceventDate, eventAmount, eventOpen, "0", "0", ParseMultiPayment(1), strict });
                            //alert.Show("Success", alert.AlertType.success);

                            //freeSwitch.Value = true;
                            //freeSwitch_OnValueChange(bunifuFlatButton1, EventArgs.Empty);
                            //PaymentCombo.selectedIndex = -1;
                            //LocationCombo.selectedIndex = -1;
                            //txtEventName.Text = "";
                            //Strict.Checked = false;

                            var sponsorsHelp = new SponsorsHelp();
                            sponsorsHelp.FetchData();
                            sponsorsHelp.SetUpEvent(txtEventName.Text.Trim(), LocationCombo.selectedValue.Trim(), DropTime.selectedValue.Trim() + TimePicker.selectedValue.Trim(), EndTime.selectedValue.Trim() + EndAM.selectedValue.Trim(), eventDate.Value.ToShortDateString().Trim(), eventAmount, partial, "-1", "0", "0", strict);

                            Panel1.Controls.Add(sponsorsHelp);
                            sponsorsHelp.Dock = DockStyle.Fill;
                            sponsorsHelp.BringToFront();
                        }
                    }
                }
                else
                {
                    //string query = "insert into custom_event(event_name,event_location,event_stime,event_date,event_cost,event_open,event_registered,event_attended,sponsor,strict) values(@name,@loc,@time,@date,@cost,@open,@registered,@attended,@sponsor,@strict)";
                    //SqlUtils.ExecuteInsert(query, new string[] { "@name", "@loc", "@time", "@date", "@cost", "@open", "registered", "@attended", "@sponsor", "@strict" }, new string[] { eventName, LocationCombo.selectedValue.Trim(), DropTime.selectedValue + TimePicker.selectedValue, ceventDate, eventAmount, eventOpen, "0", "0", ParseMultiPayment(1), strict });
                    //alert.Show("Success", alert.AlertType.success);

                    //freeSwitch.Value = true;
                    //freeSwitch_OnValueChange(bunifuFlatButton1, EventArgs.Empty);
                    //PaymentCombo.selectedIndex = -1;
                    //LocationCombo.selectedIndex = -1;
                    //txtEventName.Text = "";
                    //Strict.Checked = false;


                    //SqlUtils.ExecuteInsert(query, new string[] { "@name", "@loc", "@time","@endtime", "@date", "@cost", "@partial" ,"@open", "registered", "@attended", "@sponsor", "@strict" }, new string[] { eventName, LocationCombo.selectedValue.Trim(), DropTime.selectedValue + TimePicker.selectedValue, ceventDate, eventAmount, eventOpen, "0", "0", ParseMultiPayment(1), strict });
                    try
                    {
                        var sponsorsHelp = new SponsorsHelp();
                        sponsorsHelp.FetchData();

                        sponsorsHelp.SetUpEvent(txtEventName.Text.Trim(), LocationCombo.selectedValue.Trim(), DropTime.selectedValue.Trim() + TimePicker.selectedValue.Trim(), EndTime.selectedValue.Trim() + EndAM.selectedValue.Trim(), eventDate.Value.ToShortDateString().Trim(), eventAmount, partial, "-1", "0", "0", strict);
                        Panel1.Controls.Add(sponsorsHelp);
                        sponsorsHelp.Dock = DockStyle.Fill;
                        sponsorsHelp.BringToFront();
                    }
                    catch (Exception ex) { MessageBox.Show( ex.Message);}

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void freeSwitch_OnValueChange_1(object sender, EventArgs e)
        {
            var lblAmount = Amount;

            if (freeSwitch.Value == false)
            {
                panel2.Visible = true;
                PaymentCombo.Visible = true;
                lblAmount.Visible = true;
            }
            else
            {
                PaymentCombo.Visible = false;
                lblAmount.Visible = false;
                panel2.Visible = false;
                bunifuCards1_Click(null, EventArgs.Empty);
                bunifuCards2_Click(null, EventArgs.Empty);
                bunifuCards3_Click(null, EventArgs.Empty);
                bunifuCards4_Click(null, EventArgs.Empty);
                bunifuCards5_Click(null, EventArgs.Empty);


            }
        }

        private void bunifuiOSSwitch1_OnValueChange_1(object sender, EventArgs e)
        {
            string text = "";
            if (bunifuiOSSwitch1.Value == false)
                text = "full payment";
            else
                text = "partial payment";
            minimum.Visible = bunifuiOSSwitch1.Value;
            PaymentOpt.Text = text.ToUpper();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            var sponsor = new Sponsors();
            sponsor.InitializeData();
            sponsor.Show();
        }

        private void PaymentCombo_onItemSelected_1(object sender, EventArgs e)
        {
            List<Bunifu.Framework.UI.BunifuCards> cards = new List<Bunifu.Framework.UI.BunifuCards>();
            cards.Add(bunifuCards1);
            cards.Add(bunifuCards2);
            cards.Add(bunifuCards3);
            cards.Add(bunifuCards4);
            cards.Add(bunifuCards5);
            GlobalCards = cards;
            foreach (var item in cards)
            {
                if (item.Controls[4].Text == "default" && !item.Visible && !IsPaymentExist(0))
                {
                    item.Controls[4].Text = PaymentCombo.selectedValue;
                    ValidPayments.Add(PaymentCombo.selectedValue);
                    item.BackColor = Misc.GetColor();
                    item.Visible = true;
                    alert.Show("Payment added", alert.AlertType.success);
                    break;
                }
                else
                    alert.Show("Payment already exist!", alert.AlertType.info);
            }

        }


        private void bunifuCards1_Click_1(object sender, EventArgs e)
        {
            ValidPayments.Remove(bunifuCards1.Controls[4].Text);
            bunifuCards1.Controls[4].Text = "default";
            bunifuCards1.Visible = false;
        }

        private void bunifuCards2_Click_1(object sender, EventArgs e)
        {
            ValidPayments.Remove(bunifuCards2.Controls[4].Text);
            bunifuCards2.Controls[4].Text = "default";
            bunifuCards2.Visible = false;
        }

        private void bunifuCards3_Click_1(object sender, EventArgs e)
        {
            ValidPayments.Remove(bunifuCards3.Controls[4].Text);
            bunifuCards3.Controls[4].Text = "default";
            bunifuCards3.Visible = false;
        }

        private void bunifuCards4_Click_1(object sender, EventArgs e)
        {
            ValidPayments.Remove(bunifuCards4.Controls[4].Text);
            bunifuCards4.Controls[4].Text = "default";
            bunifuCards4.Visible = false;
        }

        private void bunifuCards5_Click_1(object sender, EventArgs e)
        {
            ValidPayments.Remove(bunifuCards5.Controls[4].Text);
            bunifuCards5.Controls[4].Text = "default";
            bunifuCards5.Visible = false;
        }
    }
}
