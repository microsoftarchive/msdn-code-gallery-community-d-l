namespace MSDN.FSharp.Charting.Tester

open System
open System.Drawing
open System.Windows.Forms
open System.Windows.Forms.DataVisualization.Charting

open MSDN.FSharp.Charting
open MSDN.FSharp.Charting.ChartStyleExtensions


type public CombineLineForm() as form =
    inherit Form()

    let chart =
        FSharpChart.Combine
            [ FSharpChart.Line([ for f in 0.0 .. 0.1 .. 10.0 -> sin f ], Name = "Sin Wave")
              FSharpChart.Line([ for f in 0.0 .. 0.1 .. 10.0 -> cos f ], Name = "Cosine Wave") ]
            |> FSharpChart.WithArea.AxisX(MajorGrid = Grid(LineColor = Color.LightGray))
            |> FSharpChart.WithArea.AxisY(Minimum = -1.0, Maximum = 1.0, MajorGrid = Grid(LineColor = Color.LightGray))
            |> FSharpChart.WithMargin(5.0f, 5.0f, 5.0f, 5.0f)

    // initialize your controls
    let chartControl = new ChartControl(chart, Dock = DockStyle.Fill)        

    do
        // add controls to the form
        form.SuspendLayout();
        form.Controls.Add(chartControl)

        // define form properties
        form.ClientSize <- new Size(600, 600)
        form.Text <- "F# Chart Tester Utility"

        // define a menu for testing
        form.Menu <- new MainMenu()
        let menuTest = form.Menu.MenuItems.Add("&Test")

        menuTest.MenuItems.AddRange begin
            [|
                let mtName = new MenuItem("Set Chart &Name")
                mtName.Click.AddHandler(new System.EventHandler(fun sender e -> form.nameChangeClicked(sender, e)))
                yield mtName

                let mtTitle = new MenuItem("Set &Title Legend")
                mtTitle.Click.AddHandler(new System.EventHandler(fun sender e -> form.titleChangeClicked(sender, e)))
                yield mtTitle

                let mtBack = new MenuItem("Set &Background")
                mtBack.Click.AddHandler(new System.EventHandler(fun sender e -> form.backgroundChangeClicked(sender, e)))
                yield mtBack

                let mtQuit  = new MenuItem("&Quit")
                mtQuit.Click.AddHandler(new System.EventHandler(fun sender e -> form.quitClicked(sender, e)))
                yield mtQuit
            |]
        end

        // render
        form.ResumeLayout(false)
        form.PerformLayout()

    // event to change title from the GenericChart
    member form.nameChangeClicked(sender:obj, e:EventArgs) = 
        chart.Name <- "AreaMain"

    member form.titleChangeClicked(sender:obj, e:EventArgs) = 
        chart.Margin <- (2.0f, 12.0f, 2.0f, 2.0f)
        chart.Title <- StyleHelper.Title("Chart Sin/Cosine", FontSize = 12.0f, FontStyle = FontStyle.Bold)
        chart.Legend <- StyleHelper.Legend(InsideArea = false, Alignment = StringAlignment.Center, Docking = Docking.Top, FontName = "Arial Narrow")

    member form.backgroundChangeClicked(sender:obj, e:EventArgs) = 
        chart.Background <- ChartStyles.Background.Gradient(Color.White, Color.LightBlue, GradientStyle.TopBottom)

    // event to close the application
    member form.quitClicked(sender:obj, e:EventArgs) = 
        form.Close()