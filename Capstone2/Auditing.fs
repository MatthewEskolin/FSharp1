//contains the console and filesystem audit functions
module Capstone2.Auditing

open Capstone2.Domain
   
//File System Logger
let fileSystemAudit account message = 
    let directoryName = sprintf @"C:\temp\learnfs\capstone2\%s" account.Owner.Name 
    System.IO.Directory.CreateDirectory(directoryName) |> ignore
    let writer = System.IO.File.AppendText(sprintf @"%s\%A" directoryName account.AccountId)
    writer.WriteLine(sprintf "Account %A:%s" account.AccountId message) |> ignore
    writer.Flush() |> ignore


let consoleAudit account message = 
    let formattedMessage = sprintf "Account %A:%s" account.AccountId message
    printfn "%s" formattedMessage


let auditAs (operationName:string) (audit:Account -> string -> unit) (operation:decimal -> Account -> Account) (amount:decimal) (account:Account) : Account = 
        //do operation
        let accountResult = operation amount account
        let auditMessage  = sprintf "Performing an %s operation for $%M..." operationName amount
        audit account auditMessage |> ignore
        accountResult
        //audit operation


