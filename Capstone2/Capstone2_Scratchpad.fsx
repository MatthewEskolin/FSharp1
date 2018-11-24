//Create Records
type Customer = { Name : string }
type Account = { AccountId: System.Guid; Owner: Customer; Balance : decimal }

///Deposits an amount into an account
let deposit (amount:decimal) (account:Account) : Account = 
    let newBalance = account.Balance + amount
    let newAccount = { account with Balance = newBalance}
    newAccount 


let withdrawl (amount:decimal) (account:Account) : Account = 
    if(amount > account.Balance) 
        then account 
    else
        let newBalance = account.Balance - amount
        let newAccount = { account with Balance = newBalance }
        newAccount
        

let testCustomer : Customer = { Name = "John Smith"}
let testCustomer1 : Customer = { Name = "Mike Johnson"}
let account1 : Account = { AccountId = System.Guid.NewGuid(); Owner = testCustomer; Balance = 5000M;}


    





