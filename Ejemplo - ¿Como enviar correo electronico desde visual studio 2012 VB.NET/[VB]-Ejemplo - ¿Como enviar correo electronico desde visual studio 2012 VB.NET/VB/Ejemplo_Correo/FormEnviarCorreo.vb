Imports System.Net
Imports System.Net.Mail

Public Class FormEnviarCorreo

    Dim fileDialogBox As New OpenFileDialog()

    Private Sub FormEnviarCorreo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NotifyIcon1.ShowBalloonTip(5000)

    End Sub
    Sub Enviar_Correo()
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        _SMTP.Credentials = New System.Net.NetworkCredential(txtCorreo.Text + cbxClienteCorreo.Text, txtContraseña.Text)
        _SMTP.Host = txtSMTP.Text
        _SMTP.Port = txtPuerto.Text
        _SMTP.EnableSsl = True

        ' CONFIGURACION_DEL_MENSAJE()
        _Message.[To].Add(Me.txtPara.Text.ToString) 'Cuenta de Correo al que se le quiere enviar el e-mail
        _Message.From = New System.Net.Mail.MailAddress(txtCorreo.Text + cbxClienteCorreo.Text, txtNombre.Text, System.Text.Encoding.UTF8) 'Quien lo envía
        _Message.Subject = Me.txtAsunto.Text.ToString 'Sujeto del e-mail
        _Message.SubjectEncoding = System.Text.Encoding.UTF8 'Codificacion
        _Message.Body = Me.txtMensaje.Text.ToString 'contenido del mail
        _Message.BodyEncoding = System.Text.Encoding.UTF8
        _Message.Priority = System.Net.Mail.MailPriority.Normal
        _Message.IsBodyHtml = False
        _Message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
        _Message.CC.Add(txtCC.Text)

        'ENVIO()
        Try
            _SMTP.Send(_Message)
            MessageBox.Show("Mensaje enviado correctamene", "Exito!", MessageBoxButtons.OK)
        Catch ex As System.Net.Mail.SmtpException
            MessageBox.Show(ex.ToString, "Error!", MessageBoxButtons.OK)
        End Try
        _Message = Nothing
        _SMTP = Nothing
    End Sub
    Sub Enviar_Correo_SinCC()
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        _SMTP.Credentials = New System.Net.NetworkCredential(txtCorreo.Text + cbxClienteCorreo.Text, txtContraseña.Text)
        _SMTP.Host = txtSMTP.Text
        _SMTP.Port = txtPuerto.Text
        _SMTP.EnableSsl = True

        ' CONFIGURACION_DEL_MENSAJE()
        _Message.[To].Add(Me.txtPara.Text.ToString) 'Cuenta de Correo al que se le quiere enviar el e-mail
        _Message.From = New System.Net.Mail.MailAddress(txtCorreo.Text + cbxClienteCorreo.Text, txtNombre.Text, System.Text.Encoding.UTF8) 'Quien lo envía
        _Message.Subject = Me.txtAsunto.Text.ToString 'Sujeto del e-mail
        _Message.SubjectEncoding = System.Text.Encoding.UTF8 'Codificacion
        _Message.Body = Me.txtMensaje.Text.ToString 'contenido del mail
        _Message.BodyEncoding = System.Text.Encoding.UTF8
        _Message.Priority = System.Net.Mail.MailPriority.Normal
        _Message.IsBodyHtml = False
        _Message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure


        'ENVIO()
        Try
            _SMTP.Send(_Message)
            MessageBox.Show("Mensaje enviado correctamene", "Exito!", MessageBoxButtons.OK)
        Catch ex As System.Net.Mail.SmtpException
            MessageBox.Show(ex.ToString, "Error!", MessageBoxButtons.OK)
        End Try
        _Message = Nothing
        _SMTP = Nothing
    End Sub
    Sub Enviar_Correo_Adjunto()
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        _SMTP.Credentials = New System.Net.NetworkCredential(txtCorreo.Text + cbxClienteCorreo.Text, txtContraseña.Text)
        _SMTP.Host = txtSMTP.Text
        _SMTP.Port = txtPuerto.Text
        _SMTP.EnableSsl = True

        ' CONFIGURACION_DEL_MENSAJE()
        _Message.[To].Add(Me.txtPara.Text.ToString) 'Cuenta de Correo al que se le quiere enviar el e-mail
        _Message.From = New System.Net.Mail.MailAddress(txtCorreo.Text + cbxClienteCorreo.Text, txtNombre.Text, System.Text.Encoding.UTF8) 'Quien lo envía
        _Message.Subject = Me.txtAsunto.Text.ToString 'Sujeto del e-mail
        _Message.SubjectEncoding = System.Text.Encoding.UTF8 'Codificacion
        _Message.Body = Me.txtMensaje.Text.ToString 'contenido del mail
        _Message.BodyEncoding = System.Text.Encoding.UTF8
        _Message.Priority = System.Net.Mail.MailPriority.Normal
        _Message.IsBodyHtml = False
        Dim adjunto = New System.Net.Mail.Attachment(txtUbicacion.Text + "\" + txtNombreArchivo.Text)
        _Message.Attachments.Add(adjunto)
        _Message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
        _Message.CC.Add(txtCC.Text)
        'ENVIO()
        Try
            _SMTP.Send(_Message)
            MessageBox.Show("Mensaje enviado correctamene", "Exito! - www.JandC-Ec.webs.com", MessageBoxButtons.OK)
        Catch ex As System.Net.Mail.SmtpException
            MessageBox.Show(ex.ToString, "Error! - www.JandC-Ec.webs.com", MessageBoxButtons.OK)
        End Try
        _Message = Nothing
        _SMTP = Nothing
    End Sub
    Public Function AbrirArchivo() As String
        'declarar una cadena, esto se contendrá el nombre del archivo que volvamos
        Dim strFileName = ""
        'declare a new open file dialog


        'añadir filtros de archivos, este paso es opcional, pero si se observa la captura de pantalla 
        'por encima de ella no se ve limpia si la deja fuera, le expliqué con más 
        'detalle en mi sitio cómo agregar / modificar estos valores
        fileDialogBox.Filter = "Formato de texto enriquecido (*.rtf)|*.Rtf|" _
             & "Archivos de texto (*.txt)|*.Txt|" _
             & "Documentos de Word(*.Doc, *.docx)|*.Doc, *.Docx|" _
             & "Archivos de imagen(*.Bmp; *.jpg; *.gif) |*.bmp; *.Jpg, *.Gif|" _
             & "Documentos de PowerPoint (*.Pptx; *.ppt)|*.pptx; *.Ppt|" _
             & "Documentos de Excel (*.XLS;*.XLSX)|*.XLS;*.XLSX|" _
             & "Todos los archivos (*.*)|"
        'esto establece el filtro por defecto que hemos creado en la línea de arriba, si no lo hace 
        'establecer un FilterIndex se usará por defecto automáticamente a 1
        fileDialogBox.FilterIndex = 3
        'esta línea le dice a la caja de diálogo de archivo de la carpeta en que debe comenzar en la primera         'He escogido a los usuarios de mi carpeta de documentos
        fileDialogBox.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal)

        'Check to see if the user clicked the open button
        If (fileDialogBox.ShowDialog() = DialogResult.OK) Then
            strFileName = fileDialogBox.FileName
            'Else
            '   MsgBox("You did not select a file!")
        End If

        'return the name of the file
        Return strFileName
    End Function
    Private Sub btnAdjuntar_Click(sender As Object, e As EventArgs) Handles btnAdjuntar.Click
        btnQuitarAdjunto.Enabled = True
        btnAdjuntar.Enabled = False
        'declare a string to the filename
        Dim strFileNameAndPath As String = AbrirArchivo()

        'check to see if they selected a file or just clicked cancel
        If (strFileNameAndPath = "") Then
            'Chastise the user for not selecting a file :)
            MsgBox("Usted no selecciono nigún archivo")
        Else
            txtNombreArchivo.Text = System.IO.Path.GetFileName(strFileNameAndPath)
            txtUbicacion.Text = System.IO.Path.GetDirectoryName(strFileNameAndPath)
            txtExtencionArchivo.Text = System.IO.Path.GetExtension(strFileNameAndPath)
            txtCreadoArchivo.Text = System.IO.File.GetCreationTime(strFileNameAndPath)
            txtModificoArchivo.Text = System.IO.File.GetLastWriteTime(strFileNameAndPath)
            'Begin doing whatever it is you would normally do with the file!
            'MsgBox("You selected this file: " & strFileNameAndPath & vbCrLf & _
            '   "The filename is: " & System.IO.Path.GetFileName(strFileNameAndPath) & vbCrLf & _
            '   "Located in: " & System.IO.Path.GetDirectoryName(strFileNameAndPath) & vbCrLf & _
            '   "It has the following extension: " & System.IO.Path.GetExtension(strFileNameAndPath) & vbCrLf & _
            '   "The file was created on " & System.IO.File.GetCreationTime(strFileNameAndPath) & vbCrLf & _
            '   "The file was last written to on " & System.IO.File.GetLastWriteTime(strFileNameAndPath) _
            ')
        End If

    End Sub
    Private Function QuitarAdjunto(ByVal Quitar As String)
        fileDialogBox = New OpenFileDialog
        txtNombreArchivo.Text = Quitar
        txtExtencionArchivo.Text = Quitar
        txtCreadoArchivo.Text = Quitar
        txtModificoArchivo.Text = Quitar
        txtUbicacion.Text = Quitar
        Return False
    End Function

    Private Sub btnQuitarAdjunto_Click(sender As Object, e As EventArgs) Handles btnQuitarAdjunto.Click
        Cursor = Cursors.AppStarting
        QuitarAdjunto("")
        Cursor = Cursors.Arrow
    End Sub
    Private Function VaciarCorreo(ByVal vaciar As String)
        txtNombre.Text = ""
        txtCorreo.Text = ""
        txtContraseña.Text = ""
        txtPara.Text = ""
        txtCC.Text = ""
        txtAsunto.Text = ""
        txtMensaje.Text = ""
        QuitarAdjunto("")
        Return False
    End Function
    Private Sub btnEnviarCorreo_Click(sender As Object, e As EventArgs) Handles btnEnviarCorreo.Click
        Cursor = Cursors.AppStarting
        If txtCorreo.Text = "" Or txtContraseña.Text = "" Or txtPara.Text = "" Then
            MessageBox.Show("No puede enviar el correo, verifique los datos ingresados", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If txtUbicacion.Text = "" Then
                If txtCC.Text = "" Then Enviar_Correo_SinCC() Else Enviar_Correo()
            Else
                If txtCC.Text = "" Then Enviar_Correo_SinCC() Else Enviar_Correo_Adjunto()
            End If
            VaciarCorreo("")
        End If
        Cursor = Cursors.Arrow
    End Sub

    Private Sub CerrarToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Close()
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Process.Start("www.JandC-ec.webs.com")
    End Sub

    Private Sub EnviarCorreoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnviarCorreoToolStripMenuItem.Click
        Cursor = Cursors.AppStarting
        Dim res = DialogResult
        res = MessageBox.Show("¿Desea enviar el correo?", "Enviar Correo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If res = Windows.Forms.DialogResult.Yes Then
            btnEnviarCorreo_Click(btnEnviarCorreo, e)
        Else

        End If

        Cursor = Cursors.Arrow

    End Sub

    Private Sub NuevoCorreoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoCorreoToolStripMenuItem.Click
        Cursor = Cursors.AppStarting
        Dim res = DialogResult
        res = MessageBox.Show("¿Desea crear un nuevo correo?", "Nuevo Correo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If res = Windows.Forms.DialogResult.Yes Then
            VaciarCorreo("")
        Else

        End If

        Cursor = Cursors.Arrow
    End Sub

    Private Sub VisitarPaginaWebToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisitarPaginaWebToolStripMenuItem.Click
        MessageBox.Show("Gracias por apoyar nuesro trabajo", "Muchas gracias Atte. Josué Chavez")
        Process.Start("www.JandC-ec.webs.com")
    End Sub

    Private Sub LikeEnFacebookToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LikeEnFacebookToolStripMenuItem.Click
        MessageBox.Show("Gracias por apoyar nuesro trabajo", "Muchas gracias Atte. Josué Chavez")
        Process.Start("www.facebook.com/JandC.Ecuador")
    End Sub

    Private Sub SíguenosEnTwitterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SíguenosEnTwitterToolStripMenuItem.Click
        MessageBox.Show("Gracias por apoyar nuesro trabajo", "Muchas gracias Atte. Josué Chavez")
        Process.Start("www.twitter.com/JandC_Ecuador")
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub FormEnviarCorreo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        NotifyIcon1.Visible = False
    End Sub
End Class