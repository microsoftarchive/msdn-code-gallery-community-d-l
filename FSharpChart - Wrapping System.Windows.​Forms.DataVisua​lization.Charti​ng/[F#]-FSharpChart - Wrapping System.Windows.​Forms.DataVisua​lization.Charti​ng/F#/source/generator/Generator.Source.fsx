#r "..\\..\\htmlagilitypack\\HtmlAgilityPack.dll"
open System.Net
open System.Linq
open System.Collections.Generic
open HtmlAgilityPack

// --------------------------------------------------------------------------------------
// Utilities for downloading web pages

let cache = __SOURCE_DIRECTORY__ + "\\..\\cache\\"
let cacheFiles = true

let asyncDownload (s:string) = async {
  let wc = new WebClient()
  let fn = cache + System.Web.HttpUtility.UrlEncode(s) + ".html"
  let! html = async { 
    if System.IO.File.Exists fn then 
      return System.IO.File.ReadAllText fn
    else 
      let! html = wc.AsyncDownloadString(System.Uri(s)) 
      if cacheFiles then System.IO.File.WriteAllText(fn, html)
      return html }
  let doc = new HtmlDocument()
  doc.LoadHtml(html)
  return doc }

let download s = asyncDownload s |> Async.RunSynchronously

// --------------------------------------------------------------------------------------
// Types describing custom properties

type CustomType =
  | EnumerationType of string * string list
  | IntRangeType of string
  | FloatRangeType of string
  | BooleanType
  | ColorType
  | SeriesType
  | StringType

type CustomValue = 
  | EnumerationValue of string
  | BooleanValue of bool
  | IntValue of int
  | FloatValue of float
  | Undefined
  | ColorValue of string
  | StringValue of string

type Property =
  { Name : string
    Description : string
    Default : CustomValue
    Type : CustomType }

type ValuesCount = 
  | One = 1
  | Two = 2 
  | Three = 3
  | Four = 4
  | Multi = 5

type ChartType = 
  { Name : string
    Description : string
    ChartType : string
    ValuesCount : ValuesCount
    Properties : seq<Property> }

// --------------------------------------------------------------------------------------
// Parsing of properties

let (|ParseString|_|) (range, def) = 
  if range = "Any valid numeric or percentage value" then Some(StringType, StringValue def)
  elif range.StartsWith("A positive number or percentage") then Some(StringType, StringValue def)
  elif range = "Â" && def = "Â" then Some(StringType, Undefined)
  else None

let (|ParseSeries|_|) (range:string, def) = 
  if range.StartsWith("Name of any existing series") then Some(SeriesType, Undefined)
  else None

let (|ParseColor|_|) (range, def) = 
  if (range = "Any named color, ARGB or RGB value." ||
      range = "Any named color, ARGB or RGB value.Â") && 
     (def = "Empty" || (System.Enum.TryParse(def) : bool * System.Drawing.KnownColor) |> fst) then
    Some(ColorType, ColorValue def) else None  

let (|ParseEnumeration|_|) name (range:string, def) = 
  let items = range.Split [| ',' |] |> Seq.map (fun s -> s.Trim())
  if Seq.length items <= 1 then None else
    let def = 
      if def = "Â" then Some Undefined 
      elif items |> Seq.exists ((=) def) then Some(EnumerationValue(name + "." + def))
      else None
    def |> Option.map (fun def -> EnumerationType(name, items |> List.ofSeq), def)

let (|ParseRange|_|) (range:string, def:string) = 
  let split = range.IndexOf("â€“") // '-' is turned into this..
  if split > 0 then
    let nfrom = range.Substring(0, split).Trim()
    let nto = range.Substring(split+3).Trim()
    try Some(IntRangeType(sprintf "Any integer from %d to %d." (int nfrom) (int nto)), IntValue(int def))
    with _ -> 
      try Some(FloatRangeType(sprintf "Any double from %d to %d." (int nfrom) (int nto)), FloatValue(float def))
      with _ -> None
  elif range.StartsWith("0, 1, 2") then 
    try Some(IntRangeType("Any positive integer 0."), IntValue(int def))
    with _ -> None
  elif range.StartsWith("Any integer") then
    try Some(IntRangeType(range), IntValue(int def))
    with _ -> None
  elif range.StartsWith("Any double") then
    try Some(FloatRangeType(range), IntValue(int def))
    with _ -> None
  else None

let (|ParseBoolean|_|) (range, def) = 
  if range <> "True, False" && range <> "True, False, Auto" then None
  else Some(BooleanType, BooleanValue(def = "True"))

let parseProperty name description (attrs:IDictionary<string, string>) : Property =
  let typ, value = 
    match attrs.["Value range"], attrs.["Default value"] with 
    | ParseBoolean (typ, value) -> printfn "%s [Parsed Boolean]" name; typ, value
    | ParseRange (typ, value) -> printfn "%s [Parsed Range]" name; typ, value
    | ParseEnumeration name (typ, value) -> printfn "%s [Parsed Enumeration]" name; typ, value
    | ParseColor (typ, value) -> printfn "%s [Parsed Color]" name; typ, value
    | ParseSeries (typ, value) -> printfn "%s [Parsed Series]" name; typ, value
    | ParseString (typ, value) -> printfn "%s [Parsed String]" name; typ, value
    | _ ->
      printfn "\n%s\n%s" name description
      for (KeyValue(k, v)) in attrs do
        printfn " - %s = %s" k v
      StringType, Undefined
  { Name = name; Description = description.Replace("\n"," ").Replace("\r"," ");
    Default = value; Type = typ }

// --------------------------------------------------------------------------------------
// Download & process from the web

let propertiesDoc = download "http://msdn.microsoft.com/en-us/library/dd456764.aspx"

let properties = 
  [ for dl in propertiesDoc.DocumentNode.SelectNodes("//dl") do
      let a = dl.SelectSingleNode("dt/a")
      let p = dl.SelectSingleNode("dd/p")
      let doc = download (a.Attributes.["href"].Value)
      let attributes =
        [ for n in doc.DocumentNode.SelectNodes("//div[@class='tableSection']/table/tr") do
            let [key; value] = [ for td in n.SelectNodes("td") -> td.InnerText.Trim() ]
            yield key, value ] |> dict
      let name = a.InnerText.Trim()
      yield name, parseProperty name (p.InnerText.Trim()) attributes ] |> dict

// --------------------------------------------------------------------------------------
// Download chart types 

let chartsDoc = download "http://msdn.microsoft.com/en-us/library/dd489233.aspx"
let reg = new System.Text.RegularExpressions.Regex("\([^\)]*\)[\ \.]*")

let getValuesCount num = 
  let num = reg.Replace(num, "")
  match num, System.Int32.TryParse(num) with
  | _, (true, 1) -> ValuesCount.One
  | _, (true, 2) -> ValuesCount.Two
  | _, (true, 3) -> ValuesCount.Three
  | _, (true, 4) -> ValuesCount.Four
  | s, _ when s.StartsWith("Six or more") -> ValuesCount.Multi
  | _ -> failwithf "Cannot parse Y values per point: %s" num

let charts = 
  [ for dl in chartsDoc.DocumentNode.SelectNodes("//dl") do
      // Extract basic information from the list
      let a = dl.SelectSingleNode("dt/a")
      let p = dl.SelectSingleNode("dd/p")
      let doc = download (a.Attributes.["href"].Value)  
      // Download attributes table 
      let attributes =
        [ for n in doc.DocumentNode.SelectNodes("//div[@class='tableSection']/table").First().SelectNodes("tr") do
            let [key; value] = [ for td in n.SelectNodes("td") -> td.InnerText.Trim() ]
            yield key, value ] |> dict

      // Obtain properties associated with the chart
      let props = 
        if attributes.ContainsKey("Custom attributes") |> not then [] else
          [ for k in attributes.["Custom attributes"].Split [| ',' |] do
              if not (k.Contains("read-only")) then
                yield properties.[k.Trim()] ]

      // Print some logging and return chart object
      printfn "%s [%s]" (a.InnerText.Trim()) (attributes.["SeriesChartType value"].Trim())
      yield { Name = a.InnerText.Trim()
              Description = p.InnerText.Trim().Replace("\n"," ").Replace("\r"," ")
              ValuesCount = getValuesCount (attributes.["Number of Y values per point"])
              ChartType = (attributes.["SeriesChartType value"].Trim())
              Properties = props } ]

// --------------------------------------------------------------------------------------
// Utilities

module Seq =
  let groupsOfAtMost (size: int) (s: seq<'v>) : seq<list<'v>> =
    seq { let en = s.GetEnumerator()
          let more = ref true
          while !more do
            let group = 
              [ let i = ref 0
                while !i < size && en.MoveNext () do
                  yield en.Current
                  i := !i + 1 ]
            if List.isEmpty group then more := false
            else yield group }

// --------------------------------------------------------------------------------------
// Generate F# types from the data

let out k = Printf.fprintfn System.Console.Out k

let getTypeName typ = 
  match typ with 
  | EnumerationType(s, _) -> s, None
  | IntRangeType(rem) -> "int", Some rem
  | FloatRangeType(rem) -> "float", Some rem
  | BooleanType -> "bool", None
  | ColorType -> "ColorWrapper", None
  | SeriesType | StringType -> "string", None

let getDefaultValue typ value = 
  match typ, value with 
  | _, EnumerationValue s -> s
  | _, BooleanValue b -> b.ToString().ToLower()
  | FloatRangeType _, IntValue n -> n.ToString() + ".0"
  | _, IntValue n -> n.ToString()
  | _, FloatValue f -> f.ToString(System.Globalization.CultureInfo.InvariantCulture)
  | _, ColorValue c -> "Color." + c
  | _, StringValue s -> sprintf "\"%s\"" s
  | IntRangeType _, Undefined -> "0"
  | FloatRangeType _, Undefined -> "0.0"
  | (SeriesType _ | StringType), Undefined -> "\"\""
  | ColorType, Undefined -> "Color.Empty"
  | EnumerationType(n, opts), Undefined -> sprintf "%s.%s" n (opts |> Seq.head)
  | _ -> failwithf "Cannot get default value %A of type %A" value typ


let printDescription prefix indent (description:string) = 
  let lines = description.Replace("Â", "").Split [| ' ' |] |> Seq.groupsOfAtMost 10
  //for line in lines do 
  out "%s///%s %s" prefix indent (lines |> Seq.concat |> String.concat " ")

let printProperty (prop:Property) = 
  let typeName, remarks = getTypeName prop.Type
  let defaultValue = getDefaultValue prop.Type prop.Default
  // Nice name that doesn't start with number
  let niceName =  
    if prop.Name.StartsWith("3D") then prop.Name.Substring(2) + "3D"
    else prop.Name
  match remarks with 
  | None -> 
      printDescription "    " "" prop.Description
  | Some rem -> 
      out "    /// <summary>"
      printDescription "    " "  " prop.Description
      out "    /// </summary>"
      out "    /// <remarks>%s</remarks>" rem
  out "    member x.%s" niceName
  match prop.Type with 
  | ColorType ->
      out "        with get() = x.GetCustomProperty<%s>(\"%s\", ColorWrapper(%s)).Color" typeName prop.Name defaultValue
      out "        and set(v) = x.SetCustomProperty<%s>(\"%s\", ColorWrapper(v))" typeName prop.Name
  | _ ->
      out "        with get() = x.GetCustomProperty<%s>(\"%s\", %s)" typeName prop.Name defaultValue
      out "        and set(v) = x.SetCustomProperty<%s>(\"%s\", v)" typeName prop.Name
  out ""

// --------------------------------------------------------------------------------------
// Generate F# code with the chart types

for chart in charts do 
  printDescription "" "" chart.Description
  out "type %sChart() = " (chart.ChartType.Replace("SeriesChartType.", ""))
  out "    inherit GenericChart<%sValue>()" (chart.ValuesCount.ToString())
  out ""
  out "    /// Returns the type of the chart series"
  out "    override x.ChartType = %s" chart.ChartType
  out ""
  for prop in chart.Properties do 
    printProperty prop
  out ""
    
// --------------------------------------------------------------------------------------
// Generate F# code with enumerations 
// NOTE: Manually rename LabelStyle to LabelPosition because LabelStyle is already taken!
for prop in properties.Values do 
  match prop.Type with 
  | EnumerationType(name, opts) ->
      printDescription "" "" prop.Description
      out "type %s = " name
      opts |> Seq.iteri (fun i opt ->
        out "    | %s = %d" opt i)

      out ""
  | _ -> ()

let (|Let|) v input = (v, input)

// --------------------------------------------------------------------------------------
// Generate static class with extension methods

out "type Chart ="
for chart in charts do 
  let name = chart.ChartType.Replace("SeriesChartType.", "")
  match chart.ValuesCount with
  | ValuesCount.One | ValuesCount.Two | ValuesCount.Three | ValuesCount.Four ->
      let count = int chart.ValuesCount
      let conv = chart.ValuesCount.ToString().ToLower()

      let args prefixf sep = 
        if count > 1 then [ for i in 1 .. count -> System.String.Format(prefixf, string i) ] |> String.concat sep
        else System.String.Format(prefixf, "")

      // NOTE: We can remove type parameters if we want to 
      // use 'inline' and hat-typed different values (not IConvertible)

      // Enumerable overloads
      let gspec = sprintf "%s when %s" (args "'TY{0}" ", ") (args "'TY{0} :> IConvertible" " and ")
      let argspec = sprintf "seq<%s>" (args "'TY{0}" " * ")
      printDescription "    " "" chart.Description
      out "    static member %s<%s>(data: %s) = " name gspec argspec
      out "        GenericChart<_>.Create<%sChart>(%sY data)" name conv

      let argspec = sprintf "seq<'TX * (%s)>" (args "'TY{0}" " * ")
      let gspec = sprintf "'TX, %s when 'TX :> IConvertible and %s" (args "'TY{0}" ", ") (args "'TY{0} :> IConvertible" " and ") 
      printDescription "    " "" chart.Description
      out "    static member inline %s<%s>(data:%s) = " name gspec argspec
      out "        GenericChart<_>.Create<%sChart>(%sXYSeq data)" name conv

      let argspec = sprintf "seq<'TX>" 
      let gspec = sprintf "'TX, %s when 'TX :> IConvertible and %s" (args "'TY{0}Values, 'TY{0}" ", ") (args "'TY{0} :> IConvertible and 'TY{0}Values :> seq<'TY{0}>" " and ")
      printDescription "    " "" chart.Description
      out "    static member inline %s<%s>(xvalues:%s, %s) = " name gspec argspec (args "yvalues{0}:'TY{0}Values" ", ")
      out "        GenericChart<_>.Create<%sChart>(%sXY xvalues %s)" name conv (args "yvalues{0}" " ")

      // Observable overloads
      let gspec = sprintf "%s when %s" (args "'TY{0}" ", ") (args "'TY{0} :> IConvertible" " and ")
      printDescription "    " "" chart.Description
      out "    static member %s<%s>(data:IObservable<%s>, ?MaxPoints) = " name gspec (args "'TY{0}" " * ")
      out "        GenericChart<_>.Create<%sChart>(%sYObs (defaultArg MaxPoints -1) data)" name conv

      let gspec = sprintf "'TX, %s when %s and 'TX :> IConvertible" (args "'TY{0}" ", ") (args "'TY{0} :> IConvertible" " and ")
      printDescription "    " "" chart.Description
      out "    static member %s<%s>(data:IObservable<'TX * (%s)>, ?MaxPoints) = " name gspec (args "'TY{0}" " * ")
      out "        GenericChart<_>.Create<%sChart>(%sXYObs (defaultArg MaxPoints -1) data)" name conv
      out ""

  | ValuesCount.Multi ->
      // Special handling of BoxPlot
      printDescription "    " "" chart.Description
      out "    static member inline %s(data:seq<'T1 * 'T2 * 'T3 * 'T4 * 'T5 * 'T6>) = " name
      out "        GenericChart<_>.Create<%sChart>(sixY data)" name
      printDescription "  " "" chart.Description
      out "    static member inline %s(data:seq<'TX * 'TYValue[]>) = " name
      out "        GenericChart<_>.Create<%sChart>(sixXYArr data)" name
      printDescription "  " "" chart.Description
      out "    static member inline %s(data:seq<'TYValue[]>) =" name
      out "        GenericChart<_>.Create<%sChart>(sixYArr data)" name
      out ""
