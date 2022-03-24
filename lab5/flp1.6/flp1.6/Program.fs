open System

let rec gcd x y =
    match y with
    |y when y=0 -> x 
    |_-> gcd y (x%y)

let IsCoprIntg x y = gcd x y = 1

let Euler a = 
    let rec eEuler a b (value:int) =
        match b with
        |b when b = 0 -> value 
        |_->
            let aValue = 
                match a with
                |a when IsCoprIntg a b -> value+1
                |_-> value
            let nB = b-1
            eEuler a nB aValue
    eEuler a (a-1) 0

[<EntryPoint>]
let main arg = 
    printfn"%i" (Euler 4)
    0
