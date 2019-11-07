# Kinect v2 SDK Sample Code re-worked in VB.NET (skeleton & gestures)
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- Kinect
- Kinect SDK
- Gesture Recognition
## Topics
- Visual Basic .NET
- Kinect
- Gestures
- Basic Kinect Programming
- Gesture Recognition
## Updated
- 11/10/2014
## Description

<h1>Introduction</h1>
<p><em>This code sample is my own re-working into Visual Basic of a some classes from the C# DiscreetGestureBasics-WPF sample code inlcuded in the Kinect for Windows SDK 2.0 Public Preview. The code handles skeletal processing and display plus discrete gesture
 recognition.</em></p>
<p><em>The code I've written and provided here is a work in progress, so I'm providing it purely as a good headstart for VB.NET coders delving into the SDK since the current examples are are present in C#.&nbsp;</em><em style="font-size:10px">Please forgive
 any hack-and-slash coding shortcuts as this is very much a work in progress and very much porotype code :-) That said, feedback and comments are welcome.</em></p>
<p><em style="font-size:10px">UPDATE: The code now has a built-in kicking gesture detector database. Swithc on the skeletal tracker and it will track gesture&nbsp;confidence values (0 to 1) for Standing, kick left, kick right, kick right (across body) and kick
 left (across body). It writes these values out as CSV to the gesture output window.<br>
</em></p>
<h2>Please rate this code sample if you find it useful. Thanks.</h2>
<p>I will post updated code as my development continues, so keep an eye out for updates.</p>
<h1><span>Building the Sample</span></h1>
<p>You'll need Visual Studio 2013 (or VS 2012 with some tweaking) to open, compile and run the sample code in the solution. It's set-up for .NET 4.5 and 64-bit compilation. Of course, you'll also need the latest Kinect v2 for Windows SDK 2.0 Public Preview
 (the code provided references build 1409 of the v2 SDK public preview).</p>
<p>Visual Studio Solution references (may need updating if the SDK changes path):</p>
<p><img id="126527" src="126527-refs.png" alt="" width="656" height="117"></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>The sample will compile and run, displaying live skeletal data in a simple Windows Forms application. The skeletal tracker class (<strong>GestureDetector.vb</strong>) generates live skeletal data from the bodies tracked by the Kinect Sensor and uses their
 skeletal points to draw output bitmap images frame-by-frame (as Bitmap objects) in real time when a valid Kinect v2 sensor is detected.</p>
<p>At the moment, the gesture detection class (<strong>GestureDetector.vb</strong>) is ready-to-go, but not yet being used in the sample code provided. You'll need to build your own gesture database using the SDK Visual Gesture Builder and alter the code to
 detect your gestures from that database. You'll see from the code that my sample is eventually going to track some left and right footed &quot;kicking&quot; gestures for a psychological response experiment.</p>
<p><span style="font-size:2em">Source Code Files</span></p>
<ul>
<li><em><strong>StartScreen.vb</strong> - The main GUI (Windows Forms) screen for displaying things.</em>
</li><li><em><strong>SkeletalTracker.vb</strong> - This class parses Kinect skeletal and hand-tracking data and outputs skeleton display frames as live sequences of bitmap images (snippet below):</em>
</li></ul>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">    ' Method which draws the active 2D skeletons into a bitmap image of specified height and width and returns it
    Public Function DrawActiveSkeletons(ByVal activeBodies As List(Of Body), imgW As Integer, imgH As Integer) As Bitmap
        ' Set up the drawing area
        displayWidth = imgW : displayHeight = imgH
        drawImg = New Bitmap(imgW, imgH)
        drawGraph = Graphics.FromImage(drawImg)
        Dim penIndex As Integer = 0
        ' Cycle through each body / person found in the field of view
        For Each bod As Body In activeBodies
            DrawClippedEdges(bod)
            Dim drawPen As Pen = bodyColors(penIndex) : penIndex &#43;= 1
            Dim _3DJoints As IReadOnlyDictionary(Of JointType, Joint) = bod.Joints
            ' convert the joint points to a 2D (flat) display space
            Dim jointPoints As New Dictionary(Of JointType, Point)
            For Each jType As JointType In _3DJoints.Keys
                ' sometimes the depth(Z) of an inferred joint may show as negative
                ' clamp down to 0.1f to prevent coordinate mapper from returning (-Infinity, -Infinity)
                Dim _3DPoint As CameraSpacePoint = _3DJoints(jType).Position
                If _3DPoint.Z &lt;= InferredZPositionClamp Then _3DPoint.Z = InferredZPositionClamp
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
    End Function</pre>
<div class="preview">
<pre class="vb">&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Method&nbsp;which&nbsp;draws&nbsp;the&nbsp;active&nbsp;2D&nbsp;skeletons&nbsp;into&nbsp;a&nbsp;bitmap&nbsp;image&nbsp;of&nbsp;specified&nbsp;height&nbsp;and&nbsp;width&nbsp;and&nbsp;returns&nbsp;it</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;DrawActiveSkeletons(<span class="visualBasic__keyword">ByVal</span>&nbsp;activeBodies&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;List(<span class="visualBasic__keyword">Of</span>&nbsp;Body),&nbsp;imgW&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>,&nbsp;imgH&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Bitmap&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Set&nbsp;up&nbsp;the&nbsp;drawing&nbsp;area</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;displayWidth&nbsp;=&nbsp;imgW&nbsp;:&nbsp;displayHeight&nbsp;=&nbsp;imgH&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;drawImg&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Bitmap(imgW,&nbsp;imgH)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;drawGraph&nbsp;=&nbsp;Graphics.FromImage(drawImg)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;penIndex&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Cycle&nbsp;through&nbsp;each&nbsp;body&nbsp;/&nbsp;person&nbsp;found&nbsp;in&nbsp;the&nbsp;field&nbsp;of&nbsp;view</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;<span class="visualBasic__keyword">Each</span>&nbsp;bod&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Body&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;activeBodies&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DrawClippedEdges(bod)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;drawPen&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Pen&nbsp;=&nbsp;bodyColors(penIndex)&nbsp;:&nbsp;penIndex&nbsp;&#43;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;_3DJoints&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IReadOnlyDictionary(<span class="visualBasic__keyword">Of</span>&nbsp;JointType,&nbsp;Joint)&nbsp;=&nbsp;bod.Joints&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;convert&nbsp;the&nbsp;joint&nbsp;points&nbsp;to&nbsp;a&nbsp;2D&nbsp;(flat)&nbsp;display&nbsp;space</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;jointPoints&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Dictionary(<span class="visualBasic__keyword">Of</span>&nbsp;JointType,&nbsp;Point)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;<span class="visualBasic__keyword">Each</span>&nbsp;jType&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;JointType&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;_3DJoints.Keys&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;sometimes&nbsp;the&nbsp;depth(Z)&nbsp;of&nbsp;an&nbsp;inferred&nbsp;joint&nbsp;may&nbsp;show&nbsp;as&nbsp;negative</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;clamp&nbsp;down&nbsp;to&nbsp;0.1f&nbsp;to&nbsp;prevent&nbsp;coordinate&nbsp;mapper&nbsp;from&nbsp;returning&nbsp;(-Infinity,&nbsp;-Infinity)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;_3DPoint&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;CameraSpacePoint&nbsp;=&nbsp;_3DJoints(jType).Position&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;_3DPoint.Z&nbsp;&lt;=&nbsp;InferredZPositionClamp&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;_3DPoint.Z&nbsp;=&nbsp;InferredZPositionClamp&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;depthPoint&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;DepthSpacePoint&nbsp;=&nbsp;coordinateMapper.MapCameraPointToDepthSpace(_3DPoint)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;jointPoints.Add(jType,&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Point(depthPoint.X,&nbsp;depthPoint.Y))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Draw&nbsp;the&nbsp;body</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DrawBody(_3DJoints,&nbsp;jointPoints,&nbsp;drawPen)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Draw&nbsp;the&nbsp;left&nbsp;hand</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DrawHand(bod.HandLeftState,&nbsp;jointPoints(JointType.HandLeft))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Draw&nbsp;the&nbsp;right&nbsp;hand</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DrawHand(bod.HandRightState,&nbsp;jointPoints(JointType.HandRight))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;drawImg&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<ul>
<li><em><strong>GestureDetector.vb</strong> - The gesture detection class (set up for discrete gestures, but could easily be adapted for continuous ones). Currently not in use, but is ready to go with little modification. Sample of gesture detection method
 shown below:</em> </li></ul>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">#Region &quot;Gesture Tracking&quot;

    ' Handles gesture detection results arriving from the sensor for the associated body tracking Id
    Private Sub Reader_GestureFrameArrived(sender As Object, e As VisualGestureBuilderFrameArrivedEventArgs)
        Dim frameReference As VisualGestureBuilderFrameReference = e.FrameReference
        Using frame As VisualGestureBuilderFrame = frameReference.AcquireFrame
            If Not IsNothing(frame) Then
                ' get the discrete gesture results which arrived with the latest frame
                Dim discreteResults As IReadOnlyDictionary(Of Gesture, DiscreteGestureResult) = frame.DiscreteGestureResults
                If Not IsNothing(discreteResults) Then
                    For Each gest As Gesture In vgbFrameSource.Gestures
                        ' Parse each gesture of interest (as set in the constructor)
                        Dim result As DiscreteGestureResult = Nothing
                        discreteResults.TryGetValue(gest, result)
                        If Not IsNothing(result) AndAlso result.Detected Then
                            ' Gesture detected, so update the GUI accordingly
                            resultTxt.Text &amp;= gest.Name &amp; &quot; detected: &quot; &amp; result.Confidence
                        End If
                    Next
                End If
            End If
        End Using
    End Sub

    ' Handles the TrackingIdLost event for the VisualGestureBuilderSource object
    Private Sub Source_TrackingIdLost(ByVal sender As Object, ByVal e As TrackingIdLostEventArgs)
        ' Gestures not being tracked since the tracking ID has been lost. Update UI accordingly
        ' resultLabel.Text = &quot;No gestures detected&quot;
    End Sub

#End Region</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__preproc">#Region&nbsp;&quot;Gesture&nbsp;Tracking</span>&quot;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Handles&nbsp;gesture&nbsp;detection&nbsp;results&nbsp;arriving&nbsp;from&nbsp;the&nbsp;sensor&nbsp;for&nbsp;the&nbsp;associated&nbsp;body&nbsp;tracking&nbsp;Id</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Reader_GestureFrameArrived(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;VisualGestureBuilderFrameArrivedEventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;frameReference&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;VisualGestureBuilderFrameReference&nbsp;=&nbsp;e.FrameReference&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;frame&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;VisualGestureBuilderFrame&nbsp;=&nbsp;frameReference.AcquireFrame&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Not</span>&nbsp;IsNothing(frame)&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;get&nbsp;the&nbsp;discrete&nbsp;gesture&nbsp;results&nbsp;which&nbsp;arrived&nbsp;with&nbsp;the&nbsp;latest&nbsp;frame</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;discreteResults&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IReadOnlyDictionary(<span class="visualBasic__keyword">Of</span>&nbsp;Gesture,&nbsp;DiscreteGestureResult)&nbsp;=&nbsp;frame.DiscreteGestureResults&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Not</span>&nbsp;IsNothing(discreteResults)&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;<span class="visualBasic__keyword">Each</span>&nbsp;gest&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Gesture&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;vgbFrameSource.Gestures&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Parse&nbsp;each&nbsp;gesture&nbsp;of&nbsp;interest&nbsp;(as&nbsp;set&nbsp;in&nbsp;the&nbsp;constructor)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;result&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;DiscreteGestureResult&nbsp;=&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;discreteResults.TryGetValue(gest,&nbsp;result)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Not</span>&nbsp;IsNothing(result)&nbsp;<span class="visualBasic__keyword">AndAlso</span>&nbsp;result.Detected&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Gesture&nbsp;detected,&nbsp;so&nbsp;update&nbsp;the&nbsp;GUI&nbsp;accordingly</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resultTxt.Text&nbsp;&amp;=&nbsp;gest.Name&nbsp;&amp;&nbsp;<span class="visualBasic__string">&quot;&nbsp;detected:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;result.Confidence&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Handles&nbsp;the&nbsp;TrackingIdLost&nbsp;event&nbsp;for&nbsp;the&nbsp;VisualGestureBuilderSource&nbsp;object</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Source_TrackingIdLost(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;TrackingIdLostEventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Gestures&nbsp;not&nbsp;being&nbsp;tracked&nbsp;since&nbsp;the&nbsp;tracking&nbsp;ID&nbsp;has&nbsp;been&nbsp;lost.&nbsp;Update&nbsp;UI&nbsp;accordingly</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;resultLabel.Text&nbsp;=&nbsp;&quot;No&nbsp;gestures&nbsp;detected&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span><span class="visualBasic__preproc">&nbsp;
&nbsp;
#End&nbsp;Region</span></pre>
</div>
</div>
</div>
<h1>More Information</h1>
<p><em>Essential viewing and reading:</em></p>
<ul>
<li><em><a title="Custom Gestures, Kinect for Windows v2 and the Visual Gesture Builder" href="http://channel9.msdn.com/coding4fun/kinect/Custom-Gestures-Kinect-for-Windows-v2-and-the-Visual-Gesture-Builder" target="_blank">&quot;Custom Gestures, Kinect for Windows
 v2 and the Visual Gesture Builder&quot;</a> - a Channel9 video which I recommend reading before delving into the code.<br>
</em></li><li><em>Visual Gesture Builder&nbsp;whitepaper, <a title="VGB whitepaper: A Data-Driven Solution to Gesture Detection" href="http://aka.ms/k4wv2vgb" target="_blank">
&quot;Visual Gesture Builder: A Data-Driven Solution to Gesture Detection&quot;</a></em> </li><li><a title="Kinect for Windows SDK 2.0 Public Preview" href="http://www.microsoft.com/en-us/download/details.aspx?id=43661" target="_blank"><em>Kinect for Windows SDK 2.0</em></a>
</li></ul>
