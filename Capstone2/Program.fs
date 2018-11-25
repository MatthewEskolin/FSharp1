// Learn more about F# at http://fsharp.org
open System
open Capstone2.Operations
open Capstone2.Auditing
open Capstone2.Domain
open System.Linq.Expressions
open System.Linq.Expressions


[<EntryPoint>]
let main argv =

    //User Inputs user name
    System.Console.Write("User Name: ");
    let userName = System.Console.ReadLine()

    //User Inputs Opening
    System.Console.Write("Opening Balance: ");
    let openBalance = Decimal.Parse(System.Console.ReadLine())

    //create Customer
    let customer = { Name = userName} : Customer
    let mutable account = { AccountId = System.Guid.NewGuid(); Owner = customer; Balance = openBalance } : Account

     
    let withdrawWithAudit = withdraw |> auditAs "withdraw" consoleAudit
    let depositWithAudit = deposit |> auditAs "deposit" consoleAudit

    while true do
        Console.Write("Choose Account Action >>>")
        let action = Console.ReadLine()
        if action = "x" then Environment.Exit 0
        if action <> "d" && action <> "w" then Console.WriteLine("commands are (x - exit, d - deposit, w - withdraw")
            //invalid command return to top of loop
        else
            Console.Write("Amount >>>")
            let amount1 = Console.ReadLine() 
            let amount = Decimal.Parse(amount1)

            account <-
                if action = "d" then account |> depositWithAudit amount
                elif action = "w" then account |> withdrawWithAudit amount
                else account

            0 |> ignore 


    printfn "Hello World from F#!"
    0 // return an integer exit code
