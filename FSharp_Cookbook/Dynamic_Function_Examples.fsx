open System

type Rule = string -> bool * string
let rules : Rule list = 
    [fun text -> (text.Split ' ').Length = 3, "Must be three words"
     fun text -> text.Length <= 30, "Max length is 30 characters"
     fun text -> text |> Seq.filter Char.IsLetter |> Seq.forall Char.IsUpper, "All letters must be caps"]


let rule1 (text : string)  = 
         printfn "Running rule 1 - (three word rule)"
         (text.Split ' ').Length = 3,"Must be three words"

let rule2 (text : string) =
         printfn "Running rule 2 - (length check)"
         text.Length <= 30, "Max length is 30 characters"



let rule3 (text : string) =
        printfn "Running rule 3 (upper case check)"
        text |> Seq.filter Char.IsLetter |> Seq.forall Char.IsUpper, "All Caps"


let rules2 : Rule list = [rule1;rule2;rule3]



let validateText (rules2: Rule list) word = 
    let passed, error = rules.[0] word
    if not passed then false, error
    else
        let passed, error = rules.[1] word
        if not passed then false,error
        else
            let passed, error = rules.[2] word
            if not passed then false, error
            else true, ""
            
            

validateText rules " 234 `243234234EST TEST NO"

//The above if else logic is wayy to confusing, can we simplify this?
//here we go

let buildValidator (rules2 : Rule list) =
    rules2
    |> List.reduce(fun firstRule secondRule   -> fun word ->
                        let passed,error = firstRule word
                        if passed then
                            let passed, error = secondRule word
                            if passed then true, "" else false, error
                        else false, error)



()
                    

let validate = buildValidator rules2                
let word = "HELLO FrOM F#"
validate word                    
