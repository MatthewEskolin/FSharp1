open Hopac
open HttpFs.Client
open FSharp.Data

let apiBaseUrl = "https://www.alphavantage.com/query?"

let body =
  Request.createUrl Get "http://gmiprime.com"
  |> Request.responseAsString
  |> run

printfn "Here's the body: %s" body
System.Console.ReadLine() |> ignore

let result = Http.RequestString("http://www.google.com")
System.Console.Write(result)
System.Console.ReadLine() |> ignore






