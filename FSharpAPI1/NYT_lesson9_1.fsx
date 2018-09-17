let parse(person:string) = 
    let seperated = person.Split(' ' )
    seperated.[0], seperated.[1],int(seperated.[2])

let myRecord = parse("Mary Asteroids 2900")
let a,b,c = myRecord
a
b
c


