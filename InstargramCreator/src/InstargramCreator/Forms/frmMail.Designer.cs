namespace InstargramCreator
{
    partial class frmMail
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

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMail));
            this.label1 = new System.Windows.Forms.Label();
            this.txtIMap = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPortEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOkMail = new System.Windows.Forms.Button();
            this.btnCancelMail = new System.Windows.Forms.Button();
            this.btnOpenmail = new System.Windows.Forms.Button();
            this.txtEmaifile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCatch = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(86, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Email SETTING";
            // 
            // txtIMap
            // 
            this.txtIMap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtIMap.Location = new System.Drawing.Point(108, 95);
            this.txtIMap.Name = "txtIMap";
            this.txtIMap.Size = new System.Drawing.Size(150, 23);
            this.txtIMap.TabIndex = 6;
            this.txtIMap.Text = "outlook.office355.com";
            this.txtIMap.TextChanged += new System.EventHandler(this.txtIMap_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "IMAP Server :";
            // 
            // txtPortEmail
            // 
            this.txtPortEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtPortEmail.Location = new System.Drawing.Point(108, 147);
            this.txtPortEmail.Name = "txtPortEmail";
            this.txtPortEmail.Size = new System.Drawing.Size(85, 23);
            this.txtPortEmail.TabIndex = 8;
            this.txtPortEmail.Text = "113";
            this.txtPortEmail.TextChanged += new System.EventHandler(this.txtPortEmail_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Port :";
            // 
            // btnOkMail
            // 
            this.btnOkMail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnOkMail.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOkMail.Location = new System.Drawing.Point(143, 329);
            this.btnOkMail.Name = "btnOkMail";
            this.btnOkMail.Size = new System.Drawing.Size(75, 23);
            this.btnOkMail.TabIndex = 10;
            this.btnOkMail.Text = "OK";
            this.btnOkMail.UseVisualStyleBackColor = false;
            this.btnOkMail.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancelMail
            // 
            this.btnCancelMail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnCancelMail.Location = new System.Drawing.Point(241, 329);
            this.btnCancelMail.Name = "btnCancelMail";
            this.btnCancelMail.Size = new System.Drawing.Size(75, 23);
            this.btnCancelMail.TabIndex = 11;
            this.btnCancelMail.Text = "Cancel";
            this.btnCancelMail.UseVisualStyleBackColor = false;
            this.btnCancelMail.Click += new System.EventHandler(this.btnCancelMail_Click);
            // 
            // btnOpenmail
            // 
            this.btnOpenmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnOpenmail.Location = new System.Drawing.Point(259, 195);
            this.btnOpenmail.Name = "btnOpenmail";
            this.btnOpenmail.Size = new System.Drawing.Size(57, 23);
            this.btnOpenmail.TabIndex = 12;
            this.btnOpenmail.Text = "Open";
            this.btnOpenmail.UseVisualStyleBackColor = false;
            this.btnOpenmail.Click += new System.EventHandler(this.btnOpenmail_Click);
            // 
            // txtEmaifile
            // 
            this.txtEmaifile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtEmaifile.Location = new System.Drawing.Point(108, 195);
            this.txtEmaifile.Name = "txtEmaifile";
            this.txtEmaifile.Size = new System.Drawing.Size(150, 23);
            this.txtEmaifile.TabIndex = 13;
            this.txtEmaifile.TextChanged += new System.EventHandler(this.txtEmaifile_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = " Email File :";
            // 
            // cbCatch
            // 
            this.cbCatch.AutoSize = true;
            this.cbCatch.Location = new System.Drawing.Point(9, 250);
            this.cbCatch.Name = "cbCatch";
            this.cbCatch.Size = new System.Drawing.Size(106, 19);
            this.cbCatch.TabIndex = 15;
            this.cbCatch.Text = "Catch-all Email";
            this.cbCatch.UseVisualStyleBackColor = true;
            this.cbCatch.CheckedChanged += new System.EventHandler(this.cbCatch_CheckedChanged);
            // 
            // frmMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(328, 364);
            this.Controls.Add(this.cbCatch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEmaifile);
            this.Controls.Add(this.btnOpenmail);
            this.Controls.Add(this.btnCancelMail);
            this.Controls.Add(this.btnOkMail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPortEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIMap);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMail";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "InstargramCreator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        //private void InitializeComponent()
        //{
        //    this.components = new System.ComponentModel.Container();
        //    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        //    this.ClientSize = new System.Drawing.Size(800, 450);
        //    this.Text = "frmMail";
        //}

        #endregion
        private Label label1;
        private TextBox txtIMap;
        private Label label2;
        private TextBox txtPortEmail;
        private Label label3;
        private Button btnOkMail;
        private Button btnCancelMail;
        private Button btnOpenmail;
        private TextBox txtEmaifile;
        private Label label4;
        private CheckBox cbCatch;
    }
}