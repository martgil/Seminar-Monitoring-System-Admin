namespace Capstone.QR
{
    partial class FormChangePassword
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChangePassword));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.oldPass = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.newPass = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.confirmPass = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.ChangePassBtn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Old Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Confirm Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "New Password";
            // 
            // oldPass
            // 
            this.oldPass.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(45)))), ((int)(((byte)(168)))));
            this.oldPass.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.oldPass.BorderColorMouseHover = System.Drawing.Color.BlueViolet;
            this.oldPass.BorderThickness = 3;
            this.oldPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.oldPass.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.oldPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.oldPass.isPassword = true;
            this.oldPass.Location = new System.Drawing.Point(153, 22);
            this.oldPass.Margin = new System.Windows.Forms.Padding(4);
            this.oldPass.Name = "oldPass";
            this.oldPass.Size = new System.Drawing.Size(208, 31);
            this.oldPass.TabIndex = 3;
            this.oldPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // newPass
            // 
            this.newPass.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(45)))), ((int)(((byte)(168)))));
            this.newPass.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.newPass.BorderColorMouseHover = System.Drawing.Color.BlueViolet;
            this.newPass.BorderThickness = 3;
            this.newPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.newPass.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.newPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.newPass.isPassword = true;
            this.newPass.Location = new System.Drawing.Point(153, 61);
            this.newPass.Margin = new System.Windows.Forms.Padding(4);
            this.newPass.Name = "newPass";
            this.newPass.Size = new System.Drawing.Size(208, 31);
            this.newPass.TabIndex = 4;
            this.newPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // confirmPass
            // 
            this.confirmPass.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(45)))), ((int)(((byte)(168)))));
            this.confirmPass.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.confirmPass.BorderColorMouseHover = System.Drawing.Color.BlueViolet;
            this.confirmPass.BorderThickness = 3;
            this.confirmPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.confirmPass.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.confirmPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.confirmPass.isPassword = true;
            this.confirmPass.Location = new System.Drawing.Point(153, 100);
            this.confirmPass.Margin = new System.Windows.Forms.Padding(4);
            this.confirmPass.Name = "confirmPass";
            this.confirmPass.Size = new System.Drawing.Size(208, 31);
            this.confirmPass.TabIndex = 5;
            this.confirmPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // ChangePassBtn
            // 
            this.ChangePassBtn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.ChangePassBtn.BackColor = System.Drawing.Color.SeaGreen;
            this.ChangePassBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ChangePassBtn.BorderRadius = 0;
            this.ChangePassBtn.ButtonText = "Change Password";
            this.ChangePassBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChangePassBtn.DisabledColor = System.Drawing.Color.Gray;
            this.ChangePassBtn.Iconcolor = System.Drawing.Color.Transparent;
            this.ChangePassBtn.Iconimage = null;
            this.ChangePassBtn.Iconimage_right = null;
            this.ChangePassBtn.Iconimage_right_Selected = null;
            this.ChangePassBtn.Iconimage_Selected = null;
            this.ChangePassBtn.IconMarginLeft = 0;
            this.ChangePassBtn.IconMarginRight = 0;
            this.ChangePassBtn.IconRightVisible = true;
            this.ChangePassBtn.IconRightZoom = 0D;
            this.ChangePassBtn.IconVisible = true;
            this.ChangePassBtn.IconZoom = 90D;
            this.ChangePassBtn.IsTab = false;
            this.ChangePassBtn.Location = new System.Drawing.Point(12, 153);
            this.ChangePassBtn.Name = "ChangePassBtn";
            this.ChangePassBtn.Normalcolor = System.Drawing.Color.SeaGreen;
            this.ChangePassBtn.OnHovercolor = System.Drawing.Color.SeaGreen;
            this.ChangePassBtn.OnHoverTextColor = System.Drawing.Color.White;
            this.ChangePassBtn.selected = false;
            this.ChangePassBtn.Size = new System.Drawing.Size(349, 42);
            this.ChangePassBtn.TabIndex = 6;
            this.ChangePassBtn.Text = "Change Password";
            this.ChangePassBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChangePassBtn.Textcolor = System.Drawing.Color.White;
            this.ChangePassBtn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangePassBtn.Click += new System.EventHandler(this.ChangePassBtn_Click);
            // 
            // FormChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 218);
            this.Controls.Add(this.ChangePassBtn);
            this.Controls.Add(this.confirmPass);
            this.Controls.Add(this.newPass);
            this.Controls.Add(this.oldPass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormChangePassword";
            this.Text = "Change Administrator Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuMetroTextbox oldPass;
        private Bunifu.Framework.UI.BunifuMetroTextbox newPass;
        private Bunifu.Framework.UI.BunifuMetroTextbox confirmPass;
        private Bunifu.Framework.UI.BunifuFlatButton ChangePassBtn;
    }
}