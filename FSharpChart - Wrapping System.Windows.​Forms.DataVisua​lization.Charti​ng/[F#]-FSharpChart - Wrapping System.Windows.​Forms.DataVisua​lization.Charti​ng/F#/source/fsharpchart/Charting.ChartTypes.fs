namespace MSDN.FSharp.Charting
    
open System
open System.Drawing
open System.Collections.Generic
open System.Windows.Forms
open System.Windows.Forms.DataVisualization.Charting

open MSDN.FSharp.Charting.ChartStyles
open MSDN.FSharp.Charting.ChartData
open MSDN.FSharp.Charting.ChartData.Internal
open MSDN.FSharp.Charting.ChartFormUtilities


module ChartTypes = 

    [<AbstractClass>]
    type GenericChart() as self =     
               
        // Events
        let propChangedMargin = Event<float32 * float32 * float32 * float32>()
        let propChangedBackground = Event<Background>()
        let propChangedName = Event<string>()
        let propChangedTitle = Event<Title>()
        let propChangedLegend = Event<Legend>()
        let propChangedCustom = Event<string * obj>()

        let customProperties = new Dictionary<_, _>()

        let mutable area = lazy (
            let area = new ChartArea()
            applyPropertyDefaults (self.ChartType) area
            area)

        let mutable series = lazy (
            let series = new Series()
            applyPropertyDefaults (self.ChartType) series
            series)

        let mutable chart = lazy (
            let ch = new Chart()
            applyPropertyDefaults (self.ChartType) ch
            ch)

        let mutable title = lazy (
            let title = new Title()
            applyPropertyDefaults (self.ChartType) title
            title)

        let mutable legend = lazy (
            let legend = new Legend()
            applyPropertyDefaults (self.ChartType) legend
            legend)

        let mutable name:string = ""

        let evalLazy v =
          let l = lazy v
          l.Force() |> ignore
          l

        let mutable data = ChartData.YValues []
        let mutable margin = (0.0f, 0.0f, 0.0f, 0.0f)
        let titles = new ResizeArray<Title>()
        let legends = new ResizeArray<Legend>()

        abstract ChartType : SeriesChartType
    
        member internal x.Data with get() = data and set v = data <- v
        member internal x.Chart with get() = chart.Value and set v = chart <- evalLazy v
        
        // deal with properties that raise events
        member x.Margin with get() = margin
                        and set v =
                            margin <- v
                            propChangedMargin.Trigger(v)

        member x.Background with set v =
                                applyBackground chart.Value v
                                propChangedBackground.Trigger(v)

        member x.Name with get() = name
                      and set v =
                          name <- v
                          propChangedName.Trigger(v)

        member x.Title with get() = title.Value 
                       and set v = 
                           title <- evalLazy v
                           propChangedTitle.Trigger(v)

        member x.Legend with get() = legend.Value
                        and set v =
                            legend <- evalLazy v
                            propChangedLegend.Trigger(v)        

        // other properties
        member x.Area with get() = area.Value
                      and set v =
                          area <- evalLazy v

        member x.Series with get() = series.Value
                        and set v =
                            series <- evalLazy v

        // internal
        member internal x.Titles = titles
        member internal x.LazyTitle = title
        member internal x.Legends = legends
        member internal x.LazyLegend = legend

        member internal x.LazyChart = chart
        member internal x.LazyArea = area
        member internal x.LazySeries = series
        
        [<CLIEvent>]
        member x.MarginChanged = propChangedMargin.Publish
        [<CLIEvent>]
        member x.BackgroundChanged = propChangedBackground.Publish
        [<CLIEvent>]
        member x.NameChanged = propChangedName.Publish
        [<CLIEvent>]
        member x.TitleChanged = propChangedTitle.Publish
        [<CLIEvent>]
        member x.LegendChanged = propChangedLegend.Publish
        [<CLIEvent>]
        member x.CustomPropertyChanged = propChangedCustom.Publish

        member x.CustomProperties = 
            customProperties :> seq<_>

        member x.GetCustomProperty<'T>(name, def) = 
            match customProperties.TryGetValue name with
            | true, v -> (box v) :?> 'T
            | _ -> def

        member x.SetCustomProperty<'T>(name, v:'T) = 
            customProperties.[name] <- box v
            propChangedCustom.Trigger((name, box v))

        static member internal Create<'T when 'T :> GenericChart and 'T : (new : unit -> 'T)>(data) : 'T =
            let t = new 'T()
            t.Data <- data
            t

        member public x.CopyChartToClipboard() =
            use ms = new IO.MemoryStream()
            x.Chart.SaveImage(ms, ChartImageFormat.Png)
            ms.Seek(0L, IO.SeekOrigin.Begin) |> ignore
            Clipboard.SetImage(Bitmap.FromStream ms)

        member public x.CopyChartToClipboardEmf(control:Control) =
            use ms = new IO.MemoryStream()
            x.Chart.SaveImage(ms, ChartImageFormat.Emf)
            ms.Seek(0L, IO.SeekOrigin.Begin) |> ignore
            use emf = new System.Drawing.Imaging.Metafile(ms)
            ClipboardMetafileHelper.PutEnhMetafileOnClipboard(control.Handle, emf) |> ignore

        member public x.SaveChartAs(filename : string, format : ChartImageFormat) =
            x.Chart.SaveImage(filename, format)

        // property used for chart binding
        member x.ChartBinder with get() =
                                let binder:ChartBinder<string> = { ChartBinder.Chart = x.Chart; ChartBinder.SetCustomProperty = x.SetCustomProperty}
                                binder

    [<AbstractClass>]
    type GenericChart<'TData when 'TData :> DataSource and 'TData : (new : unit -> 'TData)>() = 
        inherit GenericChart()

    type private ColorWrapper(clr:Color) =
        member x.Color = clr
        override x.ToString() =
            if clr.IsEmpty then "Empty" else
            sprintf "%d" (clr.ToArgb()) // clr.R clr.G clr.B

    // ------------------------------------------------------------------------------------
    // [AUTOGENERATED]: Specific chart types for setting custom properties

    /// Displays multiple series of data as stacked areas. The cumulative proportion
    /// of each stacked element is always 100% of the Y
    /// axis.
    type StackedArea100Chart() = 
        inherit GenericChart<OneValue>()

        /// Returns the type of the chart series
        override x.ChartType = SeriesChartType.StackedArea100

        /// <summary>
        ///   Specifies the 3D series depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointDepth
            with get() = x.GetCustomProperty<int>("PixelPointDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointDepth", v)

        /// <summary>
        ///   Specifies the 3D gap depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointGapDepth
            with get() = x.GetCustomProperty<int>("PixelPointGapDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointGapDepth", v)


    /// Displays multiple series of data as stacked bars. The cumulative
    /// proportion of each stacked element is always 100% of the Y axis.
    type StackedBar100Chart() = 
        inherit GenericChart<OneValue>()

        /// Returns the type of the chart series
        override x.ChartType = SeriesChartType.StackedBar100

        /// Specifies the placement of the data point label.
        member x.BarLabelStyle
            with get() = x.GetCustomProperty<BarLabelStyle>("BarLabelStyle", BarLabelStyle.Outside)
            and set(v) = x.SetCustomProperty<BarLabelStyle>("BarLabelStyle", v)

        /// Specifies the drawing style of data points.
        member x.DrawingStyle
            with get() = x.GetCustomProperty<DrawingStyle>("DrawingStyle", DrawingStyle.Default)
            and set(v) = x.SetCustomProperty<DrawingStyle>("DrawingStyle", v)

        /// <summary>
        ///   Specifies the maximum width of the data point in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.MaxPixelPointWidth
            with get() = x.GetCustomProperty<int>("MaxPixelPointWidth", 0)
            and set(v) = x.SetCustomProperty<int>("MaxPixelPointWidth", v)

        /// <summary>
        ///   Specifies the minimum data point width in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.MinPixelPointWidth
            with get() = x.GetCustomProperty<int>("MinPixelPointWidth", 0)
            and set(v) = x.SetCustomProperty<int>("MinPixelPointWidth", v)

        /// <summary>
        ///   Specifies the 3D series depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointDepth
            with get() = x.GetCustomProperty<int>("PixelPointDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointDepth", v)

        /// <summary>
        ///   Specifies the 3D gap depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointGapDepth
            with get() = x.GetCustomProperty<int>("PixelPointGapDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointGapDepth", v)

        /// <summary>
        ///   Specifies the data point width in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointWidth
            with get() = x.GetCustomProperty<int>("PixelPointWidth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointWidth", v)

        /// <summary>
        ///   Specifies the relative data point width.
        /// </summary>
        /// <remarks>Any double from 0 to 2.</remarks>
        member x.PointWidth
            with get() = x.GetCustomProperty<float>("PointWidth", 0.8)
            and set(v) = x.SetCustomProperty<float>("PointWidth", v)

        /// Specifies the name of the stacked group.
        member x.StackedGroupName
            with get() = x.GetCustomProperty<string>("StackedGroupName", "")
            and set(v) = x.SetCustomProperty<string>("StackedGroupName", v)


    /// Displays multiple series of data as stacked columns. The cumulative
    /// proportion of each stacked element is always 100% of the
    /// Y axis.
    type StackedColumn100Chart() = 
        inherit GenericChart<OneValue>()

        /// Returns the type of the chart series
        override x.ChartType = SeriesChartType.StackedColumn100

        /// Specifies the drawing style of data points.
        member x.DrawingStyle
            with get() = x.GetCustomProperty<DrawingStyle>("DrawingStyle", DrawingStyle.Default)
            and set(v) = x.SetCustomProperty<DrawingStyle>("DrawingStyle", v)

        /// <summary>
        ///   Specifies the maximum width of the data point in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.MaxPixelPointWidth
            with get() = x.GetCustomProperty<int>("MaxPixelPointWidth", 0)
            and set(v) = x.SetCustomProperty<int>("MaxPixelPointWidth", v)

        /// <summary>
        ///   Specifies the minimum data point width in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.MinPixelPointWidth
            with get() = x.GetCustomProperty<int>("MinPixelPointWidth", 0)
            and set(v) = x.SetCustomProperty<int>("MinPixelPointWidth", v)

        /// <summary>
        ///   Specifies the 3D series depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointDepth
            with get() = x.GetCustomProperty<int>("PixelPointDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointDepth", v)

        /// <summary>
        ///   Specifies the 3D gap depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointGapDepth
            with get() = x.GetCustomProperty<int>("PixelPointGapDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointGapDepth", v)

        /// <summary>
        ///   Specifies the data point width in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointWidth
            with get() = x.GetCustomProperty<int>("PixelPointWidth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointWidth", v)

        /// <summary>
        ///   Specifies the relative data point width.
        /// </summary>
        /// <remarks>Any double from 0 to 2.</remarks>
        member x.PointWidth
            with get() = x.GetCustomProperty<float>("PointWidth", 0.8)
            and set(v) = x.SetCustomProperty<float>("PointWidth", v)

        /// Specifies the name of the stacked group.
        member x.StackedGroupName
            with get() = x.GetCustomProperty<string>("StackedGroupName", "")
            and set(v) = x.SetCustomProperty<string>("StackedGroupName", v)


    /// Emphasizes the degree of change over time and shows the
    /// relationship of the parts to a whole.
    type AreaChart() = 
        inherit GenericChart<OneValue>()

        /// Returns the type of the chart series
        override x.ChartType = SeriesChartType.Area

        /// Specifies the value to be used for empty points.
        member x.EmptyPointValue
            with get() = x.GetCustomProperty<EmptyPointValue>("EmptyPointValue", EmptyPointValue.Average)
            and set(v) = x.SetCustomProperty<EmptyPointValue>("EmptyPointValue", v)

        /// Specifies the label position of the data point.
        member x.LabelStyle
            with get() = x.GetCustomProperty<LabelStyle>("LabelStyle", LabelStyle.Auto)
            and set(v) = x.SetCustomProperty<LabelStyle>("LabelStyle", v)

        /// <summary>
        ///   Specifies the 3D series depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointDepth
            with get() = x.GetCustomProperty<int>("PixelPointDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointDepth", v)

        /// <summary>
        ///   Specifies the 3D gap depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointGapDepth
            with get() = x.GetCustomProperty<int>("PixelPointGapDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointGapDepth", v)

        /// Specifies whether marker lines are displayed when rendered in 3D.
        member x.ShowMarkerLines
            with get() = x.GetCustomProperty<bool>("ShowMarkerLines", false)
            and set(v) = x.SetCustomProperty<bool>("ShowMarkerLines", v)


    /// Illustrates comparisons among individual items.
    type BarChart() = 
        inherit GenericChart<OneValue>()

        /// Returns the type of the chart series
        override x.ChartType = SeriesChartType.Bar

        /// Specifies the placement of the data point label.
        member x.BarLabelStyle
            with get() = x.GetCustomProperty<BarLabelStyle>("BarLabelStyle", BarLabelStyle.Outside)
            and set(v) = x.SetCustomProperty<BarLabelStyle>("BarLabelStyle", v)

        /// Specifies the drawing style of data points.
        member x.DrawingStyle
            with get() = x.GetCustomProperty<DrawingStyle>("DrawingStyle", DrawingStyle.Default)
            and set(v) = x.SetCustomProperty<DrawingStyle>("DrawingStyle", v)

        /// Specifies whether series of the same chart type are drawn
        /// next to each other instead of overlapping each other.
        member x.DrawSideBySide
            with get() = x.GetCustomProperty<DrawSideBySide>("DrawSideBySide", DrawSideBySide.Auto)
            and set(v) = x.SetCustomProperty<DrawSideBySide>("DrawSideBySide", v)

        /// Specifies the value to be used for empty points.
        member x.EmptyPointValue
            with get() = x.GetCustomProperty<EmptyPointValue>("EmptyPointValue", EmptyPointValue.Average)
            and set(v) = x.SetCustomProperty<EmptyPointValue>("EmptyPointValue", v)

        /// <summary>
        ///   Specifies the maximum width of the data point in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.MaxPixelPointWidth
            with get() = x.GetCustomProperty<int>("MaxPixelPointWidth", 0)
            and set(v) = x.SetCustomProperty<int>("MaxPixelPointWidth", v)

        /// <summary>
        ///   Specifies the minimum data point width in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.MinPixelPointWidth
            with get() = x.GetCustomProperty<int>("MinPixelPointWidth", 0)
            and set(v) = x.SetCustomProperty<int>("MinPixelPointWidth", v)

        /// <summary>
        ///   Specifies the 3D series depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointDepth
            with get() = x.GetCustomProperty<int>("PixelPointDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointDepth", v)

        /// <summary>
        ///   Specifies the 3D gap depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointGapDepth
            with get() = x.GetCustomProperty<int>("PixelPointGapDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointGapDepth", v)

        /// <summary>
        ///   Specifies the data point width in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointWidth
            with get() = x.GetCustomProperty<int>("PixelPointWidth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointWidth", v)

        /// <summary>
        ///   Specifies the relative data point width.
        /// </summary>
        /// <remarks>Any double from 0 to 2.</remarks>
        member x.PointWidth
            with get() = x.GetCustomProperty<float>("PointWidth", 0.8)
            and set(v) = x.SetCustomProperty<float>("PointWidth", v)


    /// Consists of one or more box symbols that summarize the
    /// distribution of the data within one or more data sets.
    type BoxPlotChart() = 
        inherit GenericChart<MultiValue>()

        /// Returns the type of the chart series
        override x.ChartType = SeriesChartType.BoxPlot

        /// <summary>
        ///   Specifies the percentile value of the box of the Box
        ///   Plot chart.
        /// </summary>
        /// <remarks>Any integer from 0 to 50.</remarks>
        member x.BoxPlotPercentile
            with get() = x.GetCustomProperty<int>("BoxPlotPercentile", 25)
            and set(v) = x.SetCustomProperty<int>("BoxPlotPercentile", v)

        /// Specifies the name of the series to be used as
        /// the data source for the Box Plot chart.
        member x.BoxPlotSeries
            with get() = x.GetCustomProperty<string>("BoxPlotSeries", "")
            and set(v) = x.SetCustomProperty<string>("BoxPlotSeries", v)

        /// Specifies whether to display the average value for the Box
        /// Plot chart.
        member x.BoxPlotShowAverage
            with get() = x.GetCustomProperty<bool>("BoxPlotShowAverage", true)
            and set(v) = x.SetCustomProperty<bool>("BoxPlotShowAverage", v)

        /// Specifies whether to display the median value for the Box
        /// Plot chart.
        member x.BoxPlotShowMedian
            with get() = x.GetCustomProperty<bool>("BoxPlotShowMedian", true)
            and set(v) = x.SetCustomProperty<bool>("BoxPlotShowMedian", v)

        /// Specifies whether the unusual values value for the Box Plot
        /// chart will be shown.
        member x.BoxPlotShowUnusualValues
            with get() = x.GetCustomProperty<bool>("BoxPlotShowUnusualValues", true)
            and set(v) = x.SetCustomProperty<bool>("BoxPlotShowUnusualValues", v)

        /// <summary>
        ///   Specifies the percentile value of the whiskers of the Box
        ///   Plot chart.
        /// </summary>
        /// <remarks>Any integer from 0 to 50.</remarks>
        member x.BoxPlotWhiskerPercentile
            with get() = x.GetCustomProperty<int>("BoxPlotWhiskerPercentile", 10)
            and set(v) = x.SetCustomProperty<int>("BoxPlotWhiskerPercentile", v)

        /// Specifies whether series of the same chart type are drawn
        /// next to each other instead of overlapping each other.
        member x.DrawSideBySide
            with get() = x.GetCustomProperty<DrawSideBySide>("DrawSideBySide", DrawSideBySide.Auto)
            and set(v) = x.SetCustomProperty<DrawSideBySide>("DrawSideBySide", v)

        /// <summary>
        ///   Specifies the maximum width of the data point in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.MaxPixelPointWidth
            with get() = x.GetCustomProperty<int>("MaxPixelPointWidth", 0)
            and set(v) = x.SetCustomProperty<int>("MaxPixelPointWidth", v)

        /// <summary>
        ///   Specifies the minimum data point width in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.MinPixelPointWidth
            with get() = x.GetCustomProperty<int>("MinPixelPointWidth", 0)
            and set(v) = x.SetCustomProperty<int>("MinPixelPointWidth", v)

        /// <summary>
        ///   Specifies the 3D series depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointDepth
            with get() = x.GetCustomProperty<int>("PixelPointDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointDepth", v)

        /// <summary>
        ///   Specifies the 3D gap depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointGapDepth
            with get() = x.GetCustomProperty<int>("PixelPointGapDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointGapDepth", v)

        /// <summary>
        ///   Specifies the data point width in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointWidth
            with get() = x.GetCustomProperty<int>("PixelPointWidth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointWidth", v)

        /// <summary>
        ///   Specifies the relative data point width.
        /// </summary>
        /// <remarks>Any double from 0 to 2.</remarks>
        member x.PointWidth
            with get() = x.GetCustomProperty<float>("PointWidth", 0.8)
            and set(v) = x.SetCustomProperty<float>("PointWidth", v)


    /// A variation of the Point chart type, where the data
    /// points are replaced by bubbles of different sizes.
    type BubbleChart() = 
        inherit GenericChart<TwoValue>()

        /// Returns the type of the chart series
        override x.ChartType = SeriesChartType.Bubble

        /// <summary>
        ///   Specifies the maximum size of the bubble radius as a
        ///   percentage of the chart area size.
        /// </summary>
        /// <remarks>Any integer from 0 to 100.</remarks>
        member x.BubbleMaxSize
            with get() = x.GetCustomProperty<int>("BubbleMaxSize", 15)
            and set(v) = x.SetCustomProperty<int>("BubbleMaxSize", v)

        /// <summary>
        ///   Specifies the minimum size of the bubble radius as a
        ///   percentage of the chart area size.
        /// </summary>
        /// <remarks>Any integer from 0 to 100.</remarks>
        member x.BubbleMinSize
            with get() = x.GetCustomProperty<int>("BubbleMinSize", 3)
            and set(v) = x.SetCustomProperty<int>("BubbleMinSize", v)

        /// <summary>
        ///   Specifies the maximum bubble size, which is a percentage of
        ///   the chart area that is set by BubbleMaxSize.
        /// </summary>
        /// <remarks>Any double.</remarks>
        member x.BubbleScaleMax
            with get() = x.GetCustomProperty<float>("BubbleScaleMax", 15.0)
            and set(v) = x.SetCustomProperty<float>("BubbleScaleMax", v)

        /// <summary>
        ///   Specifies the minimum bubble size, which is a percentage of
        ///   the chart area that is set by BubbleMinSize.
        /// </summary>
        /// <remarks>Any double.</remarks>
        member x.BubbleScaleMin
            with get() = x.GetCustomProperty<float>("BubbleScaleMin", 3.0)
            and set(v) = x.SetCustomProperty<float>("BubbleScaleMin", v)

        /// Specifies whether to use the bubble size as the data
        /// point label.
        member x.BubbleUseSizeForLabel
            with get() = x.GetCustomProperty<bool>("BubbleUseSizeForLabel", false)
            and set(v) = x.SetCustomProperty<bool>("BubbleUseSizeForLabel", v)

        /// Specifies the value to be used for empty points.
        member x.EmptyPointValue
            with get() = x.GetCustomProperty<EmptyPointValue>("EmptyPointValue", EmptyPointValue.Average)
            and set(v) = x.SetCustomProperty<EmptyPointValue>("EmptyPointValue", v)

        /// Specifies the label position of the data point.
        member x.LabelStyle
            with get() = x.GetCustomProperty<LabelStyle>("LabelStyle", LabelStyle.Auto)
            and set(v) = x.SetCustomProperty<LabelStyle>("LabelStyle", v)

        /// <summary>
        ///   Specifies the 3D series depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointDepth
            with get() = x.GetCustomProperty<int>("PixelPointDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointDepth", v)

        /// <summary>
        ///   Specifies the 3D gap depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointGapDepth
            with get() = x.GetCustomProperty<int>("PixelPointGapDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointGapDepth", v)


    /// Used to display stock information using high, low, open and
    /// close values.
    type CandlestickChart() = 
        inherit GenericChart<FourValue>()

        /// Returns the type of the chart series
        override x.ChartType = SeriesChartType.Candlestick

        /// Specifies the Y value to use as the data point
        /// label.
        member x.LabelValueType
            with get() = x.GetCustomProperty<LabelValueType>("LabelValueType", LabelValueType.Close)
            and set(v) = x.SetCustomProperty<LabelValueType>("LabelValueType", v)

        /// <summary>
        ///   Specifies the maximum width of the data point in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.MaxPixelPointWidth
            with get() = x.GetCustomProperty<int>("MaxPixelPointWidth", 0)
            and set(v) = x.SetCustomProperty<int>("MaxPixelPointWidth", v)

        /// <summary>
        ///   Specifies the minimum data point width in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.MinPixelPointWidth
            with get() = x.GetCustomProperty<int>("MinPixelPointWidth", 0)
            and set(v) = x.SetCustomProperty<int>("MinPixelPointWidth", v)

        /// <summary>
        ///   Specifies the 3D series depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointDepth
            with get() = x.GetCustomProperty<int>("PixelPointDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointDepth", v)

        /// <summary>
        ///   Specifies the 3D gap depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointGapDepth
            with get() = x.GetCustomProperty<int>("PixelPointGapDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointGapDepth", v)

        /// <summary>
        ///   Specifies the data point width in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointWidth
            with get() = x.GetCustomProperty<int>("PixelPointWidth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointWidth", v)

        /// <summary>
        ///   Specifies the relative data point width.
        /// </summary>
        /// <remarks>Any double from 0 to 2.</remarks>
        member x.PointWidth
            with get() = x.GetCustomProperty<float>("PointWidth", 0.8)
            and set(v) = x.SetCustomProperty<float>("PointWidth", v)

        /// Specifies the data point color to use to indicate a
        /// decreasing trend.
        member x.PriceDownColor
            with get() = x.GetCustomProperty<ColorWrapper>("PriceDownColor", ColorWrapper(Color.Empty)).Color
            and set(v) = x.SetCustomProperty<ColorWrapper>("PriceDownColor", ColorWrapper(v))

        /// Specifies the data point color that indicates an increasing trend.
        member x.PriceUpColor
            with get() = x.GetCustomProperty<ColorWrapper>("PriceUpColor", ColorWrapper(Color.Empty)).Color
            and set(v) = x.SetCustomProperty<ColorWrapper>("PriceUpColor", ColorWrapper(v))


    /// Uses a sequence of columns to compare values across categories.
    type ColumnChart() = 
        inherit GenericChart<OneValue>()

        /// Returns the type of the chart series
        override x.ChartType = SeriesChartType.Column

        /// Specifies the drawing style of data points.
        member x.DrawingStyle
            with get() = x.GetCustomProperty<DrawingStyle>("DrawingStyle", DrawingStyle.Default)
            and set(v) = x.SetCustomProperty<DrawingStyle>("DrawingStyle", v)

        /// Specifies whether series of the same chart type are drawn
        /// next to each other instead of overlapping each other.
        member x.DrawSideBySide
            with get() = x.GetCustomProperty<DrawSideBySide>("DrawSideBySide", DrawSideBySide.Auto)
            and set(v) = x.SetCustomProperty<DrawSideBySide>("DrawSideBySide", v)

        /// Specifies the value to be used for empty points.
        member x.EmptyPointValue
            with get() = x.GetCustomProperty<EmptyPointValue>("EmptyPointValue", EmptyPointValue.Average)
            and set(v) = x.SetCustomProperty<EmptyPointValue>("EmptyPointValue", v)

        /// Specifies the label position of the data point.
        member x.LabelStyle
            with get() = x.GetCustomProperty<LabelStyle>("LabelStyle", LabelStyle.Auto)
            and set(v) = x.SetCustomProperty<LabelStyle>("LabelStyle", v)

        /// <summary>
        ///   Specifies the maximum width of the data point in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.MaxPixelPointWidth
            with get() = x.GetCustomProperty<int>("MaxPixelPointWidth", 0)
            and set(v) = x.SetCustomProperty<int>("MaxPixelPointWidth", v)

        /// <summary>
        ///   Specifies the minimum data point width in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.MinPixelPointWidth
            with get() = x.GetCustomProperty<int>("MinPixelPointWidth", 0)
            and set(v) = x.SetCustomProperty<int>("MinPixelPointWidth", v)

        /// <summary>
        ///   Specifies the 3D series depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointDepth
            with get() = x.GetCustomProperty<int>("PixelPointDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointDepth", v)

        /// <summary>
        ///   Specifies the 3D gap depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointGapDepth
            with get() = x.GetCustomProperty<int>("PixelPointGapDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointGapDepth", v)

        /// <summary>
        ///   Specifies the data point width in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointWidth
            with get() = x.GetCustomProperty<int>("PixelPointWidth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointWidth", v)

        /// <summary>
        ///   Specifies the relative data point width.
        /// </summary>
        /// <remarks>Any double from 0 to 2.</remarks>
        member x.PointWidth
            with get() = x.GetCustomProperty<float>("PointWidth", 0.8)
            and set(v) = x.SetCustomProperty<float>("PointWidth", v)


    /// Similar to the Pie chart type, except that it has
    /// a hole in the center.
    type DoughnutChart() = 
        inherit GenericChart<OneValue>()

        /// Returns the type of the chart series
        override x.ChartType = SeriesChartType.Doughnut

        /// <summary>
        ///   Specifies the 3D label line size as a percentage of
        ///   the default size.
        /// </summary>
        /// <remarks>Any integer from 30 to 200.</remarks>
        member x.LabelLineSize3D
            with get() = x.GetCustomProperty<int>("3DLabelLineSize", 100)
            and set(v) = x.SetCustomProperty<int>("3DLabelLineSize", v)

        /// Specifies the color of the collected pie or doughnut slice.
        member x.CollectedColor
            with get() = x.GetCustomProperty<ColorWrapper>("CollectedColor", ColorWrapper(Color.Empty)).Color
            and set(v) = x.SetCustomProperty<ColorWrapper>("CollectedColor", ColorWrapper(v))

        /// Specifies the label of the collected pie slice.
        member x.CollectedLabel
            with get() = x.GetCustomProperty<string>("CollectedLabel", "")
            and set(v) = x.SetCustomProperty<string>("CollectedLabel", v)

        /// Specifies the legend text for the collected pie slice.
        member x.CollectedLegendText
            with get() = x.GetCustomProperty<string>("CollectedLegendText", "")
            and set(v) = x.SetCustomProperty<string>("CollectedLegendText", v)

        /// Specifies whether the collected pie slice will be shown as
        /// exploded.
        member x.CollectedSliceExploded
            with get() = x.GetCustomProperty<bool>("CollectedSliceExploded", true)
            and set(v) = x.SetCustomProperty<bool>("CollectedSliceExploded", v)

        /// <summary>
        ///   Specifies the threshold value for collecting small pie slices.
        /// </summary>
        /// <remarks>Any double between 0 and 100 if CollectedThresholdUsePercent is true; otherwise, any double &gt; 0.</remarks>
        member x.CollectedThreshold
            with get() = x.GetCustomProperty<float>("CollectedThreshold", 0.0)
            and set(v) = x.SetCustomProperty<float>("CollectedThreshold", v)

        /// Specifies whether to use the collected threshold value as a
        /// percentage.
        member x.CollectedThresholdUsePercent
            with get() = x.GetCustomProperty<bool>("CollectedThresholdUsePercent", true)
            and set(v) = x.SetCustomProperty<bool>("CollectedThresholdUsePercent", v)

        /// Specifies the tooltip text of the collected pie slice.
        member x.CollectedToolTip
            with get() = x.GetCustomProperty<string>("CollectedToolTip", "")
            and set(v) = x.SetCustomProperty<string>("CollectedToolTip", v)

        /// <summary>
        ///   Specifies the radius of the doughnut portion in the Doughnut
        ///   chart.
        /// </summary>
        /// <remarks>Any integer from 0 to 100.</remarks>
        member x.DoughnutRadius
            with get() = x.GetCustomProperty<int>("DoughnutRadius", 60)
            and set(v) = x.SetCustomProperty<int>("DoughnutRadius", v)

        /// Specifies whether the Pie or Doughnut data point is exploded.
        member x.Exploded
            with get() = x.GetCustomProperty<bool>("Exploded", false)
            and set(v) = x.SetCustomProperty<bool>("Exploded", v)

        /// <summary>
        ///   Specifies the size of the horizontal segment of the callout
        ///   line.
        /// </summary>
        /// <remarks>Any integer from 0 to 100.</remarks>
        member x.LabelsHorizontalLineSize
            with get() = x.GetCustomProperty<int>("LabelsHorizontalLineSize", 1)
            and set(v) = x.SetCustomProperty<int>("LabelsHorizontalLineSize", v)

        /// <summary>
        ///   Specifies the size of the radial segment of the callout
        ///   line.
        /// </summary>
        /// <remarks>Any integer from 0 to 100.</remarks>
        member x.LabelsRadialLineSize
            with get() = x.GetCustomProperty<int>("LabelsRadialLineSize", 1)
            and set(v) = x.SetCustomProperty<int>("LabelsRadialLineSize", v)

        /// <summary>
        ///   Specifies the minimum pie or doughnut size.
        /// </summary>
        /// <remarks>Any integer from 10 to 70.</remarks>
        member x.MinimumRelativePieSize
            with get() = x.GetCustomProperty<int>("MinimumRelativePieSize", 30)
            and set(v) = x.SetCustomProperty<int>("MinimumRelativePieSize", v)

        /// Specifies the drawing style of the data points.
        member x.PieDrawingStyle
            with get() = x.GetCustomProperty<PieDrawingStyle>("PieDrawingStyle", PieDrawingStyle.Default)
            and set(v) = x.SetCustomProperty<PieDrawingStyle>("PieDrawingStyle", v)

        /// Specifies the label style of the data points.
        member x.PieLabelStyle
            with get() = x.GetCustomProperty<PieLabelStyle>("PieLabelStyle", PieLabelStyle.Inside)
            and set(v) = x.SetCustomProperty<PieLabelStyle>("PieLabelStyle", v)

        /// Specifies the color of the radial and horizontal segments of
        /// the callout lines.
        member x.PieLineColor
            with get() = x.GetCustomProperty<ColorWrapper>("PieLineColor", ColorWrapper(Color.Black)).Color
            and set(v) = x.SetCustomProperty<ColorWrapper>("PieLineColor", ColorWrapper(v))

        /// <summary>
        ///   Specifies the angle of the data point in the Pie
        ///   or Doughnut chart.
        /// </summary>
        /// <remarks>Any integer from 0 to 360.</remarks>
        member x.PieStartAngle
            with get() = x.GetCustomProperty<int>("PieStartAngle", 90)
            and set(v) = x.SetCustomProperty<int>("PieStartAngle", v)


    /// Consists of lines with markers that are used to display
    /// statistical information about the data displayed in a graph.
    type ErrorBarChart() = 
        inherit GenericChart<ThreeValue>()

        /// Returns the type of the chart series
        override x.ChartType = SeriesChartType.ErrorBar

        /// Specifies whether series of the same chart type are drawn
        /// next to each other instead of overlapping each other.
        member x.DrawSideBySide
            with get() = x.GetCustomProperty<DrawSideBySide>("DrawSideBySide", DrawSideBySide.Auto)
            and set(v) = x.SetCustomProperty<DrawSideBySide>("DrawSideBySide", v)

        /// Specifies the appearance of the marker at the center value
        /// of the error bar.
        member x.ErrorBarCenterMarkerStyle
            with get() = x.GetCustomProperty<ErrorBarCenterMarkerStyle>("ErrorBarCenterMarkerStyle", ErrorBarCenterMarkerStyle.None)
            and set(v) = x.SetCustomProperty<ErrorBarCenterMarkerStyle>("ErrorBarCenterMarkerStyle", v)

        /// Specifies the name of the series to be used as
        /// the data source for the Error Bar chart calculations.
        member x.ErrorBarSeries
            with get() = x.GetCustomProperty<string>("ErrorBarSeries", "")
            and set(v) = x.SetCustomProperty<string>("ErrorBarSeries", v)

        /// Specifies the visibility of the upper and lower error values.
        member x.ErrorBarStyle
            with get() = x.GetCustomProperty<ErrorBarStyle>("ErrorBarStyle", ErrorBarStyle.Both)
            and set(v) = x.SetCustomProperty<ErrorBarStyle>("ErrorBarStyle", v)

        /// Specifies how the upper and lower error values are calculated
        /// for the center values of the ErrorBarSeries.
        member x.ErrorBarType
            with get() = x.GetCustomProperty<ErrorBarType>("ErrorBarType", ErrorBarType.FixedValue)
            and set(v) = x.SetCustomProperty<ErrorBarType>("ErrorBarType", v)

        /// <summary>
        ///   Specifies the maximum width of the data point in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.MaxPixelPointWidth
            with get() = x.GetCustomProperty<int>("MaxPixelPointWidth", 0)
            and set(v) = x.SetCustomProperty<int>("MaxPixelPointWidth", v)

        /// <summary>
        ///   Specifies the minimum data point width in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.MinPixelPointWidth
            with get() = x.GetCustomProperty<int>("MinPixelPointWidth", 0)
            and set(v) = x.SetCustomProperty<int>("MinPixelPointWidth", v)

        /// <summary>
        ///   Specifies the 3D series depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointDepth
            with get() = x.GetCustomProperty<int>("PixelPointDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointDepth", v)

        /// <summary>
        ///   Specifies the 3D gap depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointGapDepth
            with get() = x.GetCustomProperty<int>("PixelPointGapDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointGapDepth", v)

        /// <summary>
        ///   Specifies the data point width in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointWidth
            with get() = x.GetCustomProperty<int>("PixelPointWidth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointWidth", v)

        /// <summary>
        ///   Specifies the relative data point width.
        /// </summary>
        /// <remarks>Any double from 0 to 2.</remarks>
        member x.PointWidth
            with get() = x.GetCustomProperty<float>("PointWidth", 0.8)
            and set(v) = x.SetCustomProperty<float>("PointWidth", v)


    /// A variation of the Line chart that significantly reduces the
    /// drawing time of a series that contains a very large
    /// number of data points.
    type FastLineChart() = 
        inherit GenericChart<OneValue>()

        /// Returns the type of the chart series
        override x.ChartType = SeriesChartType.FastLine

        /// <summary>
        ///   Specifies the 3D series depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointDepth
            with get() = x.GetCustomProperty<int>("PixelPointDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointDepth", v)

        /// <summary>
        ///   Specifies the 3D gap depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointGapDepth
            with get() = x.GetCustomProperty<int>("PixelPointGapDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointGapDepth", v)


    /// A variation of the Point chart type that significantly reduces
    /// the drawing time of a series that contains a very
    /// large number of data points.
    type FastPointChart() = 
        inherit GenericChart<OneValue>()

        /// Returns the type of the chart series
        override x.ChartType = SeriesChartType.FastPoint


    /// Displays in a funnel shape data that equals 100% when
    /// totaled.
    type FunnelChart() = 
        inherit GenericChart<OneValue>()

        /// Returns the type of the chart series
        override x.ChartType = SeriesChartType.Funnel

        /// Specifies the line color of the callout for the data
        /// point labels of Funnel or Pyramid charts.
        member x.CalloutLineColor
            with get() = x.GetCustomProperty<ColorWrapper>("CalloutLineColor", ColorWrapper(Color.Empty)).Color
            and set(v) = x.SetCustomProperty<ColorWrapper>("CalloutLineColor", ColorWrapper(v))

        /// Specifies the 3D drawing style of the Funnel chart type.
        member x.Funnel3DDrawingStyle
            with get() = x.GetCustomProperty<Funnel3DDrawingStyle>("Funnel3DDrawingStyle", Funnel3DDrawingStyle.SquareBase)
            and set(v) = x.SetCustomProperty<Funnel3DDrawingStyle>("Funnel3DDrawingStyle", v)

        /// <summary>
        ///   Specifies the 3D rotation angle of the Funnel chart type.
        /// </summary>
        /// <remarks>Any integer from -10 to 10.</remarks>
        member x.Funnel3DRotationAngle
            with get() = x.GetCustomProperty<int>("Funnel3DRotationAngle", 5)
            and set(v) = x.SetCustomProperty<int>("Funnel3DRotationAngle", v)

        /// Specifies the data point label placement of the Funnel chart
        /// type when the FunnelLabelStyle is set to Inside.
        member x.FunnelInsideLabelAlignment
            with get() = x.GetCustomProperty<FunnelInsideLabelAlignment>("FunnelInsideLabelAlignment", FunnelInsideLabelAlignment.Center)
            and set(v) = x.SetCustomProperty<FunnelInsideLabelAlignment>("FunnelInsideLabelAlignment", v)

        /// Specifies the data point label style of the Funnel chart
        /// type.
        member x.FunnelLabelStyle
            with get() = x.GetCustomProperty<FunnelLabelStyle>("FunnelLabelStyle", FunnelLabelStyle.OutsideInColumn)
            and set(v) = x.SetCustomProperty<FunnelLabelStyle>("FunnelLabelStyle", v)

        /// <summary>
        ///   Specifies the minimum height of a data point in the
        ///   Funnel chart, measured in relative coordinates.
        /// </summary>
        /// <remarks>Any integer from 0 to 100.</remarks>
        member x.FunnelMinPointHeight
            with get() = x.GetCustomProperty<int>("FunnelMinPointHeight", 0)
            and set(v) = x.SetCustomProperty<int>("FunnelMinPointHeight", v)

        /// <summary>
        ///   Specifies the neck height of the Funnel chart type.
        /// </summary>
        /// <remarks>Any integer from 0 to 100.</remarks>
        member x.FunnelNeckHeight
            with get() = x.GetCustomProperty<int>("FunnelNeckHeight", 5)
            and set(v) = x.SetCustomProperty<int>("FunnelNeckHeight", v)

        /// <summary>
        ///   Specifies the neck width of the Funnel chart type.
        /// </summary>
        /// <remarks>Any integer from 0 to 100.</remarks>
        member x.FunnelNeckWidth
            with get() = x.GetCustomProperty<int>("FunnelNeckWidth", 5)
            and set(v) = x.SetCustomProperty<int>("FunnelNeckWidth", v)

        /// Placement of the data point label in the Funnel chart
        /// when FunnelLabelStyle is set to Outside or OutsideInColumn.
        member x.FunnelOutsideLabelPlacement
            with get() = x.GetCustomProperty<FunnelOutsideLabelPlacement>("FunnelOutsideLabelPlacement", FunnelOutsideLabelPlacement.Right)
            and set(v) = x.SetCustomProperty<FunnelOutsideLabelPlacement>("FunnelOutsideLabelPlacement", v)

        /// <summary>
        ///   Specifies the gap size between the points of a Funnel
        ///   chart, measured in relative coordinates.
        /// </summary>
        /// <remarks>Any integer from 0 to 100.</remarks>
        member x.FunnelPointGap
            with get() = x.GetCustomProperty<int>("FunnelPointGap", 0)
            and set(v) = x.SetCustomProperty<int>("FunnelPointGap", v)

        /// Specifies the style of the Funnel chart type.
        member x.FunnelStyle
            with get() = x.GetCustomProperty<FunnelStyle>("FunnelStyle", FunnelStyle.YIsHeight)
            and set(v) = x.SetCustomProperty<FunnelStyle>("FunnelStyle", v)


    /// Displays a series of connecting vertical lines where the thickness
    /// and direction of the lines are dependent on the action
    /// of the price value.
    type KagiChart() = 
        inherit GenericChart<OneValue>()

        /// Returns the type of the chart series
        override x.ChartType = SeriesChartType.Kagi

        /// <summary>
        ///   Specifies the 3D series depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointDepth
            with get() = x.GetCustomProperty<int>("PixelPointDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointDepth", v)

        /// <summary>
        ///   Specifies the 3D gap depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointGapDepth
            with get() = x.GetCustomProperty<int>("PixelPointGapDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointGapDepth", v)

        /// Specifies the data point color that indicates an increasing trend.
        member x.PriceUpColor
            with get() = x.GetCustomProperty<ColorWrapper>("PriceUpColor", ColorWrapper(Color.Empty)).Color
            and set(v) = x.SetCustomProperty<ColorWrapper>("PriceUpColor", ColorWrapper(v))

        /// Specifies the reversal amount for the chart.
        member x.ReversalAmount
            with get() = x.GetCustomProperty<string>("ReversalAmount", "3%")
            and set(v) = x.SetCustomProperty<string>("ReversalAmount", v)

        /// <summary>
        ///   Specifies the index of the Y value to use to
        ///   plot the Kagi, Renko, or Three Line Break chart, with
        ///   the first Y value at index 0.
        /// </summary>
        /// <remarks>Any positive integer 0.</remarks>
        member x.UsedYValue
            with get() = x.GetCustomProperty<int>("UsedYValue", 0)
            and set(v) = x.SetCustomProperty<int>("UsedYValue", v)


    /// Illustrates trends in data with the passing of time.
    type LineChart() = 
        inherit GenericChart<OneValue>()

        /// Returns the type of the chart series
        override x.ChartType = SeriesChartType.Line

        /// Specifies the value to be used for empty points.
        member x.EmptyPointValue
            with get() = x.GetCustomProperty<EmptyPointValue>("EmptyPointValue", EmptyPointValue.Average)
            and set(v) = x.SetCustomProperty<EmptyPointValue>("EmptyPointValue", v)

        /// Specifies the label position of the data point.
        member x.LabelStyle
            with get() = x.GetCustomProperty<LabelStyle>("LabelStyle", LabelStyle.Auto)
            and set(v) = x.SetCustomProperty<LabelStyle>("LabelStyle", v)

        /// <summary>
        ///   Specifies the 3D series depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointDepth
            with get() = x.GetCustomProperty<int>("PixelPointDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointDepth", v)

        /// <summary>
        ///   Specifies the 3D gap depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointGapDepth
            with get() = x.GetCustomProperty<int>("PixelPointGapDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointGapDepth", v)

        /// Specifies whether marker lines are displayed when rendered in 3D.
        member x.ShowMarkerLines
            with get() = x.GetCustomProperty<bool>("ShowMarkerLines", false)
            and set(v) = x.SetCustomProperty<bool>("ShowMarkerLines", v)


    /// Shows how proportions of data, shown as pie-shaped pieces, contribute to
    /// the data as a whole.
    type PieChart() = 
        inherit GenericChart<OneValue>()

        /// Returns the type of the chart series
        override x.ChartType = SeriesChartType.Pie

        /// <summary>
        ///   Specifies the 3D label line size as a percentage of
        ///   the default size.
        /// </summary>
        /// <remarks>Any integer from 30 to 200.</remarks>
        member x.LabelLineSize3D
            with get() = x.GetCustomProperty<int>("3DLabelLineSize", 100)
            and set(v) = x.SetCustomProperty<int>("3DLabelLineSize", v)

        /// Specifies the color of the collected pie or doughnut slice.
        member x.CollectedColor
            with get() = x.GetCustomProperty<ColorWrapper>("CollectedColor", ColorWrapper(Color.Empty)).Color
            and set(v) = x.SetCustomProperty<ColorWrapper>("CollectedColor", ColorWrapper(v))

        /// Specifies the label of the collected pie slice.
        member x.CollectedLabel
            with get() = x.GetCustomProperty<string>("CollectedLabel", "")
            and set(v) = x.SetCustomProperty<string>("CollectedLabel", v)

        /// Specifies the legend text for the collected pie slice.
        member x.CollectedLegendText
            with get() = x.GetCustomProperty<string>("CollectedLegendText", "")
            and set(v) = x.SetCustomProperty<string>("CollectedLegendText", v)

        /// Specifies whether the collected pie slice will be shown as
        /// exploded.
        member x.CollectedSliceExploded
            with get() = x.GetCustomProperty<bool>("CollectedSliceExploded", true)
            and set(v) = x.SetCustomProperty<bool>("CollectedSliceExploded", v)

        /// <summary>
        ///   Specifies the threshold value for collecting small pie slices.
        /// </summary>
        /// <remarks>Any double between 0 and 100 if CollectedThresholdUsePercent is true; otherwise, any double &gt; 0.</remarks>
        member x.CollectedThreshold
            with get() = x.GetCustomProperty<float>("CollectedThreshold", 0.0)
            and set(v) = x.SetCustomProperty<float>("CollectedThreshold", v)

        /// Specifies whether to use the collected threshold value as a
        /// percentage.
        member x.CollectedThresholdUsePercent
            with get() = x.GetCustomProperty<bool>("CollectedThresholdUsePercent", true)
            and set(v) = x.SetCustomProperty<bool>("CollectedThresholdUsePercent", v)

        /// Specifies the tooltip text of the collected pie slice.
        member x.CollectedToolTip
            with get() = x.GetCustomProperty<string>("CollectedToolTip", "")
            and set(v) = x.SetCustomProperty<string>("CollectedToolTip", v)

        /// Specifies whether the Pie or Doughnut data point is exploded.
        member x.Exploded
            with get() = x.GetCustomProperty<bool>("Exploded", false)
            and set(v) = x.SetCustomProperty<bool>("Exploded", v)

        /// <summary>
        ///   Specifies the size of the horizontal segment of the callout
        ///   line.
        /// </summary>
        /// <remarks>Any integer from 0 to 100.</remarks>
        member x.LabelsHorizontalLineSize
            with get() = x.GetCustomProperty<int>("LabelsHorizontalLineSize", 1)
            and set(v) = x.SetCustomProperty<int>("LabelsHorizontalLineSize", v)

        /// <summary>
        ///   Specifies the size of the radial segment of the callout
        ///   line.
        /// </summary>
        /// <remarks>Any integer from 0 to 100.</remarks>
        member x.LabelsRadialLineSize
            with get() = x.GetCustomProperty<int>("LabelsRadialLineSize", 1)
            and set(v) = x.SetCustomProperty<int>("LabelsRadialLineSize", v)

        /// <summary>
        ///   Specifies the minimum pie or doughnut size.
        /// </summary>
        /// <remarks>Any integer from 10 to 70.</remarks>
        member x.MinimumRelativePieSize
            with get() = x.GetCustomProperty<int>("MinimumRelativePieSize", 30)
            and set(v) = x.SetCustomProperty<int>("MinimumRelativePieSize", v)

        /// Specifies the drawing style of the data points.
        member x.PieDrawingStyle
            with get() = x.GetCustomProperty<PieDrawingStyle>("PieDrawingStyle", PieDrawingStyle.Default)
            and set(v) = x.SetCustomProperty<PieDrawingStyle>("PieDrawingStyle", v)

        /// Specifies the label style of the data points.
        member x.PieLabelStyle
            with get() = x.GetCustomProperty<PieLabelStyle>("PieLabelStyle", PieLabelStyle.Inside)
            and set(v) = x.SetCustomProperty<PieLabelStyle>("PieLabelStyle", v)

        /// Specifies the color of the radial and horizontal segments of
        /// the callout lines.
        member x.PieLineColor
            with get() = x.GetCustomProperty<ColorWrapper>("PieLineColor", ColorWrapper(Color.Black)).Color
            and set(v) = x.SetCustomProperty<ColorWrapper>("PieLineColor", ColorWrapper(v))

        /// <summary>
        ///   Specifies the angle of the data point in the Pie
        ///   or Doughnut chart.
        /// </summary>
        /// <remarks>Any integer from 0 to 360.</remarks>
        member x.PieStartAngle
            with get() = x.GetCustomProperty<int>("PieStartAngle", 90)
            and set(v) = x.SetCustomProperty<int>("PieStartAngle", v)


    /// Uses points to represent data points.
    type PointChart() = 
        inherit GenericChart<OneValue>()

        /// Returns the type of the chart series
        override x.ChartType = SeriesChartType.Point

        /// Specifies the value to be used for empty points.
        member x.EmptyPointValue
            with get() = x.GetCustomProperty<EmptyPointValue>("EmptyPointValue", EmptyPointValue.Average)
            and set(v) = x.SetCustomProperty<EmptyPointValue>("EmptyPointValue", v)

        /// Specifies the label position of the data point.
        member x.LabelStyle
            with get() = x.GetCustomProperty<LabelStyle>("LabelStyle", LabelStyle.Auto)
            and set(v) = x.SetCustomProperty<LabelStyle>("LabelStyle", v)

        /// <summary>
        ///   Specifies the 3D series depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointDepth
            with get() = x.GetCustomProperty<int>("PixelPointDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointDepth", v)

        /// <summary>
        ///   Specifies the 3D gap depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointGapDepth
            with get() = x.GetCustomProperty<int>("PixelPointGapDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointGapDepth", v)


    /// Disregards the passage of time and only displays changes in
    /// prices.
    type PointAndFigureChart() = 
        inherit GenericChart<TwoValue>()

        /// Returns the type of the chart series
        override x.ChartType = SeriesChartType.PointAndFigure

        /// Specifies the box size in the Renko or Point and
        /// Figure charts.
        member x.BoxSize
            with get() = x.GetCustomProperty<string>("BoxSize", "4%")
            and set(v) = x.SetCustomProperty<string>("BoxSize", v)

        /// <summary>
        ///   Specifies the 3D series depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointDepth
            with get() = x.GetCustomProperty<int>("PixelPointDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointDepth", v)

        /// <summary>
        ///   Specifies the 3D gap depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointGapDepth
            with get() = x.GetCustomProperty<int>("PixelPointGapDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointGapDepth", v)

        /// Specifies the data point color that indicates an increasing trend.
        member x.PriceUpColor
            with get() = x.GetCustomProperty<ColorWrapper>("PriceUpColor", ColorWrapper(Color.Empty)).Color
            and set(v) = x.SetCustomProperty<ColorWrapper>("PriceUpColor", ColorWrapper(v))

        /// Specifies whether the Point and Figure chart should draw the
        /// X and O values proportionally.
        member x.ProportionalSymbols
            with get() = x.GetCustomProperty<bool>("ProportionalSymbols", true)
            and set(v) = x.SetCustomProperty<bool>("ProportionalSymbols", v)

        /// Specifies the reversal amount for the chart.
        member x.ReversalAmount
            with get() = x.GetCustomProperty<string>("ReversalAmount", "3%")
            and set(v) = x.SetCustomProperty<string>("ReversalAmount", v)

        /// <summary>
        ///   Specifies the index of the Y value to use for
        ///   the high price in the Point and Figure chart, with
        ///   the first Y value at index 0.
        /// </summary>
        /// <remarks>Any positive integer 0.</remarks>
        member x.UsedYValueHigh
            with get() = x.GetCustomProperty<int>("UsedYValueHigh", 0)
            and set(v) = x.SetCustomProperty<int>("UsedYValueHigh", v)

        /// <summary>
        ///   Specifies the index of the Y value to use for
        ///   the low price in the Point and Figure chart, with
        ///   the first Y value at index 0.
        /// </summary>
        /// <remarks>Any positive integer 0.</remarks>
        member x.UsedYValueLow
            with get() = x.GetCustomProperty<int>("UsedYValueLow", 0)
            and set(v) = x.SetCustomProperty<int>("UsedYValueLow", v)


    /// A circular graph on which data points are displayed using
    /// the angle, and the distance from the center point.
    type PolarChart() = 
        inherit GenericChart<OneValue>()

        /// Returns the type of the chart series
        override x.ChartType = SeriesChartType.Polar

        /// Specifies the plot area shape in Radar and Polar charts.
        member x.AreaDrawingStyle
            with get() = x.GetCustomProperty<AreaDrawingStyle>("AreaDrawingStyle", AreaDrawingStyle.Circle)
            and set(v) = x.SetCustomProperty<AreaDrawingStyle>("AreaDrawingStyle", v)

        /// Specifies the text orientation of the axis labels in Radar
        /// and Polar charts.
        member x.CircularLabelStyle
            with get() = x.GetCustomProperty<CircularLabelStyle>("CircularLabelStyle", CircularLabelStyle.Horizontal)
            and set(v) = x.SetCustomProperty<CircularLabelStyle>("CircularLabelStyle", v)

        /// Specifies the value to be used for empty points.
        member x.EmptyPointValue
            with get() = x.GetCustomProperty<EmptyPointValue>("EmptyPointValue", EmptyPointValue.Average)
            and set(v) = x.SetCustomProperty<EmptyPointValue>("EmptyPointValue", v)

        /// Specifies the label position of the data point.
        member x.LabelStyle
            with get() = x.GetCustomProperty<LabelStyle>("LabelStyle", LabelStyle.Auto)
            and set(v) = x.SetCustomProperty<LabelStyle>("LabelStyle", v)

        /// Specifies the drawing style of the Polar chart type.
        member x.PolarDrawingStyle
            with get() = x.GetCustomProperty<PolarDrawingStyle>("PolarDrawingStyle", PolarDrawingStyle.Line)
            and set(v) = x.SetCustomProperty<PolarDrawingStyle>("PolarDrawingStyle", v)


    /// Displays data that, when combined, equals 100%.
    type PyramidChart() = 
        inherit GenericChart<OneValue>()

        /// Returns the type of the chart series
        override x.ChartType = SeriesChartType.Pyramid

        /// Specifies the line color of the callout for the data
        /// point labels of Funnel or Pyramid charts.
        member x.CalloutLineColor
            with get() = x.GetCustomProperty<ColorWrapper>("CalloutLineColor", ColorWrapper(Color.Empty)).Color
            and set(v) = x.SetCustomProperty<ColorWrapper>("CalloutLineColor", ColorWrapper(v))

        /// Specifies the 3D drawing style of the Pyramid chart type.
        member x.Pyramid3DDrawingStyle
            with get() = x.GetCustomProperty<Pyramid3DDrawingStyle>("Pyramid3DDrawingStyle", Pyramid3DDrawingStyle.SquareBase)
            and set(v) = x.SetCustomProperty<Pyramid3DDrawingStyle>("Pyramid3DDrawingStyle", v)

        /// <summary>
        ///   Specifies the 3D rotation angle of the Pyramid chart.
        /// </summary>
        /// <remarks>Any integer from -10 to 10.</remarks>
        member x.Pyramid3DRotationAngle
            with get() = x.GetCustomProperty<int>("Pyramid3DRotationAngle", 5)
            and set(v) = x.SetCustomProperty<int>("Pyramid3DRotationAngle", v)

        /// Specifies the placement of the data point labels in the
        /// Pyramid chart when they are placed inside the pyramid.
        member x.PyramidInsideLabelAlignment
            with get() = x.GetCustomProperty<PyramidInsideLabelAlignment>("PyramidInsideLabelAlignment", PyramidInsideLabelAlignment.Center)
            and set(v) = x.SetCustomProperty<PyramidInsideLabelAlignment>("PyramidInsideLabelAlignment", v)

        /// Specifies the style of data point labels in the Pyramid
        /// chart.
        member x.PyramidLabelStyle
            with get() = x.GetCustomProperty<PyramidLabelStyle>("PyramidLabelStyle", PyramidLabelStyle.OutsideInColumn)
            and set(v) = x.SetCustomProperty<PyramidLabelStyle>("PyramidLabelStyle", v)

        /// <summary>
        ///   Specifies the minimum height of a data point measured in
        ///   relative coordinates.
        /// </summary>
        /// <remarks>Any integer from 0 to 100.</remarks>
        member x.PyramidMinPointHeight
            with get() = x.GetCustomProperty<int>("PyramidMinPointHeight", 0)
            and set(v) = x.SetCustomProperty<int>("PyramidMinPointHeight", v)

        /// Specifies the placement of the data point labels in the
        /// Pyramid chart when the labels are placed outside the pyramid.
        member x.PyramidOutsideLabelPlacement
            with get() = x.GetCustomProperty<PyramidOutsideLabelPlacement>("PyramidOutsideLabelPlacement", PyramidOutsideLabelPlacement.Right)
            and set(v) = x.SetCustomProperty<PyramidOutsideLabelPlacement>("PyramidOutsideLabelPlacement", v)

        /// <summary>
        ///   Specifies the gap size between the data points, measured in
        ///   relative coordinates.
        /// </summary>
        /// <remarks>Any integer from 0 to 100.</remarks>
        member x.PyramidPointGap
            with get() = x.GetCustomProperty<int>("PyramidPointGap", 0)
            and set(v) = x.SetCustomProperty<int>("PyramidPointGap", v)

        /// Specifies whether the data point value represents a linear height
        /// or the surface of the segment.
        member x.PyramidValueType
            with get() = x.GetCustomProperty<PyramidValueType>("PyramidValueType", PyramidValueType.Linear)
            and set(v) = x.SetCustomProperty<PyramidValueType>("PyramidValueType", v)


    /// A circular chart that is used primarily as a data
    /// comparison tool.
    type RadarChart() = 
        inherit GenericChart<OneValue>()

        /// Returns the type of the chart series
        override x.ChartType = SeriesChartType.Radar

        /// Specifies the plot area shape in Radar and Polar charts.
        member x.AreaDrawingStyle
            with get() = x.GetCustomProperty<AreaDrawingStyle>("AreaDrawingStyle", AreaDrawingStyle.Circle)
            and set(v) = x.SetCustomProperty<AreaDrawingStyle>("AreaDrawingStyle", v)

        /// Specifies the text orientation of the axis labels in Radar
        /// and Polar charts.
        member x.CircularLabelStyle
            with get() = x.GetCustomProperty<CircularLabelStyle>("CircularLabelStyle", CircularLabelStyle.Horizontal)
            and set(v) = x.SetCustomProperty<CircularLabelStyle>("CircularLabelStyle", v)

        /// Specifies the value to be used for empty points.
        member x.EmptyPointValue
            with get() = x.GetCustomProperty<EmptyPointValue>("EmptyPointValue", EmptyPointValue.Average)
            and set(v) = x.SetCustomProperty<EmptyPointValue>("EmptyPointValue", v)

        /// Specifies the label position of the data point.
        member x.LabelStyle
            with get() = x.GetCustomProperty<LabelStyle>("LabelStyle", LabelStyle.Auto)
            and set(v) = x.SetCustomProperty<LabelStyle>("LabelStyle", v)

        /// Specifies the drawing style of the Radar chart.
        member x.RadarDrawingStyle
            with get() = x.GetCustomProperty<RadarDrawingStyle>("RadarDrawingStyle", RadarDrawingStyle.Area)
            and set(v) = x.SetCustomProperty<RadarDrawingStyle>("RadarDrawingStyle", v)


    /// Displays a range of data by plotting two Y values per data
    /// point, with each Y value being drawn as a line
    /// chart.
    type RangeChart() = 
        inherit GenericChart<TwoValue>()

        /// Returns the type of the chart series
        override x.ChartType = SeriesChartType.Range

        /// Specifies the value to be used for empty points.
        member x.EmptyPointValue
            with get() = x.GetCustomProperty<EmptyPointValue>("EmptyPointValue", EmptyPointValue.Average)
            and set(v) = x.SetCustomProperty<EmptyPointValue>("EmptyPointValue", v)

        /// Specifies the label position of the data point.
        member x.LabelStyle
            with get() = x.GetCustomProperty<LabelStyle>("LabelStyle", LabelStyle.Auto)
            and set(v) = x.SetCustomProperty<LabelStyle>("LabelStyle", v)

        /// <summary>
        ///   Specifies the 3D series depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointDepth
            with get() = x.GetCustomProperty<int>("PixelPointDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointDepth", v)

        /// <summary>
        ///   Specifies the 3D gap depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointGapDepth
            with get() = x.GetCustomProperty<int>("PixelPointGapDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointGapDepth", v)

        /// Specifies whether marker lines are displayed when rendered in 3D.
        member x.ShowMarkerLines
            with get() = x.GetCustomProperty<bool>("ShowMarkerLines", false)
            and set(v) = x.SetCustomProperty<bool>("ShowMarkerLines", v)


    /// Displays separate events that have beginning and end values.
    type RangeBarChart() = 
        inherit GenericChart<TwoValue>()

        /// Returns the type of the chart series
        override x.ChartType = SeriesChartType.RangeBar

        /// Specifies the placement of the data point label.
        member x.BarLabelStyle
            with get() = x.GetCustomProperty<BarLabelStyle>("BarLabelStyle", BarLabelStyle.Outside)
            and set(v) = x.SetCustomProperty<BarLabelStyle>("BarLabelStyle", v)

        /// Specifies the drawing style of data points.
        member x.DrawingStyle
            with get() = x.GetCustomProperty<DrawingStyle>("DrawingStyle", DrawingStyle.Default)
            and set(v) = x.SetCustomProperty<DrawingStyle>("DrawingStyle", v)

        /// Specifies whether series of the same chart type are drawn
        /// next to each other instead of overlapping each other.
        member x.DrawSideBySide
            with get() = x.GetCustomProperty<DrawSideBySide>("DrawSideBySide", DrawSideBySide.Auto)
            and set(v) = x.SetCustomProperty<DrawSideBySide>("DrawSideBySide", v)

        /// Specifies the value to be used for empty points.
        member x.EmptyPointValue
            with get() = x.GetCustomProperty<EmptyPointValue>("EmptyPointValue", EmptyPointValue.Average)
            and set(v) = x.SetCustomProperty<EmptyPointValue>("EmptyPointValue", v)

        /// <summary>
        ///   Specifies the maximum width of the data point in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.MaxPixelPointWidth
            with get() = x.GetCustomProperty<int>("MaxPixelPointWidth", 0)
            and set(v) = x.SetCustomProperty<int>("MaxPixelPointWidth", v)

        /// <summary>
        ///   Specifies the minimum data point width in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.MinPixelPointWidth
            with get() = x.GetCustomProperty<int>("MinPixelPointWidth", 0)
            and set(v) = x.SetCustomProperty<int>("MinPixelPointWidth", v)

        /// <summary>
        ///   Specifies the 3D series depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointDepth
            with get() = x.GetCustomProperty<int>("PixelPointDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointDepth", v)

        /// <summary>
        ///   Specifies the 3D gap depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointGapDepth
            with get() = x.GetCustomProperty<int>("PixelPointGapDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointGapDepth", v)

        /// <summary>
        ///   Specifies the data point width in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointWidth
            with get() = x.GetCustomProperty<int>("PixelPointWidth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointWidth", v)

        /// <summary>
        ///   Specifies the relative data point width.
        /// </summary>
        /// <remarks>Any double from 0 to 2.</remarks>
        member x.PointWidth
            with get() = x.GetCustomProperty<float>("PointWidth", 0.8)
            and set(v) = x.SetCustomProperty<float>("PointWidth", v)


    /// Displays a range of data by plotting two Y values
    /// per data point.
    type RangeColumnChart() = 
        inherit GenericChart<TwoValue>()

        /// Returns the type of the chart series
        override x.ChartType = SeriesChartType.RangeColumn

        /// Specifies the drawing style of data points.
        member x.DrawingStyle
            with get() = x.GetCustomProperty<DrawingStyle>("DrawingStyle", DrawingStyle.Default)
            and set(v) = x.SetCustomProperty<DrawingStyle>("DrawingStyle", v)

        /// Specifies whether series of the same chart type are drawn
        /// next to each other instead of overlapping each other.
        member x.DrawSideBySide
            with get() = x.GetCustomProperty<DrawSideBySide>("DrawSideBySide", DrawSideBySide.Auto)
            and set(v) = x.SetCustomProperty<DrawSideBySide>("DrawSideBySide", v)

        /// Specifies the value to be used for empty points.
        member x.EmptyPointValue
            with get() = x.GetCustomProperty<EmptyPointValue>("EmptyPointValue", EmptyPointValue.Average)
            and set(v) = x.SetCustomProperty<EmptyPointValue>("EmptyPointValue", v)

        /// <summary>
        ///   Specifies the maximum width of the data point in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.MaxPixelPointWidth
            with get() = x.GetCustomProperty<int>("MaxPixelPointWidth", 0)
            and set(v) = x.SetCustomProperty<int>("MaxPixelPointWidth", v)

        /// <summary>
        ///   Specifies the minimum data point width in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.MinPixelPointWidth
            with get() = x.GetCustomProperty<int>("MinPixelPointWidth", 0)
            and set(v) = x.SetCustomProperty<int>("MinPixelPointWidth", v)

        /// <summary>
        ///   Specifies the 3D series depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointDepth
            with get() = x.GetCustomProperty<int>("PixelPointDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointDepth", v)

        /// <summary>
        ///   Specifies the 3D gap depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointGapDepth
            with get() = x.GetCustomProperty<int>("PixelPointGapDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointGapDepth", v)

        /// <summary>
        ///   Specifies the data point width in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointWidth
            with get() = x.GetCustomProperty<int>("PixelPointWidth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointWidth", v)

        /// <summary>
        ///   Specifies the relative data point width.
        /// </summary>
        /// <remarks>Any double from 0 to 2.</remarks>
        member x.PointWidth
            with get() = x.GetCustomProperty<float>("PointWidth", 0.8)
            and set(v) = x.SetCustomProperty<float>("PointWidth", v)


    /// Displays a series of connecting vertical lines where the thickness
    /// and direction of the lines are dependent on the action
    /// of the price value.
    type RenkoChart() = 
        inherit GenericChart<OneValue>()

        /// Returns the type of the chart series
        override x.ChartType = SeriesChartType.Renko

        /// Specifies the box size in the Renko or Point and
        /// Figure charts.
        member x.BoxSize
            with get() = x.GetCustomProperty<string>("BoxSize", "4%")
            and set(v) = x.SetCustomProperty<string>("BoxSize", v)

        /// <summary>
        ///   Specifies the 3D series depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointDepth
            with get() = x.GetCustomProperty<int>("PixelPointDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointDepth", v)

        /// <summary>
        ///   Specifies the 3D gap depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointGapDepth
            with get() = x.GetCustomProperty<int>("PixelPointGapDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointGapDepth", v)

        /// Specifies the data point color that indicates an increasing trend.
        member x.PriceUpColor
            with get() = x.GetCustomProperty<ColorWrapper>("PriceUpColor", ColorWrapper(Color.Empty)).Color
            and set(v) = x.SetCustomProperty<ColorWrapper>("PriceUpColor", ColorWrapper(v))

        /// <summary>
        ///   Specifies the index of the Y value to use to
        ///   plot the Kagi, Renko, or Three Line Break chart, with
        ///   the first Y value at index 0.
        /// </summary>
        /// <remarks>Any positive integer 0.</remarks>
        member x.UsedYValue
            with get() = x.GetCustomProperty<int>("UsedYValue", 0)
            and set(v) = x.SetCustomProperty<int>("UsedYValue", v)


    /// A Line chart that plots a fitted curve through each
    /// data point in a series.
    type SplineChart() = 
        inherit GenericChart<OneValue>()

        /// Returns the type of the chart series
        override x.ChartType = SeriesChartType.Spline

        /// Specifies the value to be used for empty points.
        member x.EmptyPointValue
            with get() = x.GetCustomProperty<EmptyPointValue>("EmptyPointValue", EmptyPointValue.Average)
            and set(v) = x.SetCustomProperty<EmptyPointValue>("EmptyPointValue", v)

        /// Specifies the label position of the data point.
        member x.LabelStyle
            with get() = x.GetCustomProperty<LabelStyle>("LabelStyle", LabelStyle.Auto)
            and set(v) = x.SetCustomProperty<LabelStyle>("LabelStyle", v)

        /// <summary>
        ///   Specifies the line tension for the drawing of curves between
        ///   data points.
        /// </summary>
        /// <remarks>Any double from 0 to 2.</remarks>
        member x.LineTension
            with get() = x.GetCustomProperty<float>("LineTension", 0.8)
            and set(v) = x.SetCustomProperty<float>("LineTension", v)

        /// <summary>
        ///   Specifies the 3D series depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointDepth
            with get() = x.GetCustomProperty<int>("PixelPointDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointDepth", v)

        /// <summary>
        ///   Specifies the 3D gap depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointGapDepth
            with get() = x.GetCustomProperty<int>("PixelPointGapDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointGapDepth", v)

        /// Specifies whether marker lines are displayed when rendered in 3D.
        member x.ShowMarkerLines
            with get() = x.GetCustomProperty<bool>("ShowMarkerLines", false)
            and set(v) = x.SetCustomProperty<bool>("ShowMarkerLines", v)


    /// An Area chart that plots a fitted curve through each
    /// data point in a series.
    type SplineAreaChart() = 
        inherit GenericChart<OneValue>()

        /// Returns the type of the chart series
        override x.ChartType = SeriesChartType.SplineArea

        /// Specifies the value to be used for empty points.
        member x.EmptyPointValue
            with get() = x.GetCustomProperty<EmptyPointValue>("EmptyPointValue", EmptyPointValue.Average)
            and set(v) = x.SetCustomProperty<EmptyPointValue>("EmptyPointValue", v)

        /// Specifies the label position of the data point.
        member x.LabelStyle
            with get() = x.GetCustomProperty<LabelStyle>("LabelStyle", LabelStyle.Auto)
            and set(v) = x.SetCustomProperty<LabelStyle>("LabelStyle", v)

        /// <summary>
        ///   Specifies the line tension for the drawing of curves between
        ///   data points.
        /// </summary>
        /// <remarks>Any double from 0 to 2.</remarks>
        member x.LineTension
            with get() = x.GetCustomProperty<float>("LineTension", 0.8)
            and set(v) = x.SetCustomProperty<float>("LineTension", v)

        /// <summary>
        ///   Specifies the 3D series depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointDepth
            with get() = x.GetCustomProperty<int>("PixelPointDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointDepth", v)

        /// <summary>
        ///   Specifies the 3D gap depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointGapDepth
            with get() = x.GetCustomProperty<int>("PixelPointGapDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointGapDepth", v)

        /// Specifies whether marker lines are displayed when rendered in 3D.
        member x.ShowMarkerLines
            with get() = x.GetCustomProperty<bool>("ShowMarkerLines", false)
            and set(v) = x.SetCustomProperty<bool>("ShowMarkerLines", v)


    /// Displays a range of data by plotting two Y values per
    /// data point, with each Y value drawn as a line
    /// chart.
    type SplineRangeChart() = 
        inherit GenericChart<TwoValue>()

        /// Returns the type of the chart series
        override x.ChartType = SeriesChartType.SplineRange

        /// Specifies the value to be used for empty points.
        member x.EmptyPointValue
            with get() = x.GetCustomProperty<EmptyPointValue>("EmptyPointValue", EmptyPointValue.Average)
            and set(v) = x.SetCustomProperty<EmptyPointValue>("EmptyPointValue", v)

        /// Specifies the label position of the data point.
        member x.LabelStyle
            with get() = x.GetCustomProperty<LabelStyle>("LabelStyle", LabelStyle.Auto)
            and set(v) = x.SetCustomProperty<LabelStyle>("LabelStyle", v)

        /// <summary>
        ///   Specifies the line tension for the drawing of curves between
        ///   data points.
        /// </summary>
        /// <remarks>Any double from 0 to 2.</remarks>
        member x.LineTension
            with get() = x.GetCustomProperty<float>("LineTension", 0.8)
            and set(v) = x.SetCustomProperty<float>("LineTension", v)

        /// <summary>
        ///   Specifies the 3D series depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointDepth
            with get() = x.GetCustomProperty<int>("PixelPointDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointDepth", v)

        /// <summary>
        ///   Specifies the 3D gap depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointGapDepth
            with get() = x.GetCustomProperty<int>("PixelPointGapDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointGapDepth", v)

        /// Specifies whether marker lines are displayed when rendered in 3D.
        member x.ShowMarkerLines
            with get() = x.GetCustomProperty<bool>("ShowMarkerLines", false)
            and set(v) = x.SetCustomProperty<bool>("ShowMarkerLines", v)


    /// An Area chart that stacks two or more data series
    /// on top of one another.
    type StackedAreaChart() = 
        inherit GenericChart<OneValue>()

        /// Returns the type of the chart series
        override x.ChartType = SeriesChartType.StackedArea

        /// <summary>
        ///   Specifies the 3D series depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointDepth
            with get() = x.GetCustomProperty<int>("PixelPointDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointDepth", v)

        /// <summary>
        ///   Specifies the 3D gap depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointGapDepth
            with get() = x.GetCustomProperty<int>("PixelPointGapDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointGapDepth", v)


    /// Displays series of the same chart type as stacked bars.
    type StackedBarChart() = 
        inherit GenericChart<OneValue>()

        /// Returns the type of the chart series
        override x.ChartType = SeriesChartType.StackedBar

        /// Specifies the placement of the data point label.
        member x.BarLabelStyle
            with get() = x.GetCustomProperty<BarLabelStyle>("BarLabelStyle", BarLabelStyle.Outside)
            and set(v) = x.SetCustomProperty<BarLabelStyle>("BarLabelStyle", v)

        /// Specifies the drawing style of data points.
        member x.DrawingStyle
            with get() = x.GetCustomProperty<DrawingStyle>("DrawingStyle", DrawingStyle.Default)
            and set(v) = x.SetCustomProperty<DrawingStyle>("DrawingStyle", v)

        /// <summary>
        ///   Specifies the maximum width of the data point in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.MaxPixelPointWidth
            with get() = x.GetCustomProperty<int>("MaxPixelPointWidth", 0)
            and set(v) = x.SetCustomProperty<int>("MaxPixelPointWidth", v)

        /// <summary>
        ///   Specifies the minimum data point width in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.MinPixelPointWidth
            with get() = x.GetCustomProperty<int>("MinPixelPointWidth", 0)
            and set(v) = x.SetCustomProperty<int>("MinPixelPointWidth", v)

        /// <summary>
        ///   Specifies the 3D series depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointDepth
            with get() = x.GetCustomProperty<int>("PixelPointDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointDepth", v)

        /// <summary>
        ///   Specifies the 3D gap depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointGapDepth
            with get() = x.GetCustomProperty<int>("PixelPointGapDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointGapDepth", v)

        /// <summary>
        ///   Specifies the data point width in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointWidth
            with get() = x.GetCustomProperty<int>("PixelPointWidth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointWidth", v)

        /// <summary>
        ///   Specifies the relative data point width.
        /// </summary>
        /// <remarks>Any double from 0 to 2.</remarks>
        member x.PointWidth
            with get() = x.GetCustomProperty<float>("PointWidth", 0.8)
            and set(v) = x.SetCustomProperty<float>("PointWidth", v)

        /// Specifies the name of the stacked group.
        member x.StackedGroupName
            with get() = x.GetCustomProperty<string>("StackedGroupName", "")
            and set(v) = x.SetCustomProperty<string>("StackedGroupName", v)


    /// Used to compare the contribution of each value to a
    /// total across categories.
    type StackedColumnChart() = 
        inherit GenericChart<OneValue>()

        /// Returns the type of the chart series
        override x.ChartType = SeriesChartType.StackedColumn

        /// Specifies the drawing style of data points.
        member x.DrawingStyle
            with get() = x.GetCustomProperty<DrawingStyle>("DrawingStyle", DrawingStyle.Default)
            and set(v) = x.SetCustomProperty<DrawingStyle>("DrawingStyle", v)

        /// <summary>
        ///   Specifies the maximum width of the data point in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.MaxPixelPointWidth
            with get() = x.GetCustomProperty<int>("MaxPixelPointWidth", 0)
            and set(v) = x.SetCustomProperty<int>("MaxPixelPointWidth", v)

        /// <summary>
        ///   Specifies the minimum data point width in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.MinPixelPointWidth
            with get() = x.GetCustomProperty<int>("MinPixelPointWidth", 0)
            and set(v) = x.SetCustomProperty<int>("MinPixelPointWidth", v)

        /// <summary>
        ///   Specifies the 3D series depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointDepth
            with get() = x.GetCustomProperty<int>("PixelPointDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointDepth", v)

        /// <summary>
        ///   Specifies the 3D gap depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointGapDepth
            with get() = x.GetCustomProperty<int>("PixelPointGapDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointGapDepth", v)

        /// <summary>
        ///   Specifies the data point width in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointWidth
            with get() = x.GetCustomProperty<int>("PixelPointWidth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointWidth", v)

        /// <summary>
        ///   Specifies the relative data point width.
        /// </summary>
        /// <remarks>Any double from 0 to 2.</remarks>
        member x.PointWidth
            with get() = x.GetCustomProperty<float>("PointWidth", 0.8)
            and set(v) = x.SetCustomProperty<float>("PointWidth", v)

        /// Specifies the name of the stacked group.
        member x.StackedGroupName
            with get() = x.GetCustomProperty<string>("StackedGroupName", "")
            and set(v) = x.SetCustomProperty<string>("StackedGroupName", v)


    /// Similar to the Line chart type, but uses vertical and
    /// horizontal lines to connect the data points in a series
    /// forming a step-like progression.
    type StepLineChart() = 
        inherit GenericChart<OneValue>()

        /// Returns the type of the chart series
        override x.ChartType = SeriesChartType.StepLine

        /// Specifies the value to be used for empty points.
        member x.EmptyPointValue
            with get() = x.GetCustomProperty<EmptyPointValue>("EmptyPointValue", EmptyPointValue.Average)
            and set(v) = x.SetCustomProperty<EmptyPointValue>("EmptyPointValue", v)

        /// Specifies the label position of the data point.
        member x.LabelStyle
            with get() = x.GetCustomProperty<LabelStyle>("LabelStyle", LabelStyle.Auto)
            and set(v) = x.SetCustomProperty<LabelStyle>("LabelStyle", v)

        /// <summary>
        ///   Specifies the 3D series depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointDepth
            with get() = x.GetCustomProperty<int>("PixelPointDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointDepth", v)

        /// <summary>
        ///   Specifies the 3D gap depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointGapDepth
            with get() = x.GetCustomProperty<int>("PixelPointGapDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointGapDepth", v)

        /// Specifies whether marker lines are displayed when rendered in 3D.
        member x.ShowMarkerLines
            with get() = x.GetCustomProperty<bool>("ShowMarkerLines", false)
            and set(v) = x.SetCustomProperty<bool>("ShowMarkerLines", v)


    /// Displays significant stock price points including the open, close, high,
    /// and low price points.
    type StockChart() = 
        inherit GenericChart<FourValue>()

        /// Returns the type of the chart series
        override x.ChartType = SeriesChartType.Stock

        /// Specifies the Y value to use as the data point
        /// label.
        member x.LabelValueType
            with get() = x.GetCustomProperty<LabelValueType>("LabelValueType", LabelValueType.Close)
            and set(v) = x.SetCustomProperty<LabelValueType>("LabelValueType", v)

        /// <summary>
        ///   Specifies the maximum width of the data point in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.MaxPixelPointWidth
            with get() = x.GetCustomProperty<int>("MaxPixelPointWidth", 0)
            and set(v) = x.SetCustomProperty<int>("MaxPixelPointWidth", v)

        /// <summary>
        ///   Specifies the minimum data point width in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.MinPixelPointWidth
            with get() = x.GetCustomProperty<int>("MinPixelPointWidth", 0)
            and set(v) = x.SetCustomProperty<int>("MinPixelPointWidth", v)

        /// Specifies the marker style for open and close values.
        member x.OpenCloseStyle
            with get() = x.GetCustomProperty<OpenCloseStyle>("OpenCloseStyle", OpenCloseStyle.Line)
            and set(v) = x.SetCustomProperty<OpenCloseStyle>("OpenCloseStyle", v)

        /// <summary>
        ///   Specifies the 3D series depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointDepth
            with get() = x.GetCustomProperty<int>("PixelPointDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointDepth", v)

        /// <summary>
        ///   Specifies the 3D gap depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointGapDepth
            with get() = x.GetCustomProperty<int>("PixelPointGapDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointGapDepth", v)

        /// <summary>
        ///   Specifies the data point width in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointWidth
            with get() = x.GetCustomProperty<int>("PixelPointWidth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointWidth", v)

        /// <summary>
        ///   Specifies the relative data point width.
        /// </summary>
        /// <remarks>Any double from 0 to 2.</remarks>
        member x.PointWidth
            with get() = x.GetCustomProperty<float>("PointWidth", 0.8)
            and set(v) = x.SetCustomProperty<float>("PointWidth", v)

        /// Specifies whether markers for open and close prices are displayed.
        member x.ShowOpenClose
            with get() = x.GetCustomProperty<ShowOpenClose>("ShowOpenClose", ShowOpenClose.Both)
            and set(v) = x.SetCustomProperty<ShowOpenClose>("ShowOpenClose", v)


    /// Displays a series of vertical boxes, or lines, that reflect
    /// changes in price values.
    type ThreeLineBreakChart() = 
        inherit GenericChart<OneValue>()

        /// Returns the type of the chart series
        override x.ChartType = SeriesChartType.ThreeLineBreak

        /// <summary>
        ///   Specifies the number of lines to use in a Three
        ///   Line Break chart.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.NumberOfLinesInBreak
            with get() = x.GetCustomProperty<int>("NumberOfLinesInBreak", 3)
            and set(v) = x.SetCustomProperty<int>("NumberOfLinesInBreak", v)

        /// <summary>
        ///   Specifies the 3D series depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointDepth
            with get() = x.GetCustomProperty<int>("PixelPointDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointDepth", v)

        /// <summary>
        ///   Specifies the 3D gap depth in pixels.
        /// </summary>
        /// <remarks>Any integer &gt; 0</remarks>
        member x.PixelPointGapDepth
            with get() = x.GetCustomProperty<int>("PixelPointGapDepth", 0)
            and set(v) = x.SetCustomProperty<int>("PixelPointGapDepth", v)

        /// Specifies the data point color that indicates an increasing trend.
        member x.PriceUpColor
            with get() = x.GetCustomProperty<ColorWrapper>("PriceUpColor", ColorWrapper(Color.Empty)).Color
            and set(v) = x.SetCustomProperty<ColorWrapper>("PriceUpColor", ColorWrapper(v))

        /// <summary>
        ///   Specifies the index of the Y value to use to
        ///   plot the Kagi, Renko, or Three Line Break chart, with
        ///   the first Y value at index 0.
        /// </summary>
        /// <remarks>Any positive integer 0.</remarks>
        member x.UsedYValue
            with get() = x.GetCustomProperty<int>("UsedYValue", 0)
            and set(v) = x.SetCustomProperty<int>("UsedYValue", v)

    // [/AUTOGENERATED]
    // ------------------------------------------------------------------------------------
    // Special types of charts - combine multiple series & create row/columns

    type CombinedChart(charts:seq<GenericChart>) as this =
        inherit GenericChart<DataSourceCombined>()

        do
            let firstChart = Seq.head charts
            this.Area <- firstChart.Area
            this.Legend <- firstChart.Legend
            this.Margin <- firstChart.Margin

        override x.ChartType = enum<SeriesChartType> -1
        member x.Charts = charts

    type SubplotChart(charts:seq<GenericChart>, orientation:Orientation) = 
        inherit GenericChart<DataSourceCombined>()
        let r = 1.0 / (charts |> Seq.length |> float)
        let mutable splitSizes = seq { for c in charts -> r }

        override x.ChartType = enum<SeriesChartType> -1
        member x.SplitSizes with get() = splitSizes and set v = splitSizes <- v
        member x.Orientation = orientation
        member x.Charts = charts
