open System
open System.IO

let dirs = System.IO.Directory.EnumerateDirectories "C:/"
let dirsInfos = dirs |> Seq.map(fun x -> new DirectoryInfo(x))
let directoryMap = dirsInfos|> Seq.map(fun x -> x.Name,x.CreationTimeUtc) |> Map.ofSeq
let directoryAges = directoryMap |> Map.map(fun x  y -> (DateTime.Now - directoryMap.[x]).TotalDays)



//Using Fold T