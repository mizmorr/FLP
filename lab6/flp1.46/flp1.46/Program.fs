open System
let mm a b =
    match a with
    |a when a>b -> b
    |_-> a
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
let rec listSum list1 list2=
    match list1 with
    |[] ->list2
    |h::t ->listSum t (h::list2)

let relist list =
    let rec rl list list1 list2=
        match list with
        |[] ->listSum list1 list2
        |h::t ->    
                if h>=0 then rl t (h::list1) list2
                else rl t list1 (h::list2)
    rl list [] []

[<EntryPoint>]
let main arg = 
    printfn "%A" (readData)
    printfn "%A" (relist readData)
    0

