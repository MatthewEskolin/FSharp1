module Capstone2.Operations

open Capstone2.Domain

let withdraw (amount:decimal) (account:Account) : Account = 
    if(amount > account.Balance) 
        then account 
    else
        let newBalance = account.Balance - amount
        let newAccount = { account with Balance = newBalance }
        newAccount
        


let deposit (amount:decimal) (account:Account) : Account = 
    let newBalance = account.Balance + amount
    let newAccount = { account with Balance = newBalance}
    newAccount


