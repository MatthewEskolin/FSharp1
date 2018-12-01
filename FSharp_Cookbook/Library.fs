//I have been learning F# using the book "Get Programming with F# - A Guide for .NET developers" by Issac Abraham
//This project will contain the most important pieces of code aquired through my learning process, things that will best help me retain my knowledge.
//This project should be a reference guide for how to do things in F#

module FSharp_Cookbook.Core 


open System.IO
open System.Collections.Generic



open System.Collections.Generic
open System


//(1) String Functions


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



//(2) Misc. Features

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
open System
open System.Net

let webclient = new WebClient()
let fsharpOrg = webclient.DownloadString(Uri "http://fsharp.org")

//Type Inference Example
let createList(first, second) = 
    let output = List()
    output.Add(first)
    output.Add(second)
    output




