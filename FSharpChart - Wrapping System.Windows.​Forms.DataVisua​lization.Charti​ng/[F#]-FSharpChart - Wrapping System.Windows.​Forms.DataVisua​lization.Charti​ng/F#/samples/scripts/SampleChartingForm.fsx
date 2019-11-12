#load "..//..//scripts//FSharpChart.fsx"
#load "SampleData.fs"
 
open System
open System.Drawing
open System.Windows.Forms
open System.Windows.Forms.DataVisualization.Charting

open MSDN.FSharp.Charting
open MSDN.FSharp.Charting.ChartTypes

let GetControl =

    let t1, t2 = DateTime(1984,01,15), DateTime(1984,08,20)
    let ds, op, hi, lo, cl, vo = Data.sp t1 t2
    let ma1, ma2 = Data.spma 40 t1 t2, Data.spma 10 t1 t2
    let ch1, ch2 = Data.spchan 20 t1 t2
    let atr = Data.spatr 10 t1 t2

    // Create a color with specified alpha channel value
    let withAlpha a (clr:Color) = 
        Color.FromArgb(a, int clr.R, int clr.G, int clr.B)

    // Configuration of area that is reused to create two similar
    // areas. It sets style, axes properties and adds legend
    let gridAndLegendStyle chartObject = 
        let dashGrid = Grid(LineColor = Color.Gainsboro, LineDashStyle = ChartDashStyle.Dash)
        chartObject
        |> FSharpChart.WithArea.Style(Background = ChartStyles.Background.Solid Color.AliceBlue) 
        |> FSharpChart.WithArea.AxisY(MajorGrid = dashGrid) 
        |> FSharpChart.WithArea.AxisX(MajorGrid = dashGrid)
        |> FSharpChart.WithArea.AxisY2(MajorGrid = dashGrid)
        |> FSharpChart.WithLegend
            ( InsideArea = false, Font = new Font("Arial", 8.0f), 
                Alignment = StringAlignment.Center, Docking = Docking.Top)

    // FSharpChart on the upper side of view
    // (Combines candlesticks, range chart and two line charts)
    let upperChart = 
        FSharpChart.Combine
            [ FSharpChart.Candlestick(ds, hi, lo, op, cl, Name = "SP", PointWidth = 0.5)
                |> FSharpChart.WithSeries.Style(Color = Color.SeaGreen)
              FSharpChart.Range(ds, ch1, ch2, Name = "CHAN20")
                |> FSharpChart.WithSeries.Style( Color = (Color.LightSkyBlue |> withAlpha 32), BorderColor = Color.SkyBlue, BorderWidth = 1 )
              FSharpChart.Line(ds, ma1, Name = "MA40")
              FSharpChart.Line(ds, ma2, Name = "MA10") ]
        |> FSharpChart.WithArea.AxisY
            ( LabelStyle = new LabelStyle(Font = new Font("Arial", 7.0f)), Minimum = 550.0, Maximum = 580.0 )
        |> FSharpChart.WithArea.AxisX(MajorTickMark = TickMark(Enabled = false), LabelStyle = new LabelStyle(Enabled = false))
        |> gridAndLegendStyle
        |> FSharpChart.WithCreate

    // FSharpChart on the lower side of the view
    // (Combines column chart with a line chart)
    let lowerChart = 
        FSharpChart.Combine
            [ FSharpChart.Column(ds, vo, Name = "VOLUME", PointWidth = 1.0)
                |> FSharpChart.WithSeries.Style(Color = Color.SkyBlue, BorderColor = Color.Blue, BorderWidth = 1)
              FSharpChart.Line(ds, atr, Name = "ATR10")
                |> FSharpChart.WithSeries.Style(Color = Color.DarkRed) 
                |> FSharpChart.WithSeries.AxisType(YAxisType = AxisType.Secondary) ]
        |> FSharpChart.WithArea.AxisX(LabelStyle = new LabelStyle(Format = "yyyy\nMM-dd", Font = new Font("Arial", 7.0f)))
        |> FSharpChart.WithArea.AxisY(LabelStyle = new LabelStyle(Format = "0,K", Font = new Font("Arial", 7.0f)))
        |> FSharpChart.WithArea.AxisY2(LabelStyle = new LabelStyle(Font = new Font("Arial", 7.0f)))
        |> gridAndLegendStyle
        |> FSharpChart.WithCreate

    let ch =
        FSharpChart.Rows 
            ( [ upperChart 
                |> FSharpChart.WithArea.Name("UpperChart")
                lowerChart 
                |> FSharpChart.WithArea.Align("UpperChart", AreaAlignmentOrientations.Vertical)
                |> FSharpChart.WithMargin(0.0f, 5.0f, 0.0f, 0.0f) ],
            SplitSizes = [ 0.7; 0.3 ])
        |> FSharpChart.WithMargin(0.0f, 7.0f, 1.0f, 2.0f)

    new ChartControl(ch, Dock = DockStyle.Fill)
    
// --------------------------------------------------------------------------------------
// One more larger examples
// (Based on 'futures' from http://code.msdn.microsoft.com/fschart)
// --------------------------------------------------------------------------------------

let frm = new Form(Visible = true, TopMost = true, Width = 700, Height = 500)
let ctl = GetControl
frm.Controls.Add(ctl)
frm.Text <- "Multi Row Combined Chart"
frm.Show()
ctl.Focus() |> ignore

// --------------------------------------------------------------------------------------
// Simple WPF rendering sample
// --------------------------------------------------------------------------------------

// standard WPF DLLs
#r "WindowsBase"
#r "PresentationCore"
#r "PresentationFramework"
#r "WindowsFormsIntegration" // WPF/Forms integration DLL
#r "System.Xaml" // needed only because of F# IntelliSense issue...

open MSDN.FSharp
open System.Windows

// create a chart
let area = Charting.FSharpChart.Area [for x in 1 .. 10 -> sprintf "Column %i" x, x*x]
// create a WPF host control containing it
let host = new Forms.Integration.WindowsFormsHost(Child = new Charting.ChartControl(area))
// create and show a WPF form with the control
let wnd = Window(Content = host, Title = "WPF/Forms Interop", Visibility = Visibility.Visible)
