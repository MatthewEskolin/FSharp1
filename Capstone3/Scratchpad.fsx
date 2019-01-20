#load "Domain.fs"
#load "Operations.fs"

open Capstone3.Operations
open Capstone3.Domain
open System
open System.Windows.Forms
open System


//Is it possible to use unions for this?
type commands = Withdrawal | Deposit | Exit | InvalidCommand
let parseCommand (command:char) = if command = 'w' then Withdrawal elif command ='d' then Deposit elif command = 'x' then Exit else InvalidCommand


let isValidCommand (command:char) =  if command = 'w' || command = 'd' || command = 'x' then true else false
let isStopCommand (command:char) = if command = 'x' then true else false

let getAmount (command:char) =
    if command = 'd' then ('d',50M)
    elif command = 'w' then ('w',25M)
    elif command = 'x' then ('x',0M)
    else ('E',0M) //error condition


let test = 4

let processCommand (account:Account) (command:char,amount:decimal) = 
    if command = 'd' then account |> deposit amount
    else account |> withdraw amount


//Let'st ry using the pipeline
let openingAccount = { Owner = { Name = "Isaac" }; Balance = 0M; AccountId = Guid.Empty } 
let account =
    let commands = [ 'd'; 'd'; 'w'; 'z'; 'f'; 'd'; 'x'; 'w' ]

    commands
    |> Seq.filter isValidCommand
    |> Seq.takeWhile (not << isStopCommand)
    |> Seq.map getAmount
    |> Seq.fold processCommand openingAccount

    



