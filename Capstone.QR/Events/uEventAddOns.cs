using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capstone.QR.Tools;

namespace Capstone.QR.Events
{
    public partial class uEventAddOns : UserControl
    {
        // Use try and catch in data addition to identify uniqueness in both payment and location

        public uEventAddOns()
        {
            InitializeComponent();
        }
        
        public static uEventAddOns Instance()
        {
            return new uEventAddOns();
        }

        public void Initializer()
        {
            // Fields: LocationCombo , PaymentCombo
            List<string> locations = FetchValidLocation();
            List<string> payments = FetchValidPayment();
            PaymentCombo.Clear();
            LocationCombo.Clear();
            foreach (var location in locations)
            {
                LocationCombo.AddItem(location);
            }

            foreach (var payment in payments)
            {
                PaymentCombo.AddItem(payment);
            }
        }
        
        private List<string> FetchValidLocation()
        {
            List<string> validLocation = new List<string>();
            var reader = SqlUtils.ExecuteQueryReader("select * from valid_location", false);
            while (reader.Read())
            {
                validLocation.Add(reader["location"].ToString());
            }

            return validLocation;
        }

        private List<string> FetchValidPayment()
        {
            List<string> validPayment = new List<string>();
            var reader = SqlUtils.ExecuteQueryReader("select * from valid_payment", false);
            while (reader.Read())
            {
                validPayment.Add(reader["payment"].ToString());
            }

            return validPayment;
        }

        private void AddPayment_Click(object sender, EventArgs e)
        {
            int callback = 0;
            // Field Name
            if (NewPayment.Text.Trim().Length <= 0)
                alert.Show("Empty Fields...", alert.AlertType.error);
            else if (!int.TryParse(NewPayment.Text, out callback))
                alert.Show("Payment not valid", alert.AlertType.error);
            else if (Convert.ToInt32(NewPayment.Text) < 0)
                alert.Show("Payment not accepted.", alert.AlertType.error);
            else if ((Convert.ToInt32(NewPayment.Text) >= 50 && Convert.ToInt32(NewPayment.Text) <= 0))
            {
                var result = MessageBox.Show("You are about to add a payment that is less than 50.", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    AddNewPayment(NewPayment.Text.Trim());
                }
            }
            else
                AddNewPayment(NewPayment.Text.Trim());
            Initializer(); // Refresher too :D
        }

        private void AddNewPayment(string payment)
        {
            try
            {
                SqlUtils.ExecuteInsert("insert into valid_payment values (@payment)", new string[] { "@payment" }, new string[] { payment });
                alert.Show("New Payment Added", alert.AlertType.success);
            }
            catch (SqlException ex)
            {
                alert.Show("Payment already exists", alert.AlertType.info);
            }
        }

        private void AddLocation_Click(object sender, EventArgs e)
        {
            if (NewLocation.Text.Trim().Length <= 0)
                alert.Show("Empty Fields...", alert.AlertType.info);
            else if (NewLocation.Text.Trim().Length <= 5)
                alert.Show("Location is too short.", alert.AlertType.info);
            else
            {
                SqlUtils.ExecuteInsert("insert into valid_location values (@location)", new string[] { "@location" }, new string[] { NewLocation.Text.Trim() });
                Initializer();
                alert.Show("New Location Added.", alert.AlertType.success);
            }

        }

        private void RemoveLocation_Click(object sender, EventArgs e)
        {
            if(LocationCombo.selectedIndex != -1)
            {
                var result = MessageBox.Show("Are you sure you want to remove it from the list?","Confirmation",MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    SqlUtils.ExecuteQuery("delete from valid_location where location='" + LocationCombo.selectedValue.Trim() + "'", false);
                    alert.Show("Successfully removed.", alert.AlertType.success);
                }
                LocationCombo.selectedIndex = -1;
                Initializer();
            }
            else
                alert.Show("Invalid Selection", alert.AlertType.error);
        }

        private void RemovePayment_Click(object sender, EventArgs e)
        {
            if (PaymentCombo.selectedIndex != -1)
            {
                var result = MessageBox.Show("Are you sure you want to remove it from the list?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    SqlUtils.ExecuteQuery("delete from valid_payment where payment='" + PaymentCombo.selectedValue + "'", false);
                    alert.Show("Successfully removed.", alert.AlertType.success);
                }
                LocationCombo.selectedIndex = -1;
                Initializer();
            }
            else
                alert.Show("Invalid Selection", alert.AlertType.error);
        }
    }
}
