namespace MSDN.FSharp.Charting
    
open System
open System.Collections.Generic
open System.Reflection
open System.Windows.Forms
open System.Windows.Forms.DataVisualization.Charting

open MSDN.FSharp.Charting.ChartTypes
open MSDN.FSharp.Charting.ChartStyles
open MSDN.FSharp.Charting.ChartData
open MSDN.FSharp.Charting.ChartData.Internal
open MSDN.FSharp.Charting.ChartFormUtilities


type ChartControl(ch:GenericChart) as self = 
    inherit UserControl()

    let seriesCounter = createCounter()
    let areaCounter = createCounter()
    let legendCounter = createCounter()

    let createTitleChange (chart:Chart) (ch:GenericChart) = 
        ch.TitleChanged.Add(function 
                t ->
                if (chart.Titles.Count > 0) then
                    chart.Titles.[0] <- t
                else
                    chart.Titles.Add t)

    let createLegendChange (chart:Chart) (ch:GenericChart) (series:Series list) = 
        ch.LegendChanged.Add(function 
                l ->
                if (chart.Legends.Count > 0) then
                    chart.Legends.[0] <- l
                else
                    chart.Legends.Add l
                if (chart.ChartAreas.Count > 0) then l.DockedToChartArea <- chart.ChartAreas.[0].Name
                for s in series do (s:Series).Legend <- l.Name)

    let createArea (chart:Chart) (ch:GenericChart) ((left, top, right, bottom) as pos) = 

        let setMargin (area:ChartArea) ((left, top, right, bottom) as pos) = 
            area.Position.X <- left
            area.Position.Y <- top 
            area.Position.Width <- right - left
            area.Position.Height <- bottom - top 

        let area = new ChartArea()
        applyPropertyDefaults (ch.ChartType) area
        chart.ChartAreas.Add area

        if ch.LazyArea.IsValueCreated then
            applyProperties area ch.Area
            if (ch.Area.Area3DStyle.Enable3D) then
                applyProperties area.Area3DStyle ch.Area.Area3DStyle

        area.Name <- 
            if ch.LazyArea.IsValueCreated && not (String.IsNullOrEmpty ch.Area.Name) 
            then ch.Area.Name else sprintf "Area_%d" (areaCounter())
        ch.NameChanged.Add(function
            n ->
                area.Name <- 
                    if not (String.IsNullOrEmpty n) 
                    then n else sprintf "Area_%d" (areaCounter()))

        setMargin area pos
        ch.MarginChanged.Add(function
            a ->                
                let (l, t, r, b) = (0.0f, 0.0f, 100.0f, 100.0f)
                let (ml, mt, mr, mb) = a
                let (l, t, r, b) = (l + ml, t + mt, r - mr, b - mb)
                setMargin area (l, t, r, b))


        let processTitles (ch:GenericChart) =
            for title in seq { if ch.LazyTitle.IsValueCreated then yield ch.Title 
                               yield! ch.Titles } do
                chart.Titles.Add title
            createTitleChange chart ch
    
        let processSeries (ch:GenericChart) =
            let name = 
                if not (String.IsNullOrEmpty ch.Name) then ch.Name
                else sprintf "GenericChart_Series_%d" (seriesCounter())
            let series = new Series()
            applyPropertyDefaults (ch.ChartType) series
            if ch.LazySeries.IsValueCreated then
                applyProperties series ch.Series

            series.Name <- name
            series.ChartType <- ch.ChartType
            series.ChartArea <- area.Name
            chart.Series.Add series
            
            // Set data
            setSeriesData false series ch.Data chart ch.SetCustomProperty

            let cult = System.Threading.Thread.CurrentThread.CurrentCulture
            System.Threading.Thread.CurrentThread.CurrentCulture <- System.Globalization.CultureInfo.InvariantCulture
            let props = 
              [ for (KeyValue(k, v)) in ch.CustomProperties -> 
                  sprintf "%s=%s" k (v.ToString()) ]
              |> String.concat ", "
            System.Threading.Thread.CurrentThread.CurrentCulture <- cult
            series.CustomProperties <- props

            ch.CustomPropertyChanged.Add(function
                (name, value) -> series.SetCustomProperty(name, System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", value)))

            for leg in ch.Legends do
              let legend = new Legend()
              applyProperties legend leg
              legend.Name <- sprintf "Legend_%d" (legendCounter())
              legend.DockedToChartArea <- area.Name
              chart.Legends.Add legend
              series.Legend <- legend.Name
            createLegendChange chart ch [series]

            series

        match ch with
        | :? CombinedChart as cch ->
            let series = 
                [ for c in cch.Charts do
                    let s = processSeries c
                    processTitles c
                    yield s ]
            
            for leg in ch.Legends do
                let legend = new Legend()
                applyProperties legend leg
                legend.Name <- sprintf "Legend_%d" (legendCounter())
                legend.DockedToChartArea <- area.Name
                chart.Legends.Add legend
                for s in series do s.Legend <- legend.Name
            createLegendChange chart ch series

            processTitles cch
            series
        | c ->
            let series = processSeries c

            processTitles c
            [ series ]

    let createChart (ch:GenericChart) = 
        let chart = new Chart()
        applyPropertyDefaults (ch.ChartType) chart
        self.Controls.Add chart

        let rec loop (ch:GenericChart) (l, t, r, b) = 
            let (ml, mt, mr, mb) = ch.Margin
            let (l, t, r, b) = (l + ml, t + mt, r - mr, b - mb)
            match ch with
            | :? SubplotChart as subplot ->
                for title in ch.Titles do
                    chart.Titles.Add title
                createTitleChange chart ch
        
                let total = subplot.SplitSizes |> Seq.sum
                let available = if subplot.Orientation = Orientation.Vertical then b - t else r - l
                let k = float available / total

                let offs = ref 0.0f
                let series = 
                    [ for ch, siz in Seq.zip subplot.Charts subplot.SplitSizes do
                        if subplot.Orientation = Orientation.Vertical then
                          yield! loop ch (l, t + !offs, r, t + !offs + float32 (siz * k))
                        else
                          yield! loop ch (l + !offs, t, l + !offs + float32 (siz * k), b)
                        offs := !offs + float32 (siz * k) ]

                for leg in ch.Chart.Legends do
                    let legend = new Legend() 
                    applyProperties legend leg
                    legend.Name <- sprintf "Legend_%d" (legendCounter())
                    //legend.DockedToChartArea <- area.Name
                    chart.Legends.Add legend
                    for s in series do (s:Series).Legend <- legend.Name
                createLegendChange chart ch series

                series
            | _ ->
              createArea chart ch (l, t, r, b)

        let series = loop ch (0.0f, 0.0f, 100.0f, 100.0f)
        if ch.LazyChart.IsValueCreated then 
            applyProperties chart ch.Chart
        chart.Dock <- DockStyle.Fill
        ch.Chart <- chart

        chart, series
  
    let chart, series = createChart ch
    let props = new PropertyGrid(Width = 250, Dock = DockStyle.Right, SelectedObject = chart, Visible = false)
  
    do
      self.Controls.Add chart
      self.Controls.Add props

      let menu = new ContextMenu()
      let dlg = new SaveFileDialog(Filter = "PNG (*.png)|*.png|Bitmap (*.bmp;*.dib)|*.bmp;*.dib|GIF (*.gif)|*.gif|TIFF (*.tiff;*.tif)|*.tiff;*.tif|EMF (*.emf)|*.emf|JPEG (*.jpeg;*.jpg;*.jpe)|*.jpeg;*.jpg;*.jpe|EMF+ (*.emf)|*.emf|EMF+Dual (*.emf)|*.emf")
      let miCopy = new MenuItem("&Copy Image to Clipboard", Shortcut = Shortcut.CtrlC)
      let miCopyEmf = new MenuItem("Copy Image to Clipboard as &EMF", Shortcut = Shortcut.CtrlShiftC)
      let miSave = new MenuItem("&Save Image As..", Shortcut = Shortcut.CtrlS)
      let miEdit = new MenuItem("Show Property &Grid", Shortcut = Shortcut.CtrlG)

      miEdit.Click.Add(fun _ -> 
        miEdit.Checked <- not miEdit.Checked
        props.Visible <- miEdit.Checked)

      miCopy.Click.Add(fun _ ->        
        ch.CopyChartToClipboard())

      miCopyEmf.Click.Add(fun _ ->
        ch.CopyChartToClipboardEmf(self))

      miSave.Click.Add(fun _ ->
        if dlg.ShowDialog() = DialogResult.OK then
            let fmt = 
                match dlg.FilterIndex with
                | 1 -> ChartImageFormat.Png
                | 2 -> ChartImageFormat.Bmp
                | 3 -> ChartImageFormat.Gif
                | 4 -> ChartImageFormat.Tiff
                | 5 -> ChartImageFormat.Emf
                | 6 -> ChartImageFormat.Jpeg
                | 7 -> ChartImageFormat.EmfPlus
                | 8 -> ChartImageFormat.EmfDual
                | _ -> ChartImageFormat.Png
            chart.SaveImage(dlg.FileName, fmt) )

      menu.MenuItems.AddRange [| miCopy; miCopyEmf; miSave; miEdit |]
      self.ContextMenu <- menu

    member x.ChartSeries = seq { for s in series -> s }
