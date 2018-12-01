open System.IO
open System.Collections.Generic








let addNum args = 
    let a,b = args
    a + b

addNum (3,4)

open System
Int32.TryParse("234x")

//Chapter 10 - Records

type Address = { Street : string; Town : string; City : string}


//Chapter 13 - Achieving Code Reuse
//Example of Higher Order Function

type Customer = { Age: int }
let where filter customers = 
    seq {
            for customer in customers do
                if filter customer then
                    yield customer }
 

let customers = [ { Age = 21}; {Age = 84 }; {Age = 23}]
let isOver35 customer = customer.Age > 35



customers |> where isOver35
customers |> where (fun customer -> customer.Age > 35)

let result = where 23 4

