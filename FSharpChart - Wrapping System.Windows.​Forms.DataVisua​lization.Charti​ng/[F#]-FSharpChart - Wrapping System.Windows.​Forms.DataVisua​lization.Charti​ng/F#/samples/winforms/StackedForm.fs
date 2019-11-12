namespace MSDN.FSharp.Charting.Tester

open System
open System.Drawing
open System.Windows.Forms
open System.Windows.Forms.DataVisualization.Charting

open MSDN.FSharp.Charting
open MSDN.FSharp.Charting.ChartStyleExtensions
open MSDN.FSharp.Charting.ChartData


type public StackedForm() as form =
    inherit Form()

    let rndStacked = new System.Random()
    let dataX() = [ for f in 1 .. 10 -> round (rndStacked.NextDouble() * 100.0)]
    let dataXY() = [ for f in 1 .. 10 -> (f, round (rndStacked.NextDouble() * 100.0))]

    let chart =
        [dataX(); dataX()]
        |> FSharpChart.StackedColumn
        |> FSharpChart.WithSeries.DataPoint(Label="#VAL")

    // initialize your controls
    let chartControl = new ChartControl(chart, Dock = DockStyle.Fill)
    let series = new StackedValue()

    do
        // get access to the series
        series.BindSeries(chartControl.ChartSeries)

        // add controls to the form
        form.SuspendLayout();
        form.Controls.Add(chartControl)

        // define form properties
        form.ClientSize <- new Size(600, 600)
        form.Text <- "F# Stacked Tester Utility"

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
        let rndStacked = new System.Random()
        let dataX() = [ for f in 1 .. 10 -> round (rndStacked.NextDouble() * 100.0)]
        let dataXY() = [ for f in 1 .. 10 -> (f, round (rndStacked.NextDouble() * 100.0))]
        series.SetData([ dataXY(); dataXY(); dataXY() ], chart.ChartBinder)

    member form.quitClicked(sender:obj, e:EventArgs) = 
        form.Close()