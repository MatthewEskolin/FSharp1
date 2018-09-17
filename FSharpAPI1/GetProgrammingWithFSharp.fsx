open System.IO
open System.Collections.Generic


let greetPerson name age height = sprintf "Hello, %s. You are %d years old %d" name age height
greetPerson "Fred" 54 3

let gretPerson = 5
gretPerson




let TestShadowing() =
   let a = 1
   let a = 2
   a



let TestShadowing2() =
   let a = 1
   printfn "a: %i" a
   if true then
      let a = 2
      printfn "a: %i" a
   printfn "a: %i" a



//Function countwords returns: the number of words in a string
let countWords (text:string) =
    let count = text.Split(' ').Length
    let result = text + " " + count.ToString()
    File.WriteAllText("c:/temp/output.txt",result)
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



//listing 5.5
let add (a, b) = 
    let answer = a + b 
    answer |> ignore
    answer

add(4,3)


//listing 5.9
let createList<'a>(first:'a, second) = 
    let otuput = List()
    output.Add(first)
    output.Add(second)
    output

    

let myList = List()

open System.Collections.Generic
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
