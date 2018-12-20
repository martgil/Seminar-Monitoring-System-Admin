namespace Capstone.QR
{
    partial class UserChecker
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
            this.PasswordVerify = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PasswordVerify
            // 
            this.PasswordVerify.BorderColorFocused = System.Drawing.Color.SeaGreen;
            this.PasswordVerify.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PasswordVerify.BorderColorMouseHover = System.Drawing.Color.SeaGreen;
            this.PasswordVerify.BorderThickness = 3;
            this.PasswordVerify.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PasswordVerify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.PasswordVerify.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PasswordVerify.isPassword = true;
            this.PasswordVerify.Location = new System.Drawing.Point(13, 32);
            this.PasswordVerify.Margin = new System.Windows.Forms.Padding(4);
            this.PasswordVerify.Name = "PasswordVerify";
            this.PasswordVerify.Size = new System.Drawing.Size(392, 39);
            this.PasswordVerify.TabIndex = 0;
            this.PasswordVerify.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PasswordVerify.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PasswordVerify_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label1.Location = new System.Drawing.Point(48, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(325, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Please enter your recently entered administrative password";
            // 
            // UserChecker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 77);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PasswordVerify);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UserChecker";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check User Validity";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuMetroTextbox PasswordVerify;
        private System.Windows.Forms.Label label1;
    }
}