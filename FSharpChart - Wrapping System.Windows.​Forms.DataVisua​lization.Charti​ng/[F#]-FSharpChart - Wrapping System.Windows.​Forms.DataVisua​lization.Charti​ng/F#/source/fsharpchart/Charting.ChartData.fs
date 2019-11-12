#nowarn "40"

namespace MSDN.FSharp.Charting
    
open System
open System.Collections
open System.Collections.Generic
open System.Windows.Forms.DataVisualization.Charting

open MSDN.FSharp.Charting
open MSDN.FSharp.Charting.ChartStyles
open MSDN.FSharp.Charting.ChartFormUtilities

module ChartData = 

    module internal Internal = 
        [<RequireQualifiedAccess>]
        type internal ChartData =
            // single value
            | YValues of IEnumerable
            | XYValues of IEnumerable * IEnumerable
            | YValuesChanging of int * IObservable<float>
            | XYValuesChanging of int * IObservable<IConvertible * float>
            // multiple values
            | MultiYValues of IEnumerable[]
            | MultiYValuesChanging of int * IObservable<float[]>
            | XMultiYValues of IEnumerable * IEnumerable[]    
            | XMultiYValuesChanging of int * IObservable<IConvertible * float[]>

            // stacked values
            | StackedYValues of seq<IEnumerable>
            | StackedXYValues of seq<IEnumerable * IEnumerable>

            // This one is treated specially (for box plot, we need to add data as a separate series)
            // TODO: This is a bit inconsistent - we should unify the next one with the last 
            // four and then handle boxplot chart type when adding data to the series
            | BoxPlotYArrays of seq<IEnumerable>
            | BoxPlotXYArrays of seq<IConvertible * IEnumerable>
            // A version of BoxPlot arrays with X values is missing (could be useful)
            // Observable version is not supported (probably nobody needs it)
            // (Unifying would sovlve these though)

        // ----------------------------------------------------------------------------------
        // Utilities for working with enumerable and tuples

        let map f (source:seq<_>) = 
          { new IEnumerable with
              member x.GetEnumerator() = 
                let en = source.GetEnumerator()
                { new IEnumerator with 
                    member x.Current = box (f en.Current)
                    member x.MoveNext() = en.MoveNext()
                    member x.Reset() = en.Reset() } }

        // There are quite a few variations - let's have some write-only combinator fun

        let useq (e:seq<_>) = e :> IEnumerable

        let el1of3 (a, _, _) = a 
        let el2of3 (_, a, _) = a 
        let el3of3 (_, _, a) = a 

        let el1of4 (a, _, _, _) = a 
        let el2of4 (_, a, _, _) = a 
        let el3of4 (_, _, a, _) = a 
        let el4of4 (_, _, _, a) = a 

        let el1of5 (a, _, _, _, _) = a 
        let el2of5 (_, a, _, _, _) = a 
        let el3of5 (_, _, a, _, _) = a 
        let el4of5 (_, _, _, a, _) = a 
        let el5of5 (_, _, _, _, a) = a 

        let el1of6 (a, _, _, _, _, _) = a 
        let el2of6 (_, a, _, _, _, _) = a 
        let el3of6 (_, _, a, _, _, _) = a 
        let el4of6 (_, _, _, a, _, _) = a 
        let el5of6 (_, _, _, _, a, _) = a 
        let el6of6 (_, _, _, _, _, a) = a 

        let tuple2 f g (x, y) = f x, g y
        let tuple3 f g h (x, y, z) = f x, g y, h z
        let tuple4 f g h i (x, y, z, w) = f x, g y, h z, i w

        let arr2 (a, b) = [| a; b |]
        let arr3 (a, b, c) = [| a; b; c |]
        let arr4 (a, b, c, d) = [| a; b; c; d |]

        // Converts Y value of a chart (defines the type too)
        let culture = System.Globalization.CultureInfo.InvariantCulture
        let cval (v:System.IConvertible) = v.ToDouble culture
        let cobj (v:System.IConvertible) = v

        // Alternative option:
        // (uses op_Explicit -> float constraint for values and any 'obj' allowed for X values)
        //   let cval a = float a' 
        //   let cobj (a:obj) = a

        // ----------------------------------------------------------------------------------
        // Single Y value

        // Y values only
        let oneY (source:seq<_>) = 
          ChartData.YValues(map cval source)
        // X and Y values as tuples
        let oneXYSeq (source:seq<_ * _>) = 
          ChartData.XYValues(map (fst >> cobj) source, map (snd >> cval >> box) source)
        // X and Y values as sequences
        let oneXY (xsource:seq<_>) (ysource:seq<_>) = 
          ChartData.XYValues(map cobj xsource, map cval ysource)
        
        // Y values changing
        let oneYObs maxPoints (source) = 
          ChartData.YValuesChanging(maxPoints, source |> Observable.map cval)
        // X and Y values as tuples, changing
        let oneXYObs maxPoints (source) = 
          ChartData.XYValuesChanging(maxPoints, source |> Observable.map (tuple2 cobj cval))

        // ----------------------------------------------------------------------------------
        // Two Y values

        // Y values only
        let twoY source = 
          ChartData.MultiYValues([| map (fst >> cval >> box) source; map (snd >> cval >> box) source |])
        // X and Y values as tuples
        let twoXYSeq source = 
          ChartData.XMultiYValues(map (fst >> cobj) source, [| map (snd >> fst >> cval >> box) source; map (snd >> snd >> cval >> box) source |])
        // X and Y values as sequences
        let twoXY xsource ysource1 ysource2 = 
          ChartData.XMultiYValues(map cobj xsource, [| map cval ysource1; map cval ysource2 |])

        // Y values changing
        let twoYObs maxPoints (source) = 
          ChartData.MultiYValuesChanging(maxPoints, source |> Observable.map (tuple2 cval cval >> arr2))
        // X and Y values as tuples, changing
        let twoXYObs maxPoints (source) = 
          ChartData.XMultiYValuesChanging(maxPoints, source |> Observable.map (tuple2 cobj (tuple2 cval cval >> arr2)))

        // ----------------------------------------------------------------------------------
        // Three Y values

        // Y values only
        let threeY source = 
          ChartData.MultiYValues([| map (el1of3 >> cval >> box) source; map (el2of3 >> cval >> box) source; map (el3of3 >> cval >> box) source |])
        // X and Y values as tuples
        let threeXYSeq source = 
          ChartData.XMultiYValues(map (fst >> cobj) source, [| map (snd >> el1of3 >> cval >> box) source; map (snd >> el2of3 >> cval >> box) source; map (snd >> el3of3 >> cval >> box) source |])
        // X and Y values as sequences
        let threeXY xsource ysource1 ysource2 ysource3 = 
          ChartData.XMultiYValues(map cobj xsource, [| map cval ysource1; map cval ysource2; map cval ysource3 |])

        // Y values changing
        let threeYObs maxPoints (source) = 
          ChartData.MultiYValuesChanging(maxPoints, source |> Observable.map (tuple3 cval cval cval >> arr3))
        // X and Y values as tuples, changing
        let threeXYObs maxPoints (source) = 
          ChartData.XMultiYValuesChanging(maxPoints, source |> Observable.map (tuple2 cobj (tuple3 cval cval cval >> arr3)))

        // ----------------------------------------------------------------------------------
        // Four Y values

        // Y values only
        let fourY source = 
          ChartData.MultiYValues([| map (el1of4 >> cval >> box) source; map (el2of4 >> cval >> box) source; map (el3of4 >> cval >> box) source; map (el4of4 >> cval >> box) source |])
        // X and Y values as tuples
        let fourXYSeq source = 
          ChartData.XMultiYValues(map (fst >> cobj) source, [| map (snd >> el1of4 >> cval >> box) source; map (snd >> el2of4 >> cval >> box) source; map (snd >> el3of4 >> cval >> box) source; map (snd >> el4of4 >> cval >> box) source |])
        // X and Y values as sequences
        let fourXY xsource ysource1 ysource2 ysource3 ysource4 = 
          ChartData.XMultiYValues(map cobj xsource, [| map cval ysource1; map cval ysource2; map cval ysource3; map cval ysource4 |])

        // Y values changing
        let fourYObs maxPoints (source) = 
          ChartData.MultiYValuesChanging(maxPoints, source |> Observable.map (tuple4 cval cval cval cval >> arr4))
        // X and Y values as tuples, changing
        let fourXYObs maxPoints (source) = 
          ChartData.XMultiYValuesChanging(maxPoints, source |> Observable.map (tuple2 cobj (tuple4 cval cval cval cval >> arr4)))

        // ----------------------------------------------------------------------------------
        // Six or more values

        // Y values only
        let sixY source = 
          ChartData.MultiYValues([| map (el1of6 >> cval >> box) source; map (el2of6 >> cval >> box) source; map (el3of6 >> cval >> box) source; map (el4of6 >> cval >> box) source; map (el5of6 >> cval >> box) source; map (el6of6 >> cval >> box) source |])
        // X and Y values as array
        let sixXYArr source = 
          let length = source |> Seq.head |> snd |> Array.length
          ChartData.XMultiYValues(map (fst >> cobj) source, [| for i in 0 .. length-1 -> seq { for (_, v) in source -> cval v.[i] } |> useq |])
        // Y values (for BoxPlot charts)
        let sixYArrBox (source:seq<#IConvertible[]>) = 
          ChartData.BoxPlotYArrays (source |> Seq.map (map cval))
        // X and Y values as array (for BoxPlot charts)
        let sixXYArrBox source = 
          let series = (source |> Seq.map (fun item -> cobj (fst item), map cval (snd item)))
          ChartData.BoxPlotXYArrays(series)

        // ----------------------------------------------------------------------------------
        // Stacked sequence values

        // Sequence of Y Values only
        let seqY (source:list<list<'TY>>) = 
            ChartData.StackedYValues (source |> List.map (map cval))
        // Sequence of X and Y Values only
        let seqXY (source: list<list<'TX * 'TY>>) = 
            let series = (source |> List.map (fun item -> List.unzip item |> (fun itemXY -> (map cobj (fst itemXY), map cval (snd itemXY))) ))
            ChartData.StackedXYValues (series)

        // --------------------------------------------------------------------------------------

        let internal bindObservable (chart:Chart) (series:Series) maxPoints values adder = 
            series.Points.Clear()
            let rec disp = 
                values |> Observable.subscribe (fun v ->
                    let op () = 
                        try
                            adder series.Points v
                            if maxPoints <> -1 && series.Points.Count > maxPoints then
                                series.Points.RemoveAt(0) 
                        with 
                        | :? NullReferenceException ->
                            disp.Dispose() 
                    if chart.InvokeRequired then
                        chart.Invoke(Action(op)) |> ignore
                    else 
                        op())
            ()


        let internal setSeriesData resetSeries (series:Series) data (chart:Chart) setCustomProperty =             

            let bindBoxPlot values getSeries getLabel (displayLabel:bool) = 
                let labels = chart.ChartAreas.[0].AxisX.CustomLabels
                let name = series.Name
                if resetSeries then
                    labels.Clear()
                    while chart.Series.Count > 1 do chart.Series.RemoveAt(1)                                 
                let seriesNames = 
                    values |> Seq.mapi (fun index series ->
                        let name = getLabel name index series
                        let dataSeries = new Series(name, Enabled = false, ChartType=SeriesChartType.BoxPlot)
                        dataSeries.Points.DataBindY [| getSeries series |]
                        if displayLabel then
                            labels.Add(float (index), float (index + 2), name) |> ignore
                            dataSeries.AxisLabel <- name
                            dataSeries.Label <- name
                        chart.Series.Add dataSeries
                        name )
                let boxPlotSeries = seriesNames |> String.concat ";"
                setCustomProperty("BoxPlotSeries", boxPlotSeries)

            let bindStackedChart values binder =                
                let name = series.Name
                let chartType = series.ChartType       
                while chart.Series.Count > 0 do chart.Series.RemoveAt(0)        
                values |> Seq.iteri (fun index seriesValue ->
                    let name = sprintf "Stacked_%s_%d" name index
                    let dataSeries = new Series(name, Enabled = false, ChartType=chartType)
                    applyProperties dataSeries series
                    dataSeries.Name <- name
                    binder dataSeries seriesValue
                    chart.Series.Add dataSeries)

            match data with 
            // Single Y value 
            | ChartData.YValues ys ->
                series.Points.DataBindY [| ys |]
            | ChartData.XYValues(xs, ys) ->
                series.Points.DataBindXY(xs, [| ys |])
            | ChartData.XYValuesChanging(maxPoints, xys) ->
                bindObservable chart series maxPoints xys (fun pts (x, y) -> pts.AddXY(x, y) |> ignore)
            | ChartData.YValuesChanging(maxPoints, ys) ->
                bindObservable chart series maxPoints ys (fun pts y -> pts.AddY(y) |> ignore)
            
            // Multiple Y values
            // TODO: Won't work for BoxPlot chart when the array contains more than 6 values
            // (but on the other hand, this will work for all 2/3/4 Y values charts)
            | ChartData.XMultiYValues(xs, yss) -> 
                series.Points.DataBindXY(xs, yss)
            | ChartData.MultiYValues yss ->
                series.Points.DataBindY yss
            | ChartData.MultiYValuesChanging(maxPoints, yss) ->
                bindObservable chart series maxPoints yss (fun pts ys -> pts.AddY(Array.map box ys) |> ignore)
            | ChartData.XMultiYValuesChanging(maxPoints, yss) ->
                bindObservable chart series maxPoints yss (fun pts (x, ys) -> pts.AddXY(x, Array.map box ys) |> ignore)
            
            // Special case for BoxPlot
            | ChartData.BoxPlotYArrays values ->
                bindBoxPlot values (fun value -> value) (fun name index value -> sprintf "Boxplot_%s_%d" name index) false
            | ChartData.BoxPlotXYArrays values ->
                bindBoxPlot values (snd) (fun name index value -> string (fst value)) true

            // Special case for Stacked
            | ChartData.StackedYValues values ->
                bindStackedChart values (fun (dataSeries:Series) seriesValue -> dataSeries.Points.DataBindY [| seriesValue |])
            | ChartData.StackedXYValues values ->
                bindStackedChart values (fun (dataSeries:Series) seriesValue -> dataSeries.Points.DataBindXY((fst seriesValue), ([| snd seriesValue |])))

    // ----------------------------------------------------------------------------------
    // Types that represent data loaded on a chart (and can be used to 
    // modify the data after the chart is created (see also Chart.Create))

    open Internal

    type ChartBinder<'T> = {
        Chart:Chart
        SetCustomProperty: string * 'T -> unit }

    [<AbstractClass>]
    type DataSource() = 
        abstract BindSeries : seq<Series> -> unit

    [<AbstractClass>]
    type DataSourceSingleSeries() =
        inherit DataSource() 
        let mutable series = None
        member internal x.SetDataInternal(data, ?chart:Chart, ?setCustomProperty) =
            match series with
            | None -> failwith "Error: Series has not been set for this data source."
            | Some series -> 
                match (chart, setCustomProperty) with
                | (Some ch, Some property) -> setSeriesData true series data ch property
                | (Some ch, _) -> setSeriesData true series data ch ignore
                | (_, _) -> setSeriesData true series data null ignore                 
        override x.BindSeries(seriesSeq) =
            match List.ofSeq seriesSeq with
            | [single] -> series <- Some single
            | _ -> failwith "Error: Binding multiple series to a data source object that supports only a single series"

    type OneValue() = 
        inherit DataSourceSingleSeries()
        member x.SetData<'TY when 'TY :> IConvertible>(data:seq<'TY>) = 
            base.SetDataInternal(oneY data)
        member x.SetData<'TX, 'TY when 'TX :> IConvertible and 'TY :> IConvertible>(data: seq<'TX * ('TY)>) = 
            base.SetDataInternal(oneXYSeq data)
        member x.SetData<'TX, 'TY when 'TX :> IConvertible and 'TY :> IConvertible>(xvalues:seq<'TX>, yvalues:seq<'TY>) = 
            base.SetDataInternal(oneXY xvalues yvalues)
        member x.SetData<'TY when 'TY :> IConvertible>(data:IObservable<'TY>, ?MaxPoints) = 
            base.SetDataInternal(oneYObs (defaultArg MaxPoints -1) data)
        member x.SetData<'TX, 'TY when 'TY :> IConvertible and 'TX :> IConvertible>(data:IObservable<'TX * ('TY)>, ?MaxPoints) = 
            base.SetDataInternal(oneXYObs (defaultArg MaxPoints -1) data)

    type TwoValue() = 
        inherit DataSourceSingleSeries()
        member x.SetData<'TY1, 'TY2 when 'TY1 :> IConvertible and 'TY2 :> IConvertible>(data:seq<'TY1 * 'TY2>) = 
            base.SetDataInternal(twoY data)
        member x.SetData<'TX, 'TY1, 'TY2 when 'TX :> IConvertible and 'TY1 :> IConvertible and 'TY2 :> IConvertible>(data:seq<'TX * ('TY1 * 'TY2)>) = 
            base.SetDataInternal(twoXYSeq data)
        member x.SetData<'TX, 'TY1, 'TY2 when 'TX :> IConvertible and 'TY1 :> IConvertible and 'TY2 :> IConvertible>(xvalues:seq<'TX>, yvalues1:seq<'TY1>, yvalues2:seq<'TY2>) = 
            base.SetDataInternal(twoXY xvalues yvalues1 yvalues2)
        member x.SetData<'TY1, 'TY2 when 'TY1 :> IConvertible and 'TY2 :> IConvertible>(data:IObservable<'TY1 * 'TY2>, ?MaxPoints) = 
            base.SetDataInternal(twoYObs (defaultArg MaxPoints -1) data)
        member x.SetData<'TX, 'TY1, 'TY2 when 'TY1 :> IConvertible and 'TY2 :> IConvertible and 'TX :> IConvertible>(data:IObservable<'TX * ('TY1 * 'TY2)>, ?MaxPoints) = 
            base.SetDataInternal(twoXYObs (defaultArg MaxPoints -1) data)

    type ThreeValue() = 
        inherit DataSourceSingleSeries()
        member x.SetData<'TY1, 'TY2, 'TY3 when 'TY1 :> IConvertible and 'TY2 :> IConvertible and 'TY3 :> IConvertible >(data:seq<'TY1 * 'TY2 * 'TY3>) = 
            base.SetDataInternal(threeY data)
        member x.SetData<'TX, 'TY1, 'TY2, 'TY3 when 'TX :> IConvertible and 'TY1 :> IConvertible and 'TY2 :> IConvertible and 'TY3 :> IConvertible>(data:seq<'TX * ('TY1 * 'TY2 * 'TY3)>) = 
            base.SetDataInternal(threeXYSeq data)
        member x.SetData<'TX, 'TY1, 'TY2, 'TY3 when 'TX :> IConvertible and 'TY1 :> IConvertible and 'TY2 :> IConvertible and 'TY3 :> IConvertible>(xvalues:seq<'TX>, yvalues1:seq<'TY1>, yvalues2:seq<'TY2>, yvalues3:seq<'TY3>) = 
            base.SetDataInternal(threeXY xvalues yvalues1 yvalues2 yvalues3)
        member x.SetData<'TY1, 'TY2, 'TY3 when 'TY1 :> IConvertible and 'TY2 :> IConvertible and 'TY3 :> IConvertible>(data:IObservable<'TY1 * 'TY2 * 'TY3>, ?MaxPoints) = 
            base.SetDataInternal(threeYObs (defaultArg MaxPoints -1) data)
        member x.SetData<'TX, 'TY1, 'TY2, 'TY3 when 'TY1 :> IConvertible and 'TY2 :> IConvertible and 'TY3 :> IConvertible and 'TX :> IConvertible>(data:IObservable<'TX * ('TY1 * 'TY2 * 'TY3)>, ?MaxPoints) = 
            base.SetDataInternal(threeXYObs (defaultArg MaxPoints -1) data)

    type FourValue() = 
        inherit DataSourceSingleSeries()
        member x.SetData<'TY1, 'TY2, 'TY3, 'TY4 when 'TY1 :> IConvertible and 'TY2 :> IConvertible and 'TY3 :> IConvertible and 'TY4 :> IConvertible>(data:seq<'TY1 * 'TY2 * 'TY3 * 'TY4>) = 
            base.SetDataInternal(fourY data)
        member x.SetData<'TX, 'TY1, 'TY2, 'TY3, 'TY4 when 'TX :> IConvertible and 'TY1 :> IConvertible and 'TY2 :> IConvertible and 'TY3 :> IConvertible and 'TY4 :> IConvertible>(data:seq<'TX * ('TY1 * 'TY2 * 'TY3 * 'TY4)>) = 
            base.SetDataInternal(fourXYSeq data)
        member x.SetData<'TXValues, 'TX, 'TY1, 'TY2, 'TY3, 'TY4 when 'TX :> IConvertible and 'TY1 :> IConvertible and 'TY2 :> IConvertible and 'TY3 :> IConvertible and 'TY4 :> IConvertible>(xvalues:seq<'TX>, yvalues1:seq<'TY1> , yvalues2:seq<'TY2>, yvalues3:seq<'TY3>, yvalues4:seq<'TY4>) = 
            base.SetDataInternal(fourXY xvalues yvalues1 yvalues2 yvalues3 yvalues4)
        member x.SetData<'TY1, 'TY2, 'TY3, 'TY4 when 'TY1 :> IConvertible and 'TY2 :> IConvertible and 'TY3 :> IConvertible and 'TY4 :> IConvertible>(data:IObservable<'TY1 * 'TY2 * 'TY3 * 'TY4>, ?MaxPoints) = 
            base.SetDataInternal(fourYObs (defaultArg MaxPoints -1) data)
        member x.SetData<'TX, 'TY1, 'TY2, 'TY3, 'TY4 when 'TY1 :> IConvertible and 'TY2 :> IConvertible and 'TY3 :> IConvertible and 'TY4 :> IConvertible and 'TX :> IConvertible>(data:IObservable<'TX * ('TY1 * 'TY2 * 'TY3 * 'TY4)>, ?MaxPoints) = 
            base.SetDataInternal(fourXYObs (defaultArg MaxPoints -1) data)

    type MultiValue() = 
        inherit DataSourceSingleSeries()
        member x.SetData(data:seq<'T1 * 'T2 * 'T3 * 'T4 * 'T5 * 'T6>, chartBinder:ChartBinder<string>) = 
            base.SetDataInternal(sixY data, chartBinder.Chart, chartBinder.SetCustomProperty)
        member x.SetData(data:seq<'TX * 'TYValue[]>, chartBinder:ChartBinder<string>) = 
            base.SetDataInternal(sixXYArrBox data, chartBinder.Chart, chartBinder.SetCustomProperty)
        member x.SetData(data:seq<'TYValue[]>, chartBinder:ChartBinder<string>) = 
            base.SetDataInternal(sixYArrBox data, chartBinder.Chart, chartBinder.SetCustomProperty)

    type StackedValue() =
        inherit DataSourceSingleSeries()
        member x.SetData(data: list<list<'TY>>, chartBinder:ChartBinder<string>) =
            base.SetDataInternal(seqY data, chartBinder.Chart)
        member x.SetData(data: list<list<'TX * 'TY>>, chartBinder:ChartBinder<string>) =
            base.SetDataInternal(seqXY data, chartBinder.Chart)


    type DataSourceCombined() = 
        inherit DataSource()
        let mutable seriesTable = dict []
        override x.BindSeries(seriesSeq) =
            seriesTable <- dict [ for s in seriesSeq -> s.Name, s ]
        member x.Find<'TData when 'TData :> DataSource and 'TData : (new : unit -> 'TData)>(name) =
            match seriesTable.TryGetValue(name) with
            | true, obj ->
                // TODO: We do not check if the series has the right data type
                let data = new 'TData()
                data.BindSeries [obj]
                data
            | _ -> failwithf "Error: Series with the name %s not found" name
