//I have been learning F# using the book "Get Programming with F# - A Guide for .NET developers" by Issac Abraham
//This project will contain the most important pieces of code aquired through my learning process, things that will best help me retain my knowledge.
//This project should be a reference guide for how to do things in F#


//module TESt
//
//
module FSharp_Cookbook.Core 


open System.IO
open System.Collections.Generic
open System.Collections.Generic
open System
open System
open System.Net

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//(1) String Functions
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



    //printfn
    let hello name = printfn "Hello %s" name //creats a function that when called prints to the console

    //sprintf
    let greetPerson name age height = sprintf "Hello, %s. You are %d years old %d" name age height
    let string = greetPerson "Fred" 54 3


    //count number of words in a string
    let countWords (text:string) =
        let count = text.Split(' ').Length
        let result = text + " " + count.ToString()
        System.IO.File.WriteAllText("c:/temp/output.txt",result)

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//(2) Misc. Features 
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


//Curried Function Example
let curriedAdd a b = a + b           //notice how only one argument is defined for curriedAdd - a new function "addFive" is created with the signature ( int -> int) 
let addFive = curriedAdd 5           //now that all the arguments have been passed, "final" is the integer result of adding 5 to 1232.
let final = addFive 1232



//Writing to a File
let writeToFile (date:System.DateTime) filename text =
    let formattedDate = date.ToString("yyMMdd")             //Date formatting
    let path = sprintf "%s-%s.txt" formattedDate filename
    System.IO.File.WriteAllText(path, text)
    "F"




//Working with Tuples and Records
let parse(person:string) =      //Creates a Tuple from a string, by splitting out the elements
    let seperated = person.Split(' ' )
    seperated.[0], seperated.[1],int(seperated.[2])

let myRecord = parse("Mary Asteroids 2900")


let a,b,c = myRecord //extracts tuple elements intro three seperate values
a
b
c



// - explicity define tuple
let explicit : int * int = 10,6
let implicit = 34,3




//Web Download Example
let webclient = new WebClient()
let fsharpOrg = webclient.DownloadString(Uri "http://fsharp.org")

//Type Inference Example
let createList(first, second) = 
    let output = List()
    output.Add(first)
    output.Add(second)
    output


/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//(3) Working with Collections - LINQ the F# Way
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////n



//
//(3.1) Selecting and Filtering
//



type Customer = { Age: int }
let where filter customers = 
    seq {
            for customer in customers do
                if filter customer then
                    yield customer }
 

let customers = [ { Age = 21}; {Age = 84 }; {Age = 23}]
let isOver35 customer = customer.Age > 35

let r1 = customers |> where isOver35
let r2= customers |> where (fun customer -> customer.Age > 35)


//The following 2 examples show how to chain LINQlike expression together to answer a specific question about the dataset.

// Listing 15.1
type FootballResult = { HomeTeam : string; AwayTeam : string; HomeGoals : int; AwayGoals : int }
let create (ht, hg) (at, ag) = { HomeTeam = ht; AwayTeam = at; HomeGoals = hg; AwayGoals = ag }
let results =
    [ create ("Messiville", 1) ("Ronaldo City", 2)
      create ("Ronaldo City", 1) ("Bale Town", 2) ]


// Listing 15.4
let isAwayWin result = result.AwayGoals > result.HomeGoals
let finalResults = results |> List.filter isAwayWin |> List.countBy(fun result -> result.AwayTeam) |> List.sortByDescending(fun (_, awayWins) -> awayWins)


//Create an Array
let numbersArray = [|4; 4; 3; 4; 3; 4;|]
    //access an array
let num = numbersArray.[3]
    //pick a slice
let pickIndexes = numbersArray.[1..4]
    //mutate a value
numbersArray.[4] <- 4


//SELECT MANY example
//Many to Many relationships --- use collect to take a many to many reslationshp and flatten it into a single list of every item..
//> below is a useful reference for how to create list types...
type Order = { OrderId : int }
type Customer2 = {CustomerId : int; Orders: Order list; Town :string}
let customers2 : Customer2 list = []
let orders : Order list = customers2 |> List.collect(fun c -> c.Orders)


//Using Pairwise to work with relationshpis between adjacent items in the list... Consider researching windowed for doing this with more than 2 items
open System
open System.Data
[ DateTime(2010,5,1); DateTime(2010,6,1); DateTime(2010,6,12); DateTime(2010,7,3) ] |> List.pairwise |> List.map(fun (a, b) -> b - a) |> List.map(fun x -> x.TotalDays)




//
//(3.2) Grouping
//
type Cordinate = {X :int; Y: int}
let cordinatesXY = [{X = 5; Y = 6};
                    {X = 5; Y = 2};
                    {X = 5; Y = 3};
                    {X = 5; Y = 3}; ]

//groupBy, countBy, and partiion operation
let groupbyY = cordinatesXY |> List.groupBy(fun cord -> cord.X)
let groupbyX = cordinatesXY |> List.groupBy(fun cord -> cord.Y)

let countByY = cordinatesXY |> List.countBy(fun cord -> cord.Y)
let countByX = cordinatesXY |> List.countBy(fun cord -> cord.X)

let partitionY = cordinatesXY |> List.partition(fun cord -> cord.Y > 3 )
let partitionX = cordinatesXY |> List.partition(fun cord -> cord.Y = 2)


let result = ([{X = 5; Y = 6;}; {X = 5; Y = 2;}; {X = 5; Y = 3;}; {X = 5; Y = 3;}], [])



let inventory = ["Apples",0.33; "Oranges", 0.23; "Bananas", 0.45] |> Map.ofList
let cheapFruit, expensiveFruit = inventory |> Map.partition(fun fruit cost -> cost < 0.3)






////Using Fold To create custom aggregate functions
let sum inputs = 
    Seq.fold    
        (fun state input ->
            let newState = state + input
            printfn "Current state is %d, input is %d, new state is %d" state input newState
            newState)
        0
        inputs

sum[1 .. 6]


//Using Yield with Seq
let lines : string seq = 
    seq {
    use sr = new StreamReader(File.OpenRead @"test_doc.txt")
    while (not sr.EndOfStream) do
        yield sr.ReadLine() }
(0,lines) ||> Seq.fold(fun total line -> total + line.Length)


lines 
Environment.CurrentDirectory
    
    
    }




