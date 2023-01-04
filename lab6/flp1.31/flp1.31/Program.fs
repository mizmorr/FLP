open System
let rec readlist n =
    match n with
    |n when n=0 -> []
    |_->
        let Head = System.Convert.ToInt32(Console.ReadLine())
        let Tail = readlist (n-1)
        Head::Tail
let readData =
    let n =  System.Convert.ToInt32(Console.ReadLine())
    readlist n

let rec check (p:int->bool) list value =
    match list with
    |[]->value
    |h::t->
        if p h then check p t (value+1)
        else check p t value
let IsEven x = x%2=0
let NumbEven list =
    check IsEven list 0

[<EntryPoint>]
let main agr = 
    printfn "%A" (readData)
    printfn "%i" (NumbEven readData)
    0
    