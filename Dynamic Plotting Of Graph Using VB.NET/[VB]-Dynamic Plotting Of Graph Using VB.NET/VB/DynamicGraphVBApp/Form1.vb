Imports System.Drawing
Imports System.Threading

Public Class frmGraph
    Private m_GraphThread As Thread
    Private m_Y As Integer

    'Start Drawing Graph
    Private Sub btnGraph_Click(sender As System.Object, e As System.EventArgs) Handles btnGraph.Click
        If m_GraphThread Is Nothing Then
            ' The thread isn't running. Start it.
            AddStatus("Starting thread")

            m_GraphThread = New Thread(AddressOf DrawGraph)
            m_GraphThread.Priority = ThreadPriority.BelowNormal
            m_GraphThread.IsBackground = True
            m_GraphThread.Start()

            AddStatus("Thread started")

            btnGraph.Text = "Stop"
        Else
            ' The thread is running. Stop it.
            AddStatus("Stopping thread")

            m_GraphThread.Abort()
            ' m_GraphThread.Join()
            m_GraphThread = Nothing

            AddStatus("Thread stopped")

            btnGraph.Text = "Start"
        End If
    End Sub

    ' Draw a graph until stopped.
    Private Sub DrawGraph()
        Try
            ' Generate pseudo-random values.
            Dim y As Integer = m_Y
            Do
                ' Generate the next value.
                NewValue()

                ' Plot the new value.
                PlotValue(y, m_Y)
                y = m_Y
            Loop
        Catch ex As Exception
            AddStatus("[Thread] " & ex.Message)
        End Try
    End Sub

    ' Generate the next value.
    Private Sub NewValue()
        ' Delay a bit before calculating the value.
        Dim stop_time As Date = Now.AddMilliseconds(20)
        Do While Now < stop_time
        Loop

        ' Calculate the next value.
        Static rnd As New Random
        m_Y += rnd.Next(System.Convert.ToInt32(txtMinValue.Text), System.Convert.ToInt32(txtMaxValue.Text))
        If m_Y < 0 Then m_Y = 0
        If m_Y >= picGraph.ClientSize.Height - 1 Then m_Y = picGraph.ClientSize.Height - 1
    End Sub

    Private Delegate Sub PlotValueDelegate(ByVal old_y As Integer, ByVal new_y As Integer)

    Private Sub PlotValue(ByVal old_y As Integer, ByVal new_y As Integer)
        ' See if we're on the worker thread and thus
        ' need to invoke the main UI thread.
        If Me.InvokeRequired Then
            ' Make arguments for the delegate.
            Dim args As Object() = {old_y, new_y}

            ' Make the delegate.
            Dim plot_value_delegate As PlotValueDelegate
            plot_value_delegate = AddressOf PlotValue

            ' Invoke the delegate on the main UI thread.
            Me.Invoke(plot_value_delegate, args)

            ' We're done.
            Exit Sub
        End If

        ' Make the Bitmap and Graphics objects.
        Dim wid As Integer = picGraph.ClientSize.Width
        Dim hgt As Integer = picGraph.ClientSize.Height
        Dim bm As New Bitmap(wid, hgt)
        Dim gr As Graphics = Graphics.FromImage(bm)
        Dim m_Ymid As Integer
        Dim GRID_STEP As Integer = Convert.ToInt32(txtGridSpacing.Text) 'Assign Grid Spacing
        m_Ymid = hgt / 2
        ' Move the old data one pixel to the left.
        gr.DrawImage(picGraph.Image, -1, 0)

        ' Erase the right edge and draw guide lines.
        gr.DrawLine(Pens.Blue, wid - 1, 0, wid - 1, hgt - 1)
        For i As Integer = m_Ymid To picGraph.ClientSize.Height Step GRID_STEP
            gr.DrawLine(Pens.LightBlue, wid - 2, i, wid - 1, i)
        Next i
        For i As Integer = m_Ymid To 0 Step -GRID_STEP
            gr.DrawLine(Pens.LightBlue, wid - 2, i, wid - 1, i)
        Next i

        ' Plot a new pixel.
        gr.DrawLine(Pens.White, wid - 2, old_y, wid - 1, new_y)

        ' Display the result.
        picGraph.Image = bm
        picGraph.Refresh()

        gr.Dispose()
    End Sub

    ' Add a status string to txtStatus.
    Private Delegate Sub AddStatusDelegate(ByVal txt As String)

    Private Sub AddStatus(ByVal txt As String)
        ' See if we're on the worker thread and thus
        ' need to invoke the main UI thread.
        If Me.InvokeRequired Then
            ' Make arguments for the delegate.
            Dim args As Object() = {txt}

            ' Make the delegate.
            Dim add_status_delegate As AddStatusDelegate
            add_status_delegate = AddressOf AddStatus

            ' Invoke the delegate on the main UI thread.
            Me.Invoke(add_status_delegate, args)

            ' We're done.
            Exit Sub
        End If

        txtStatus.Text &= vbCrLf & txt
        txtStatus.Select(txtStatus.Text.Length, 0)
        txtStatus.ScrollToCaret()
    End Sub

End Class
