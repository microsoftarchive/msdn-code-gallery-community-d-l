namespace Rubrica
{
    partial class FrmRubrica
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
            this.Label7 = new System.Windows.Forms.Label();
            this.txtPosizioneRubricaAttuale = new System.Windows.Forms.TextBox();
            this.txtCognomeAttuale = new System.Windows.Forms.TextBox();
            this.txtNomeAttuale = new System.Windows.Forms.TextBox();
            this.txtTelefonoAttuale = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.txtPosizioneRubrica = new System.Windows.Forms.TextBox();
            this.txtCognome = new System.Windows.Forms.TextBox();
            this.btnInserisci = new System.Windows.Forms.Button();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblCognome = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtEliminaPosizioneRubrica = new System.Windows.Forms.TextBox();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.btnModifica = new System.Windows.Forms.Button();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtEliminaNome = new System.Windows.Forms.TextBox();
            this.btnAggiorna = new System.Windows.Forms.Button();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.btnRicerca = new System.Windows.Forms.Button();
            this.cbTipoRicerca = new System.Windows.Forms.ComboBox();
            this.txtRicerca = new System.Windows.Forms.TextBox();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.dtgRubrica = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COGNOME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TELEFONO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POSIZIONE_RUBRICA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabellaRubricaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rubricaDataSet = new Rubrica.RubricaDataSet();
            this.EsciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.txtEliminaCognome = new System.Windows.Forms.TextBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.txtEliminaTelefono = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnElimina = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.tabellaRubricaTableAdapter = new Rubrica.RubricaDataSetTableAdapters.TabellaRubricaTableAdapter();
            this.GroupBox1.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRubrica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabellaRubricaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rubricaDataSet)).BeginInit();
            this.MenuStrip.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(6, 158);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(116, 13);
            this.Label7.TabIndex = 11;
            this.Label7.Text = "POSIZIONE RUBRICA";
            // 
            // txtPosizioneRubricaAttuale
            // 
            this.txtPosizioneRubricaAttuale.BackColor = System.Drawing.Color.White;
            this.txtPosizioneRubricaAttuale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPosizioneRubricaAttuale.Location = new System.Drawing.Point(128, 155);
            this.txtPosizioneRubricaAttuale.Name = "txtPosizioneRubricaAttuale";
            this.txtPosizioneRubricaAttuale.ReadOnly = true;
            this.txtPosizioneRubricaAttuale.Size = new System.Drawing.Size(100, 20);
            this.txtPosizioneRubricaAttuale.TabIndex = 10;
            // 
            // txtCognomeAttuale
            // 
            this.txtCognomeAttuale.BackColor = System.Drawing.Color.White;
            this.txtCognomeAttuale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCognomeAttuale.Location = new System.Drawing.Point(128, 75);
            this.txtCognomeAttuale.Name = "txtCognomeAttuale";
            this.txtCognomeAttuale.Size = new System.Drawing.Size(100, 20);
            this.txtCognomeAttuale.TabIndex = 2;
            // 
            // txtNomeAttuale
            // 
            this.txtNomeAttuale.BackColor = System.Drawing.Color.White;
            this.txtNomeAttuale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNomeAttuale.Location = new System.Drawing.Point(128, 33);
            this.txtNomeAttuale.Name = "txtNomeAttuale";
            this.txtNomeAttuale.Size = new System.Drawing.Size(100, 20);
            this.txtNomeAttuale.TabIndex = 1;
            // 
            // txtTelefonoAttuale
            // 
            this.txtTelefonoAttuale.BackColor = System.Drawing.Color.White;
            this.txtTelefonoAttuale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefonoAttuale.Location = new System.Drawing.Point(128, 116);
            this.txtTelefonoAttuale.Name = "txtTelefonoAttuale";
            this.txtTelefonoAttuale.Size = new System.Drawing.Size(100, 20);
            this.txtTelefonoAttuale.TabIndex = 3;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(6, 36);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(91, 13);
            this.Label4.TabIndex = 5;
            this.Label4.Text = "NOME ATTUALE";
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.GroupBox1.Controls.Add(this.Label8);
            this.GroupBox1.Controls.Add(this.txtPosizioneRubrica);
            this.GroupBox1.Controls.Add(this.txtCognome);
            this.GroupBox1.Controls.Add(this.btnInserisci);
            this.GroupBox1.Controls.Add(this.txtNome);
            this.GroupBox1.Controls.Add(this.txtTelefono);
            this.GroupBox1.Controls.Add(this.lblNome);
            this.GroupBox1.Controls.Add(this.lblTelefono);
            this.GroupBox1.Controls.Add(this.lblCognome);
            this.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GroupBox1.Location = new System.Drawing.Point(27, 53);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(258, 281);
            this.GroupBox1.TabIndex = 20;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "INSERIMENTO DATI";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(6, 158);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(116, 13);
            this.Label8.TabIndex = 12;
            this.Label8.Text = "POSIZIONE RUBRICA";
            // 
            // txtPosizioneRubrica
            // 
            this.txtPosizioneRubrica.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPosizioneRubrica.Location = new System.Drawing.Point(128, 155);
            this.txtPosizioneRubrica.Name = "txtPosizioneRubrica";
            this.txtPosizioneRubrica.Size = new System.Drawing.Size(100, 20);
            this.txtPosizioneRubrica.TabIndex = 8;
            // 
            // txtCognome
            // 
            this.txtCognome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCognome.Location = new System.Drawing.Point(128, 75);
            this.txtCognome.Name = "txtCognome";
            this.txtCognome.Size = new System.Drawing.Size(100, 20);
            this.txtCognome.TabIndex = 2;
            // 
            // btnInserisci
            // 
            this.btnInserisci.Location = new System.Drawing.Point(153, 237);
            this.btnInserisci.Name = "btnInserisci";
            this.btnInserisci.Size = new System.Drawing.Size(75, 23);
            this.btnInserisci.TabIndex = 0;
            this.btnInserisci.Text = "INSERISCI";
            this.btnInserisci.UseVisualStyleBackColor = true;
            this.btnInserisci.Click += new System.EventHandler(this.btnInserisci_Click);
            // 
            // txtNome
            // 
            this.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNome.Location = new System.Drawing.Point(128, 33);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(100, 20);
            this.txtNome.TabIndex = 1;
            // 
            // txtTelefono
            // 
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefono.Location = new System.Drawing.Point(128, 116);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(100, 20);
            this.txtTelefono.TabIndex = 3;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(6, 36);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(39, 13);
            this.lblNome.TabIndex = 5;
            this.lblNome.Text = "NOME";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(6, 119);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(64, 13);
            this.lblTelefono.TabIndex = 7;
            this.lblTelefono.Text = "TELEFONO";
            // 
            // lblCognome
            // 
            this.lblCognome.AutoSize = true;
            this.lblCognome.Location = new System.Drawing.Point(6, 78);
            this.lblCognome.Name = "lblCognome";
            this.lblCognome.Size = new System.Drawing.Size(62, 13);
            this.lblCognome.TabIndex = 6;
            this.lblCognome.Text = "COGNOME";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(6, 158);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(116, 13);
            this.Label9.TabIndex = 12;
            this.Label9.Text = "POSIZIONE RUBRICA";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(6, 119);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(116, 13);
            this.Label5.TabIndex = 7;
            this.Label5.Text = "TELEFONO ATTUALE";
            // 
            // txtEliminaPosizioneRubrica
            // 
            this.txtEliminaPosizioneRubrica.BackColor = System.Drawing.Color.White;
            this.txtEliminaPosizioneRubrica.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEliminaPosizioneRubrica.Location = new System.Drawing.Point(128, 155);
            this.txtEliminaPosizioneRubrica.Name = "txtEliminaPosizioneRubrica";
            this.txtEliminaPosizioneRubrica.ReadOnly = true;
            this.txtEliminaPosizioneRubrica.Size = new System.Drawing.Size(100, 20);
            this.txtEliminaPosizioneRubrica.TabIndex = 12;
            // 
            // GroupBox3
            // 
            this.GroupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.GroupBox3.Controls.Add(this.Label7);
            this.GroupBox3.Controls.Add(this.txtPosizioneRubricaAttuale);
            this.GroupBox3.Controls.Add(this.txtCognomeAttuale);
            this.GroupBox3.Controls.Add(this.txtNomeAttuale);
            this.GroupBox3.Controls.Add(this.txtTelefonoAttuale);
            this.GroupBox3.Controls.Add(this.Label4);
            this.GroupBox3.Controls.Add(this.Label5);
            this.GroupBox3.Controls.Add(this.btnModifica);
            this.GroupBox3.Controls.Add(this.Label6);
            this.GroupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GroupBox3.Location = new System.Drawing.Point(555, 53);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(258, 281);
            this.GroupBox3.TabIndex = 22;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "MODIFICA DATI";
            // 
            // btnModifica
            // 
            this.btnModifica.Location = new System.Drawing.Point(153, 237);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(75, 23);
            this.btnModifica.TabIndex = 9;
            this.btnModifica.Text = "MODIFICA";
            this.btnModifica.UseVisualStyleBackColor = true;
            this.btnModifica.Click += new System.EventHandler(this.btnModifica_Click);
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(6, 78);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(114, 13);
            this.Label6.TabIndex = 6;
            this.Label6.Text = "COGNOME ATTUALE";
            // 
            // txtEliminaNome
            // 
            this.txtEliminaNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEliminaNome.Location = new System.Drawing.Point(128, 33);
            this.txtEliminaNome.Name = "txtEliminaNome";
            this.txtEliminaNome.Size = new System.Drawing.Size(100, 20);
            this.txtEliminaNome.TabIndex = 1;
            // 
            // btnAggiorna
            // 
            this.btnAggiorna.Location = new System.Drawing.Point(9, 163);
            this.btnAggiorna.Name = "btnAggiorna";
            this.btnAggiorna.Size = new System.Drawing.Size(75, 23);
            this.btnAggiorna.TabIndex = 20;
            this.btnAggiorna.Text = "AGGIORNA";
            this.btnAggiorna.UseVisualStyleBackColor = true;
            this.btnAggiorna.Click += new System.EventHandler(this.btnAggiorna_Click);
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(6, 114);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(54, 13);
            this.Label11.TabIndex = 19;
            this.Label11.Text = "RICERCA";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(6, 50);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(82, 13);
            this.Label10.TabIndex = 18;
            this.Label10.Text = "TIPO RICERCA";
            // 
            // GroupBox5
            // 
            this.GroupBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.GroupBox5.Controls.Add(this.btnAggiorna);
            this.GroupBox5.Controls.Add(this.Label11);
            this.GroupBox5.Controls.Add(this.Label10);
            this.GroupBox5.Controls.Add(this.btnRicerca);
            this.GroupBox5.Controls.Add(this.cbTipoRicerca);
            this.GroupBox5.Controls.Add(this.txtRicerca);
            this.GroupBox5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GroupBox5.Location = new System.Drawing.Point(536, 340);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(277, 192);
            this.GroupBox5.TabIndex = 25;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "RICERCA";
            // 
            // btnRicerca
            // 
            this.btnRicerca.Location = new System.Drawing.Point(186, 163);
            this.btnRicerca.Name = "btnRicerca";
            this.btnRicerca.Size = new System.Drawing.Size(75, 23);
            this.btnRicerca.TabIndex = 13;
            this.btnRicerca.Text = "TROVA";
            this.btnRicerca.UseVisualStyleBackColor = true;
            this.btnRicerca.Click += new System.EventHandler(this.btnRicerca_Click);
            // 
            // cbTipoRicerca
            // 
            this.cbTipoRicerca.FormattingEnabled = true;
            this.cbTipoRicerca.Items.AddRange(new object[] {
            "NOME",
            "COGNOME",
            "TELEFONO"});
            this.cbTipoRicerca.Location = new System.Drawing.Point(140, 47);
            this.cbTipoRicerca.Name = "cbTipoRicerca";
            this.cbTipoRicerca.Size = new System.Drawing.Size(121, 21);
            this.cbTipoRicerca.TabIndex = 17;
            // 
            // txtRicerca
            // 
            this.txtRicerca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRicerca.Location = new System.Drawing.Point(102, 111);
            this.txtRicerca.Name = "txtRicerca";
            this.txtRicerca.Size = new System.Drawing.Size(159, 20);
            this.txtRicerca.TabIndex = 13;
            // 
            // GroupBox4
            // 
            this.GroupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.GroupBox4.Controls.Add(this.dtgRubrica);
            this.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GroupBox4.Location = new System.Drawing.Point(27, 340);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(503, 195);
            this.GroupBox4.TabIndex = 23;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "VISUALIZZAZIONE DATI RUBRICA";
            // 
            // dtgRubrica
            // 
            this.dtgRubrica.AutoGenerateColumns = false;
            this.dtgRubrica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgRubrica.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.NOME,
            this.COGNOME,
            this.TELEFONO,
            this.POSIZIONE_RUBRICA});
            this.dtgRubrica.DataSource = this.tabellaRubricaBindingSource;
            this.dtgRubrica.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgRubrica.Location = new System.Drawing.Point(3, 16);
            this.dtgRubrica.MultiSelect = false;
            this.dtgRubrica.Name = "dtgRubrica";
            this.dtgRubrica.Size = new System.Drawing.Size(497, 176);
            this.dtgRubrica.TabIndex = 10;
            this.dtgRubrica.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgRubrica_RowHeaderMouseClick);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            // 
            // NOME
            // 
            this.NOME.DataPropertyName = "NOME";
            this.NOME.HeaderText = "NOME";
            this.NOME.Name = "NOME";
            // 
            // COGNOME
            // 
            this.COGNOME.DataPropertyName = "COGNOME";
            this.COGNOME.HeaderText = "COGNOME";
            this.COGNOME.Name = "COGNOME";
            // 
            // TELEFONO
            // 
            this.TELEFONO.DataPropertyName = "TELEFONO";
            this.TELEFONO.HeaderText = "TELEFONO";
            this.TELEFONO.Name = "TELEFONO";
            // 
            // POSIZIONE_RUBRICA
            // 
            this.POSIZIONE_RUBRICA.DataPropertyName = "POSIZIONE_RUBRICA";
            this.POSIZIONE_RUBRICA.HeaderText = "POSIZIONE_RUBRICA";
            this.POSIZIONE_RUBRICA.Name = "POSIZIONE_RUBRICA";
            // 
            // tabellaRubricaBindingSource
            // 
            this.tabellaRubricaBindingSource.DataMember = "TabellaRubrica";
            this.tabellaRubricaBindingSource.DataSource = this.rubricaDataSet;
            // 
            // rubricaDataSet
            // 
            this.rubricaDataSet.DataSetName = "RubricaDataSet";
            this.rubricaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // EsciToolStripMenuItem
            // 
            this.EsciToolStripMenuItem.Name = "EsciToolStripMenuItem";
            this.EsciToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.EsciToolStripMenuItem.Text = "&Esci";
            this.EsciToolStripMenuItem.Click += new System.EventHandler(this.EsciToolStripMenuItem_Click);
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = System.Drawing.Color.White;
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EsciToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(839, 24);
            this.MenuStrip.TabIndex = 24;
            this.MenuStrip.Text = "MenuStrip1";
            // 
            // txtEliminaCognome
            // 
            this.txtEliminaCognome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEliminaCognome.Location = new System.Drawing.Point(128, 75);
            this.txtEliminaCognome.Name = "txtEliminaCognome";
            this.txtEliminaCognome.Size = new System.Drawing.Size(100, 20);
            this.txtEliminaCognome.TabIndex = 2;
            // 
            // GroupBox2
            // 
            this.GroupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.GroupBox2.Controls.Add(this.txtEliminaPosizioneRubrica);
            this.GroupBox2.Controls.Add(this.Label9);
            this.GroupBox2.Controls.Add(this.txtEliminaCognome);
            this.GroupBox2.Controls.Add(this.txtEliminaNome);
            this.GroupBox2.Controls.Add(this.txtEliminaTelefono);
            this.GroupBox2.Controls.Add(this.Label1);
            this.GroupBox2.Controls.Add(this.Label2);
            this.GroupBox2.Controls.Add(this.btnElimina);
            this.GroupBox2.Controls.Add(this.Label3);
            this.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GroupBox2.Location = new System.Drawing.Point(291, 53);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(258, 281);
            this.GroupBox2.TabIndex = 21;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "ELIMINAZIONE DATI";
            // 
            // txtEliminaTelefono
            // 
            this.txtEliminaTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEliminaTelefono.Location = new System.Drawing.Point(128, 116);
            this.txtEliminaTelefono.Name = "txtEliminaTelefono";
            this.txtEliminaTelefono.Size = new System.Drawing.Size(100, 20);
            this.txtEliminaTelefono.TabIndex = 3;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(6, 36);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(39, 13);
            this.Label1.TabIndex = 5;
            this.Label1.Text = "NOME";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(6, 119);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(64, 13);
            this.Label2.TabIndex = 7;
            this.Label2.Text = "TELEFONO";
            // 
            // btnElimina
            // 
            this.btnElimina.Location = new System.Drawing.Point(153, 237);
            this.btnElimina.Name = "btnElimina";
            this.btnElimina.Size = new System.Drawing.Size(75, 23);
            this.btnElimina.TabIndex = 4;
            this.btnElimina.Text = "ELIMINA";
            this.btnElimina.UseVisualStyleBackColor = true;
            this.btnElimina.Click += new System.EventHandler(this.btnElimina_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(6, 78);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(39, 13);
            this.Label3.TabIndex = 6;
            this.Label3.Text = "Label3";
            // 
            // tabellaRubricaTableAdapter
            // 
            this.tabellaRubricaTableAdapter.ClearBeforeFill = true;
            // 
            // FrmRubrica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(839, 555);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.GroupBox5);
            this.Controls.Add(this.GroupBox4);
            this.Controls.Add(this.MenuStrip);
            this.Controls.Add(this.GroupBox2);
            this.Name = "FrmRubrica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RUBRICA";
            this.Load += new System.EventHandler(this.FrmRubrica_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgRubrica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabellaRubricaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rubricaDataSet)).EndInit();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.TextBox txtPosizioneRubricaAttuale;
        internal System.Windows.Forms.TextBox txtCognomeAttuale;
        internal System.Windows.Forms.TextBox txtNomeAttuale;
        internal System.Windows.Forms.TextBox txtTelefonoAttuale;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.TextBox txtPosizioneRubrica;
        internal System.Windows.Forms.TextBox txtCognome;
        internal System.Windows.Forms.Button btnInserisci;
        internal System.Windows.Forms.TextBox txtNome;
        internal System.Windows.Forms.TextBox txtTelefono;
        internal System.Windows.Forms.Label lblNome;
        internal System.Windows.Forms.Label lblTelefono;
        internal System.Windows.Forms.Label lblCognome;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txtEliminaPosizioneRubrica;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Button btnModifica;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.TextBox txtEliminaNome;
        internal System.Windows.Forms.Button btnAggiorna;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.GroupBox GroupBox5;
        internal System.Windows.Forms.Button btnRicerca;
        internal System.Windows.Forms.ComboBox cbTipoRicerca;
        internal System.Windows.Forms.TextBox txtRicerca;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.DataGridView dtgRubrica;
        internal System.Windows.Forms.ToolStripMenuItem EsciToolStripMenuItem;
        internal System.Windows.Forms.MenuStrip MenuStrip;
        internal System.Windows.Forms.TextBox txtEliminaCognome;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.TextBox txtEliminaTelefono;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button btnElimina;
        internal System.Windows.Forms.Label Label3;
        private RubricaDataSet rubricaDataSet;
        private System.Windows.Forms.BindingSource tabellaRubricaBindingSource;
        private RubricaDataSetTableAdapters.TabellaRubricaTableAdapter tabellaRubricaTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOME;
        private System.Windows.Forms.DataGridViewTextBoxColumn COGNOME;
        private System.Windows.Forms.DataGridViewTextBoxColumn TELEFONO;
        private System.Windows.Forms.DataGridViewTextBoxColumn POSIZIONE_RUBRICA;
    }
}

