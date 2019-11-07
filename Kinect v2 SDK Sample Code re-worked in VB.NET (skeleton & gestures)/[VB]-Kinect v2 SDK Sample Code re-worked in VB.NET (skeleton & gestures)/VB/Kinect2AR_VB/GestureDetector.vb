Imports System
Imports System.Collections.Generic
Imports Microsoft.Kinect
Imports Microsoft.Kinect.VisualGestureBuilder

' Gesture Detector class which listens for VisualGestureBuilderFrame events from the service
' and updates the associated GestureResultView object with the latest results for the 'Seated' gesture
Public Class GestureDetector
    Implements IDisposable

    Private disposedValue As Boolean ' To detect redundant calls

    ' Path to the gesture database that was trained with VGB
    Private ReadOnly gestureDatabase As String = "GestureDB\Kick Responses.gbd"

    ' Name of the gestures in the database that we want to track (the possible "kick" responses)
    Private ReadOnly kickGestureNames() As String = {"Standing", "KickAcross_Right", "KickStraight_Right", "KickAcross_Left", "KickStraight_Left"}

    ' Gesture frame source which should be tied to a body tracking ID
    Private vgbFrameSource As VisualGestureBuilderFrameSource

    ' Gesture frame reader which will handle gesture events coming from the sensor
    Private vgbFrameReader As VisualGestureBuilderFrameReader

    ' A local copy of the text box which stores the gesture detector results for display in the UI
    Private resultTxt As TextBox

    ' Initializes a new instance of the GestureDetector class along with the gesture frame source and reader
    ' Also takes a reference to a string to which detected gestures are written (as a text result)
    Public Sub New(ByVal kinectSensor As KinectSensor, ByRef txtBox As TextBox)
        ' Check for nulls and if necessary, throw exceptions
        If IsNothing(kinectSensor) Then Throw New ArgumentNullException("kinectSensor")
        resultTxt = txtBox

        ' create the VGB source. The associated body tracking ID will be set when a valid body frame arrives from the sensor.
        vgbFrameSource = New VisualGestureBuilderFrameSource(kinectSensor, 0)
        AddHandler vgbFrameSource.TrackingIdLost, AddressOf Source_TrackingIdLost

        ' open the reader for the VGB frames
        vgbFrameReader = vgbFrameSource.OpenReader()
        If Not IsNothing(vgbFrameReader) Then
            vgbFrameReader.IsPaused = True
            AddHandler vgbFrameReader.FrameArrived, AddressOf Reader_GestureFrameArrived
        End If

        ' Add all the gesture in the database (the 4 possible kick responses)
        Using db As VisualGestureBuilderDatabase = New VisualGestureBuilderDatabase(gestureDatabase)
            vgbFrameSource.AddGestures(db.AvailableGestures)
        End Using
    End Sub

    ' Gets or sets the body tracking ID associated with the current detector
    ' The tracking ID can change whenever a body comes in/out of scope
    Public Property TrackingId() As Int64
        Get
            Return vgbFrameSource.TrackingId
        End Get
        Set(ByVal value As Int64)
            vgbFrameSource.TrackingId = value
        End Set
    End Property

    ' Gets or sets a value indicating whether or not the detector is currently paused
    ' If the body tracking ID associated with the detector is not valid, then the detector should be paused
    Public Property IsPaused() As Boolean
        Get
            Return vgbFrameReader.IsPaused
        End Get
        Set(ByVal value As Boolean)
            vgbFrameReader.IsPaused = value
        End Set
    End Property

#Region "IDisposable Support"

    ' Disposes all unmanaged resources for the class
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    ' Disposes the VisualGestureBuilderFrameSource and VisualGestureBuilderFrameReader objects
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                If Not IsNothing(vgbFrameReader) Then
                    RemoveHandler vgbFrameReader.FrameArrived, AddressOf Reader_GestureFrameArrived
                    vgbFrameReader.Dispose()
                    vgbFrameReader = Nothing
                End If
                If Not IsNothing(vgbFrameSource) Then
                    RemoveHandler vgbFrameSource.TrackingIdLost, AddressOf Source_TrackingIdLost
                    vgbFrameSource.Dispose()
                    vgbFrameSource = Nothing
                End If
            End If
        End If
        Me.disposedValue = True
    End Sub

#End Region

#Region "Gesture Tracking"

    ' Handles gesture detection results arriving from the sensor for the associated body tracking Id
    Private Sub Reader_GestureFrameArrived(sender As Object, e As VisualGestureBuilderFrameArrivedEventArgs)
        Dim frameReference As VisualGestureBuilderFrameReference = e.FrameReference
        Using frame As VisualGestureBuilderFrame = frameReference.AcquireFrame
            If Not IsNothing(frame) Then
                ' get the discrete gesture results which arrived with the latest frame
                Dim discreteResults As IReadOnlyDictionary(Of Gesture, DiscreteGestureResult) = frame.DiscreteGestureResults
                If Not IsNothing(discreteResults) Then
                    Dim strOutput As String = Common.rTimer.ElapsedMilliseconds & ",Standing,KickAcross_Right,KickStraight_Right,KickAcross_Left,KickStraight_Left"
                    For Each gest As Gesture In vgbFrameSource.Gestures
                        ' Parse each gesture of interest (as set in the constructor)
                        Dim result As DiscreteGestureResult = Nothing
                        discreteResults.TryGetValue(gest, result)
                        ' If Not IsNothing(result) AndAlso result.Detected Then
                        If Not IsNothing(result) Then
                            ' Record gesture confidence value
                            strOutput = strOutput.Replace(gest.Name, result.Confidence)
                        End If
                    Next
                    resultTxt.Text &= strOutput & vbNewLine
                End If
            End If
        End Using
    End Sub

    ' Handles the TrackingIdLost event for the VisualGestureBuilderSource object
    Private Sub Source_TrackingIdLost(ByVal sender As Object, ByVal e As TrackingIdLostEventArgs)

    End Sub

#End Region

End Class
