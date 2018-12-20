namespace Capstone.QR.Events
{
    partial class uViewEvent
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.EventData = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EventName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EventLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EventDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EventTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EventCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Registered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Attended = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EventData)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(241)))), ((int)(((byte)(248)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.EventData);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1130, 702);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label1.Location = new System.Drawing.Point(156, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(783, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "You can click the status buttons which corresponds a specified actions. For examp" +
    "le, open an event for registration.";
            // 
            // EventData
            // 
            this.EventData.AllowUserToAddRows = false;
            this.EventData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.EventData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.EventData.BackgroundColor = System.Drawing.Color.White;
            this.EventData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EventData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.EventData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.EventData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EventData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.EventName,
            this.EventLocation,
            this.EventDate,
            this.EventTime,
            this.EventCost,
            this.Registered,
            this.Attended,
            this.Status});
            this.EventData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.EventData.DoubleBuffered = true;
            this.EventData.EnableHeadersVisualStyles = false;
            this.EventData.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.EventData.HeaderForeColor = System.Drawing.Color.White;
            this.EventData.Location = new System.Drawing.Point(0, 86);
            this.EventData.Name = "EventData";
            this.EventData.ReadOnly = true;
            this.EventData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.EventData.Size = new System.Drawing.Size(1130, 616);
            this.EventData.TabIndex = 0;
            this.EventData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EventData_CellContentClick);
            // 
            // Id
            // 
            this.Id.HeaderText = "#";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // EventName
            // 
            this.EventName.HeaderText = "Event Name";
            this.EventName.Name = "EventName";
            this.EventName.ReadOnly = true;
            // 
            // EventLocation
            // 
            this.EventLocation.HeaderText = "Event Locations";
            this.EventLocation.Name = "EventLocation";
            this.EventLocation.ReadOnly = true;
            // 
            // EventDate
            // 
            this.EventDate.HeaderText = "Event Date";
            this.EventDate.Name = "EventDate";
            this.EventDate.ReadOnly = true;
            // 
            // EventTime
            // 
            this.EventTime.HeaderText = "Event Time";
            this.EventTime.Name = "EventTime";
            this.EventTime.ReadOnly = true;
            // 
            // EventCost
            // 
            this.EventCost.HeaderText = "Event Cost";
            this.EventCost.Name = "EventCost";
            this.EventCost.ReadOnly = true;
            // 
            // Registered
            // 
            this.Registered.HeaderText = "# of Registered Attendees";
            this.Registered.Name = "Registered";
            this.Registered.ReadOnly = true;
            // 
            // Attended
            // 
            this.Attended.HeaderText = "# of Attendees";
            this.Attended.Name = "Attended";
            this.Attended.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // uViewEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "uViewEvent";
            this.Size = new System.Drawing.Size(1130, 702);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EventData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuCustomDataGrid EventData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventName;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Registered;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attended;
        private System.Windows.Forms.DataGridViewButtonColumn Status;
    }
}
