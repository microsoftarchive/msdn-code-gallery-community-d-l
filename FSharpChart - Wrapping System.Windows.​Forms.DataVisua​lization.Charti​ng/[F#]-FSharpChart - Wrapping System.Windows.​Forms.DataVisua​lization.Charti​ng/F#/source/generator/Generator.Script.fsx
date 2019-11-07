open System.Net
open System.Linq
open System.Collections.Generic
open System.IO
open System.Text.RegularExpressions 

// --------------------------------------------------------------------------------------
// Utility for creating a single FSX file
// The code will parse through the template file and replace each #file with the appropriate file contents

let codeDir = __SOURCE_DIRECTORY__ + "\\..\\fsharpchart\\"
let templateName = __SOURCE_DIRECTORY__ + "\\FSharpChart.fstemplate"
let sourceName = __SOURCE_DIRECTORY__ + "\\..\\..\\scripts\\FSharpChart.fsx"
let startLine = "// ----------------------------------- "
let commentLine = "// "
let blankLine = ""

let filePattern = "^\#file\s+\"(?<filename>.*)\"$"
let codePattern = "^module|type|\[<.*>\]"
let openPattern = "^open MSDN\.FSharp\.Charting\.(?<openstatement>.*)$"

// Processes the contents of a code file
let isNotCodeStart (line:string) =
    if not (Regex.Match(line, codePattern).Success) then true
    else false

let getOpenStatements (lines:string list) (line:string) = 
    let m = Regex.Match(line, openPattern, RegexOptions.IgnoreCase)
    if m.Success && m.Groups.Count = 2 then ("open " + m.Groups.["openstatement"].Value) :: lines
    else lines
    
let openFileLines filename = 
    File.ReadAllLines(codeDir + filename)
    |> Seq.takeWhile isNotCodeStart
    |> Seq.fold getOpenStatements []

let codeFileLines filename = 
    File.ReadAllLines(codeDir + filename)
    |> Seq.skipWhile isNotCodeStart

let processCode filename =
    [ yield startLine
      yield commentLine + filename
      yield startLine

      // yield any neccessary open statements
      match openFileLines filename with
      | [] -> ()
      | _ -> 
        yield! (openFileLines filename)
        yield blankLine

      // yield the module/type code lines
      yield! (codeFileLines filename)

      yield blankLine]

// Define the output of the template file processing any #file elements
let (|MatchFileInclude|_|) (line:string) = 
    let m = Regex.Match(line, filePattern, RegexOptions.IgnoreCase)
    if m.Success && m.Groups.Count = 2 then Some(m.Groups.["filename"].Value) else None

let templateFile =
    [ for line in File.ReadAllLines(templateName) do
        match line with
        | MatchFileInclude filename -> yield! (processCode filename) 
        | _ -> yield line ]


// open and write the file contents
do
    use codeFile = File.CreateText(sourceName)

    templateFile
    |> Seq.iter codeFile.WriteLine
