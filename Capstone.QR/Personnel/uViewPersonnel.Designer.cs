namespace Capstone.QR.Personnel
{
    partial class uViewPersonnel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TablePersonnel = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.eventid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.givenName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.TablePersonnel)).BeginInit();
            this.SuspendLayout();
            // 
            // TablePersonnel
            // 
            this.TablePersonnel.AllowUserToAddRows = false;
            this.TablePersonnel.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TablePersonnel.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.TablePersonnel.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.TablePersonnel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TablePersonnel.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TablePersonnel.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.TablePersonnel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablePersonnel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.eventid,
            this.userid,
            this.givenName});
            this.TablePersonnel.DoubleBuffered = true;
            this.TablePersonnel.EnableHeadersVisualStyles = false;
            this.TablePersonnel.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.TablePersonnel.HeaderForeColor = System.Drawing.Color.White;
            this.TablePersonnel.Location = new System.Drawing.Point(0, 58);
            this.TablePersonnel.Name = "TablePersonnel";
            this.TablePersonnel.ReadOnly = true;
            this.TablePersonnel.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.TablePersonnel.Size = new System.Drawing.Size(1130, 702);
            this.TablePersonnel.TabIndex = 0;
            // 
            // eventid
            // 
            this.eventid.HeaderText = "Username";
            this.eventid.Name = "eventid";
            this.eventid.ReadOnly = true;
            // 
            // userid
            // 
            this.userid.HeaderText = "Fullname";
            this.userid.Name = "userid";
            this.userid.ReadOnly = true;
            // 
            // givenName
            // 
            this.givenName.HeaderText = "Assigned Event";
            this.givenName.Name = "givenName";
            this.givenName.ReadOnly = true;
            // 
            // uViewPersonnel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TablePersonnel);
            this.Name = "uViewPersonnel";
            this.Size = new System.Drawing.Size(1130, 702);
            ((System.ComponentModel.ISupportInitialize)(this.TablePersonnel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCustomDataGrid TablePersonnel;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventid;
        private System.Windows.Forms.DataGridViewTextBoxColumn userid;
        private System.Windows.Forms.DataGridViewTextBoxColumn givenName;
    }
}
