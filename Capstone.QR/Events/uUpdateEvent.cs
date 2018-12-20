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
using System.Text.RegularExpressions;
using Capstone.QR.Events;

namespace Capstone.QR
{
    public partial class uUpdateEvent : UserControl
    {
        public static uUpdateEvent Instance()
        {
            return new uUpdateEvent();
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

        public uUpdateEvent()
        {
            InitializeComponent();
            var r= SqlUtils.ExecuteQueryReader("select payment from valid_payment", false);
            while (r.Read())
            {
                Payment.AddItem(r[0].ToString());
            }
            GetValidLocation();
        }

        List<string> GlobalNameList = new List<string>();
        List<string> GenericList = new List<string>();
        List<string> ValidPayments = new List<string>();
        public void InitNameList(List<string> EventNames)
        {
            EventNameList.Clear();
            GlobalNameList = EventNames;

            foreach (string name in EventNames)
            {
                EventNameList.AddItem(Misc.StripColonRight(name));
            }
            
            ResetFields();
        }

        private void Searchbar_KeyUp(object sender, KeyEventArgs e)
        {
            EventNameList.Clear();
            
            bool found = false;
            var pattern = new Regex(Regex.Escape(Searchbar.Text),RegexOptions.IgnoreCase);

            if (Searchbar.Text.Trim().Length > 0)
            {
                if (RefreshNameList(1, Searchbar.Text.Trim()))
                    found = true;
                if (found == false)
                {
                    EventNameList.Clear();
                    EventNameList.AddItem("No Result Found");
                }
            }
            else
            {
                RefreshNameList(0,"");
            }
        }

        private void ResetFields()
        {
            Strict.Checked = false;
            freeSwitch.Value = true;
            label6.Text = "";
            label6.Visible = false;
            txtEventName.Text = "";
            eventDate.Value = DateTime.Now;
            DropTime.selectedIndex = 0;
            TimePicker.selectedIndex = 0;
        }
        int id;
        List<Bunifu.Framework.UI.BunifuCards> GlobalCards = new List<Bunifu.Framework.UI.BunifuCards>();
        List<string> Sponsorsz = new List<string>();
        private void EventNameList_onItemSelected(object sender, EventArgs e)
        {

            ValidPayments.Clear();
            GlobalCards.Clear();
            var ind = EventNameList.selectedIndex;
            string value= GlobalNameList[ind];
            int i = value.IndexOf(":");
            string raw = value.Substring(0,i);
            id = Convert.ToInt32(raw);
            var reader = SqlUtils.ExecuteQueryReader("select * from custom_event where eventid="+raw, false);
            while (reader.Read())
            {
                if (Convert.ToInt32(reader["strict"]) == 0)
                    Strict.Checked = false;
                else
                    Strict.Checked = true;
                string[] sponsors = reader["sponsor"].ToString().Split(',');
                if (sponsors.Length != 0)
                {
                    foreach (var item in sponsors)
                    {
                        Sponsorsz.Add(item);
                    }
                }

                if(reader["event_cost"].ToString() != "0")
                {
                    freeSwitch.Value = false;
                    List<Bunifu.Framework.UI.BunifuCards> cards = new List<Bunifu.Framework.UI.BunifuCards>();
                    cards.Add(bunifuCards1);
                    cards.Add(bunifuCards2);
                    cards.Add(bunifuCards3);
                    cards.Add(bunifuCards4);
                    cards.Add(bunifuCards5);
                    string[] payments =  reader["event_cost"].ToString().Split(',');
                    try
                    {
                        for (int c = 0; c < payments.Length; c++)
                        {
                            cards[c].Controls[4].Text = payments[c];
                            cards[c].BackColor = Misc.GetColor();
                            cards[c].Visible = true;
                            ValidPayments.Add(payments[c]);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    ValidPayments.Add("0");
                    freeSwitch.Value = true;
                    List<Bunifu.Framework.UI.BunifuCards> cards = new List<Bunifu.Framework.UI.BunifuCards>();
                    cards.Add(bunifuCards1);
                    cards.Add(bunifuCards2);
                    cards.Add(bunifuCards3);
                    cards.Add(bunifuCards4);
                    cards.Add(bunifuCards5);
                    try
                    {
                        for (int c = 0; c < cards.Count ; c++)
                        {
                            cards[c].Controls[4].Text = "";
                            cards[c].Visible = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                // default select payment

                // reload and use add event functions :)
               
                //List<Bunifu.Framework.UI.BunifuCards> cards = new List<Bunifu.Framework.UI.BunifuCards>();
                //cards.Add(bunifuCards1);
                //cards.Add(bunifuCards2);
                //cards.Add(bunifuCards3);
                //cards.Add(bunifuCards4);
                //cards.Add(bunifuCards5);
                //GlobalCards = cards;
                //foreach (var item in cards)
                //{
                //    if (item.Controls[4].Text == "default" && !item.Visible && !IsPaymentExist(0))
                //    {
                //        item.Controls[4].Text = PaymentCombo.selectedValue;
                //        ValidPayments.Add(PaymentCombo.selectedValue);
                //        item.BackColor = Misc.GetColor();
                //        item.Visible = true;
                //        alert.Show("Payment added", alert.AlertType.success);
                //        break;
                //    }
                //    else
                //        alert.Show("Payment already exist!", alert.AlertType.info);
                //}

                //if (Convert.ToInt32(reader["event_cost"]) == 0)
                //{
                //    freeSwitch.Value = true;
                //    txtAmount.Visible = false;
                //}
                //else
                //{
                //    freeSwitch.Value = false;
                //    txtAmount.Visible = true;
                //    txtAmount.Text = Convert.ToInt32(reader["event_cost"]).ToString();
                //}

                txtEventName.Text = reader["event_name"].ToString();
                eventDate.Value = (DateTime) reader["event_date"];

                var time = (TimeSpan) reader["event_stime"];
                int hour = time.Hours;

                if(hour <= 12)
                {
                    DropTime.selectedIndex = hour - 2;
                    TimePicker.selectedIndex = 0;
                }
                else
                {
                    DropTime.selectedIndex = hour - 13;
                    TimePicker.selectedIndex = 1;
                }
                

            }
            
        }

        private bool RefreshNameList(int search, string keyword)
        {
            bool count = false;

            if (search == 0)
            {
                List<string> NameList = new List<string>();
                var readerz = SqlUtils.ExecuteQueryReader("select eventid,event_name from custom_event", false);
                while (readerz.Read())
                {
                    NameList.Add(Convert.ToInt32(readerz["eventid"]) + ":" + readerz["event_name"].ToString());
                }
                EventNameList.Clear();
                GlobalNameList = NameList;
                foreach (string name in GlobalNameList)
                {
                    EventNameList.AddItem(Misc.StripColonRight(name));
                }
            }
            else if (search == 1 && keyword != "")
            {
                List<string> NameList = new List<string>();
                var readerz = SqlUtils.ExecuteQueryReader("select eventid,event_name from custom_event where event_name like '%"+ keyword + "%'" , false);
                while (readerz.Read())
                {
                    NameList.Add(Convert.ToInt32(readerz["eventid"]) + ":" + readerz["event_name"].ToString());
                }
                EventNameList.Clear();
                GlobalNameList = NameList;
                foreach (string name in GlobalNameList)
                {
                    EventNameList.AddItem(Misc.StripColonRight(name));
                    count = true;
                }
            }
            return count;
        }

        List<string> Sponsors = new List<string>();
        private string ParseMultiPayment(int modifier = 0)
        {

            string moded = "";
            if (modifier == 0)
            {
                string payments = "";
                foreach (var payment in ValidPayments)
                {
                    payments +=  payment + ",";
                }
                moded = payments.Substring(0, payments.Length - 1);
            }
         

            return moded;
        }
        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {

                int strict = 0;
                if (Strict.Checked)
                    strict = 1;

                //int amount;
                //if (freeSwitch.Value == false)
                //    amount = Convert.ToInt32(Payment.selectedValue);
                //else
                //    amount = 0;
                string eventAmount = freeSwitch.Value == false ? ParseMultiPayment() : "0";

                bool invalid = false;
                string name = txtEventName.Text.Trim();

                DateTime date;

                if (TimePicker.selectedIndex == 0)
                    date = eventDate.Value + new TimeSpan(Convert.ToInt32(DropTime.selectedValue), 0, 0);
                else
                    date = eventDate.Value - new TimeSpan(Convert.ToInt32(DropTime.selectedValue), 0, 0);




                if (name.Length > 50 || name.Length < 8)
                {
                    alert.Show("Invalid event name", alert.AlertType.info);
                    invalid = true;
                }

                if (LocationCombo.selectedIndex == -1)
                {
                    alert.Show("Invalid Location", alert.AlertType.warnig);
                    invalid = true;
                }

                if (date.CompareTo(DateTime.Now) == -1)
                {
                    alert.Show("Invalid date", alert.AlertType.info);
                    invalid = true;
                }

                if (invalid == false)
                {
                    var sponsorsHelp = new SponsorsHelp();
                    sponsorsHelp.FetchData();
                    sponsorsHelp.SetUpFromUpdate(txtEventName.Text.Trim(), LocationCombo.selectedValue, DropTime.selectedValue + TimePicker.selectedValue, EndTime.selectedValue + EndAM.selectedValue, eventDate.Value.ToShortDateString(), eventAmount, Strict.Checked == true ? "1" : "0", id.ToString());
                    panel1.Controls.Add(sponsorsHelp);
                    sponsorsHelp.Dock = DockStyle.Fill;
                    sponsorsHelp.BringToFront();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message);}
                //try
                //{
                //    SqlUtils.ExecuteQuery("update custom_event set event_name='" + name + "', sponsor='" + sponsor + "', event_location='" + location + "', event_stime='" + DropTime.selectedValue+ TimePicker.selectedValue + "', strict='" + strict + "', event_date='" +eventDate.Value+"' where eventid="+ id, false);
                //    RefreshNameList(0,"");
                //    alert.Show("Update Success",alert.AlertType.success);
                //}
                //catch (Exception ex)
                //{
                //    alert.Show("Unknown Error Occurs...", alert.AlertType.error);
                //}
            }


        private bool IsPaymentExist(int modifier)
        {

            bool exist = false;
            if (modifier == 0) //payment
            {
                foreach (var item in GlobalCards)
                {

                    if (item.Controls[4].Text == Payment.selectedValue)
                        exist = true;
                }
            }

            return exist;
        }

        private void freeSwitch_OnValueChange(object sender, EventArgs e)
        {
            if (freeSwitch.Value == false)
            {
                Payment.Visible = true;
                label6.Visible = true;
            }
            else
            {
                ValidPayments.Clear();
                ValidPayments.Add("0");
                List<Bunifu.Framework.UI.BunifuCards> cards = new List<Bunifu.Framework.UI.BunifuCards>();
                cards.Add(bunifuCards1);
                cards.Add(bunifuCards2);
                cards.Add(bunifuCards3);
                cards.Add(bunifuCards4);
                cards.Add(bunifuCards5);
                try
                {
                    for (int c = 0; c < cards.Count; c++)
                    {
                        cards[c].Controls[4].Text = "";
                        cards[c].Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Payment.Visible = false;
                label6.Visible = false;
            }
        }

        private void Payment_onItemSelected(object sender, EventArgs e)
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
                if (!item.Visible && !IsPaymentExist(0))
                {
                    item.Controls[4].Text = Payment.selectedValue;
                    ValidPayments.Add(Payment.selectedValue);
                    item.BackColor = Misc.GetColor();
                    item.Visible = true;
                    alert.Show("Payment added", alert.AlertType.success);
                    break;
                }
                else
                {
                    alert.Show("Payment already exist!", alert.AlertType.info);
                }
            }
       
        }

        private void bunifuCards2_Click(object sender, EventArgs e)
        {
            ValidPayments.Remove(bunifuCards2.Controls[4].Text);
            bunifuCards2.Controls[4].Text = "default";
            bunifuCards2.Visible = false;
        }

        private void bunifuCards1_Click(object sender, EventArgs e)
        {
            ValidPayments.Remove(bunifuCards1.Controls[4].Text);
            bunifuCards1.Controls[4].Text = "default";
            bunifuCards1.Visible = false;
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
    }



  



   
}

