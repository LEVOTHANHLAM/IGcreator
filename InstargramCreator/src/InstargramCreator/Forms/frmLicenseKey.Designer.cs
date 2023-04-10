namespace InstargramCreator
{
    partial class frmLicenseKey
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLicenseKey));
            this.txtLicenkey = new System.Windows.Forms.TextBox();
            this.btnLicenkey = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnUpDate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtLicenkey
            // 
            this.txtLicenkey.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtLicenkey.Location = new System.Drawing.Point(111, 93);
            this.txtLicenkey.Name = "txtLicenkey";
            this.txtLicenkey.Size = new System.Drawing.Size(201, 23);
            this.txtLicenkey.TabIndex = 0;
            this.txtLicenkey.Text = "d05ff668-7d5c-4280-9ff4-0d9c08989059";
            this.txtLicenkey.TextChanged += new System.EventHandler(this.txtLicenkey_TextChanged);
            // 
            // btnLicenkey
            // 
            this.btnLicenkey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnLicenkey.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLicenkey.Location = new System.Drawing.Point(153, 178);
            this.btnLicenkey.Name = "btnLicenkey";
            this.btnLicenkey.Size = new System.Drawing.Size(72, 34);
            this.btnLicenkey.TabIndex = 1;
            this.btnLicenkey.Text = "OK";
            this.btnLicenkey.UseVisualStyleBackColor = false;
            this.btnLicenkey.Click += new System.EventHandler(this.btnLicenkey_Click);
            // 
            // txtPath
            // 
            this.txtPath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtPath.Location = new System.Drawing.Point(111, 138);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(201, 23);
            this.txtPath.TabIndex = 2;
            this.txtPath.TextChanged += new System.EventHandler(this.txtPath_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(6, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "License Key:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(6, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "LDPlayer Path:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(78, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(256, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "IT\'s NICE TO MEET YOU!";
            // 
            // btnUpDate
            // 
            this.btnUpDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnUpDate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpDate.Location = new System.Drawing.Point(153, 178);
            this.btnUpDate.Name = "btnUpDate";
            this.btnUpDate.Size = new System.Drawing.Size(72, 34);
            this.btnUpDate.TabIndex = 6;
            this.btnUpDate.Text = "Update";
            this.btnUpDate.UseVisualStyleBackColor = false;
            this.btnUpDate.Click += new System.EventHandler(this.btnUpDate_Click);
            // 
            // frmLicenseKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(360, 232);
            this.Controls.Add(this.btnUpDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnLicenkey);
            this.Controls.Add(this.txtLicenkey);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLicenseKey";
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmLicenseKey_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private TextBox txtLicenkey;
        private Button btnLicenkey;
        private TextBox txtPath;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnUpDate;
    }
}