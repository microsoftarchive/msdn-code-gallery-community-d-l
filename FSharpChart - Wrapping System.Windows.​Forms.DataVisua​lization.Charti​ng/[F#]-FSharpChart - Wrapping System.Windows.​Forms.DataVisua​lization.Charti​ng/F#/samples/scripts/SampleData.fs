// --------------------------------------------------------------------------------------
// Generates sample data for demo charts.
// (From http://code.msdn.microsoft.com/fschart)
// --------------------------------------------------------------------------------------

module Data

open System

let uniform =
    let rnd = new System.Random()
    fun () -> rnd.NextDouble()

let gauss() =
    let rec sumU n acc = if n <= 0 then acc else sumU (n - 1) (acc + uniform())
    sumU 12 0.0 - 6.0

let brownian =
    Seq.unfold (fun b -> Some (b, b + gauss())) 0.0

let brownianPath n =
    brownian |> Seq.take (n + 1) |> Seq.map (fun x -> x / sqrt (float n)) |> Seq.toArray

let brownianX n = Array.init (n + 1) (fun k -> float k / float n)
let brownianY n = brownianPath n

let aggregate period ps =
    let n = Array.length ps
    let p = n / period
    let o = Array.zeroCreate p
    let h = Array.zeroCreate p
    let l = Array.zeroCreate p
    let c = Array.zeroCreate p
    let rec bar k =
        if k >= p then () else
        let i1 = k * period
        let i2 = i1 + period - 1
        o.[k] <- ps.[i1]
        c.[k] <- ps.[i2]
        h.[k] <- Array.max ps.[i1 .. i2]
        l.[k] <- Array.min ps.[i1 .. i2]
        bar (k + 1)
    bar 0
    o, h, l, c

let brownianBarsAsList n p =
    let y = brownianY n
    let o, h, l, c = aggregate p (Array.map ((+)10.0) y)
    let d = Array.init (n / p) (fun t -> DateTime.Today.AddDays(float <| t - n / p))
    [ for i in 0 .. d.Length - 1 -> d.[i], (h.[i], l.[i], o.[i], c.[i]) ]

let brownianBarsAsTupleOfLists n p =
    let y = brownianY n
    let o, h, l, c = aggregate p (Array.map ((+)10.0) y)
    let d = Array.init (n / p) (fun t -> DateTime.Today.AddDays(float <| t - n / p))
    d, h, l, o, c

open System.IO

let sp, spma, spchan, spatr =
    
    let date (s : string) =
        let ymd =  int s
        let d   =  ymd % 100
        let m   = (ymd % 10000) / 100
        let y   =  ymd / 10000
        DateTime(y, m, d)
    
    let lines = File.ReadAllLines (__SOURCE_DIRECTORY__ + "\\SampleData.txt")
    let a() = Array.zeroCreate lines.Length
    let d, o, h, l, c, v = a(), a(), a(), a(), a(), a()
    lines
    |> Seq.iteri (fun i s ->
        let fields = s.Split [|','|]
        d.[i] <- date  fields.[0]
        o.[i] <- float fields.[1]
        h.[i] <- float fields.[2]
        l.[i] <- float fields.[3]
        c.[i] <- float fields.[4]
        v.[i] <- float fields.[6]
    )
    
    let tr = Array.init d.Length (fun i -> if i = 0 then h.[0] - l.[0] else max h.[i] c.[i-1] - min l.[i] c.[i-1])
    
    let findIndex t = Array.findIndex (fun s -> s >= t) d
    
    let foldRange f i1 i2 acc (a : array<_>) =
        let mutable acc = acc
        for i = i1 to i2 do
            acc <- f acc a.[i]
        acc
    
    fun t1 t2 ->
        let i1, i2 = findIndex t1, findIndex t2
        d.[i1..i2], o.[i1..i2], h.[i1..i2], l.[i1..i2], c.[i1..i2], v.[i1..i2]
    ,
    fun n t1 t2 ->
        let i1, i2 = findIndex t1, findIndex t2
        if n < 1 || n > i1 + 1 then failwith "not enough data"
        Array.init (i2 - i1 + 1) (fun k -> (foldRange (+) (i1 + k - n + 1) (i1 + k) 0.0 c) / float n)
    ,
    fun n t1 t2 ->
        let i1, i2 = findIndex t1, findIndex t2
        if n < 1 || n > i1 + 1 then failwith "not enough data"
        Array.init (i2 - i1 + 1) (fun k -> foldRange min (i1 + k - n + 1) (i1 + k) 1.0e9 l),
        Array.init (i2 - i1 + 1) (fun k -> foldRange max (i1 + k - n + 1) (i1 + k) 0.0   h)
    ,
    fun n t1 t2 ->
        let i1, i2 = findIndex t1, findIndex t2
        if n < 1 || n > i1 + 1 then failwith "not enough data"
        Array.init (i2 - i1 + 1) (fun k -> (foldRange (+) (i1 + k - n + 1) (i1 + k) 0.0 tr) / float n)
