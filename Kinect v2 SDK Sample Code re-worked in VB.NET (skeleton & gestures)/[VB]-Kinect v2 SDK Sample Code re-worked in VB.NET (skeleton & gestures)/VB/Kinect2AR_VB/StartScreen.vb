Imports Microsoft.Kinect
Imports Microsoft.Kinect.VisualGestureBuilder

Public Class StartScreen

    ' New line character shorthand
    Dim NL As String = vbNewLine

    ' Shared Kinect Sensor Object
    Friend Shared kSensor As KinectSensor

    ' Response timer (shared) for recording gestures


    ' Kinect bodies (all 6 and only the active ones)
    Private allBods(5) As Body
    Private activeBods As List(Of Body)
    Private firstActiveBod As Body

    ' Shared Reader for body frames
    Friend Shared bodyFrameReader As BodyFrameReader

    ' Shared SkeletalTracker object which tracks detected Kinect bodies as skeletons with to XYZ co-ordinates
    Friend Shared skelTracker As SkeletalTracker

    ' Gesture detector for the tracked body (a custom-made class in this project)
    Friend Shared gestureDetector As GestureDetector

    ' Track skeletal data (or not) flag
    Private trackBodies As Boolean = False

    ' Screens for a two screen set-up
    Private primaryScreen As Screen
    Private secondScreen As Screen

#Region "Form"

    Private Sub StartScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Common.rTimer = New Stopwatch
        primaryScreen = Screen.PrimaryScreen
        If Screen.AllScreens.Where(Function(s) Not s.Primary).Count > 0 Then
            secondScreen = Screen.AllScreens.Where(Function(s) Not s.Primary).First
        Else
            secondScreen = Screen.PrimaryScreen
        End If
        ' Want smoothest re-draws
        Me.DoubleBuffered = True
        ' Get the default Kinect sensor (if attached)
        kSensor = KinectSensor.GetDefault
        ' Add an event handler to cover sensor availability changes (connected or not)
        AddHandler kSensor.IsAvailableChanged, AddressOf Sensor_IsAvailableChanged
        ' Try to open the sensor for reading data
        kSensor.Open()
        ' Initialize the skeletal tracker for this sensor
        skelTracker = New SkeletalTracker(kSensor)
        ' Gesture tracker
        gestureDetector = New GestureDetector(kSensor, txtGestures)
        ' open the reader for the body frames
        bodyFrameReader = kSensor.BodyFrameSource.OpenReader()
        ' Add an event handler to the reader to fire when a Kinect frame arrives (every 1/30s)
        AddHandler bodyFrameReader.FrameArrived, AddressOf Reader_BodyFrameArrived
        ' Show this form on the primary display and the stimulus form to the secondary
        BindToScreen(Me, primaryScreen)
    End Sub

    ' Show or hide skeletal display
    Private Sub chkShowSkel_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowSkel.CheckedChanged
        If chkShowSkel.Checked Then
            trackBodies = True
            chkShowSkel.Image = My.Resources.stickman
            chkShowSkel.Text = "ON"
            txtGestures.Text = "Time (ms),Standing,Right Kick (X),Right Kick,Left Kick (X),Left Kick" & NL
            Common.rTimer.Restart()
        Else
            trackBodies = False
            chkShowSkel.Image = My.Resources.no_stickman
            chkShowSkel.Text = "OFF"
            Common.rTimer.Reset()
        End If
    End Sub

    ' Show a screen on a certain display
    Private Sub BindToScreen(ByVal frm As Form, scr As Screen)
        Dim formPos As Point = frm.Location
        Dim formOffset = GetFormOffsetPosition(frm)
        Dim newPos = scr.Bounds.Location + formOffset
        frm.Location = newPos
    End Sub

#End Region

#Region "Kinect Sensor"

    ' Handles the event when a physical sensor becomes unavailable/available (e.g. paused, closed, unplugged)
    Private Sub Sensor_IsAvailableChanged(sender As Object, e As IsAvailableChangedEventArgs)
        If kSensor.IsAvailable Then
            lblSensorStatus.Text = "Kinect" & NL & "Found"
            lblSensorStatus.ForeColor = Color.Green
            lblSensorStatus.BackColor = Color.PaleGreen
            picConn.Image = My.Resources.connected
            picConn.BackColor = Color.PaleGreen
        Else
            lblSensorStatus.Text = "Kinect" & NL & "not" & NL & "Found"
            lblSensorStatus.ForeColor = Color.Red
            lblSensorStatus.BackColor = Color.MistyRose
            picConn.Image = My.Resources.disconnected
            picConn.BackColor = Color.MistyRose
        End If
    End Sub

    ' Handles the body frame data arriving from the sensor and updates the associated gesture detector object for each body
    Private Sub Reader_BodyFrameArrived(sender As Object, e As BodyFrameArrivedEventArgs)
        ' Get a temporary, disposable reference to the acquired Kinect body frame
        Using bodyFrame As BodyFrame = e.FrameReference.AcquireFrame
            If Not trackBodies OrElse IsNothing(bodyFrame) Then
                ' Not tracking bodies or no body frame available to track - pause the gesture detector and update status only
                gestureDetector.IsPaused = True
                UpdateTrackingStatus()
            Else
                ' The first time GetAndRefreshBodyData is called, Kinect will allocate each Body in the array.
                ' As long as those body objects are not disposed and not set to null the body objects will be re-used.
                bodyFrame.GetAndRefreshBodyData(allBods)
                ' Find the bodies that are being actively tracked
                activeBods = skelTracker.GetActiveBodies(allBods)
                If activeBods.Count = 0 Then
                    ' No active bodies, so no need to track
                    gestureDetector.IsPaused = True
                    UpdateTrackingStatus(0)
                Else
                    ' Enable gesture detection just for the first active body
                    gestureDetector.TrackingId = activeBods(0).TrackingId
                    gestureDetector.IsPaused = False
                    UpdateTrackingStatus(activeBods.Count)
                    ' Draw just the first active body skeleton using bitmap image generated via the SkeletalTracker
                    firstActiveBod = activeBods(0)
                    Dim image As Bitmap = skelTracker.DrawSkeleton(firstActiveBod, picSkeleton.Width, picSkeleton.Height)
                    picSkeleton.Image = image
                End If
            End If
        End Using
    End Sub

    Private Function GetKinectCapabilities() As String
        Dim capStr As String = "Kinect sensor detected with SensorID = " & kSensor.UniqueKinectId & NL
        If kSensor.KinectCapabilities.HasFlag(KinectCapabilities.Gamechat) Then
            capStr &= "Kinect has In-Game Chat Capabilities" & NL
        End If
        If kSensor.KinectCapabilities.HasFlag(KinectCapabilities.Expressions) Then
            capStr &= "Kinect has Facial Expression Recognition Capabilities" & NL
        End If
        If kSensor.KinectCapabilities.HasFlag(KinectCapabilities.Face) Then
            capStr &= "Kinect has Facial Recognition Capabilities" & NL
        End If
        If kSensor.KinectCapabilities.HasFlag(KinectCapabilities.Audio) Then
            capStr &= "Kinect has Audio Capabilities" & NL
        End If
        If kSensor.KinectCapabilities.HasFlag(KinectCapabilities.Vision) Then
            capStr &= "Kinect has Vision Capabilities" & NL
        End If
        If kSensor.KinectCapabilities = KinectCapabilities.None Then
            capStr = "Kinect detected but is has no capabilities - is it broken?"
        End If
        Return capStr
    End Function

#End Region

#Region "Helper Methods"

    ' Determine the given form's offset position on its screen
    Private Function GetFormOffsetPosition(ByVal frm As Form) As Point
        Dim formPos As Point = frm.Location
        Dim currScreen = If(primaryScreen.Bounds.Contains(formPos), primaryScreen, secondScreen)
        Dim offset As Point = formPos - currScreen.Bounds.Location
        Return offset
    End Function

    ' Method which updates the tracking status label
    Private Sub UpdateTrackingStatus(Optional ByVal bodyCount As Integer = 0)
        If Not trackBodies Then
            lblBodiesStatus.Text = "Body" & NL & "Tracking" & NL & "Disabled"
            lblBodiesStatus.BackColor = Color.MistyRose
            lblBodiesStatus.ForeColor = Color.Red
        Else
            If bodyCount = 0 Then
                gestureDetector.IsPaused = True
                lblBodiesStatus.Text = "No Bodies" & NL & "Found" & NL & "for" & NL & "Tracking"
                lblBodiesStatus.BackColor = Color.LightBlue
                lblBodiesStatus.ForeColor = Color.Navy
            Else
                ' Got at least one active body, so track the first body for gestures and update the status label
                lblBodiesStatus.Text = bodyCount & NL & "Bodies" & NL & "Found" & NL & "Tracking" & NL & "1st One"
                lblBodiesStatus.BackColor = Color.LightGreen
                lblBodiesStatus.ForeColor = Color.Green
            End If
        End If
    End Sub

#End Region

End Class
