Imports Microsoft.Kinect
Imports System.Windows

' Class which visualizes the Kinect Body stream for display in the UI
Public NotInheritable Class SkeletalTracker
    '
    ' Class constants
    '
    ' Radius of drawn hand circles (filled)
    Private Const HandCircleRadius As Double = 10
    ' Radius of drawn joint circles
    Private Const JointCircleRadius As Double = 5
    ' Thickness of bones
    Private Const BonePenThickness As Double = 5
    ' Thickness of clip edge rectangles
    Private Const ClipBoundsThickness As Double = 5
    Private ReadOnly clipBoundsPen As New Pen(Brushes.Red, ClipBoundsThickness)
    ' Constant for clamping Z values of camera space points from being negative
    Private Const InferredZPositionClamp As Single = 0.1F
    ' Brush used for drawing hands that are currently tracked as closed
    Private ReadOnly handClosedFill As Brush = Brushes.Red
    ' Brush used for drawing hands that are currently tracked as opened
    Private ReadOnly handOpenFill As Brush = Brushes.Blue
    ' Brush used for drawing hands that are currently tracked as in lasso (pointer) position
    Private ReadOnly handLassoFill As Brush = Brushes.Orange
    ' Brush used for drawing joints that are currently tracked
    Private ReadOnly trackedJointPen As New Pen(Color.FromArgb(255, 68, 192, 68), 3)
    ' Brush used for drawing joints that are currently inferred
    Private ReadOnly inferredJointPen As New Pen(Brushes.Yellow, 3)
    ' Pen used for drawing bones that are currently inferred (thin line)
    Private ReadOnly inferredBonePen As Pen = New Pen(Brushes.DarkGray, 2)
    ' Kinect coordinate mapper to map one type of point to another
    Private coordinateMapper As CoordinateMapper
    ' Definition of bones as interconnects between two points (tuples of two joints)
    Private bones As List(Of Tuple(Of JointType, JointType))
    ' A bitmap image to hold any display we might paint skeletons to
    Private drawImg As Bitmap
    ' The graphics object linked to the bitmap
    Private drawGraph As Graphics
    ' Width of display (depth space)
    Private displayWidth As Integer
    ' Height of display (depth space)
    Private displayHeight As Integer
    ' List of colours for each body tracked
    Private bodyColors As List(Of Pen)

    ' Class Constructor
    Public Sub New(ByVal kinectSensor As KinectSensor)
        ' Set up the Kinect co-ordinate mapper
        coordinateMapper = kinectSensor.CoordinateMapper

        ' Get the depth (display) extents
        Dim frameDesc As FrameDescription = kinectSensor.DepthFrameSource.FrameDescription

        ' Get the bounds of the joint space
        displayWidth = frameDesc.Width
        displayHeight = frameDesc.Height

        ' The bones - a list of joint pairs (the bone is the connection between the 2 joints)
        bones = New List(Of Tuple(Of JointType, JointType))

        ' Torso
        bones.Add(Tuple.Create(JointType.Head, JointType.Neck))
        bones.Add(Tuple.Create(JointType.Neck, JointType.SpineShoulder))
        bones.Add(Tuple.Create(JointType.SpineShoulder, JointType.SpineMid))
        bones.Add(Tuple.Create(JointType.SpineMid, JointType.SpineBase))
        bones.Add(Tuple.Create(JointType.SpineShoulder, JointType.ShoulderRight))
        bones.Add(Tuple.Create(JointType.SpineShoulder, JointType.ShoulderLeft))
        bones.Add(Tuple.Create(JointType.SpineBase, JointType.HipRight))
        bones.Add(Tuple.Create(JointType.SpineBase, JointType.HipLeft))

        ' Right Arm
        bones.Add(Tuple.Create(JointType.ShoulderRight, JointType.ElbowRight))
        bones.Add(Tuple.Create(JointType.ElbowRight, JointType.WristRight))
        bones.Add(Tuple.Create(JointType.WristRight, JointType.HandRight))
        bones.Add(Tuple.Create(JointType.HandRight, JointType.HandTipRight))
        bones.Add(Tuple.Create(JointType.WristRight, JointType.ThumbRight))

        ' Left Arm
        bones.Add(Tuple.Create(JointType.ShoulderLeft, JointType.ElbowLeft))
        bones.Add(Tuple.Create(JointType.ElbowLeft, JointType.WristLeft))
        bones.Add(Tuple.Create(JointType.WristLeft, JointType.HandLeft))
        bones.Add(Tuple.Create(JointType.HandLeft, JointType.HandTipLeft))
        bones.Add(Tuple.Create(JointType.WristLeft, JointType.ThumbLeft))

        ' Right Leg
        bones.Add(Tuple.Create(JointType.HipRight, JointType.KneeRight))
        bones.Add(Tuple.Create(JointType.KneeRight, JointType.AnkleRight))
        bones.Add(Tuple.Create(JointType.AnkleRight, JointType.FootRight))

        ' Left Leg
        bones.Add(Tuple.Create(JointType.HipLeft, JointType.KneeLeft))
        bones.Add(Tuple.Create(JointType.KneeLeft, JointType.AnkleLeft))
        bones.Add(Tuple.Create(JointType.AnkleLeft, JointType.FootLeft))

        ' populate body colours, one for each BodyIndex
        bodyColors = New List(Of Pen)
        bodyColors.Add(New Pen(Brushes.DarkRed, BonePenThickness))
        bodyColors.Add(New Pen(Brushes.DarkOrange, BonePenThickness))
        bodyColors.Add(New Pen(Brushes.DarkGreen, BonePenThickness))
        bodyColors.Add(New Pen(Brushes.DarkBlue, BonePenThickness))
        bodyColors.Add(New Pen(Brushes.Indigo, BonePenThickness))
        bodyColors.Add(New Pen(Brushes.Violet, BonePenThickness))

    End Sub

    ' Determines the active bodies in the Kinect sensor view and returns them as a list
    Public Function GetActiveBodies(ByVal bodies As Body()) As List(Of Body)
        Dim activeBodies As New List(Of Body)
        ' Cycle through each body / person found in the field of view
        For Each bod As Body In bodies
            If bod.IsTracked Then
                activeBodies.Add(bod)
            End If
        Next
        Return activeBodies
    End Function

    ' Determines the 1st active body and returns it as a single body
    Public Function GetFirstActiveBody(ByVal bodies As Body()) As Body
        ' Cycle through each body / person found in the field of view
        For Each bod As Body In bodies
            If bod.IsTracked Then
                Return bod
            End If
        Next
        Return Nothing
    End Function

#Region "Draw Skeletons"

    ' Method which processes multiple 2D skeletons from a Kinect bodies into a bitmap image of specified height
    Public Function DrawSkeletons(ByVal activeBodies As List(Of Body), ByVal imgW As Integer, ByVal imgH As Integer) As Bitmap
        ' Set up the drawing area
        displayWidth = imgW : displayHeight = imgH
        drawImg = New Bitmap(imgW, imgH)
        drawGraph = Graphics.FromImage(drawImg)
        Dim penIndex As Integer = 0
        ' Cycle through each body / person found in the field of view
        For Each bod As Body In activeBodies
            DrawClippedEdges(bod)
            Dim drawPen As Pen = bodyColors(penIndex) : penIndex += 1
            Dim _3DJoints As IReadOnlyDictionary(Of JointType, Joint) = bod.Joints
            ' convert the joint points to a 2D (flat) display space
            Dim jointPoints As New Dictionary(Of JointType, Point)
            For Each jType As JointType In _3DJoints.Keys
                ' sometimes the depth(Z) of an inferred joint may show as negative
                ' clamp down to 0.1f to prevent coordinate mapper from returning (-Infinity, -Infinity)
                Dim _3DPoint As CameraSpacePoint = _3DJoints(jType).Position
                If _3DPoint.Z <= InferredZPositionClamp Then _3DPoint.Z = InferredZPositionClamp
                Dim depthPoint As DepthSpacePoint = coordinateMapper.MapCameraPointToDepthSpace(_3DPoint)
                jointPoints.Add(jType, New Point(depthPoint.X, depthPoint.Y))
            Next
            ' Draw the body
            DrawBody(_3DJoints, jointPoints, drawPen)
            ' Draw the left hand
            DrawHand(bod.HandLeftState, jointPoints(JointType.HandLeft))
            ' Draw the right hand
            DrawHand(bod.HandRightState, jointPoints(JointType.HandRight))
        Next
        Return drawImg
    End Function

    ' Helper method which processes a single 2D skeleton from a Kinect Body into a bitmap image of specified height
    Public Function DrawSkeleton(ByVal bod As Body, ByVal imgW As Integer, ByVal imgH As Integer) As Bitmap
        Dim bodies As New List(Of Body)
        bodies.Add(bod)
        Return DrawSkeletons(bodies, imgW, imgH)
    End Function

    ' Draws a body
    Private Sub DrawBody(ByVal joints As IReadOnlyDictionary(Of JointType, Joint), ByVal jointPoints As Dictionary(Of JointType, Point), ByVal drawingPen As Pen)

        ' Draw each bone in the body
        For Each b As Tuple(Of JointType, JointType) In bones
            DrawBone(joints, jointPoints, b.Item1, b.Item2, drawingPen)
        Next
        joints.Keys.Reverse()
        ' Now draw the joints
        For Each jType As JointType In joints.Keys
            Dim drawPen As Pen = Nothing
            Dim trackState As TrackingState = joints(jType).TrackingState
            If trackState = TrackingState.Tracked Then
                drawPen = trackedJointPen
            ElseIf trackState = TrackingState.Inferred Then
                drawPen = inferredJointPen
            End If
            If Not IsNothing(drawPen) Then
                Dim rect As Rectangle = GetCircleBounds(jointPoints(jType), JointCircleRadius)
                drawGraph.DrawEllipse(drawPen, rect)
            End If
        Next

    End Sub

    ' Draws one bone of a body (joint to joint)
    Private Sub DrawBone(ByVal joints As IReadOnlyDictionary(Of JointType, Joint), ByVal jointPoints As Dictionary(Of JointType, Point), ByVal jointType0 As JointType, ByVal jointType1 As JointType, ByVal drawingPen As Pen)
        Dim joint0 As Joint = joints(jointType0)
        Dim joint1 As Joint = joints(jointType1)
        If (joint0.TrackingState = TrackingState.NotTracked OrElse joint1.TrackingState = TrackingState.NotTracked) Then
            ' Not tracked, so don't draw this bone
            Return
        End If
        ' Drawn bones are inferred unless both joints are being tracked
        Dim drawPen As Pen = inferredBonePen
        If (joint0.TrackingState = TrackingState.Tracked) AndAlso (joint1.TrackingState = TrackingState.Tracked) Then
            drawPen = drawingPen
        End If
        drawGraph.DrawLine(drawPen, jointPoints(jointType0), jointPoints(jointType1))
    End Sub

    ' Draws a hand symbol if the hand is tracked: red circle = closed, green circle = opened; blue circle = lasso
    Private Sub DrawHand(ByVal hState As HandState, ByVal handPosition As Point)
        Dim rect As Rectangle = GetCircleBounds(handPosition, HandCircleRadius)
        Select Case hState
            Case HandState.Closed
                drawGraph.FillEllipse(handClosedFill, rect)
            Case HandState.Open
                drawGraph.FillEllipse(handOpenFill, rect)
            Case HandState.Lasso
                drawGraph.FillEllipse(handLassoFill, rect)
            Case Else
                ' Nothing to draw
                Return
        End Select
    End Sub

    ' Draws indicators to show which edges are clipping body data
    Private Sub DrawClippedEdges(ByVal bod As Body)
        Dim clippedEdges As FrameEdges = bod.ClippedEdges
        If (clippedEdges.HasFlag(FrameEdges.Bottom)) Then
            Dim rect As Rectangle = New Rectangle(0, displayHeight - ClipBoundsThickness, displayWidth, ClipBoundsThickness)
            drawGraph.DrawRectangle(clipBoundsPen, rect)
        End If
        If (clippedEdges.HasFlag(FrameEdges.Top)) Then
            Dim rect As Rectangle = New Rectangle(0, 0, displayWidth, ClipBoundsThickness)
            drawGraph.DrawRectangle(clipBoundsPen, rect)
        End If
        If (clippedEdges.HasFlag(FrameEdges.Left)) Then
            Dim rect As Rectangle = New Rectangle(0, 0, ClipBoundsThickness, displayHeight)
            drawGraph.DrawRectangle(clipBoundsPen, rect)
        End If
        If (clippedEdges.HasFlag(FrameEdges.Right)) Then
            Dim rect As Rectangle = New Rectangle(displayWidth - ClipBoundsThickness, 0, ClipBoundsThickness, displayHeight)
            drawGraph.DrawRectangle(clipBoundsPen, rect)
        End If
    End Sub

#End Region

#Region "Helper Methods"
    Private Function GetCircleBounds(ByVal p As Point, ByVal radius As Integer) As Rectangle
        Return New Rectangle(p.X - radius, p.Y - radius, 2 * radius, 2 * radius)
    End Function
#End Region

End Class
