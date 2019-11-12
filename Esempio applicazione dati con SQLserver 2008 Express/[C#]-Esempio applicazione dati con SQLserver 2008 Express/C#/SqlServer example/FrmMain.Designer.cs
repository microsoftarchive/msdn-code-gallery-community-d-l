namespace SqlServer_example
{
    partial class FrmMain
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblSurName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtSurName = new System.Windows.Forms.TextBox();
            this.dgvExample = new System.Windows.Forms.DataGridView();
            this.lblAge = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.btnFindLinq = new System.Windows.Forms.Button();
            this.cbxLinq = new System.Windows.Forms.ComboBox();
            this.btnFindTypeData = new System.Windows.Forms.Button();
            this.cbxTypeData = new System.Windows.Forms.ComboBox();
            this.exampleDataSet = new SqlServer_example.ExampleDataSet();
            this.tABELLA1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tABELLA1TableAdapter = new SqlServer_example.ExampleDataSetTableAdapters.TABELLA1TableAdapter();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SURNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AGE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblFind = new System.Windows.Forms.Label();
            this.lblCustom = new System.Windows.Forms.Label();
            this.lblLinq = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExample)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exampleDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tABELLA1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(14, 24);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 0;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(95, 24);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(176, 24);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(14, 91);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Name";
            // 
            // lblSurName
            // 
            this.lblSurName.AutoSize = true;
            this.lblSurName.Location = new System.Drawing.Point(14, 120);
            this.lblSurName.Name = "lblSurName";
            this.lblSurName.Size = new System.Drawing.Size(51, 13);
            this.lblSurName.TabIndex = 4;
            this.lblSurName.Text = "SurName";
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(95, 91);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 6;
            // 
            // txtSurName
            // 
            this.txtSurName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSurName.Location = new System.Drawing.Point(95, 117);
            this.txtSurName.Name = "txtSurName";
            this.txtSurName.Size = new System.Drawing.Size(100, 20);
            this.txtSurName.TabIndex = 7;
            // 
            // dgvExample
            // 
            this.dgvExample.AutoGenerateColumns = false;
            this.dgvExample.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExample.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.NAME,
            this.SURNAME,
            this.AGE});
            this.dgvExample.DataSource = this.tABELLA1BindingSource;
            this.dgvExample.Location = new System.Drawing.Point(479, 13);
            this.dgvExample.Name = "dgvExample";
            this.dgvExample.ReadOnly = true;
            this.dgvExample.Size = new System.Drawing.Size(446, 412);
            this.dgvExample.TabIndex = 10;
            this.dgvExample.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExample_RowEnter);
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(14, 146);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(26, 13);
            this.lblAge.TabIndex = 5;
            this.lblAge.Text = "Age";
            // 
            // txtAge
            // 
            this.txtAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAge.Location = new System.Drawing.Point(95, 143);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(100, 20);
            this.txtAge.TabIndex = 8;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(392, 402);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox1.Controls.Add(this.txtSurName);
            this.groupBox1.Controls.Add(this.btnInsert);
            this.groupBox1.Controls.Add(this.txtAge);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.lblAge);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.lblSurName);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Location = new System.Drawing.Point(16, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(457, 179);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "INSERT DELETE UPDATE";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox2.Controls.Add(this.lblLinq);
            this.groupBox2.Controls.Add(this.lblCustom);
            this.groupBox2.Controls.Add(this.lblFind);
            this.groupBox2.Controls.Add(this.txtFind);
            this.groupBox2.Controls.Add(this.btnFindLinq);
            this.groupBox2.Controls.Add(this.cbxLinq);
            this.groupBox2.Controls.Add(this.btnFindTypeData);
            this.groupBox2.Controls.Add(this.cbxTypeData);
            this.groupBox2.Location = new System.Drawing.Point(16, 198);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(457, 179);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SEARCH TYPE";
            // 
            // txtFind
            // 
            this.txtFind.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFind.Location = new System.Drawing.Point(176, 52);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(156, 20);
            this.txtFind.TabIndex = 16;
            // 
            // btnFindLinq
            // 
            this.btnFindLinq.Location = new System.Drawing.Point(376, 110);
            this.btnFindLinq.Name = "btnFindLinq";
            this.btnFindLinq.Size = new System.Drawing.Size(75, 23);
            this.btnFindLinq.TabIndex = 15;
            this.btnFindLinq.Text = "Find Linq";
            this.btnFindLinq.UseVisualStyleBackColor = true;
            this.btnFindLinq.Click += new System.EventHandler(this.btnFindLinq_Click);
            // 
            // cbxLinq
            // 
            this.cbxLinq.BackColor = System.Drawing.Color.White;
            this.cbxLinq.FormattingEnabled = true;
            this.cbxLinq.Items.AddRange(new object[] {
            "ASCENDING NAME",
            "DESCENDING NAME",
            "ASCENDING SURNAME",
            "DESCENDING SURNAME",
            "ASCENDING AGE",
            "DESCENDING AGE"});
            this.cbxLinq.Location = new System.Drawing.Point(14, 112);
            this.cbxLinq.Name = "cbxLinq";
            this.cbxLinq.Size = new System.Drawing.Size(156, 21);
            this.cbxLinq.TabIndex = 14;
            this.cbxLinq.SelectedIndexChanged += new System.EventHandler(this.cbxLinq_SelectedIndexChanged);
            // 
            // btnFindTypeData
            // 
            this.btnFindTypeData.Location = new System.Drawing.Point(376, 50);
            this.btnFindTypeData.Name = "btnFindTypeData";
            this.btnFindTypeData.Size = new System.Drawing.Size(75, 23);
            this.btnFindTypeData.TabIndex = 13;
            this.btnFindTypeData.Text = "Find Data";
            this.btnFindTypeData.UseVisualStyleBackColor = true;
            this.btnFindTypeData.Click += new System.EventHandler(this.btnFindTypeData_Click);
            // 
            // cbxTypeData
            // 
            this.cbxTypeData.BackColor = System.Drawing.Color.White;
            this.cbxTypeData.FormattingEnabled = true;
            this.cbxTypeData.Items.AddRange(new object[] {
            "NAME",
            "SURNAME",
            "AGE"});
            this.cbxTypeData.Location = new System.Drawing.Point(14, 52);
            this.cbxTypeData.Name = "cbxTypeData";
            this.cbxTypeData.Size = new System.Drawing.Size(156, 21);
            this.cbxTypeData.TabIndex = 0;
            this.cbxTypeData.SelectedIndexChanged += new System.EventHandler(this.cbxTypeData_SelectedIndexChanged);
            // 
            // exampleDataSet
            // 
            this.exampleDataSet.DataSetName = "ExampleDataSet";
            this.exampleDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tABELLA1BindingSource
            // 
            this.tABELLA1BindingSource.DataMember = "TABELLA1";
            this.tABELLA1BindingSource.DataSource = this.exampleDataSet;
            // 
            // tABELLA1TableAdapter
            // 
            this.tABELLA1TableAdapter.ClearBeforeFill = true;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // NAME
            // 
            this.NAME.DataPropertyName = "NOME";
            this.NAME.HeaderText = "NOME";
            this.NAME.Name = "NAME";
            this.NAME.ReadOnly = true;
            // 
            // SURNAME
            // 
            this.SURNAME.DataPropertyName = "COGNOME";
            this.SURNAME.HeaderText = "COGNOME";
            this.SURNAME.Name = "SURNAME";
            this.SURNAME.ReadOnly = true;
            // 
            // AGE
            // 
            this.AGE.DataPropertyName = "AGE";
            this.AGE.HeaderText = "AGE";
            this.AGE.Name = "AGE";
            this.AGE.ReadOnly = true;
            // 
            // lblFind
            // 
            this.lblFind.AutoSize = true;
            this.lblFind.Location = new System.Drawing.Point(11, 151);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(91, 13);
            this.lblFind.TabIndex = 17;
            this.lblFind.Text = "RESULT QUERY";
            // 
            // lblCustom
            // 
            this.lblCustom.AutoSize = true;
            this.lblCustom.Location = new System.Drawing.Point(151, 27);
            this.lblCustom.Name = "lblCustom";
            this.lblCustom.Size = new System.Drawing.Size(53, 13);
            this.lblCustom.TabIndex = 18;
            this.lblCustom.Text = "CUSTOM";
            // 
            // lblLinq
            // 
            this.lblLinq.AutoSize = true;
            this.lblLinq.Location = new System.Drawing.Point(151, 87);
            this.lblLinq.Name = "lblLinq";
            this.lblLinq.Size = new System.Drawing.Size(73, 13);
            this.lblLinq.TabIndex = 19;
            this.lblLinq.Text = "LINQ QUERY";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(937, 437);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dgvExample);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SqlServerExample";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExample)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exampleDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tABELLA1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSurName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSurName;
        private System.Windows.Forms.DataGridView dgvExample;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnFindLinq;
        private System.Windows.Forms.ComboBox cbxLinq;
        private System.Windows.Forms.Button btnFindTypeData;
        private System.Windows.Forms.ComboBox cbxTypeData;
        private System.Windows.Forms.TextBox txtFind;
        private ExampleDataSet exampleDataSet;
        private System.Windows.Forms.BindingSource tABELLA1BindingSource;
        private ExampleDataSetTableAdapters.TABELLA1TableAdapter tABELLA1TableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn SURNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn AGE;
        private System.Windows.Forms.Label lblFind;
        private System.Windows.Forms.Label lblLinq;
        private System.Windows.Forms.Label lblCustom;
    }
}

