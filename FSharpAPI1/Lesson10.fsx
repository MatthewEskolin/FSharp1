let curriedAdd a b = a + b
let addFive = curriedAdd 5
let final = addFive 1232

//NYT pg129
let writeToFile (date:System.DateTime) filename text =
    let formattedDate = date.ToString("yyMMdd")
    let path = sprintf "%s-%s.txt" formattedDate filename
    System.IO.File.WriteAllText(path, text)
    "F"

let writeToToday = writeToFile System.DateTime.UtcNow.Date

writeToToday "test" "testText" 

let checkCreation (date:System.DateTime) = 
    date 

let ccda =
    System.IO.Directory.GetCurrentDirectory()
    |> System.IO.Directory.GetCreationTime
    |>  checkCreation

let result = ccda

