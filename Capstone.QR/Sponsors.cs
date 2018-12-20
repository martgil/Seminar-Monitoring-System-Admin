using Capstone.QR.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstone.QR
{
    public partial class Sponsors : Form
    {
        public Sponsors()
        {
            InitializeComponent();
        }

        public void InitializeData()
        {
            SponsorCombo.Clear();
            var reader = SqlUtils.ExecuteQueryReader("select * from valid_sponsor", false);
            while (reader.Read())
            {
                SponsorCombo.AddItem(reader["sponsor"].ToString());
            }
         
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            //check if valid
            //add todb
            try
            {
                if (NewSponsor.Text.Trim().Length == 0)
                    alert.Show("Empty Fields...", alert.AlertType.error);
                else if (NewSponsor.Text.Trim().Length <= 2)
                    alert.Show("Length is too short.", alert.AlertType.info);
                else
                {
                    SqlUtils.ExecuteInsert("insert into valid_sponsor values (@sponsor)", new string[] { "@sponsor" }, new string[] { NewSponsor.Text.Trim() });
                    alert.Show("Added Success", alert.AlertType.success);
                    InitializeData();
                }
            }
            catch (Exception ex)
            {
                alert.Show("Already exist", alert.AlertType.info);
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (SponsorCombo.selectedIndex == -1)
                alert.Show("Invalid Selection", alert.AlertType.error);
            else
            {
                try
                {
                    SqlUtils.ExecuteQuery("delete from valid_sponsor where sponsor='" + SponsorCombo.selectedValue + "'", false);
                    InitializeData();
                    alert.Show("Remove Success", alert.AlertType.success);
                }
                catch (Exception ex) { MessageBox.Show( ex.Message );}
            }
        }
    }
}
