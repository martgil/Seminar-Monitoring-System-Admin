namespace Capstone.QR.Personnel
{
    partial class uAssign
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
            this.AssignBtn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.PersonnelLister = new System.Windows.Forms.ComboBox();
            this.EventLister = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // AssignBtn
            // 
            this.AssignBtn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.AssignBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.AssignBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AssignBtn.BorderRadius = 3;
            this.AssignBtn.ButtonText = "ASSIGN NOW";
            this.AssignBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AssignBtn.DisabledColor = System.Drawing.Color.Gray;
            this.AssignBtn.Iconcolor = System.Drawing.Color.Transparent;
            this.AssignBtn.Iconimage = null;
            this.AssignBtn.Iconimage_right = null;
            this.AssignBtn.Iconimage_right_Selected = null;
            this.AssignBtn.Iconimage_Selected = null;
            this.AssignBtn.IconMarginLeft = 0;
            this.AssignBtn.IconMarginRight = 0;
            this.AssignBtn.IconRightVisible = true;
            this.AssignBtn.IconRightZoom = 0D;
            this.AssignBtn.IconVisible = true;
            this.AssignBtn.IconZoom = 90D;
            this.AssignBtn.IsTab = false;
            this.AssignBtn.Location = new System.Drawing.Point(118, 567);
            this.AssignBtn.Name = "AssignBtn";
            this.AssignBtn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.AssignBtn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.AssignBtn.OnHoverTextColor = System.Drawing.Color.White;
            this.AssignBtn.selected = false;
            this.AssignBtn.Size = new System.Drawing.Size(839, 48);
            this.AssignBtn.TabIndex = 5;
            this.AssignBtn.Text = "ASSIGN NOW";
            this.AssignBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AssignBtn.Textcolor = System.Drawing.Color.White;
            this.AssignBtn.TextFont = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AssignBtn.Click += new System.EventHandler(this.AssignBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label3.Location = new System.Drawing.Point(263, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(245, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Choose personnel to assign";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label4.Location = new System.Drawing.Point(225, 362);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(280, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "Which event you want to assign ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.label7.Location = new System.Drawing.Point(107, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(879, 25);
            this.label7.TabIndex = 14;
            this.label7.Text = "Please Select an event where to assign a personnel then choose a which personnel " +
    "you want.";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.label8.Location = new System.Drawing.Point(117, 530);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(821, 18);
            this.label8.TabIndex = 15;
            this.label8.Text = "You can assign a personnel to different event. Furthermore, the personnel can han" +
    "dle one or more event at the same time.";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PersonnelLister
            // 
            this.PersonnelLister.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.PersonnelLister.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.PersonnelLister.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PersonnelLister.FormattingEnabled = true;
            this.PersonnelLister.Location = new System.Drawing.Point(527, 255);
            this.PersonnelLister.Name = "PersonnelLister";
            this.PersonnelLister.Size = new System.Drawing.Size(298, 31);
            this.PersonnelLister.TabIndex = 16;
            // 
            // EventLister
            // 
            this.EventLister.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.EventLister.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.EventLister.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EventLister.FormattingEnabled = true;
            this.EventLister.Location = new System.Drawing.Point(527, 359);
            this.EventLister.Name = "EventLister";
            this.EventLister.Size = new System.Drawing.Size(298, 31);
            this.EventLister.TabIndex = 17;
            // 
            // uAssign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(241)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.EventLister);
            this.Controls.Add(this.PersonnelLister);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AssignBtn);
            this.Name = "uAssign";
            this.Size = new System.Drawing.Size(1130, 702);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.Framework.UI.BunifuFlatButton AssignBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox PersonnelLister;
        private System.Windows.Forms.ComboBox EventLister;
    }
}
