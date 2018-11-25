open System.IO
open System.Collections.Generic



1
   
   
//Page 50
let myRandom = System.Random 234
let myFinalRandom = myRandom.Next()
let randomString = myFinalRandom.ToString()
printfn "%s = WHATIS GOING ON  my random" randomString


//listing 4.7 Nested Inner Functions
let estimageAges(familyName, year1, year2, year3) = 
    let calculateAge yearOfBirth =
        let year = System.DateTime.Now.Year
        year - yearOfBirth

    let estimatedAge = calculateAge year1
    let estimatedAge2 = calculateAge year2
    let estimatedAge3 = calculateAge year3

    let averageAge = (estimatedAge + estimatedAge2 + estimatedAge3) / 3
    sprintf "Average age for amily %s is %d" familyName averageAge


estimageAges("Eskolin", 1960, 1960, 1987)




//listing 5.9
let createList<'a>(first:'a, second) = 
    let otuput = List()
    output.Add(first)
    output.Add(second)
    output

    

let myList = List()

open System.Collections.Generic
open System

let createList(first, second) = 
    let output = List()
    output.Add(first)
    output.Add(second)
    output


let unit1 = () 

// val createList : first:'a * second:'a -> List<'a>
"Test".GetHashCode
System.Console.WriteLine("test")



let parseName(name:string) = 
    let parts = name.Split(' ')
    let forename =   parts.[0]
    let surname  = parts.[1]
    forename, surname

let name = parseName("James X")
let forename, surname = name
let fname, sname = parseName("John Y")

name



//9.3.4
let explicit : int * int = 10,6
let implicit = 34,3

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

