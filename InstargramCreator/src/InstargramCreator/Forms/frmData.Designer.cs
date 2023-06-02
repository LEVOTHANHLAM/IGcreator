namespace InstargramCreator
{
    partial class frmData
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmData));
            btnexit = new Button();
            btnDeleteAll = new Button();
            btnExport = new Button();
            btnDelete = new Button();
            btnRefesh = new Button();
            dataGridView1 = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            accountsBindingSource = new BindingSource(components);
            ChooseCol = new DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)accountsBindingSource).BeginInit();
            SuspendLayout();
            // 
            // btnexit
            // 
            btnexit.BackColor = Color.FromArgb(50, 50, 50);
            btnexit.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnexit.ForeColor = SystemColors.ButtonHighlight;
            btnexit.Location = new Point(859, 12);
            btnexit.Name = "btnexit";
            btnexit.Size = new Size(106, 32);
            btnexit.TabIndex = 1;
            btnexit.Text = "Exit";
            btnexit.UseVisualStyleBackColor = false;
            btnexit.Click += btnexit_Click;
            // 
            // btnDeleteAll
            // 
            btnDeleteAll.BackColor = Color.FromArgb(50, 50, 50);
            btnDeleteAll.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnDeleteAll.ForeColor = SystemColors.ButtonHighlight;
            btnDeleteAll.Location = new Point(744, 12);
            btnDeleteAll.Name = "btnDeleteAll";
            btnDeleteAll.Size = new Size(109, 31);
            btnDeleteAll.TabIndex = 2;
            btnDeleteAll.Text = "Delete All ";
            btnDeleteAll.UseVisualStyleBackColor = false;
            btnDeleteAll.Click += btnDeleteAll_Click;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.FromArgb(50, 50, 50);
            btnExport.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnExport.ForeColor = SystemColors.ButtonHighlight;
            btnExport.Location = new Point(519, 12);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(106, 31);
            btnExport.TabIndex = 3;
            btnExport.Text = "Export File";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(50, 50, 50);
            btnDelete.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnDelete.ForeColor = SystemColors.ButtonHighlight;
            btnDelete.Location = new Point(633, 12);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(106, 31);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete Items";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnRefesh
            // 
            btnRefesh.BackColor = Color.FromArgb(50, 50, 50);
            btnRefesh.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnRefesh.ForeColor = SystemColors.ButtonHighlight;
            btnRefesh.Location = new Point(407, 12);
            btnRefesh.Name = "btnRefesh";
            btnRefesh.Size = new Size(106, 31);
            btnRefesh.TabIndex = 6;
            btnRefesh.Text = "Refresh";
            btnRefesh.UseVisualStyleBackColor = false;
            btnRefesh.Click += btnRefesh_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewCheckBoxColumn1, emailDataGridViewTextBoxColumn, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6 });
            dataGridView1.DataSource = accountsBindingSource;
            dataGridView1.GridColor = SystemColors.ActiveCaptionText;
            dataGridView1.Location = new Point(1, 50);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(964, 669);
            dataGridView1.StandardTab = true;
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            dataGridViewTextBoxColumn1.HeaderText = "Id";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            dataGridViewCheckBoxColumn1.HeaderText = "Select";
            dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn.HeaderText = "Email";
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "Password";
            dataGridViewTextBoxColumn2.HeaderText = "Password";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.DataPropertyName = "UserName";
            dataGridViewTextBoxColumn3.HeaderText = "UserName";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.DataPropertyName = "Proxy";
            dataGridViewTextBoxColumn4.HeaderText = "Proxy";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.DataPropertyName = "FullName";
            dataGridViewTextBoxColumn5.HeaderText = "FullName";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.DataPropertyName = "CreateDate";
            dataGridViewTextBoxColumn6.HeaderText = "CreateDate";
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // accountsBindingSource
            // 
            accountsBindingSource.DataSource = typeof(Entities.Accounts);
            // 
            // ChooseCol
            // 
            ChooseCol.Name = "ChooseCol";
            // 
            // frmData
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(50, 50, 50);
            ClientSize = new Size(968, 709);
            Controls.Add(btnRefesh);
            Controls.Add(btnDelete);
            Controls.Add(btnExport);
            Controls.Add(btnDeleteAll);
            Controls.Add(btnexit);
            Controls.Add(dataGridView1);
            ForeColor = SystemColors.ActiveCaptionText;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmData";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "InstagramCreator";
            Load += frmData_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)accountsBindingSource).EndInit();
            ResumeLayout(false);
        }


        #endregion
        //private ColumnHeader columnHeader1;
        private Button btnexit;
        private Button btnDeleteAll;
        private Button btnExport;
        private Button btnDelete;
        private Button btnRefesh;
        private DataGridView dataGridView1;
        private DataGridViewCheckBoxColumn Select;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn passwordDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn proxyDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn statusDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn hasAvatarDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn hasBioDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn createDateDataGridViewTextBoxColumn;
        // private Label label1;
        //private DataGridViewCheckBoxColumn statusDataGridViewTextBoxColumn;
        //private DataGridViewCheckBoxColumn hasAvatarDataGridViewTextBoxColumn;
        //private DataGridViewCheckBoxColumn hasBioDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn ChooseCol;
        private BindingSource accountsBindingSource;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}