namespace Capstone.QR.Report
{
    partial class ReportWin
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.FromDate = new Bunifu.Framework.UI.BunifuDatepicker();
            this.ToDate = new Bunifu.Framework.UI.BunifuDatepicker();
            this.label1 = new System.Windows.Forms.Label();
            this.ReportCombo = new Bunifu.Framework.UI.BunifuDropdown();
            this.label3 = new System.Windows.Forms.Label();
            this.bunifuFlatButton1 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.CrystalView = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.StatusReport1 = new Capstone.QR.Report.StatusReport();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(85)))), ((int)(((byte)(124)))));
            this.label2.Location = new System.Drawing.Point(132, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = " From Date";
            // 
            // FromDate
            // 
            this.FromDate.BackColor = System.Drawing.Color.SeaGreen;
            this.FromDate.BorderRadius = 0;
            this.FromDate.ForeColor = System.Drawing.Color.White;
            this.FromDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.FromDate.FormatCustom = null;
            this.FromDate.Location = new System.Drawing.Point(244, 144);
            this.FromDate.Name = "FromDate";
            this.FromDate.Size = new System.Drawing.Size(303, 36);
            this.FromDate.TabIndex = 2;
            this.FromDate.Value = new System.DateTime(2018, 11, 29, 16, 0, 23, 173);
            // 
            // ToDate
            // 
            this.ToDate.BackColor = System.Drawing.Color.SeaGreen;
            this.ToDate.BorderRadius = 0;
            this.ToDate.ForeColor = System.Drawing.Color.White;
            this.ToDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.ToDate.FormatCustom = null;
            this.ToDate.Location = new System.Drawing.Point(688, 138);
            this.ToDate.Name = "ToDate";
            this.ToDate.Size = new System.Drawing.Size(303, 36);
            this.ToDate.TabIndex = 3;
            this.ToDate.Value = new System.DateTime(2018, 11, 29, 16, 0, 50, 715);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(85)))), ((int)(((byte)(124)))));
            this.label1.Location = new System.Drawing.Point(618, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "To Date";
            // 
            // ReportCombo
            // 
            this.ReportCombo.BackColor = System.Drawing.Color.Transparent;
            this.ReportCombo.BorderRadius = 3;
            this.ReportCombo.DisabledColor = System.Drawing.Color.Gray;
            this.ReportCombo.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportCombo.ForeColor = System.Drawing.Color.White;
            this.ReportCombo.Items = new string[] {
        "Select Report Type",
        "Open Events",
        "Closed Events",
        "Pending Events",
        "Paid Attendees",
        "Attendees with Balance"};
            this.ReportCombo.Location = new System.Drawing.Point(500, 21);
            this.ReportCombo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ReportCombo.Name = "ReportCombo";
            this.ReportCombo.NomalColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.ReportCombo.onHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.ReportCombo.selectedIndex = 0;
            this.ReportCombo.Size = new System.Drawing.Size(303, 38);
            this.ReportCombo.TabIndex = 5;
            this.ReportCombo.onItemSelected += new System.EventHandler(this.ReportCombo_onItemSelected);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(85)))), ((int)(((byte)(124)))));
            this.label3.Location = new System.Drawing.Point(147, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "Event Name";
            // 
            // bunifuFlatButton1
            // 
            this.bunifuFlatButton1.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.bunifuFlatButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.bunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton1.BorderRadius = 4;
            this.bunifuFlatButton1.ButtonText = "Generate Report";
            this.bunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton1.Iconimage = null;
            this.bunifuFlatButton1.Iconimage_right = null;
            this.bunifuFlatButton1.Iconimage_right_Selected = null;
            this.bunifuFlatButton1.Iconimage_Selected = null;
            this.bunifuFlatButton1.IconMarginLeft = 0;
            this.bunifuFlatButton1.IconMarginRight = 0;
            this.bunifuFlatButton1.IconRightVisible = true;
            this.bunifuFlatButton1.IconRightZoom = 0D;
            this.bunifuFlatButton1.IconVisible = true;
            this.bunifuFlatButton1.IconZoom = 90D;
            this.bunifuFlatButton1.IsTab = false;
            this.bunifuFlatButton1.Location = new System.Drawing.Point(426, 211);
            this.bunifuFlatButton1.Name = "bunifuFlatButton1";
            this.bunifuFlatButton1.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.bunifuFlatButton1.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.bunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton1.selected = false;
            this.bunifuFlatButton1.Size = new System.Drawing.Size(368, 48);
            this.bunifuFlatButton1.TabIndex = 8;
            this.bunifuFlatButton1.Text = "Generate Report";
            this.bunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuFlatButton1.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton1.TextFont = new System.Drawing.Font("Roboto", 11.25F);
            this.bunifuFlatButton1.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // CrystalView
            // 
            this.CrystalView.ActiveViewIndex = -1;
            this.CrystalView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrystalView.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrystalView.Location = new System.Drawing.Point(23, 284);
            this.CrystalView.Name = "CrystalView";
            this.CrystalView.Size = new System.Drawing.Size(1079, 401);
            this.CrystalView.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(85)))), ((int)(((byte)(124)))));
            this.label4.Location = new System.Drawing.Point(353, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 19);
            this.label4.TabIndex = 10;
            this.label4.Text = "Select Report Type";
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(247, 18);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(303, 26);
            this.comboBox1.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(301, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(647, 52);
            this.panel1.TabIndex = 12;
            this.panel1.Visible = false;
            // 
            // ReportWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(241)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CrystalView);
            this.Controls.Add(this.bunifuFlatButton1);
            this.Controls.Add(this.ReportCombo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ToDate);
            this.Controls.Add(this.FromDate);
            this.Controls.Add(this.label2);
            this.Name = "ReportWin";
            this.Size = new System.Drawing.Size(1130, 702);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuDatepicker FromDate;
        private Bunifu.Framework.UI.BunifuDatepicker ToDate;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuDropdown ReportCombo;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sponsorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventlocationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventstimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventcostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventregisteredDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventattendedDataGridViewTextBoxColumn;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrystalView;
        private StatusReport StatusReport1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel1;
    }
}
