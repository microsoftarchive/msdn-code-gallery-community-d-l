<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEnviarCorreo
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEnviarCorreo))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtContraseña = New System.Windows.Forms.TextBox()
        Me.cbxClienteCorreo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCorreo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPuerto = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSMTP = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtAsunto = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCC = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPara = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnQuitarAdjunto = New System.Windows.Forms.Button()
        Me.btnAdjuntar = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtExtencionArchivo = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCreadoArchivo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtModificoArchivo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtUbicacion = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtNombreArchivo = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtMensaje = New System.Windows.Forms.TextBox()
        Me.btnEnviarCorreo = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EnviarCorreoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VisitarPaginaWebToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LikeEnFacebookToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SíguenosEnTwitterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoCorreoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtNombre)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtContraseña)
        Me.GroupBox1.Controls.Add(Me.cbxClienteCorreo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtCorreo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtPuerto)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtSMTP)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(603, 110)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Configuración  cliente de correo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(0, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Ingrese su Contraseña:"
        '
        'txtContraseña
        '
        Me.txtContraseña.Location = New System.Drawing.Point(122, 77)
        Me.txtContraseña.Name = "txtContraseña"
        Me.txtContraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtContraseña.Size = New System.Drawing.Size(200, 20)
        Me.txtContraseña.TabIndex = 7
        Me.txtContraseña.Text = "hulkomania2995"
        '
        'cbxClienteCorreo
        '
        Me.cbxClienteCorreo.FormattingEnabled = True
        Me.cbxClienteCorreo.Items.AddRange(New Object() {"@hotmail.com", "@yahoo.com", "@gmail.com", "@facebook.com"})
        Me.cbxClienteCorreo.Location = New System.Drawing.Point(328, 50)
        Me.cbxClienteCorreo.Name = "cbxClienteCorreo"
        Me.cbxClienteCorreo.Size = New System.Drawing.Size(121, 21)
        Me.cbxClienteCorreo.TabIndex = 6
        Me.cbxClienteCorreo.Text = "@hotmail.com"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Ingrese su correo:"
        '
        'txtCorreo
        '
        Me.txtCorreo.Location = New System.Drawing.Point(122, 51)
        Me.txtCorreo.Name = "txtCorreo"
        Me.txtCorreo.Size = New System.Drawing.Size(200, 20)
        Me.txtCorreo.TabIndex = 4
        Me.txtCorreo.Text = "josue_chavez_alcivar"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(176, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Puerto:"
        '
        'txtPuerto
        '
        Me.txtPuerto.Location = New System.Drawing.Point(222, 21)
        Me.txtPuerto.Name = "txtPuerto"
        Me.txtPuerto.Size = New System.Drawing.Size(100, 20)
        Me.txtPuerto.TabIndex = 2
        Me.txtPuerto.Text = "25"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "SMTP:"
        '
        'txtSMTP
        '
        Me.txtSMTP.Location = New System.Drawing.Point(70, 21)
        Me.txtSMTP.Name = "txtSMTP"
        Me.txtSMTP.Size = New System.Drawing.Size(100, 20)
        Me.txtSMTP.TabIndex = 0
        Me.txtSMTP.Text = "smtp.live.com"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtAsunto)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtCC)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtPara)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 128)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(603, 106)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos del correo"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Asunto:"
        '
        'txtAsunto
        '
        Me.txtAsunto.Location = New System.Drawing.Point(64, 71)
        Me.txtAsunto.Name = "txtAsunto"
        Me.txtAsunto.Size = New System.Drawing.Size(516, 20)
        Me.txtAsunto.TabIndex = 10
        Me.txtAsunto.Text = "Esto es una prueba"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "CC:"
        '
        'txtCC
        '
        Me.txtCC.Location = New System.Drawing.Point(45, 45)
        Me.txtCC.Name = "txtCC"
        Me.txtCC.Size = New System.Drawing.Size(535, 20)
        Me.txtCC.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Para:"
        '
        'txtPara
        '
        Me.txtPara.Location = New System.Drawing.Point(53, 19)
        Me.txtPara.Name = "txtPara"
        Me.txtPara.Size = New System.Drawing.Size(527, 20)
        Me.txtPara.TabIndex = 6
        Me.txtPara.Text = "josue.chavez.alcivar@facebook.com"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnQuitarAdjunto)
        Me.GroupBox3.Controls.Add(Me.btnAdjuntar)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.txtExtencionArchivo)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.txtCreadoArchivo)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.txtModificoArchivo)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.txtUbicacion)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.txtNombreArchivo)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 240)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(603, 109)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Archivos Adjuntos"
        '
        'btnQuitarAdjunto
        '
        Me.btnQuitarAdjunto.Location = New System.Drawing.Point(520, 74)
        Me.btnQuitarAdjunto.Name = "btnQuitarAdjunto"
        Me.btnQuitarAdjunto.Size = New System.Drawing.Size(75, 23)
        Me.btnQuitarAdjunto.TabIndex = 23
        Me.btnQuitarAdjunto.Text = "Quitar"
        Me.btnQuitarAdjunto.UseVisualStyleBackColor = True
        '
        'btnAdjuntar
        '
        Me.btnAdjuntar.Location = New System.Drawing.Point(439, 74)
        Me.btnAdjuntar.Name = "btnAdjuntar"
        Me.btnAdjuntar.Size = New System.Drawing.Size(75, 23)
        Me.btnAdjuntar.TabIndex = 22
        Me.btnAdjuntar.Text = "Adjuntar"
        Me.btnAdjuntar.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(377, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 13)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "Extensión:"
        '
        'txtExtencionArchivo
        '
        Me.txtExtencionArchivo.Location = New System.Drawing.Point(439, 19)
        Me.txtExtencionArchivo.Name = "txtExtencionArchivo"
        Me.txtExtencionArchivo.ReadOnly = True
        Me.txtExtencionArchivo.Size = New System.Drawing.Size(138, 20)
        Me.txtExtencionArchivo.TabIndex = 20
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(15, 74)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 13)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Se Creó:"
        '
        'txtCreadoArchivo
        '
        Me.txtCreadoArchivo.Location = New System.Drawing.Point(79, 71)
        Me.txtCreadoArchivo.Name = "txtCreadoArchivo"
        Me.txtCreadoArchivo.ReadOnly = True
        Me.txtCreadoArchivo.Size = New System.Drawing.Size(138, 20)
        Me.txtCreadoArchivo.TabIndex = 18
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(223, 74)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Se Modicó:"
        '
        'txtModificoArchivo
        '
        Me.txtModificoArchivo.Location = New System.Drawing.Point(287, 71)
        Me.txtModificoArchivo.Name = "txtModificoArchivo"
        Me.txtModificoArchivo.ReadOnly = True
        Me.txtModificoArchivo.Size = New System.Drawing.Size(138, 20)
        Me.txtModificoArchivo.TabIndex = 16
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 13)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Ubicación:"
        '
        'txtUbicacion
        '
        Me.txtUbicacion.Location = New System.Drawing.Point(79, 45)
        Me.txtUbicacion.Name = "txtUbicacion"
        Me.txtUbicacion.ReadOnly = True
        Me.txtUbicacion.Size = New System.Drawing.Size(501, 20)
        Me.txtUbicacion.TabIndex = 14
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(15, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(103, 13)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "Nombre del Archivo:"
        '
        'txtNombreArchivo
        '
        Me.txtNombreArchivo.Location = New System.Drawing.Point(122, 19)
        Me.txtNombreArchivo.Name = "txtNombreArchivo"
        Me.txtNombreArchivo.ReadOnly = True
        Me.txtNombreArchivo.Size = New System.Drawing.Size(249, 20)
        Me.txtNombreArchivo.TabIndex = 12
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtMensaje)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 355)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(603, 200)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Mensaje"
        '
        'txtMensaje
        '
        Me.txtMensaje.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMensaje.Location = New System.Drawing.Point(3, 16)
        Me.txtMensaje.Multiline = True
        Me.txtMensaje.Name = "txtMensaje"
        Me.txtMensaje.Size = New System.Drawing.Size(597, 181)
        Me.txtMensaje.TabIndex = 0
        Me.txtMensaje.Text = "Mensaje de prueba"
        '
        'btnEnviarCorreo
        '
        Me.btnEnviarCorreo.Location = New System.Drawing.Point(532, 561)
        Me.btnEnviarCorreo.Name = "btnEnviarCorreo"
        Me.btnEnviarCorreo.Size = New System.Drawing.Size(75, 23)
        Me.btnEnviarCorreo.TabIndex = 4
        Me.btnEnviarCorreo.Text = "Enviar"
        Me.btnEnviarCorreo.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(325, 80)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(47, 13)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "Nombre:"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(378, 77)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(217, 20)
        Me.txtNombre.TabIndex = 9
        Me.txtNombre.Text = "Josue"
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.NotifyIcon1.BalloonTipText = resources.GetString("NotifyIcon1.BalloonTipText")
        Me.NotifyIcon1.BalloonTipTitle = "Ejemplo - ¿Como Enviar un Correo desde VB:NET?©J&C Technical Developers"
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "©J&C Technical Developers."
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoCorreoToolStripMenuItem, Me.EnviarCorreoToolStripMenuItem, Me.VisitarPaginaWebToolStripMenuItem, Me.LikeEnFacebookToolStripMenuItem, Me.SíguenosEnTwitterToolStripMenuItem, Me.SalirToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(179, 136)
        '
        'EnviarCorreoToolStripMenuItem
        '
        Me.EnviarCorreoToolStripMenuItem.Name = "EnviarCorreoToolStripMenuItem"
        Me.EnviarCorreoToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.EnviarCorreoToolStripMenuItem.Text = "Enviar Correo"
        '
        'VisitarPaginaWebToolStripMenuItem
        '
        Me.VisitarPaginaWebToolStripMenuItem.Name = "VisitarPaginaWebToolStripMenuItem"
        Me.VisitarPaginaWebToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.VisitarPaginaWebToolStripMenuItem.Text = "Visitar pagina Web"
        '
        'LikeEnFacebookToolStripMenuItem
        '
        Me.LikeEnFacebookToolStripMenuItem.Name = "LikeEnFacebookToolStripMenuItem"
        Me.LikeEnFacebookToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.LikeEnFacebookToolStripMenuItem.Text = "Like en Facebook"
        '
        'SíguenosEnTwitterToolStripMenuItem
        '
        Me.SíguenosEnTwitterToolStripMenuItem.Name = "SíguenosEnTwitterToolStripMenuItem"
        Me.SíguenosEnTwitterToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.SíguenosEnTwitterToolStripMenuItem.Text = "Síguenos en Twitter"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'NuevoCorreoToolStripMenuItem
        '
        Me.NuevoCorreoToolStripMenuItem.Name = "NuevoCorreoToolStripMenuItem"
        Me.NuevoCorreoToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.NuevoCorreoToolStripMenuItem.Text = "Nuevo Correo"
        '
        'FormEnviarCorreo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(627, 591)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Controls.Add(Me.btnEnviarCorreo)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormEnviarCorreo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "©J&C Technical Developers. - Ejemplo Enviar Correo Electronico."
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbxClienteCorreo As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCorreo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPuerto As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSMTP As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtContraseña As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtAsunto As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCC As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPara As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtModificoArchivo As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtUbicacion As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtNombreArchivo As System.Windows.Forms.TextBox
    Friend WithEvents btnQuitarAdjunto As System.Windows.Forms.Button
    Friend WithEvents btnAdjuntar As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtExtencionArchivo As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtCreadoArchivo As System.Windows.Forms.TextBox
    Friend WithEvents txtMensaje As System.Windows.Forms.TextBox
    Friend WithEvents btnEnviarCorreo As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EnviarCorreoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VisitarPaginaWebToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LikeEnFacebookToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SíguenosEnTwitterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoCorreoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
