open System.IO

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
    
countWords("test test1 test2 test3")
