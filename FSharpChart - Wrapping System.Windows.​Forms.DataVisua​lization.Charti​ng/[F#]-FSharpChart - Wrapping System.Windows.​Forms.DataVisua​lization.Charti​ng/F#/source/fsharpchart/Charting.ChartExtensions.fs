namespace MSDN.FSharp.Charting
    
open System
open System.Collections.Generic
open System.Windows.Forms
open System.Windows.Forms.DataVisualization.Charting

open MSDN.FSharp.Charting.ChartTypes
open MSDN.FSharp.Charting.ChartData


[<AutoOpen>]
module ChartExtensions = 

    type ChartForm<'TData when 'TData :> DataSource and 'TData : (new : unit -> 'TData)>(ch:GenericChart<'TData>) = 
        inherit Form()

        let ctrl = new ChartControl(ch, Dock = DockStyle.Fill)
        do base.Controls.Add(ctrl)

        member x.ChartControl = ctrl
    
    type ChartFormUtilities() =

        static let createCounter() = 
            let count = ref 0
            (fun () -> incr count; !count)

        static let dict = new Dictionary<string, unit -> int>()

        static member ProvideTitle (chart:GenericChart) = 
            let defaultName = 
                match String.IsNullOrEmpty(chart.Name) with
                    | true ->
                        let chartType = 
                            match int chart.ChartType with
                            | -1 -> "Combined"
                            | _ -> chart.ChartType.ToString()
                        chartType  + " Chart"
                    | false -> chart.Name

            match dict.ContainsKey(defaultName) with
                | true ->
                    sprintf "%s (%i)" defaultName (dict.[defaultName]())
                | false ->
                    dict.Add(defaultName, createCounter())
                    defaultName

    type FSharpChart with

        static member Create<'TData when 'TData :> DataSource and 'TData : (new : unit -> 'TData)>(ch:GenericChart<'TData>) =
            let ds = new 'TData()
            let frm = new ChartForm<'TData>(ch, Visible = true, TopMost = true, Width = 700, Height = 500)
            frm.Text <- ChartFormUtilities.ProvideTitle ch
            ds.BindSeries(frm.ChartControl.ChartSeries)
            ds

        static member WithCreate<'TData when 'TData :> DataSource and 'TData : (new : unit -> 'TData)>(ch:GenericChart<'TData>) =
            FSharpChart.Create ch |> ignore
            ch

        static member CopyToClipboard (chart:GenericChart) =
            chart.CopyChartToClipboard()

        static member CopyToClipboardEmf (chart:GenericChart) =
            chart.CopyChartToClipboardEmf(chart.Chart)

        static member SaveAs (filename : string) (format : ChartImageFormat) (chart : GenericChart) =             
            chart.SaveChartAs(filename, format)