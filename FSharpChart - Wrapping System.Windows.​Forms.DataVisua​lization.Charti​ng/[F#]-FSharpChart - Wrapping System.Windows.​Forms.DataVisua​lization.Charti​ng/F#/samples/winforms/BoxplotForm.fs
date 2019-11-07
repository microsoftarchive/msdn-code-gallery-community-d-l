namespace MSDN.FSharp.Charting.Tester

open System
open System.Drawing
open System.Windows.Forms
open System.Windows.Forms.DataVisualization.Charting

open MSDN.FSharp.Charting
open MSDN.FSharp.Charting.ChartStyleExtensions
open MSDN.FSharp.Charting.ChartData


type public BoxplotForm() as form =
    inherit Form()

    let chart =
        let rnd = new Random()

//        FSharpChart.BoxPlot
//         ( [ [| for i in 0 .. 20 -> float (rnd.Next 20) |]
//             [| for i in 0 .. 20 -> float (rnd.Next 15 + 2) |]
//             [| for i in 0 .. 20 -> float (rnd.Next 10 + 5) |] ],
//           BoxPlotShowUnusualValues = true, BoxPlotShowMedian = false,
//           BoxPlotShowAverage = false, BoxPlotWhiskerPercentile = 10)

        // Gets matched to XMultiYValues rather than BoxPlotYArrays
        FSharpChart.BoxPlot
             ( [ "Eggs", [| for i in 0 .. 20 -> float (rnd.Next 20) |]
                 "Bacon", [| for i in 0 .. 20 -> float (rnd.Next 15 + 2) |]
                 "Sausage", [| for i in 0 .. 20 -> float (rnd.Next 5 + 5) |]
                 "Beans", [| for i in 0 .. 20 -> float (rnd.Next 10 + 3) |]
                 "Mushroom", [| for i in 0 .. 20 -> float (rnd.Next 15 + 5) |] ],
                 BoxPlotShowUnusualValues = true, BoxPlotShowMedian = true,
                 BoxPlotShowAverage = true, BoxPlotWhiskerPercentile = 10,
                 Name = "Breakfast Food BoxPlot")
        |> FSharpChart.WithMargin(1.0f, 5.0f, 1.0f, 1.0f) 
        |> FSharpChart.WithSeries.Style(Color = Color.SeaGreen)
        |> FSharpChart.WithLegend(InsideArea = false, Font = StyleHelper.Font(FontSize=12.0f), Alignment = StringAlignment.Center, Docking = Docking.Top)
        |> FSharpChart.WithArea.AxisX(LabelStyle=StyleHelper.LabelStyle(FontName="Arial Narrow"))
        |> FSharpChart.WithArea.AxisY(LabelStyle=StyleHelper.LabelStyle(FontName="Arial Narrow"))

    // initialize your controls
    let chartControl = new ChartControl(chart, Dock = DockStyle.Fill) 
    let series = new MultiValue()  

    do
        // get access to the series
        series.BindSeries(chartControl.ChartSeries)

        // add controls to the form
        form.SuspendLayout();
        form.Controls.Add(chartControl)

        // define form properties
        form.ClientSize <- new Size(600, 600)
        form.Text <- "F# BoxPlot Tester Utility"

        // define a menu for testing
        form.Menu <- new MainMenu()
        let menuTest = form.Menu.MenuItems.Add("&Test")

        menuTest.MenuItems.AddRange begin
            [|
                let mtQuit  = new MenuItem("&Quit")
                mtQuit.Click.AddHandler(new System.EventHandler(fun sender e -> form.quitClicked(sender, e)))
                yield mtQuit

                let mtData  = new MenuItem("Set &Data")
                mtData.Click.AddHandler(new System.EventHandler(fun sender e -> form.setdataClicked(sender, e)))
                yield mtData
            |]
        end

        // render
        form.ResumeLayout(false)
        form.PerformLayout()

    // event to close the application
    member form.setdataClicked(sender:obj, e:EventArgs) = 
        let rnd = new Random()
        series.SetData([ "Cereal", [| for i in 0 .. 20 -> float (rnd.Next 20) |]
                         "Yogurt", [| for i in 0 .. 20 -> float (rnd.Next 15 + 2) |]
                         "Toast", [| for i in 0 .. 20 -> float (rnd.Next 15 + 2) |]
                         "Fruit", [| for i in 0 .. 20 -> float (rnd.Next 10 + 5) |] ],
                         chart.ChartBinder)

    member form.quitClicked(sender:obj, e:EventArgs) = 
        form.Close()