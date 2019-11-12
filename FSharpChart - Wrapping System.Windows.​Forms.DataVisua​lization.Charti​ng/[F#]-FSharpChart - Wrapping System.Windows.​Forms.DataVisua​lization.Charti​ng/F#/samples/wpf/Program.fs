namespace MSDN.FSharp.Charting.Tester

open System
open System.Drawing
open System.Windows
open System.Windows.Forms
open System.Windows.Forms.DataVisualization.Charting
open System.Windows.Forms.Integration


open MSDN.FSharp.Charting
open MSDN.FSharp.Charting.ChartStyleExtensions
open MSDN.FSharp.Charting.ChartData

module Main =

    let getChartControl = 
        let chart =
            FSharpChart.Combine
                [ FSharpChart.Line([ for f in 0.0 .. 0.1 .. 10.0 -> sin f ], Name = "Sin Wave")
                  FSharpChart.Line([ for f in 0.0 .. 0.1 .. 10.0 -> cos f ], Name = "Cosine Wave") ]
                |> FSharpChart.WithArea.AxisX(MajorGrid = Grid(LineColor = Color.LightGray))
                |> FSharpChart.WithArea.AxisY(Minimum = -1.0, Maximum = 1.0, MajorGrid = Grid(LineColor = Color.LightGray))
                |> FSharpChart.WithMargin(5.0f, 5.0f, 5.0f, 5.0f)

        new ChartControl(chart, Dock = DockStyle.Fill)

    // Sample without the use of XAML
    let mainNoXaml() =   

        let formsHost = new WindowsFormsHost(Child = getChartControl)
        let graphWindow = new Window(Content = formsHost, Title = "Chart Sin/Cosine")
        
        let wpfApp = new System.Windows.Application()
        wpfApp.Run(graphWindow) |> ignore

    // Sample using XAML
    let mainWithXaml() =

        let (?) (window : Window) name = window.FindName name |> unbox

        let uri = new System.Uri("/FSharp.Charting.Wpf;component/FSharpChartWpf.xaml", UriKind.Relative)
        let window = Application.LoadComponent(uri) :?> Window

        let formsHost : WindowsFormsHost = window?chartHost
        formsHost.Child <- getChartControl

        let wpfApp = new System.Windows.Application()
        wpfApp.Run(window) |> ignore

    // Application Entry Point
    [<STAThread>]
    do
        mainWithXaml()