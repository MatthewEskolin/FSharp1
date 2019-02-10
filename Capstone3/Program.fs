module Capstone3.Program

open System
open Capstone3.Domain
open Capstone3.Operations



[<AutoOpen>]
module UserInput =
    let commands = seq {
        while true do 
            Console.Write "(d)eposit, (w)ithdraw or e(x)it: "
            yield Console.ReadKey().KeyChar
            Console.WriteLine() }

    let getAmount command =
        Console.WriteLine()
        Console.Write "Enter Amount: "
        command, Console.ReadLine() |> Decimal.Parse

[<EntryPoint>]
let main _ =
    //let name =
    //    Console.Write "Please enter your name: "
    //    Console.ReadLine()

    let withdrawWithAudit = auditAs "withdraw" Auditing.composedLogger withdraw
    let depositWithAudit = auditAs "deposit" Auditing.composedLogger deposit
    let loadAccountFromDisk = FileRepository.findTransactionsOnDisk >> Operations.loadAccount

    
    let isValidCommand (command:char) =  if command = 'w' || command = 'd' || command = 'x' then true else false
    let isStopCommand (command:char) = if command = 'x' then true else false


    //let getAmount (command:char) =
    //    if command = 'd' then ('d',50M)
    //    elif command = 'w' then ('w',25M)
    //    elif command = 'x' then ('x',0M)
    //    else ('E',0M) //error condition


    let processCommand (account:Account) (command:char,amount:decimal) = 
        printfn ""
        let account =
            if command = 'd' then account |> depositWithAudit amount
            else account |> withdrawWithAudit amount
        printfn "Current balance is $%M" account.Balance
        account




    let openingAccount =
        Console.Write "Please enter your name: "
        Console.ReadLine() |> loadAccountFromDisk



    let closingAccount =
        commands
        |> Seq.filter isValidCommand
        |> Seq.takeWhile (not << isStopCommand)
        |> Seq.map getAmount
        |> Seq.fold processCommand openingAccount

    
        // Fill in the main loop here...
        //openingAccount

    Console.Clear()
    printfn "Closing Balance:\r\n %A" closingAccount
    Console.ReadKey() |> ignore

    0