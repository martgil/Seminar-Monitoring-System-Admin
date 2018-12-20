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

namespace Capstone.QR.College
{
    public partial class uMixedCollege : UserControl
    {
        public uMixedCollege()
        {
            InitializeComponent();
        }

        public void InitializeData()
        {
            CollegeCombo.Clear();
            var reader = SqlUtils.ExecuteQueryReader("select * from college", false);
            while (reader.Read())
            {
                CollegeCombo.AddItem(reader["college_info"].ToString());
            }
        }

        // Add college
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string code = NewCollege.Text.Trim();

                if (String.IsNullOrEmpty(code) == true || String.IsNullOrEmpty(code) == true)
                    alert.Show("Empty fields..", alert.AlertType.error);
                else if (code.Length <= 10)
                    alert.Show("Length is too short", alert.AlertType.info);
                else
                {
                    SqlUtils.ExecuteInsert("insert into college values (@college)", new string[] { "@college" }, new string[] { NewCollege.Text.Trim() });
                    NewCollege.Text = "";
                    alert.Show("College added.", alert.AlertType.success);
                    InitializeData();
                }
            }
            catch (Exception)
            {
                alert.Show("Entry Already Exist", alert.AlertType.info);
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (CollegeCombo.selectedIndex == -1)
                alert.Show("Invalid Selection", alert.AlertType.info);
            else if (PermitCollegeDelete(CollegeCombo.selectedValue) == false)
                alert.Show("College not empty, remove denied", alert.AlertType.error);
            else
            {
                SqlUtils.ExecuteQuery("delete from college where college_info='" + CollegeCombo.selectedValue + "'", false);
                CollegeCombo.selectedIndex = -1;
                InitializeData();
                alert.Show("Remove Success", alert.AlertType.success);
            }
        }

        private bool PermitCollegeDelete(string collegeName)
        {
            bool valid = true;

            var reader = SqlUtils.ExecuteQueryReader("select * from course where college_info='" + collegeName + "'", false);
            if (reader.HasRows)
            {
                valid = false;
            }
            return valid;
        }

    }
}
