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
    public partial class uCollegeWinLoader : UserControl
    {
        public uCollegeWinLoader()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            var MixedCollege = new uMixedCollege(); // add necessary loader
            MixedCollege.InitializeData();
            Controls.Add(MixedCollege);
            MixedCollege.Dock = DockStyle.Fill;
            MixedCollege.BringToFront();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            var MixedCourse = new uMixedCourse();
            MixedCourse.InitializeData();
            Controls.Add(MixedCourse);
            MixedCourse.Dock = DockStyle.Fill;
            MixedCourse.BringToFront();
        }

    }
}
