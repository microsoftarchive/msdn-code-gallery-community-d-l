// --------------------------------------------------------------------------------------
// F# CHARTING LIBRARY DEMOS
// --------------------------------------------------------------------------------------

#load "..//..//scripts//FSharpChart.fsx"
#load "SampleData.fs"
 
open System
open System.Drawing
open System.Windows.Forms
open System.Windows.Forms.DataVisualization.Charting

open MSDN.FSharp.Charting
open MSDN.FSharp.Charting.ChartTypes


// --------------------------------------------------------------------------------------
// Simple charts
// All you need to know to start is the FSharpChart type
// --------------------------------------------------------------------------------------

let rnd = new Random()

// Generating only Y values
[ for f in 1.0 .. 0.1 .. 10.0 -> sin (f * 2.0) + cos f ]
|> FSharpChart.Line

let pie =
    FSharpChart.Pie([("Zone A",1);("Zone B",2);("Zone C",3)], Name="Pie Chart Example")
    |> FSharpChart.WithArea.Area3DStyle(Enable3D = true, Inclination = 60)
    |> FSharpChart.WithArea.AxisX(LabelStyle=StyleHelper.LabelStyle(FontName="Arial Narrow"))

pie.GetType().BaseType.BaseType.GetProperty("Data", enum<System.Reflection.BindingFlags> 0xffffffff).GetValue(pie, null)

// Generating X and Y values (as tuples)
[ for i in 1. .. 20. .. 1000.0 -> i, rnd.NextDouble() ]
|> FSharpChart.Line
|> FSharpChart.WithSeries.Marker(Color=Color.Red, Style=MarkerStyle.Cross)

// Generate a circle and save to clipboard
[ let radius = 5.0
for x in -radius .. 0.01 .. radius do
    let y = sqrt((radius * radius) - (x * x))
    yield (x, y)
    yield (x, -y)]
|> FSharpChart.Line
|> FSharpChart.WithCreate
|> FSharpChart.CopyToClipboard

// Generating X and Y values (separately)
let range = [ 1.0 .. 0.02 .. 100.0 ]
let xs = [ for f in range -> (cos f) * (f / 100.0) ]
let ys = [ for f in range -> (sin (2.0 * f)) * (f / 100.0) ]
// Enter the following to F# Interactive as a separate command
FSharpChart.Line(xs, ys)

// The X value can also be DateTime values (unlike Y values)
[ for i in 1. .. 10. -> DateTime.Now.AddDays i, rnd.NextDouble() ]
|> FSharpChart.Column

// Generating charts that take multiple Y values 
let data = Data.brownianBarsAsList 1000 20
data |> FSharpChart.Stock

// Different way of specifying data (using multiple sequences)
let xv, shi, slo, sop, scl = Data.brownianBarsAsTupleOfLists 1000 20
FSharpChart.Candlestick(xv, shi, slo, sop, scl)

// Creating boxplots (charts that take 6 or more arguments)
// Specify exactly 6 values using a tuple
let bp = FSharpChart.BoxPlot [ (-12.7, 11.6, -8.3, 6.4, -2.5, -1.6) ]
bp.BoxPlotShowAverage <- false


// Creating multiple boxplot diagrams
// (Multiple boxplots using a list of 6-value tuples and use 
// custom properties to hide average and median - last two values)
FSharpChart.BoxPlot 
  ( [ (-12.7, 11.6, -8.3, 6.4, 0.0, 0.0);
      (-6.7, 11.6, -5.0, 5.4, 0.0, 0.0) ],
   BoxPlotShowMedian = false, BoxPlotShowAverage = false)

// Specify arbitrary number of values using array
// (Create boxplots that are automatically calculated from the values)
FSharpChart.BoxPlot
 ( [ [| for i in 0 .. 20 -> float (rnd.Next 20) |]
     [| for i in 0 .. 20 -> float (rnd.Next 15 + 2) |]
     [| for i in 0 .. 20 -> float (rnd.Next 10 + 5) |] ],
   BoxPlotShowUnusualValues = true, BoxPlotShowMedian = false,
   BoxPlotShowAverage = false, BoxPlotWhiskerPercentile = 10)

FSharpChart.BoxPlot
    ( [ "Eggs", [| for i in 0 .. 20 -> float (rnd.Next 20) |]
        "Bacon", [| for i in 0 .. 20 -> float (rnd.Next 15 + 2) |]
        "Sausage", [| for i in 0 .. 20 -> float (rnd.Next 5 + 5) |]
        "Beans", [| for i in 0 .. 20 -> float (rnd.Next 10 + 3) |]
        "Mushroom", [| for i in 0 .. 20 -> float (rnd.Next 15 + 5) |] ],
        Name = "Breakfast Food BoxPlot")
|> FSharpChart.WithMargin(1.0f, 5.0f, 1.0f, 1.0f) 
|> FSharpChart.WithSeries.Style(Color = Color.SeaGreen)
|> FSharpChart.WithLegend(InsideArea = false, Font = new Font("Arial", 8.0f),
    Alignment = StringAlignment.Center, Docking = Docking.Top)

// --------------------------------------------------------------------------------------
// Updating values in the chart
// --------------------------------------------------------------------------------------


// We can use 'FSharpChart.Create' to get a data object that can be used to 
// change the data displayed on the chart. Data object depends on the 
// type of chart - here we can specify one Y value
let chart1 = 
  [ for f in 1.0 .. 0.1 .. 10.0 -> sin (f * 2.0) + cos f ]
  |> FSharpChart.Line |> FSharpChart.Create

// Update data on the chart
chart1.SetData [ for f in 1.0 .. 0.1 .. 10.0 -> sin (f * 2.0) + 1.5 * cos f ]
chart1.SetData [ for f in 1.0 .. 0.1 .. 10.0 -> sin (f * 2.0) + 2.0 * cos f ]
chart1.SetData [ for f in 1.0 .. 0.1 .. 10.0 -> sin (f * 2.0) + 3.0 * cos f ]



// Here we use 'FSharpChart.Create' with a chart that takes four values as 
// arguments (Note that we cannot call 'SetData' with just one Y value)
let stocks = Data.brownianBarsAsList 1000 20 |> List.map snd
let chart2 = 
  FSharpChart.Candlestick(stocks)
  |> FSharpChart.Create

// Update data on the chart
chart2.SetData [ for h, l, o, c in stocks -> h - 9.0, l - 9.0, o - 9.0, c - 9.0 ]
chart2.SetData [ for h, l, o, c in stocks -> 12.0 - l, 12.0 - h, 12.0 - c, 12.0 - o ]



// We can also update data of combined charts (created using 'FSharpChart.Rows', 
// 'FSharpChart.Columns' and 'FSharpChart.Combine'). In that case, we need to name series and
// use 'Find' method to get the series by ID (and explicitly specify data type).
let newStocks() = 
  [ for _, (h, l, o, c) in Data.brownianBarsAsList 1000 20 -> 
      h - 9.0, l - 9.0, o - 9.0, c - 9.0 ]

// Create chart with two rows with Stocks and Bar charts

let chart3 = 
  FSharpChart.Rows
    [ FSharpChart.Candlestick(newStocks(), Name = "Stocks")
      FSharpChart.Bar([ for i in 0 .. 5 -> rnd.Next(100) ], Name = "Bars") ]
  |> FSharpChart.Create

// Update data for one or the other chart (or both)
chart3.Find<ChartData.FourValue>("Stocks").SetData(newStocks())
chart3.Find<ChartData.OneValue>("Bars").SetData [ for i in 0 .. 5 -> rnd.Next(100) ]


// --------------------------------------------------------------------------------------
// Dynamic charts (using IObservable)
// --------------------------------------------------------------------------------------

// Creates observable generating random walk
// (The observable is triggered on the GUI thread - when adding points
// from the background thread, we may get some errors)
let randomWalk x = 
  let sync = System.Threading.SynchronizationContext.Current
  let obs = new Event<_>()
  let rnd = new Random(rnd.Next())
  let rec loop x = async { 
    // Generate next value (on the GUI thread)
    sync.Post((fun _ -> obs.Trigger(x)), null)
    // Wait some short time
    do! Async.Sleep(50)
    // Continue looping
    do! loop (x + rnd.NextDouble() - 0.5) }
  loop x |> Async.Start
  obs.Publish

// Random walk displayed using point chart
FSharpChart.FastPoint(randomWalk 0.0)

// Observable can be used with any type of chart...
FSharpChart.Area(randomWalk 0.0, MaxPoints=50)

// We can limit the number of displayed points (to get moving effect)
// TODO: The maximum/minimum stops automatically updating
FSharpChart.FastLine(randomWalk 1.0, MaxPoints = 50)

// We can combine multiple different moving chart series too
FSharpChart.Combine
  [ FSharpChart.FastLine(randomWalk 2.0)
    FSharpChart.FastLine(randomWalk 1.0)
    FSharpChart.FastLine(randomWalk 0.0)
    FSharpChart.FastLine(randomWalk -1.0)
    FSharpChart.FastLine(randomWalk -2.0) ]


// --------------------------------------------------------------------------------------
// Specifying additional properties 
// --------------------------------------------------------------------------------------

// Creates plot of a 'sin' function drawn in bold green 
// with yellow background and fancy chart title

// We can set properties while creating the chart
// NOTE: To keep some correspondence with the .NET charting API, we need
// to create 'Series' object to specify series-related properties and 
// similary 'ChartArea' object - we could possibly include some 
// common properties in the 'GenericChart' object directly.
FSharpChart.Line
  ( [ for f in 1.0 .. 0.1 .. 10.0 -> f, sin f ], 
    Title = new Title("Sin function", TextStyle = TextStyle.Frame, Font = new Font("Arial", 30.0f)),
    Background = ChartStyles.Background.Solid Color.PaleGoldenrod, Margin = (0.0f, 15.0f, 3.0f, 1.0f),
    Series = new Series(Color = Color.OliveDrab, BorderWidth = 2, ToolTip = "(#VALX{#0.000}, #VAL{#,##0.000;-#,##0.000})"),
    Area = new ChartArea( BackColor = Color.White, BackSecondaryColor = Color.LightYellow, 
                          BackGradientStyle = GradientStyle.DiagonalLeft) )

// The same thing wrtiten using 'chart' object and pipelining syntax
FSharpChart.Line [ for f in 1.0 .. 0.1 .. 10.0 -> f, sin f ]
|> FSharpChart.WithTitle("Sin function", TextStyle = TextStyle.Frame, Font = new Font("Arial", 30.0f))
|> FSharpChart.WithStyle(Background = ChartStyles.Background.Solid Color.PaleGoldenrod)
|> FSharpChart.WithMargin(0.0f, 15.0f, 3.0f, 1.0f)
|> FSharpChart.WithSeries.Style(Color = Color.OliveDrab, BorderWidth = 2)
|> FSharpChart.WithSeries.DataPoint(ToolTip = "(#VALX{#0.000}, #VAL{#,##0.000;-#,##0.000})")
|> FSharpChart.WithArea.Style(Background = ChartStyles.Background.Gradient(Color.White, Color.LightYellow, GradientStyle.DiagonalLeft))



// --------------------------------------------------------------------------------------
// Combining multiple data series in a single area
// --------------------------------------------------------------------------------------

// Single chart showing 'sin' and 'cos' functions
FSharpChart.Combine
  [ FSharpChart.Line [ for f in 0.0 .. 0.1 .. 10.0 -> sin f ]
    FSharpChart.Line [ for f in 0.0 .. 0.1 .. 10.0 -> cos f ] ]

// Displaying charts in two rows (or similarly columns)
FSharpChart.Rows
  [ FSharpChart.Line [ for f in 0.0 .. 0.1 .. 10.0 -> sin f ]
    FSharpChart.Line [ for f in 0.0 .. 0.1 .. 10.0 -> cos f ] ]

// We can generate combined chart using sequence expressions
// NOTE: When using 'yield', an upcats is necessary
FSharpChart.Combine
  [ for offs in 0.0 .. 0.2 .. 2.0 do
      yield (upcast FSharpChart.Line [ for f in 0.0 .. 0.1 .. 10.0 -> sin (f + offs) ])  ]

// We can use '|>' to specify visual aspects of individual 
// series as well as of the entire chart area
FSharpChart.Combine
    [ FSharpChart.Line [ for f in 0.0 .. 0.1 .. 10.0 -> sin f ]
      |> FSharpChart.WithSeries.Style(BorderWidth = 20)
      FSharpChart.Line [ for f in 0.0 .. 0.1 .. 10.0 -> cos f ] 
      |> FSharpChart.WithSeries.Style(BorderWidth = 10) ]
    |> FSharpChart.WithArea.AxisX(MajorGrid = Grid(LineColor = Color.LightGray))
    |> FSharpChart.WithArea.AxisY
        ( Minimum = -1.0, Maximum = 1.0, 
          MajorGrid = Grid(LineColor = Color.LightGray) )
    |> FSharpChart.WithMargin(5.0f, 5.0f, 5.0f, 5.0f)


// --------------------------------------------------------------------------------------
// Larger examples
// (Based on 'stockchart' from http://code.msdn.microsoft.com/fschart)
// --------------------------------------------------------------------------------------

// Generate 4 series of stock data (4 values per Y point)
let [data1; data2; data3; data4] = 
  List.init 4 (fun _ -> Data.brownianBarsAsList 1000 20)

/// Takes data & chart object and sets range of the 
/// area and visual properties of the chart object 
let setupChart data chartObject = 
    // Get maximal value and minimal value of stock prices
    let tup2 (_, a, _, _) = a
    let tup1 (a, _, _, _) = a
    let min = Math.Round((data |> Seq.map (snd >> tup2) |> Seq.min : float), 1) - 0.5
    let max = Math.Round((data |> Seq.map (snd >> tup1) |> Seq.max : float), 1) + 0.5

    // Configure the chart object using pipelining syntax
    chartObject
    |> FSharpChart.WithArea.Style(Background = ChartStyles.Background.Gradient(Color.White, Color.LightSteelBlue, GradientStyle.TopBottom))
    |> FSharpChart.WithLegend
        ( InsideArea = false, Background = ChartStyles.Background.Solid Color.Transparent, Font = new Font("Arial", 8.0f), 
          Alignment = StringAlignment.Near, Docking = Docking.Top)
    |> FSharpChart.WithArea.AxisX
        ( LabelStyle = new LabelStyle(Format = "yyyy\nMM-dd", Font = new Font("Arial", 7.0f)), 
          MajorGrid = Grid(Enabled = false), IsMarginVisible = true)
    |> FSharpChart.WithArea.AxisY
        ( Maximum = max, Minimum = min, MajorGrid = Grid(Enabled = false), 
          LabelStyle = new LabelStyle(Format = "F1", Font = new Font("Arial", 7.0f)) )


// Create 2x2 matrix with various financial charts
FSharpChart.Rows
    [ FSharpChart.Columns
        [ FSharpChart.Candlestick(data1, PointWidth = 0.5) |> setupChart data1
          FSharpChart.Stock(data2, PointWidth = 0.5) |> setupChart data2 ]
      FSharpChart.Columns
        [ FSharpChart.Stock(data3, PointWidth = 0.5) |> setupChart data3
          FSharpChart.Candlestick(data4, PointWidth = 0.5) |> setupChart data4 ]
      |> FSharpChart.WithMargin(0.0f, 5.0f, 0.0f, 0.0f) ]
|> FSharpChart.WithMargin(0.0f, 15.0f, 2.0f, 1.0f)
|> FSharpChart.WithTitle("StockPrices", Font = new Font("Arial", 16.0f))
|> FSharpChart.WithStyle(Background = ChartStyles.Background.Solid Color.LightSteelBlue)


// --------------------------------------------------------------------------------------
// Some stuff around StackedCharts
// -----------------------------------------------------------------------------------

let rndStacked = new System.Random()
let dataX() = [ for f in 1 .. 10 -> rndStacked.NextDouble() * 10.0]
let dataXY() = [ for f in 1 .. 10 -> (f, round (rndStacked.NextDouble() * 100.0))]

// Simple stacked chart
FSharpChart.Combine
  [ FSharpChart.StackedBar100(dataX(), StackedGroupName = "g1")
    FSharpChart.StackedBar100(dataX(), StackedGroupName = "g1")
    FSharpChart.StackedBar100(dataX(), StackedGroupName = "g2") ]

// Multiple stacked charts
FSharpChart.Combine
  [ FSharpChart.StackedBar(dataX(), StackedGroupName = "g1")
    FSharpChart.StackedBar(dataX(), StackedGroupName = "g1")
    FSharpChart.StackedBar(dataX(), StackedGroupName = "g1")
    FSharpChart.StackedBar(dataX(), StackedGroupName = "g2")
    FSharpChart.StackedBar(dataX(), StackedGroupName = "g2") ]

// Combined with lables
FSharpChart.Combine
  [ FSharpChart.StackedColumn(dataXY(), StackedGroupName = "g1")
    |> FSharpChart.WithSeries.DataPoint(Label="#VAL")
    FSharpChart.StackedColumn(dataXY(), StackedGroupName = "g1")
    |> FSharpChart.WithSeries.DataPoint(Label="#VAL")
    FSharpChart.StackedColumn(dataXY(), StackedGroupName = "g1")
    |> FSharpChart.WithSeries.DataPoint(Label="#VAL") ]

// Using list<list<'T>> bindings
[dataXY(); dataXY()]
|> FSharpChart.StackedArea
|> FSharpChart.WithSeries.DataPoint(Label="#VAL")

[dataXY(); dataXY(); dataXY()]
|> FSharpChart.StackedColumn
|> FSharpChart.WithSeries.DataPoint(Label="#VAL")

[dataXY(); dataXY()]
|> FSharpChart.StackedArea