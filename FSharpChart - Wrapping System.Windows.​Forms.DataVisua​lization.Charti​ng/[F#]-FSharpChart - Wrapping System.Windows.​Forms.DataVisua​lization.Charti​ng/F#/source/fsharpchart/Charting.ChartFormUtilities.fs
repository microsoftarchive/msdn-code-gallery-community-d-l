namespace MSDN.FSharp.Charting
    
open System
open System.Drawing
open System.Collections.Generic
open System.Reflection
open System.Windows.Forms.DataVisualization.Charting

open MSDN.FSharp.Charting.ChartStyles


module internal ChartFormUtilities = 

    let private typesToClone = 
        [ typeof<System.Windows.Forms.DataVisualization.Charting.LabelStyle>;
          typeof<System.Windows.Forms.DataVisualization.Charting.Axis>;
          typeof<System.Windows.Forms.DataVisualization.Charting.Grid>; 
          typeof<System.Windows.Forms.DataVisualization.Charting.TickMark>
          typeof<System.Windows.Forms.DataVisualization.Charting.ElementPosition>; 
          typeof<System.Windows.Forms.DataVisualization.Charting.AxisScaleView>; 
          typeof<System.Windows.Forms.DataVisualization.Charting.AxisScrollBar>; ]

    let private typesToCopy = [ typeof<Font>; typeof<String> ]

    let private applyDefaults (chartType:SeriesChartType) (target:'a) (targetType:Type) (property:PropertyInfo) = 
        let isMatch propDefault = 
            if String.Equals(propDefault.PropertyName, property.Name) then
                match (propDefault.ChartType, propDefault.ParentType) with
                | (Some seriesType, Some parentType) -> (targetType.IsAssignableFrom(parentType) || targetType.IsSubclassOf(parentType)) && chartType = seriesType
                | (Some seriesType, None) -> chartType = seriesType
                | (None, Some parentType) -> targetType.IsAssignableFrom(parentType) || targetType.IsSubclassOf(parentType)
                | (_, _) -> true
            else
                false
        match List.tryFind isMatch PropertyDefaults with
        | Some item -> property.SetValue(target, item.PropertyDefault, [||])
        | _ -> ()

    let applyPropertyDefaults (chartType:SeriesChartType) (target:'a) = 
        let visited = new System.Collections.Generic.Dictionary<_, _>()
        let rec loop target = 
            if not (visited.ContainsKey target) then
                visited.Add(target, true)
                let targetType = target.GetType()
                for property in targetType.GetProperties(BindingFlags.Public ||| BindingFlags.Instance) do
                    if property.CanRead then
                        if typesToClone |> Seq.exists ((=) property.PropertyType) then
                            loop (property.GetValue(target, [||]))
                        elif property.CanWrite then
                            if property.PropertyType.IsValueType || typesToCopy |> Seq.exists ((=) property.PropertyType) then
                                applyDefaults chartType target targetType property
        loop target

    let applyProperties (target:'a) (source:'a) = 
        let visited = new System.Collections.Generic.Dictionary<_, _>()
        let rec loop target source = 
            if not (visited.ContainsKey target) then
                visited.Add(target, true)
                let ty = target.GetType()
                for p in ty.GetProperties(BindingFlags.Public ||| BindingFlags.Instance) do
                    if p.CanRead then
                        if typesToClone |> Seq.exists ((=) p.PropertyType) then
                            loop (p.GetValue(target, [||])) (p.GetValue(source, [||]))
                        elif p.CanWrite then
                            if p.PropertyType.IsValueType || typesToCopy |> Seq.exists ((=) p.PropertyType) then
                                if p.GetSetMethod().GetParameters().Length <= 1 then
                                    p.SetValue(target, p.GetValue(source, [||]), [||])
//                                else
//                                    printfn "Indexed property %s.%s (type %s)" ty.Name p.Name p.PropertyType.Name
//                            else
//                                printfn "Not sure what to do with %s.%s (type %s)" ty.Name p.Name p.PropertyType.Name
//                        else 
//                            printfn "Cannot write %s.%s" ty.Name p.Name    
        loop target source

    let createCounter() = 
        let count = ref 0
        (fun () -> incr count; !count) 
