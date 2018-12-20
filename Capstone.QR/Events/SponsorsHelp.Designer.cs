namespace Capstone.QR.Events
{
    partial class SponsorsHelp
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.SponsorGrid = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.Checkbox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SponsorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bunifuFlatButton1 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.Retry = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.SponsorGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SponsorGrid
            // 
            this.SponsorGrid.AllowUserToAddRows = false;
            this.SponsorGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.SponsorGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.SponsorGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SponsorGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SponsorGrid.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.SponsorGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SponsorGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SponsorGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.SponsorGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SponsorGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Checkbox,
            this.SponsorName});
            this.SponsorGrid.DoubleBuffered = true;
            this.SponsorGrid.EnableHeadersVisualStyles = false;
            this.SponsorGrid.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.SponsorGrid.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.SponsorGrid.Location = new System.Drawing.Point(49, 49);
            this.SponsorGrid.Name = "SponsorGrid";
            this.SponsorGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.SponsorGrid.RowHeadersWidth = 50;
            this.SponsorGrid.Size = new System.Drawing.Size(1035, 522);
            this.SponsorGrid.TabIndex = 0;
            this.SponsorGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SponsorGrid_CellContentClick);
            // 
            // Checkbox
            // 
            this.Checkbox.HeaderText = "Include Sponsor";
            this.Checkbox.Name = "Checkbox";
            this.Checkbox.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Checkbox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // SponsorName
            // 
            this.SponsorName.HeaderText = "Sponsor";
            this.SponsorName.Name = "SponsorName";
            // 
            // bunifuFlatButton1
            // 
            this.bunifuFlatButton1.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(245)))));
            this.bunifuFlatButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(245)))));
            this.bunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton1.BorderRadius = 4;
            this.bunifuFlatButton1.ButtonText = "SAVE";
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
            this.bunifuFlatButton1.Location = new System.Drawing.Point(393, 616);
            this.bunifuFlatButton1.Margin = new System.Windows.Forms.Padding(4);
            this.bunifuFlatButton1.Name = "bunifuFlatButton1";
            this.bunifuFlatButton1.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(245)))));
            this.bunifuFlatButton1.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(217)))));
            this.bunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton1.selected = false;
            this.bunifuFlatButton1.Size = new System.Drawing.Size(344, 52);
            this.bunifuFlatButton1.TabIndex = 1;
            this.bunifuFlatButton1.Text = "SAVE";
            this.bunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuFlatButton1.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton1.TextFont = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton1.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // Retry
            // 
            this.Retry.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(245)))));
            this.Retry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(245)))));
            this.Retry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Retry.BorderRadius = 4;
            this.Retry.ButtonText = "ADD NEW EVENT";
            this.Retry.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Retry.DisabledColor = System.Drawing.Color.Gray;
            this.Retry.Iconcolor = System.Drawing.Color.Transparent;
            this.Retry.Iconimage = null;
            this.Retry.Iconimage_right = null;
            this.Retry.Iconimage_right_Selected = null;
            this.Retry.Iconimage_Selected = null;
            this.Retry.IconMarginLeft = 0;
            this.Retry.IconMarginRight = 0;
            this.Retry.IconRightVisible = true;
            this.Retry.IconRightZoom = 0D;
            this.Retry.IconVisible = true;
            this.Retry.IconZoom = 90D;
            this.Retry.IsTab = false;
            this.Retry.Location = new System.Drawing.Point(372, 295);
            this.Retry.Margin = new System.Windows.Forms.Padding(4);
            this.Retry.Name = "Retry";
            this.Retry.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(245)))));
            this.Retry.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(217)))));
            this.Retry.OnHoverTextColor = System.Drawing.Color.White;
            this.Retry.selected = false;
            this.Retry.Size = new System.Drawing.Size(344, 52);
            this.Retry.TabIndex = 2;
            this.Retry.Text = "ADD NEW EVENT";
            this.Retry.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Retry.Textcolor = System.Drawing.Color.White;
            this.Retry.TextFont = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Retry.Visible = false;
            this.Retry.Click += new System.EventHandler(this.Retry_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Retry);
            this.panel1.Controls.Add(this.bunifuFlatButton1);
            this.panel1.Controls.Add(this.SponsorGrid);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1130, 702);
            this.panel1.TabIndex = 3;
            // 
            // SponsorsHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(241)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.panel1);
            this.Name = "SponsorsHelp";
            this.Size = new System.Drawing.Size(1130, 702);
            ((System.ComponentModel.ISupportInitialize)(this.SponsorGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCustomDataGrid SponsorGrid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Checkbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn SponsorName;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton1;
        private Bunifu.Framework.UI.BunifuFlatButton Retry;
        private System.Windows.Forms.Panel panel1;
    }
}
