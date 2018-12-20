using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Capstone.QR.Tools;

namespace Capstone.QR
{
    public partial class firstRun : Form
    {
        
        List<Color> colors = new List<Color>();
        int currentColor = 0;
        int a = 0;
        public firstRun()
        {
            colors.Add(Color.FromArgb(0, 158, 71));
            colors.Add(Color.FromArgb(112, 191, 83));
            colors.Add(Color.FromArgb(126, 155, 40));
            colors.Add(Color.FromArgb(217, 102, 41));
            colors.Add(Color.FromArgb(217, 102, 41));
            colors.Add(Color.FromArgb(235, 83, 104));
            colors.Add(Color.FromArgb(223, 128, 255));
            colors.Add(Color.FromArgb(112, 48, 160));
            colors.Add(Color.FromArgb(107, 122, 187));
            colors.Add(Color.FromArgb(95, 136, 176));
            colors.Add(Color.FromArgb(70, 175, 227));
            colors.Add(Color.FromArgb(0, 158, 71));
            InitializeComponent();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            if (currentColor < colors.Count - 1)
            {
                this.BackColor = Bunifu.Framework.UI.BunifuColorTransition.getColorScale(a, colors[currentColor], colors[currentColor + 1]);
                if (currentColor == 2)
                {
                    notifier.Text = "Checking Machine Compatibility...";
                    if (Windows.IsServerInstalled() == false)
                    {
                        MessageBox.Show("Microsoft SQL Server Management Studio must be installed!", "Exiting", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Application.Exit();
                    }
                    
                }
                else if (currentColor == 5)
                {
                    Windows.ConfigureDirectory();
                    notifier.Text = "Creating Local Directory...";
                }
                else if (currentColor == 8)
                {
                    if (SqlUtils.IsDatabaseExist() == false)
                        SqlUtils.CreateDatabase();
                    
                    if (SqlUtils.IsTableExist("auth") == false)
                    {
                        String query = "CREATE TABLE auth (uname varchar(25), passwd nvarchar(4000))"; // For admin login table
                        SqlUtils.ExecuteQuery(query, false);
                        query = "create table custom_event (eventid int primary key not null identity,event_name varchar(400),sponsor varchar(255),event_location varchar(500),event_stime time, event_etime time, event_date date,event_cost varchar(200),event_partial int,event_open int,strict int,event_registered int,event_attended int)"; // For Event table
                        SqlUtils.ExecuteQuery(query, false);
                        query = "CREATE TABLE personnel (userid int primary key not null identity,given_name varchar(100),last_name varchar(100),username varchar(80) unique,affiliation varchar(150),contact_no varchar(50),passwd nvarchar(4000))"; // For personel table
                        SqlUtils.ExecuteQuery(query, false);
                        query = "create table college (college_info varchar(400) unique)"; // College Table
                        SqlUtils.ExecuteQuery(query, false);
                        query = "create table attendee (attendee_id int identity,userid int,first_name varchar(200),middle_initial varchar(10),last_name varchar(200),balance int,payment int,ticket_price int,course varchar(400),yrsec varchar(100),college_info varchar(400),eventid int,time_in time, time_out time, primary key(attendee_id),constraint fk_PersonnelId foreign key (userid) references personnel(userid),constraint fk_attendanceEvent foreign key (eventid)references custom_event(eventid))"; // Attendee Table
                        SqlUtils.ExecuteQuery(query, false);
                        query = "create table course (college_info varchar(400) ,course varchar(400) unique) ";
                        SqlUtils.ExecuteQuery(query, false);
                        query = "create table assigned_personnel (userid int,eventid int,constraint fk_personnelassign foreign key(userid) references personnel(userid),constraint fk_eventid foreign key(eventid) references custom_event(eventid))";
                        SqlUtils.ExecuteQuery(query, false);
                        query = "create table valid_payment (payment int unique)";
                        SqlUtils.ExecuteQuery(query, false);
                        query = "create table valid_location (location varchar(400) unique)";
                        SqlUtils.ExecuteQuery(query, false);
                        query = "create table valid_sponsor (sponsor varchar(400) unique)";
                        SqlUtils.ExecuteQuery(query, false);

                        //Insert College
                        SqlUtils.ExecuteInsert("insert into college values (@college)", new string[] { "@college" }, new string[] { "College of Architecture and Fine Arts (CAFA)" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college","@course" }, new string[] { "College of Architecture and Fine Arts (CAFA)","Bachelor in Fine Arts" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Architecture and Fine Arts (CAFA)", "Bachelor of Science in Architecture" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Architecture and Fine Arts (CAFA)", "Bachelor of Science in Landscape Architecture" });

                        SqlUtils.ExecuteInsert("insert into college values (@college)", new string[] { "@college" }, new string[] { "College of Arts and Letters (CAL)" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Arts and Letters (CAL)", "Bachelor of Arts in Broadcasting" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Arts and Letters (CAL)", "Bachelor of Arts in Journalism" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Arts and Letters (CAL)", "Bachelor of Arts in Malikhaing Pagsulat" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Arts and Letters (CAL)", "Bachelor of Arts in Mass Communication" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Arts and Letters (CAL)", "Bachelor of Arts in Theater Arts" });

                        SqlUtils.ExecuteInsert("insert into college values (@college)", new string[] { "@college" }, new string[] { "College of Business Administration (CBA)" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Business Administration (CBA)", "Bachelor of Science in Accountancy" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Business Administration (CBA)", "Bachelor of Science in Accounting Technology" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Business Administration (CBA)", "Bachelor of Science in Business Administration" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Business Administration (CBA)", "Bachelor of Science in Entrepreneurship" });

                        SqlUtils.ExecuteInsert("insert into college values (@college)", new string[] { "@college" }, new string[] { "College of Criminal Justice Education (CCJE)" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Criminal Justice Education (CCJE)", "Bachelor of Arts in Legal Management" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Criminal Justice Education (CCJE)", "Bachelor of Science in Criminology" });

                        SqlUtils.ExecuteInsert("insert into college values (@college)", new string[] { "@college" }, new string[] { "College of Hospitality and Tourism Management (CHTM)" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Hospitality and Tourism Management (CHTM)", "Bachelor of Science in Home Economics" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Hospitality and Tourism Management (CHTM)", "Bachelor of Science in Hospitality Management" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Hospitality and Tourism Management (CHTM)", "Bachelor of Science in Hotel and Restaurant Management" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Hospitality and Tourism Management (CHTM)", "Bachelor of Science in Tourism Management" });

                        SqlUtils.ExecuteInsert("insert into college values (@college)", new string[] { "@college" }, new string[] { "College of Information and Communications Technology (CICT)" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Information and Communications Technology (CICT)", "Associate in Computer Technology" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Information and Communications Technology (CICT)", "Bachelor of Industrial Technology (Computer Technology)" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Information and Communications Technology (CICT)", "Bachelor of Science in Information Technology" });

                        SqlUtils.ExecuteInsert("insert into college values (@college)", new string[] { "@college" }, new string[] { "College of Industrial Technology (CIT)" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Industrial Technology (CIT)", "Bachelor in Industrial Technology" });


                        SqlUtils.ExecuteInsert("insert into college values (@college)", new string[] { "@college" }, new string[] { "College of Law (CLaw)" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Law (CLaw)", "Bachelor of Laws" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Law (CLaw)", "Juris Doctor" });


                        SqlUtils.ExecuteInsert("insert into college values (@college)", new string[] { "@college" }, new string[] { "College of Nursing (CN)" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Nursing (CN)", "Bachelor of Science in Nursing" });

                        SqlUtils.ExecuteInsert("insert into college values (@college)", new string[] { "@college" }, new string[] { "College of Engineering (COE)" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Engineering (COE)", "Bachelor of Science in Civil Engineering" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Engineering (COE)", "Bachelor of Science in Computer Engineering" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Engineering (COE)", "Bachelor of Science in Electrical Engineering" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Engineering (COE)", "Bachelor of Science in Electronics and Communications Engineering" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Engineering (COE)", "Bachelor of Science in Industrial Engineering" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Engineering (COE)", "Bachelor of Science in Manufacuring and Engineering Management" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Engineering (COE)", "Bachelor of Science in Mechanical Engineering" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Engineering (COE)", "Bachelor of Science in Mechatronics Engineering" });
                        
                        SqlUtils.ExecuteInsert("insert into college values (@college)", new string[] { "@college" }, new string[] { "College of Education (COED)" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Education (COED)", "Bachelor in Elemetary Education" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Education (COED)", "Bachelor of Library and Information Service" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Education (COED)", "Bachelor in Secondary Education" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Education (COED)", "Bachelor of Technical-Teacher Education" });

                        SqlUtils.ExecuteInsert("insert into college values (@college)", new string[] { "@college" }, new string[] { "College of Science (CS)" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Science (CS)", "Bachelor of Science in Biology" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Science (CS)", "Bachelor of Science in Environmental Science" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Science (CS)", "Bachelor of Science in Food Science" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Science (CS)", "Bachelor of Science in Mathematics" });


                        SqlUtils.ExecuteInsert("insert into college values (@college)", new string[] { "@college" }, new string[] { "College of Sports, Exercise and Recreation (CSER)" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Sports, Exercise and Recreation (CSER)", "Bachelor in Physical Education" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Sports, Exercise and Recreation (CSER)", "Bachelor in Sports Science" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Sports, Exercise and Recreation (CSER)", "Bachelor in Physical Education (with Major)" });

                        SqlUtils.ExecuteInsert("insert into college values (@college)", new string[] { "@college" }, new string[] { "College of Social Sciences and Philosophy (CSSP)" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Social Sciences and Philosophy (CSSP)", "Bachelor of Public Administration" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Social Sciences and Philosophy (CSSP)", "Bachelor of Science in Management Economics" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "College of Social Sciences and Philosophy (CSSP)", "Bachelor of Science in Psychology" });

                        SqlUtils.ExecuteInsert("insert into college values (@college)", new string[] { "@college" }, new string[] { "Graduate School (GS)" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "Graduate School (GS)", "Doctor of Education" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "Graduate School (GS)", "Doctor of Philosophy" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "Graduate School (GS)", "Doctor of Public Administration" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "Graduate School (GS)", "Master in Physical Education" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "Graduate School (GS)", "Master in Business Administration" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "Graduate School (GS)", "Master in Public Administration" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "Graduate School (GS)", "Master of Arts in Education" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "Graduate School (GS)", "Master of Engineering Program" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "Graduate School (GS)", "Master of Industrial Technology Management" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "Graduate School (GS)", "Master of Science in Civil Engineering" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "Graduate School (GS)", "Master of Science in Computer Engineering" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "Graduate School (GS)", "Master of Science in Electronics and Communications Engineering" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "Graduate School (GS)", "Master of Information Technology" });
                        SqlUtils.ExecuteInsert("insert into course(college_info,course) values (@college,@course)", new string[] { "@college", "@course" }, new string[] { "Graduate School (GS)", "Master of Manufacturing Engineering" });
                        //pre-insert new data for both valid_location and payment;
                        SqlUtils.ExecuteInsert("insert into valid_payment values (@payment)", new string[] { "@payment" },new string[] { "100" });
                        SqlUtils.ExecuteInsert("insert into valid_payment values (@payment)", new string[] { "@payment" }, new string[] { "150" });
                        SqlUtils.ExecuteInsert("insert into valid_payment values (@payment)", new string[] { "@payment" }, new string[] { "200" });

                        SqlUtils.ExecuteInsert("insert into valid_location values (@location)", new string[] { "@location" }, new string[] { "KB Gym Malolos Bulacan" });
                        SqlUtils.ExecuteInsert("insert into valid_location values (@location)", new string[] { "@location" }, new string[] { "Bulacan State University, Activity Center" });
                        SqlUtils.ExecuteInsert("insert into valid_location values (@location)", new string[] { "@location" }, new string[] { "Bulacan State University, Valencia Hall" });

                        SqlUtils.ExecuteInsert("insert into valid_sponsor values (@sponsor)", new string[] { "@sponsor" }, new string[] { "CICT Swits Organization" });

                        //Stored Procedure

                        SqlUtils.ExecuteQuery("create procedure GetEventStatus (@fromDate date,@toDate date,@statusCode int) as select event_name, sponsor, event_location, event_stime, event_date, event_cost, event_registered, event_attended from custom_event where event_open = @statusCode and event_date between @fromDate and @toDate order by event_date asc", false);
                        SqlUtils.ExecuteQuery("create procedure AttendeeUnpaid (@eid int) as select * from attendee where balance > 0 and eventid=@eid", false);
                        SqlUtils.ExecuteQuery("create procedure AttendeePaid (@eid int) as select * from attendee where balance=0 and eventid=@eid", false);

                        SqlUtils.CreateAdminAccount();
                    }
                    notifier.Text = "Creating Databases...";

                }
                else if (currentColor == 9)
                    notifier.Text = "Finishing...";

                if (a < 100)
                    a++;
                else
                {
                    a = 0;
                    currentColor++;
                }
                timer1.Enabled = true;
                
            }
            else
            {
                timer1.Enabled = false;
                login adminLogin = new login();
                this.Hide();
                adminLogin.Show();
            }
        }

        private void firstRun_Activated(object sender, EventArgs e)
        {
            if (SqlUtils.IsDatabaseExist())
            {
                timer1.Enabled = false;
                this.Hide();
                login adminLogin = new login();
                adminLogin.SetLogo();
                adminLogin.SetBrand();
                adminLogin.Show();
            }
        }

    }
}
