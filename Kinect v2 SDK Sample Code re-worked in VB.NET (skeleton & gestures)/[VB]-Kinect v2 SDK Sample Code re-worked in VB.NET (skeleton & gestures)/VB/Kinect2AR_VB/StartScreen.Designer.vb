<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StartScreen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StartScreen))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.picConn = New System.Windows.Forms.PictureBox()
        Me.chkShowSkel = New System.Windows.Forms.CheckBox()
        Me.lblSensorStatus = New System.Windows.Forms.Label()
        Me.lblBodiesStatus = New System.Windows.Forms.Label()
        Me.picSkeleton = New System.Windows.Forms.PictureBox()
        Me.txtGestures = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picConn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSkeleton, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.KinectVB.My.Resources.Resources.Logo
        Me.PictureBox1.Location = New System.Drawing.Point(9, 14)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Padding = New System.Windows.Forms.Padding(3)
        Me.PictureBox1.Size = New System.Drawing.Size(184, 79)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'picConn
        '
        Me.picConn.BackColor = System.Drawing.Color.MistyRose
        Me.picConn.ErrorImage = Nothing
        Me.picConn.Image = Global.KinectVB.My.Resources.Resources.disconnected
        Me.picConn.InitialImage = Nothing
        Me.picConn.Location = New System.Drawing.Point(9, 106)
        Me.picConn.Margin = New System.Windows.Forms.Padding(0)
        Me.picConn.Name = "picConn"
        Me.picConn.Size = New System.Drawing.Size(83, 83)
        Me.picConn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picConn.TabIndex = 6
        Me.picConn.TabStop = False
        '
        'chkShowSkel
        '
        Me.chkShowSkel.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkShowSkel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShowSkel.Image = Global.KinectVB.My.Resources.Resources.no_stickman
        Me.chkShowSkel.Location = New System.Drawing.Point(9, 199)
        Me.chkShowSkel.Margin = New System.Windows.Forms.Padding(0)
        Me.chkShowSkel.Name = "chkShowSkel"
        Me.chkShowSkel.Size = New System.Drawing.Size(83, 139)
        Me.chkShowSkel.TabIndex = 1
        Me.chkShowSkel.Text = "OFF"
        Me.chkShowSkel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.chkShowSkel.UseVisualStyleBackColor = True
        '
        'lblSensorStatus
        '
        Me.lblSensorStatus.BackColor = System.Drawing.Color.MistyRose
        Me.lblSensorStatus.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSensorStatus.ForeColor = System.Drawing.Color.Red
        Me.lblSensorStatus.Location = New System.Drawing.Point(104, 106)
        Me.lblSensorStatus.Name = "lblSensorStatus"
        Me.lblSensorStatus.Size = New System.Drawing.Size(89, 83)
        Me.lblSensorStatus.TabIndex = 0
        Me.lblSensorStatus.Text = "Kinect not Found"
        Me.lblSensorStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblBodiesStatus
        '
        Me.lblBodiesStatus.BackColor = System.Drawing.Color.MistyRose
        Me.lblBodiesStatus.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBodiesStatus.ForeColor = System.Drawing.Color.Red
        Me.lblBodiesStatus.Location = New System.Drawing.Point(104, 199)
        Me.lblBodiesStatus.Name = "lblBodiesStatus"
        Me.lblBodiesStatus.Size = New System.Drawing.Size(89, 139)
        Me.lblBodiesStatus.TabIndex = 2
        Me.lblBodiesStatus.Text = "Body" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Tracking" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Disabled"
        Me.lblBodiesStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picSkeleton
        '
        Me.picSkeleton.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picSkeleton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picSkeleton.Location = New System.Drawing.Point(199, 14)
        Me.picSkeleton.Name = "picSkeleton"
        Me.picSkeleton.Size = New System.Drawing.Size(573, 451)
        Me.picSkeleton.TabIndex = 11
        Me.picSkeleton.TabStop = False
        '
        'txtGestures
        '
        Me.txtGestures.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGestures.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGestures.Location = New System.Drawing.Point(3, 18)
        Me.txtGestures.Multiline = True
        Me.txtGestures.Name = "txtGestures"
        Me.txtGestures.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtGestures.Size = New System.Drawing.Size(757, 137)
        Me.txtGestures.TabIndex = 0
        Me.txtGestures.Text = "Time (ms),Standing,Right Kick (X),Right Kick,Left Kick (X),Left Kick" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtGestures)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(9, 471)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(763, 158)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Recognised Gestures"
        '
        'StartScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(784, 641)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.picSkeleton)
        Me.Controls.Add(Me.lblBodiesStatus)
        Me.Controls.Add(Me.picConn)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblSensorStatus)
        Me.Controls.Add(Me.chkShowSkel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(800, 680)
        Me.Name = "StartScreen"
        Me.Text = "Kinect Action Responses (Kim Schenke)"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picConn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSkeleton, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents picConn As System.Windows.Forms.PictureBox
    Friend WithEvents chkShowSkel As System.Windows.Forms.CheckBox
    Friend WithEvents lblSensorStatus As System.Windows.Forms.Label
    Friend WithEvents lblBodiesStatus As System.Windows.Forms.Label
    Friend WithEvents picSkeleton As System.Windows.Forms.PictureBox
    Friend WithEvents txtGestures As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox

End Class
