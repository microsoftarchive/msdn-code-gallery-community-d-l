Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

<ToolboxBitmap("LEX.bmp")> _
Public Class LabelEx
    'Inherit the methods, properties, and events from the Control base class.
    Inherits Control

    'Add all of the Property Backing Feilds for the Properties added to the LabelEx class
    Private _OutLinePen As New Pen(Color.Black)
    Private _BorderPen As New Pen(Color.Black)
    Private _CenterBrush As New SolidBrush(Color.White)
    Private _BackgroundBrush As New SolidBrush(Color.Transparent)
    Private _BorderStyle As BorderType = BorderType.None
    Private _Image As Bitmap = Nothing
    Private _ImageAlign As ContentAlignment = ContentAlignment.MiddleCenter
    Private _TextAlign As ContentAlignment = ContentAlignment.MiddleCenter
    Private _TextPatternImage As Bitmap = Nothing
    Private _TextPatternImageLayout As PatternLayout = PatternLayout.Stretch
    Private _ShadowBrush As New SolidBrush(Color.FromArgb(128, Color.Black))
    Private _ShadowPen As New Pen(Color.FromArgb(128, Color.Black))
    Private _ShadowColor As Color = Color.Black
    Private _ShowTextShadow As Boolean = False
    Private _ShadowPosition As ShadowArea = ShadowArea.BottomRight
    Private _ShadowDepth As Integer = 2
    Private _ShadowTransparency As Integer = 128
    Private _ShadowStyle As ShadowDrawingType = ShadowDrawingType.FillShadow
    Private _ForeColorTransparency As Integer = 255
    Private _OutlineThickness As Integer = 1

    'Declare the Enums used for some of the special selections we want to use for some of the properties

    ''' <summary>Enum of BorderTypes used for the Labels BorderStyle.</summary>
    Public Enum BorderType As Integer
        None = 0
        Squared = 1
        Rounded = 2
    End Enum

    ''' <summary>Enum of layout styles used for the Labels TextPaternImage.</summary>
    Public Enum PatternLayout As Integer
        Normal = 0
        Center = 1
        Stretch = 2
        Tile = 3
    End Enum

    ''' <summary>Enum of areas used for the Labels ShadowPosition.</summary>
    Public Enum ShadowArea As Integer
        TopLeft = 0
        TopRight = 1
        BottomLeft = 2
        BottomRight = 3
    End Enum

    ''' <summary>Enum of drawing types used for the Labels ShadowStyle.</summary>
    Public Enum ShadowDrawingType As Integer
        DrawShadow = 0
        FillShadow = 1
    End Enum

    'In the constructor we set all the styles we want the LabelEx control to have when it is created.
    'We also set a few properties that we want the control to have set by default when a new instance is created.
    Public Sub New()
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        Me.Font = New Font("Comic Sans MS", 18, FontStyle.Bold)
        Me.Size = New Size(130, 38)
        Me.ForeColor = Color.White
        Me.BackColor = Color.Transparent
    End Sub

    'Create all of the properties we want the control to have and Override the ones it already has if they need to be used for special reasons. 

    <Category("Appearance"), Description("The background color of the Label.")> _
    <Browsable(True), DefaultValue(GetType(Color), "Transparent")> _
    Public Overrides Property BackColor() As Color
        Get
            Return MyBase.BackColor
        End Get
        Set(ByVal value As Color)
            MyBase.BackColor = value
            _BackgroundBrush.Color = value
        End Set
    End Property

    <Category("Appearance"), Description("The center color of the text.")> _
    <Browsable(True), DefaultValue(GetType(Color), "White")> _
    Public Overrides Property ForeColor() As Color
        Get
            Return MyBase.ForeColor
        End Get
        Set(ByVal value As Color)
            MyBase.ForeColor = value
            If value = Color.Transparent Then _ForeColorTransparency = 0
            _CenterBrush.Color = Color.FromArgb(_ForeColorTransparency, value)
        End Set
    End Property

    <Category("Appearance"), Description("A value between 0 and 255 that sets the transparency of the ForeColor.")> _
    <Browsable(True), DefaultValue(255)> _
    Public Property ForeColorTransparency() As Integer
        Get
            Return _ForeColorTransparency
        End Get
        Set(ByVal value As Integer)
            If value > 255 Then value = 255
            If value < 0 Or Me.ForeColor = Color.Transparent Then value = 0
            _ForeColorTransparency = value
            _CenterBrush.Color = Color.FromArgb(value, Me.ForeColor)
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("Aligns the text to the left, right, top, or bottom of the Label.")> _
    <Browsable(True), DefaultValue(GetType(ContentAlignment), "MiddleCenter")> _
    Public Property TextAlign() As ContentAlignment
        Get
            Return _TextAlign
        End Get
        Set(ByVal value As ContentAlignment)
            _TextAlign = value
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("The Image for the Label.")> _
    <Browsable(True)> _
    Public Property Image() As Bitmap
        Get
            Return _Image
        End Get
        Set(ByVal value As Bitmap)
            _Image = value
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("Aligns the Image to the left, right, top, or bottom.")> _
    <Browsable(True), DefaultValue(GetType(ContentAlignment), "MiddleCenter")> _
    Public Property ImageAlign() As ContentAlignment
        Get
            Return _ImageAlign
        End Get
        Set(ByVal value As ContentAlignment)
            _ImageAlign = value
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("The outline color of the text.")> _
    <Browsable(True), DefaultValue(GetType(Color), "Black")> _
    Public Property OutlineColor() As Color
        Get
            Return _OutLinePen.Color
        End Get
        Set(ByVal value As Color)
            _OutLinePen.Color = value
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("The thickness of the text outline. Limited to a number between 1 and 10.")> _
    <Browsable(True), DefaultValue(1)> _
    Public Property OutlineThickness() As Integer
        Get
            Return _OutlineThickness
        End Get
        Set(ByVal value As Integer)
            If value < 1 Then value = 1 'Dont let the user set lower than 1
            If value > 10 Then value = 10 'Dont let the user set higher than 10
            _OutlineThickness = value
            _OutLinePen.Width = value
            _ShadowPen.Width = value
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("The color of the Labels border.")> _
    <Browsable(True), DefaultValue(GetType(Color), "Black")> _
    Public Property BorderColor() As Color
        Get
            Return _BorderPen.Color
        End Get
        Set(ByVal value As Color)
            If value = Color.Transparent Then
                value = _BorderPen.Color 'Set it back to the prior color
                'Alert the user that Color.Transparent is not supported for this property
                Throw New Exception("The border color does not support the Transparent color")
            End If
            _BorderPen.Color = value
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("The style of the border around the Label.")> _
    <Browsable(True), DefaultValue(GetType(BorderType), "None")> _
    Public Property BorderStyle() As BorderType
        Get
            Return _BorderStyle
        End Get
        Set(ByVal value As BorderType)
            _BorderStyle = value
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("An image used as a fill pattern for the center of the text.")> _
    <Browsable(True)> _
    Public Property TextPatternImage() As Bitmap
        Get
            Return _TextPatternImage
        End Get
        Set(ByVal value As Bitmap)
            _TextPatternImage = value
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("The layout of the pattern image inside the text.")> _
    <Browsable(True), DefaultValue(GetType(PatternLayout), "Stretch")> _
    Public Property TextPatternImageLayout() As PatternLayout
        Get
            Return _TextPatternImageLayout
        End Get
        Set(ByVal value As PatternLayout)
            _TextPatternImageLayout = value
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("Show a shadow behind the text.")> _
    <Browsable(True), DefaultValue(False)> _
    Public Property ShowTextShadow() As Boolean
        Get
            Return _ShowTextShadow
        End Get
        Set(ByVal value As Boolean)
            _ShowTextShadow = value
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("The color of the shadow behind the text.")> _
    <Browsable(True), DefaultValue(GetType(Color), "Black")> _
    Public Property ShadowColor() As Color
        Get
            Return _ShadowColor
        End Get
        Set(ByVal value As Color)
            If value = Color.Transparent Then
                value = _ShadowBrush.Color 'Set it back to the prior color
                'Alert the user that Color.Transparent is not supported for this property
                Throw New Exception("The Shadow color does not support using Color.Transparent")
            End If
            _ShadowColor = value
            _ShadowBrush.Color = Color.FromArgb(_ShadowTransparency, value)
            _ShadowPen.Color = Color.FromArgb(_ShadowTransparency, value)
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("The position of the shadow behind the text.")> _
    <Browsable(True), DefaultValue(GetType(ShadowArea), "BottomRight")> _
    Public Property ShadowPosition() As ShadowArea
        Get
            Return _ShadowPosition
        End Get
        Set(ByVal value As ShadowArea)
            _ShadowPosition = value
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("A value between 1-10 that controls the depth of the shadow behind the text.")> _
    <Browsable(True), DefaultValue(2)> _
    Public Property ShadowDepth() As Integer
        Get
            Return _ShadowDepth
        End Get
        Set(ByVal value As Integer)
            If value < 1 Then value = 1 'Dont let user set this property lower than 1
            If value > 10 Then value = 10 'Dont let user set this property higher than 10
            _ShadowDepth = value
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("A value between 0 and 255 that sets the transparency of the shadow.")> _
    <Browsable(True), DefaultValue(128)> _
    Public Property ShadowTransparency() As Integer
        Get
            Return _ShadowTransparency
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then value = 0 'Dont let user set this property lower than 0
            If value > 255 Then value = 255 'Dont let user set this property higher than 255
            _ShadowTransparency = value
            _ShadowBrush.Color = Color.FromArgb(value, _ShadowColor)
            _ShadowPen.Color = Color.FromArgb(value, _ShadowColor)
            Me.Refresh()
        End Set
    End Property

    <Category("Appearance"), Description("The style used to draw the shadow.")> _
    <Browsable(True), DefaultValue(GetType(ShadowDrawingType), "FillShadow")> _
    Public Property ShadowStyle() As ShadowDrawingType
        Get
            Return _ShadowStyle
        End Get
        Set(ByVal value As ShadowDrawingType)
            _ShadowStyle = value
            Me.Refresh()
        End Set
    End Property


    'Use the OnPaint overrides sub to paint the control to match how all the properties settings have been set by the user
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        With e.Graphics
            'Fill the background with the BackColor color
            .FillRectangle(_BackgroundBrush, New Rectangle(0, 0, Me.ClientSize.Width, Me.ClientSize.Height))

            'If the BackgroundImage property has been set to an image then draw the BackgroundImage
            If Me.BackgroundImage IsNot Nothing Then
                DrawBackImage(e.Graphics)
            End If

            'If the Image property has been set to an image then draw the image on the control
            If _Image IsNot Nothing Then
                .DrawImage(_Image, AlignImage(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)))
            End If

            'If the Text property has been assigned any text then draw the text on the control
            If Me.Text.Trim <> "" Then
                'Set the smothing mode of the graphics to make things look smother
                .TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
                .SmoothingMode = SmoothingMode.AntiAlias

                'The Drawing2D.GraphicsPath used for drawing and/or filling the text
                Using pth As New Drawing2D.GraphicsPath

                    'The StringFormat used to align the text in the Label
                    Using sf As New StringFormat
                        'Use (ta) which is an integer value of the ContentAlignment integer enum to set the
                        'Alignment of the text that will be added to the Drawing2D.GraphicsPath
                        Dim ta As ContentAlignment = Me.TextAlign
                        If ta < 8 Then
                            sf.LineAlignment = StringAlignment.Near
                        ElseIf ta < 128 Then
                            sf.LineAlignment = StringAlignment.Center
                            ta = CType(ta / 16, ContentAlignment)
                        Else
                            sf.LineAlignment = StringAlignment.Far
                            ta = CType(ta / 256, ContentAlignment)
                        End If
                        If ta = ContentAlignment.TopLeft Then
                            sf.Alignment = StringAlignment.Near
                        ElseIf ta = ContentAlignment.TopCenter Then
                            sf.Alignment = StringAlignment.Center
                        ElseIf ta = ContentAlignment.TopRight Then
                            sf.Alignment = StringAlignment.Far
                        End If
                        'Add the text to the Drawing2D.GraphicsPath using the StringFormat
                        pth.AddString(Me.Text, Me.Font.FontFamily, CInt(Me.Font.Style), CSng((.DpiY * Me.Font.Size) / 72), New Rectangle(Me.Padding.Left, Me.Padding.Top, (Me.ClientSize.Width - 1) - (Me.Padding.Left + Me.Padding.Right), (Me.ClientSize.Height - 1) - (Me.Padding.Top + Me.Padding.Bottom)), sf)
                    End Using

                    'If the ShowTextShadow property is set to true then draw the shadow
                    If _ShowTextShadow Then
                        'Use the ShadowPosition property to set the Graphics.TranslateTransform to draw the
                        'shadow at the correct offset position.
                        If _ShadowPosition = ShadowArea.TopLeft Then
                            .TranslateTransform(-_ShadowDepth, -_ShadowDepth)
                        ElseIf _ShadowPosition = ShadowArea.TopRight Then
                            .TranslateTransform(+_ShadowDepth, -_ShadowDepth)
                        ElseIf _ShadowPosition = ShadowArea.BottomLeft Then
                            .TranslateTransform(-_ShadowDepth, +_ShadowDepth)
                        Else
                            .TranslateTransform(+_ShadowDepth, +_ShadowDepth)
                        End If

                        If _ShadowStyle = ShadowDrawingType.DrawShadow Then
                            'Draw the Drawing2D.GraphicsPath with the _ShadowPen that is set to the ShadowColor having the ShadowTransparency
                            .DrawPath(_ShadowPen, pth) 'Draws the shadow
                        Else
                            'Fill the Drawing2D.GraphicsPath with the _ShadowBrush that is set to the ShadowColor having the ShadowTransparency
                            .FillPath(_ShadowBrush, pth) 'Draws the shadow
                        End If

                        'Now use the Graphics.TranslateTransform to shift the graphics back in the opposite
                        'direction before Drawing and Filling the Drawing2D.GraphicsPath again with text colors
                        If _ShadowPosition = ShadowArea.TopLeft Then
                            .TranslateTransform(+(_ShadowDepth * 2), +(_ShadowDepth * 2))
                        ElseIf _ShadowPosition = ShadowArea.TopRight Then
                            .TranslateTransform(-(_ShadowDepth * 2), +(_ShadowDepth * 2))
                        ElseIf _ShadowPosition = ShadowArea.BottomLeft Then
                            .TranslateTransform(+(_ShadowDepth * 2), -(_ShadowDepth * 2))
                        Else
                            .TranslateTransform(-(_ShadowDepth * 2), -(_ShadowDepth * 2))
                        End If
                    End If

                    'If the TextPatternImage property has been set to an image then fill the center of the text with the image
                    'else the center will be filled with a soloid color of the ForeColor property.
                    If _TextPatternImage IsNot Nothing Then
                        'Use the TextPatternImageLayout property to resize and/or position the TextPatternImage
                        Dim br As Rectangle = Nothing
                        If _TextPatternImageLayout = PatternLayout.Normal Or _TextPatternImageLayout = PatternLayout.Tile Then
                            br = New Rectangle(CInt(pth.GetBounds.X) + 1, CInt(pth.GetBounds.Y + 1), _TextPatternImage.Width + 1, _TextPatternImage.Height + 1)
                        ElseIf _TextPatternImageLayout = PatternLayout.Center Then
                            Dim xx As Integer = CInt((pth.GetBounds.X + 1) + ((pth.GetBounds.Width / 2) - (_TextPatternImage.Width / 2)))
                            Dim yy As Integer = CInt((pth.GetBounds.Y + 1) + ((pth.GetBounds.Height / 2) - (_TextPatternImage.Height / 2)))
                            br = New Rectangle(xx, yy, _TextPatternImage.Width + 1, _TextPatternImage.Height + 1)
                        ElseIf _TextPatternImageLayout = PatternLayout.Stretch Then
                            br = New Rectangle(CInt(pth.GetBounds.X) + 1, CInt(pth.GetBounds.Y + 1), CInt(pth.GetBounds.Width) + 1, CInt(pth.GetBounds.Height) + 1)
                        End If
                        Using patBmp As New Bitmap(_TextPatternImage, br.Width, br.Height)
                            'Use a TextureBrush with the TextPatternImage assigned as the texture image
                            Using tb As New TextureBrush(patBmp)
                                'If the TextPatternImageLayout property is not set to Tile then set the set the
                                'TextureBrush`s WrapMode to Clamp to stop it from tiling the image.
                                If Not _TextPatternImageLayout = PatternLayout.Tile Then tb.WrapMode = WrapMode.Clamp
                                tb.TranslateTransform(br.X, br.Y)
                                'Fill the GraphicsPath with the TextureBrush.
                                .FillPath(tb, pth)
                            End Using
                        End Using
                    Else
                        'Fill the GraphicsPath with a soloid color of the ForeColor property.
                        .FillPath(_CenterBrush, pth)
                    End If
                    'Draw the GraphicsPath with the OutlineColor.
                    .DrawPath(_OutLinePen, pth)
                End Using
            End If

            'If the BorderStyle property is other than None then call the DrawBorder sub to draw the border
            If _BorderStyle <> BorderType.None Then
                DrawLabelBorder(e.Graphics, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
            End If
        End With
    End Sub

    'A private sub used to position, resize, and draw the BackgroundImage according to the BackgroundImageLayout
    Private Sub DrawBackImage(ByVal g As Graphics)
        If Me.BackgroundImageLayout = ImageLayout.None Then
            g.DrawImage(Me.BackgroundImage, 0, 0, Me.BackgroundImage.Width, Me.BackgroundImage.Height)
        ElseIf Me.BackgroundImageLayout = ImageLayout.Tile Then
            Dim tc As Integer = CInt(Math.Ceiling(Me.Width / Me.BackgroundImage.Width))
            Dim tr As Integer = CInt(Math.Ceiling(Me.Height / Me.BackgroundImage.Height))
            For y As Integer = 0 To tr - 1
                For x As Integer = 0 To tc - 1
                    g.DrawImage(Me.BackgroundImage, (x * Me.BackgroundImage.Width), (y * Me.BackgroundImage.Height), Me.BackgroundImage.Width, Me.BackgroundImage.Height)
                Next
            Next
        ElseIf Me.BackgroundImageLayout = ImageLayout.Center Then
            Dim xx As Integer = CInt((Me.Width / 2) - (Me.BackgroundImage.Width / 2))
            Dim yy As Integer = CInt((Me.Height / 2) - (Me.BackgroundImage.Height / 2))
            g.DrawImage(Me.BackgroundImage, xx, yy, Me.BackgroundImage.Width, Me.BackgroundImage.Height)
        ElseIf Me.BackgroundImageLayout = ImageLayout.Stretch Then
            g.DrawImage(Me.BackgroundImage, 0, 0, Me.Width, Me.Height)
        ElseIf Me.BackgroundImageLayout = ImageLayout.Zoom Then
            Dim meratio As Double = Me.Width / Me.Height
            Dim imgratio As Double = Me.BackgroundImage.Width / Me.BackgroundImage.Height
            Dim imgrect As New Rectangle(0, 0, Me.Width, Me.Height)
            If imgratio > meratio Then
                imgrect.Width = Me.Width
                imgrect.Height = CInt(Me.Width / imgratio)
            ElseIf imgratio < meratio Then
                imgrect.Height = Me.Height
                imgrect.Width = CInt(Me.Height * imgratio)
            End If
            imgrect.X = CInt((Me.Width / 2) - (imgrect.Width / 2))
            imgrect.Y = CInt((Me.Height / 2) - (imgrect.Height / 2))
            g.DrawImage(Me.BackgroundImage, imgrect)
        End If
    End Sub

    'A private sub used for drawing the Border part of the control
    Private Sub DrawLabelBorder(ByVal g As Graphics, ByVal rec As Rectangle)
        'If the ShowTextShadow property is true and the Text property is not an empty string then because of the
        'prior calls to the Graphics.TranslateTransform used for the shadow effect the Graphics must be shifted
        'back to its center position before drawing the border.
        If _ShowTextShadow And Me.Text.Trim <> "" Then
            If _ShadowPosition = ShadowArea.TopLeft Then
                g.TranslateTransform(-_ShadowDepth, -_ShadowDepth)
            ElseIf _ShadowPosition = ShadowArea.TopRight Then
                g.TranslateTransform(+_ShadowDepth, -_ShadowDepth)
            ElseIf _ShadowPosition = ShadowArea.BottomLeft Then
                g.TranslateTransform(-_ShadowDepth, +_ShadowDepth)
            Else
                g.TranslateTransform(+_ShadowDepth, +_ShadowDepth)
            End If
        End If

        'If the BorderStyle property is set to Rounded then draw the border with rounded corners
        'else just draw a Rectangle
        If Me.BorderStyle = BorderType.Rounded Then
            g.SmoothingMode = SmoothingMode.AntiAlias
            Using gp As New Drawing2D.GraphicsPath
                Dim rad As Integer = CInt(rec.Height / 3)
                If rec.Width < rec.Height Then rad = CInt(rec.Width / 3)
                gp.AddArc(rec.X, rec.Y, rad, rad, 180, 90)
                gp.AddArc(rec.Right - (rad), rec.Y, rad, rad, 270, 90)
                gp.AddArc(rec.Right - (rad), rec.Bottom - (rad), rad, rad, 0, 90)
                gp.AddArc(rec.X, rec.Bottom - (rad), rad, rad, 90, 90)
                gp.CloseFigure()
                g.DrawPath(_BorderPen, gp)
            End Using
        Else
            g.DrawRectangle(_BorderPen, rec.X, rec.Y, rec.Width, rec.Height)
        End If
    End Sub

    'A private function used for calculating the rectagle area of the Label to draw the Image in
    Private Function AlignImage(ByVal Rect As Rectangle) As Rectangle
        'Use the value of the ContentAlignment assigned to the ImageAlign property to set the X and Y
        'values of the returned rectangle for the image.
        Dim xp, yp As Integer
        Dim ia As ContentAlignment = _ImageAlign
        If ia < 8 Then
            yp = 0 + Me.Padding.Top
        ElseIf ia < 128 Then
            yp = CInt(Rect.Height / 2) - CInt(_Image.Height / 2)
            ia = CType(ia / 16, ContentAlignment)
        Else
            yp = Rect.Height - _Image.Height - Me.Padding.Bottom
            ia = CType(ia / 256, ContentAlignment)
        End If
        If ia = ContentAlignment.TopLeft Then
            xp = 0 + Me.Padding.Left
        ElseIf ia = ContentAlignment.TopCenter Then
            xp = CInt(Rect.Width / 2) - CInt(_Image.Width / 2)
        ElseIf ia = ContentAlignment.TopRight Then
            xp = Rect.Width - _Image.Width - Me.Padding.Right
        End If
        Return New Rectangle(xp, yp, _Image.Width, _Image.Height)
    End Function

    'Need to use the OnTextChanged overrides sub to make the Label repaint itself when the text is changed
    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
        Me.Refresh()
        MyBase.OnTextChanged(e)
    End Sub

    'Need to use the Dispose Overides sub to make sure all of the New brushes and pens created for the
    'property backing feilds are disposed.
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Me._BackgroundBrush.Dispose()
        Me._BorderPen.Dispose()
        Me._CenterBrush.Dispose()
        Me._OutLinePen.Dispose()
        Me._ShadowBrush.Dispose()
        Me._ShadowPen.Dispose()
        MyBase.Dispose(disposing)
    End Sub
End Class
