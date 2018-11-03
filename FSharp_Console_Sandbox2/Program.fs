// Learn more about F# at http://fsharp.org
open Domain
open Operations
open System

[<EntryPoint>]
let main argv =
    let joe = { FirstName = "Joseph"; LastName = "Smith" ; Age = 55 }
    if joe |> isOlderthan 34 then printfn "%s is an adult!" joe.FirstName
    else printfn "%s is a child." joe.FirstName

    let usused = Console.ReadLine()

    0 // return an integer exit code
