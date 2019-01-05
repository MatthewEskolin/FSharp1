open System.IO
open System.Collections.Generic




// Listing 15.6
let numbers = [ 1; 2; 30; 4; 5; 6 ]
let numbersQuick = [ 1 .. 6 ]
let head :: tail = numbers
let moreNumbers = 0 :: numbers
let evenMoreNumbers = moreNumbers @ [ 7 .. 9 ]




[ "Matthew", 34; "John", 33; "Tommy K", 42] |> List.map(fun (name, age) -> (age,name))
