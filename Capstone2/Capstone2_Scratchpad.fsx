//Create Records
type Customer = { Name : string }
type Account = { AccountId: System.Guid; Owner: Customer; Balance : decimal }

///Deposits an amount into an account
let deposit (amount:decimal) (account:Account) : Account = 
    let newBalance = account.Balance + amount
    let newAccount = { account with Balance = newBalance}
    newAccount 


let withdraw (amount:decimal) (account:Account) : Account = 
    if(amount > account.Balance) 
        then account 
    else
        let newBalance = account.Balance - amount
        let newAccount = { account with Balance = newBalance }
        newAccount
        

let testCustomer : Customer = { Name = "John Smith"}
let testCustomer1 : Customer = { Name = "Mike Johnson"}
let account1 : Account = { AccountId = System.Guid.NewGuid(); Owner = testCustomer; Balance = 5000M;}


    
//File System Logger
let fileSystemAudit account message = 
    let directoryName = sprintf @"C:\temp\learnfs\capstone2\%s" account.Owner.Name 
    printfn "%s" directoryName
    let logDirectory = System.IO.Directory.CreateDirectory(directoryName)
    let writer = System.IO.File.AppendText(sprintf @"%s\%A" directoryName account.AccountId)
    let result = writer.WriteLine(sprintf "Account %A:%s" account.AccountId message)
    let result = writer.WriteLine(sprintf "Account %A:%s" account.AccountId message)
    let result = writer.WriteLine(sprintf "Account %A:%s" account.AccountId message)
    writer.Flush() |> ignore
    


let consoleAudit account message = 
    let formattedMessage = sprintf "Account %A:%s" account.AccountId message
    printfn "%s" formattedMessage



let customer = { Name = "Issac" }
let account = {AccountId = System.Guid.Empty; Owner = customer; Balance = 90M}

//Test out withdraw
let newAccount = account |> withdraw 10M
newAccount.Balance = 80M

//Test out console auditor
consoleAudit account "Testing console Audit"

let auditAs (operationName:string) (audit:Account -> string -> unit)
    (operation:decimal -> Account -> Account) (amount:decimal)
    (account:Account) : Account = 
        //do operation
        let accountResult = operation amount account
        let auditMessage  = sprintf "Performing an %s operation for $%M..." operationName amount
        audit account auditMessage |> ignore
        accountResult
        //audit operation






//try using "Curried Function"
let withdrawWithConsoleAudit = auditAs "withdraw" consoleAudit withdraw
let depositWithConsoleAudit = auditAs "deposit" consoleAudit deposit


    






