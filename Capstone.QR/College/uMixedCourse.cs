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
    public partial class uMixedCourse : UserControl
    {
        public uMixedCourse()
        {
            InitializeComponent();
        }

        public void InitializeData()
        {
            AddCombo.Clear();
            RemoveCombo.Clear();    
            var reader = SqlUtils.ExecuteQueryReader("select * from college", false);
            while (reader.Read())
            {
                AddCombo.AddItem(reader["college_info"].ToString());
                RemoveCombo.AddItem(reader["college_info"].ToString());
            }
        }
        // add course
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string course = NewCourse.Text.Trim();
                if (String.IsNullOrEmpty(course) == true)
                    alert.Show("Empty fields...", alert.AlertType.error);
                else if (course.Length <= 10)
                    alert.Show("Length is too short", alert.AlertType.info);
                else
                {
                    if (AddCombo.selectedIndex != -1)
                    {
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { AddCombo.selectedValue.Trim(), NewCourse.Text.Trim() });
                        alert.Show("New Course Added.", alert.AlertType.success);

                        NewCourse.Text = "";
                        AddCombo.selectedIndex = -1;
                        InitializeData();
                    }
                    else
                        alert.Show("College Course is required", alert.AlertType.warnig);
                }
            }
            catch (Exception)
            {
                alert.Show("course already exist", alert.AlertType.error);
            }
            
            }

        private void RemoveCombo_onItemSelected(object sender, EventArgs e)
        {
            CourseCombo.Clear();
            var reader = SqlUtils.ExecuteQueryReader("select * from course where college_info='" + RemoveCombo.selectedValue + "'", false);
            while (reader.Read())
            {
                CourseCombo.AddItem(reader["course"].ToString());
            }
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            if (RemoveCombo.selectedIndex == -1 || CourseCombo.selectedIndex == -1)
                alert.Show("Invalid selection",alert.AlertType.error);
            else
            {
                SqlUtils.ExecuteQuery("delete from course where course='" + CourseCombo.selectedValue +"' and college_info='"+RemoveCombo.selectedValue +"'",false);
                alert.Show("Remove Success",alert.AlertType.success);
                InitializeData();

                RemoveCombo.selectedIndex = -1;
                CourseCombo.selectedIndex = -1;
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }


   }

