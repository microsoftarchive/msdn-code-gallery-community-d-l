<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRubrica
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnInserisci = New System.Windows.Forms.Button()
        Me.txtNome = New System.Windows.Forms.TextBox()
        Me.txtCognome = New System.Windows.Forms.TextBox()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.btnElimina = New System.Windows.Forms.Button()
        Me.lblNome = New System.Windows.Forms.Label()
        Me.lblCognome = New System.Windows.Forms.Label()
        Me.lblTelefono = New System.Windows.Forms.Label()
        Me.btnModifica = New System.Windows.Forms.Button()
        Me.dtgRubrica = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COGNOME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TELEFONO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.POSIZIONE_RUBRICA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabellaRubricaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RubricaDataSet = New Rubrica.RubricaDataSet()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPosizioneRubrica = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtEliminaPosizioneRubrica = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtEliminaCognome = New System.Windows.Forms.TextBox()
        Me.txtEliminaNome = New System.Windows.Forms.TextBox()
        Me.txtEliminaTelefono = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPosizioneRubricaAttuale = New System.Windows.Forms.TextBox()
        Me.txtCognomeAttuale = New System.Windows.Forms.TextBox()
        Me.txtNomeAttuale = New System.Windows.Forms.TextBox()
        Me.txtTelefonoAttuale = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnRicerca = New System.Windows.Forms.Button()
        Me.txtRicerca = New System.Windows.Forms.TextBox()
        Me.cbTipoRicerca = New System.Windows.Forms.ComboBox()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.EsciToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btnAggiorna = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TabellaRubricaTableAdapter = New Rubrica.RubricaDataSetTableAdapters.TabellaRubricaTableAdapter()
        CType(Me.dtgRubrica, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabellaRubricaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RubricaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnInserisci
        '
        Me.btnInserisci.Location = New System.Drawing.Point(153, 237)
        Me.btnInserisci.Name = "btnInserisci"
        Me.btnInserisci.Size = New System.Drawing.Size(75, 23)
        Me.btnInserisci.TabIndex = 0
        Me.btnInserisci.Text = "INSERISCI"
        Me.btnInserisci.UseVisualStyleBackColor = True
        '
        'txtNome
        '
        Me.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNome.Location = New System.Drawing.Point(128, 33)
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(100, 20)
        Me.txtNome.TabIndex = 1
        '
        'txtCognome
        '
        Me.txtCognome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCognome.Location = New System.Drawing.Point(128, 75)
        Me.txtCognome.Name = "txtCognome"
        Me.txtCognome.Size = New System.Drawing.Size(100, 20)
        Me.txtCognome.TabIndex = 2
        '
        'txtTelefono
        '
        Me.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTelefono.Location = New System.Drawing.Point(128, 116)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(100, 20)
        Me.txtTelefono.TabIndex = 3
        '
        'btnElimina
        '
        Me.btnElimina.Location = New System.Drawing.Point(153, 237)
        Me.btnElimina.Name = "btnElimina"
        Me.btnElimina.Size = New System.Drawing.Size(75, 23)
        Me.btnElimina.TabIndex = 4
        Me.btnElimina.Text = "ELIMINA"
        Me.btnElimina.UseVisualStyleBackColor = True
        '
        'lblNome
        '
        Me.lblNome.AutoSize = True
        Me.lblNome.Location = New System.Drawing.Point(6, 36)
        Me.lblNome.Name = "lblNome"
        Me.lblNome.Size = New System.Drawing.Size(39, 13)
        Me.lblNome.TabIndex = 5
        Me.lblNome.Text = "NOME"
        '
        'lblCognome
        '
        Me.lblCognome.AutoSize = True
        Me.lblCognome.Location = New System.Drawing.Point(6, 78)
        Me.lblCognome.Name = "lblCognome"
        Me.lblCognome.Size = New System.Drawing.Size(62, 13)
        Me.lblCognome.TabIndex = 6
        Me.lblCognome.Text = "COGNOME"
        '
        'lblTelefono
        '
        Me.lblTelefono.AutoSize = True
        Me.lblTelefono.Location = New System.Drawing.Point(6, 119)
        Me.lblTelefono.Name = "lblTelefono"
        Me.lblTelefono.Size = New System.Drawing.Size(64, 13)
        Me.lblTelefono.TabIndex = 7
        Me.lblTelefono.Text = "TELEFONO"
        '
        'btnModifica
        '
        Me.btnModifica.Location = New System.Drawing.Point(153, 237)
        Me.btnModifica.Name = "btnModifica"
        Me.btnModifica.Size = New System.Drawing.Size(75, 23)
        Me.btnModifica.TabIndex = 9
        Me.btnModifica.Text = "MODIFICA"
        Me.btnModifica.UseVisualStyleBackColor = True
        '
        'dtgRubrica
        '
        Me.dtgRubrica.AutoGenerateColumns = False
        Me.dtgRubrica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgRubrica.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.NOME, Me.COGNOME, Me.TELEFONO, Me.POSIZIONE_RUBRICA})
        Me.dtgRubrica.DataSource = Me.TabellaRubricaBindingSource
        Me.dtgRubrica.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgRubrica.Location = New System.Drawing.Point(3, 16)
        Me.dtgRubrica.MultiSelect = False
        Me.dtgRubrica.Name = "dtgRubrica"
        Me.dtgRubrica.Size = New System.Drawing.Size(497, 176)
        Me.dtgRubrica.TabIndex = 10
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        '
        'NOME
        '
        Me.NOME.DataPropertyName = "NOME"
        Me.NOME.HeaderText = "NOME"
        Me.NOME.Name = "NOME"
        '
        'COGNOME
        '
        Me.COGNOME.DataPropertyName = "COGNOME"
        Me.COGNOME.HeaderText = "COGNOME"
        Me.COGNOME.Name = "COGNOME"
        '
        'TELEFONO
        '
        Me.TELEFONO.DataPropertyName = "TELEFONO"
        Me.TELEFONO.HeaderText = "TELEFONO"
        Me.TELEFONO.Name = "TELEFONO"
        '
        'POSIZIONE_RUBRICA
        '
        Me.POSIZIONE_RUBRICA.DataPropertyName = "POSIZIONE_RUBRICA"
        Me.POSIZIONE_RUBRICA.HeaderText = "POSIZIONE_RUBRICA"
        Me.POSIZIONE_RUBRICA.Name = "POSIZIONE_RUBRICA"
        '
        'TabellaRubricaBindingSource
        '
        Me.TabellaRubricaBindingSource.DataMember = "TabellaRubrica"
        Me.TabellaRubricaBindingSource.DataSource = Me.RubricaDataSet
        '
        'RubricaDataSet
        '
        Me.RubricaDataSet.DataSetName = "RubricaDataSet"
        Me.RubricaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtPosizioneRubrica)
        Me.GroupBox1.Controls.Add(Me.txtCognome)
        Me.GroupBox1.Controls.Add(Me.btnInserisci)
        Me.GroupBox1.Controls.Add(Me.txtNome)
        Me.GroupBox1.Controls.Add(Me.txtTelefono)
        Me.GroupBox1.Controls.Add(Me.lblNome)
        Me.GroupBox1.Controls.Add(Me.lblTelefono)
        Me.GroupBox1.Controls.Add(Me.lblCognome)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox1.Location = New System.Drawing.Point(27, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(258, 281)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "INSERIMENTO DATI"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 158)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(116, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "POSIZIONE RUBRICA"
        '
        'txtPosizioneRubrica
        '
        Me.txtPosizioneRubrica.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPosizioneRubrica.Location = New System.Drawing.Point(128, 155)
        Me.txtPosizioneRubrica.Name = "txtPosizioneRubrica"
        Me.txtPosizioneRubrica.Size = New System.Drawing.Size(100, 20)
        Me.txtPosizioneRubrica.TabIndex = 8
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox2.Controls.Add(Me.txtEliminaPosizioneRubrica)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtEliminaCognome)
        Me.GroupBox2.Controls.Add(Me.txtEliminaNome)
        Me.GroupBox2.Controls.Add(Me.txtEliminaTelefono)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.btnElimina)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox2.Location = New System.Drawing.Point(291, 41)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(258, 281)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "ELIMINAZIONE DATI"
        '
        'txtEliminaPosizioneRubrica
        '
        Me.txtEliminaPosizioneRubrica.BackColor = System.Drawing.Color.White
        Me.txtEliminaPosizioneRubrica.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEliminaPosizioneRubrica.Location = New System.Drawing.Point(128, 155)
        Me.txtEliminaPosizioneRubrica.Name = "txtEliminaPosizioneRubrica"
        Me.txtEliminaPosizioneRubrica.ReadOnly = True
        Me.txtEliminaPosizioneRubrica.Size = New System.Drawing.Size(100, 20)
        Me.txtEliminaPosizioneRubrica.TabIndex = 12
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 158)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(116, 13)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "POSIZIONE RUBRICA"
        '
        'txtEliminaCognome
        '
        Me.txtEliminaCognome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEliminaCognome.Location = New System.Drawing.Point(128, 75)
        Me.txtEliminaCognome.Name = "txtEliminaCognome"
        Me.txtEliminaCognome.Size = New System.Drawing.Size(100, 20)
        Me.txtEliminaCognome.TabIndex = 2
        '
        'txtEliminaNome
        '
        Me.txtEliminaNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEliminaNome.Location = New System.Drawing.Point(128, 33)
        Me.txtEliminaNome.Name = "txtEliminaNome"
        Me.txtEliminaNome.Size = New System.Drawing.Size(100, 20)
        Me.txtEliminaNome.TabIndex = 1
        '
        'txtEliminaTelefono
        '
        Me.txtEliminaTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEliminaTelefono.Location = New System.Drawing.Point(128, 116)
        Me.txtEliminaTelefono.Name = "txtEliminaTelefono"
        Me.txtEliminaTelefono.Size = New System.Drawing.Size(100, 20)
        Me.txtEliminaTelefono.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "NOME"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 119)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "TELEFONO"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "COGNOME"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.txtPosizioneRubricaAttuale)
        Me.GroupBox3.Controls.Add(Me.txtCognomeAttuale)
        Me.GroupBox3.Controls.Add(Me.txtNomeAttuale)
        Me.GroupBox3.Controls.Add(Me.txtTelefonoAttuale)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.btnModifica)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox3.Location = New System.Drawing.Point(555, 41)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(258, 281)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "MODIFICA DATI"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 158)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "POSIZIONE RUBRICA"
        '
        'txtPosizioneRubricaAttuale
        '
        Me.txtPosizioneRubricaAttuale.BackColor = System.Drawing.Color.White
        Me.txtPosizioneRubricaAttuale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPosizioneRubricaAttuale.Location = New System.Drawing.Point(128, 155)
        Me.txtPosizioneRubricaAttuale.Name = "txtPosizioneRubricaAttuale"
        Me.txtPosizioneRubricaAttuale.ReadOnly = True
        Me.txtPosizioneRubricaAttuale.Size = New System.Drawing.Size(100, 20)
        Me.txtPosizioneRubricaAttuale.TabIndex = 10
        '
        'txtCognomeAttuale
        '
        Me.txtCognomeAttuale.BackColor = System.Drawing.Color.White
        Me.txtCognomeAttuale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCognomeAttuale.Location = New System.Drawing.Point(128, 75)
        Me.txtCognomeAttuale.Name = "txtCognomeAttuale"
        Me.txtCognomeAttuale.Size = New System.Drawing.Size(100, 20)
        Me.txtCognomeAttuale.TabIndex = 2
        '
        'txtNomeAttuale
        '
        Me.txtNomeAttuale.BackColor = System.Drawing.Color.White
        Me.txtNomeAttuale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNomeAttuale.Location = New System.Drawing.Point(128, 33)
        Me.txtNomeAttuale.Name = "txtNomeAttuale"
        Me.txtNomeAttuale.Size = New System.Drawing.Size(100, 20)
        Me.txtNomeAttuale.TabIndex = 1
        '
        'txtTelefonoAttuale
        '
        Me.txtTelefonoAttuale.BackColor = System.Drawing.Color.White
        Me.txtTelefonoAttuale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTelefonoAttuale.Location = New System.Drawing.Point(128, 116)
        Me.txtTelefonoAttuale.Name = "txtTelefonoAttuale"
        Me.txtTelefonoAttuale.Size = New System.Drawing.Size(100, 20)
        Me.txtTelefonoAttuale.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "NOME ATTUALE"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 119)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "TELEFONO ATTUALE"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 78)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(114, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "COGNOME ATTUALE"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox4.Controls.Add(Me.dtgRubrica)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox4.Location = New System.Drawing.Point(27, 328)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(503, 195)
        Me.GroupBox4.TabIndex = 15
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "VISUALIZZAZIONE DATI RUBRICA"
        '
        'btnRicerca
        '
        Me.btnRicerca.Location = New System.Drawing.Point(186, 163)
        Me.btnRicerca.Name = "btnRicerca"
        Me.btnRicerca.Size = New System.Drawing.Size(75, 23)
        Me.btnRicerca.TabIndex = 13
        Me.btnRicerca.Text = "TROVA"
        Me.btnRicerca.UseVisualStyleBackColor = True
        '
        'txtRicerca
        '
        Me.txtRicerca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRicerca.Location = New System.Drawing.Point(102, 111)
        Me.txtRicerca.Name = "txtRicerca"
        Me.txtRicerca.Size = New System.Drawing.Size(159, 20)
        Me.txtRicerca.TabIndex = 13
        '
        'cbTipoRicerca
        '
        Me.cbTipoRicerca.FormattingEnabled = True
        Me.cbTipoRicerca.Items.AddRange(New Object() {"NOME", "COGNOME", "TELEFONO"})
        Me.cbTipoRicerca.Location = New System.Drawing.Point(140, 47)
        Me.cbTipoRicerca.Name = "cbTipoRicerca"
        Me.cbTipoRicerca.Size = New System.Drawing.Size(121, 21)
        Me.cbTipoRicerca.TabIndex = 17
        '
        'MenuStrip
        '
        Me.MenuStrip.BackColor = System.Drawing.Color.White
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EsciToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(839, 24)
        Me.MenuStrip.TabIndex = 18
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'EsciToolStripMenuItem
        '
        Me.EsciToolStripMenuItem.Name = "EsciToolStripMenuItem"
        Me.EsciToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EsciToolStripMenuItem.Text = "&Esci"
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox5.Controls.Add(Me.btnAggiorna)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.btnRicerca)
        Me.GroupBox5.Controls.Add(Me.cbTipoRicerca)
        Me.GroupBox5.Controls.Add(Me.txtRicerca)
        Me.GroupBox5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox5.Location = New System.Drawing.Point(536, 328)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(277, 192)
        Me.GroupBox5.TabIndex = 19
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "RICERCA"
        '
        'btnAggiorna
        '
        Me.btnAggiorna.Location = New System.Drawing.Point(9, 163)
        Me.btnAggiorna.Name = "btnAggiorna"
        Me.btnAggiorna.Size = New System.Drawing.Size(75, 23)
        Me.btnAggiorna.TabIndex = 20
        Me.btnAggiorna.Text = "AGGIORNA"
        Me.btnAggiorna.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 114)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 13)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "RICERCA"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 50)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "TIPO RICERCA"
        '
        'TabellaRubricaTableAdapter
        '
        Me.TabellaRubricaTableAdapter.ClearBeforeFill = True
        '
        'FrmRubrica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(839, 547)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip)
        Me.MainMenuStrip = Me.MenuStrip
        Me.MaximizeBox = False
        Me.Name = "FrmRubrica"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RUBRICA"
        CType(Me.dtgRubrica, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabellaRubricaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RubricaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnInserisci As System.Windows.Forms.Button
    Friend WithEvents txtNome As System.Windows.Forms.TextBox
    Friend WithEvents txtCognome As System.Windows.Forms.TextBox
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents btnElimina As System.Windows.Forms.Button
    Friend WithEvents lblNome As System.Windows.Forms.Label
    Friend WithEvents lblCognome As System.Windows.Forms.Label
    Friend WithEvents lblTelefono As System.Windows.Forms.Label
    Friend WithEvents btnModifica As System.Windows.Forms.Button
    Friend WithEvents dtgRubrica As System.Windows.Forms.DataGridView
    Friend WithEvents IDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtEliminaCognome As System.Windows.Forms.TextBox
    Friend WithEvents txtEliminaNome As System.Windows.Forms.TextBox
    Friend WithEvents txtEliminaTelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCognomeAttuale As System.Windows.Forms.TextBox
    Friend WithEvents txtNomeAttuale As System.Windows.Forms.TextBox
    Friend WithEvents txtTelefonoAttuale As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPosizioneRubrica As System.Windows.Forms.TextBox
    Friend WithEvents txtPosizioneRubricaAttuale As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtEliminaPosizioneRubrica As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnRicerca As System.Windows.Forms.Button
    Friend WithEvents txtRicerca As System.Windows.Forms.TextBox
    Friend WithEvents cbTipoRicerca As System.Windows.Forms.ComboBox
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents EsciToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnAggiorna As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COGNOMEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TELEFONODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POSIZIONERUBRICADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PIPPODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    'Friend WithEvents RubricaDataSet As Rubrica.RubricaDataSet
    '    Friend WithEvents TabellaRubricaTableAdapter As Rubrica.RubricaDataSetTableAdapters.TabellaRubricaTableAdapter
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    'Friend WithEvents RubricaDataSet1 As Rubrica.RubricaDataSet
    'Friend WithEvents TabellaRubricaTableAdapter1 As Rubrica.RubricaDataSetTableAdapters.TabellaRubricaTableAdapter
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RubricaDataSet As Rubrica.RubricaDataSet
    Friend WithEvents TabellaRubricaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TabellaRubricaTableAdapter As Rubrica.RubricaDataSetTableAdapters.TabellaRubricaTableAdapter
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COGNOME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TELEFONO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POSIZIONE_RUBRICA As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
