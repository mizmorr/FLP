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

let resslist list a b=
    let rec rl list reslist pointer =
        match list with
        |[]->reslist
        |h::t->
            match pointer with
            |0-> if h<>a then rl t reslist pointer
                    else rl t reslist 1
            |1->if h<>b then rl t (h::reslist) pointer
                    else rl t reslist 2
            |_->rl t reslist pointer
    rl list [] 0

[<EntryPoint>]
let main arg = 
    printfn "%A" (readData)
    printfn "%A" (resslist readData 4 5)
    0
    