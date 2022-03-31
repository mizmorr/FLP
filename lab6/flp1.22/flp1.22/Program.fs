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
let rec check (func:int->int->int) list value =
    match list with
    |[]->value
    |h::t->
        let newvalue = func value h
        check func t newvalue
let listMin list = 
    match list with 
    |[] -> 0
    |h::t ->
        check mm list h

let num list a b =
    let min=listMin(list)
    let rec nNum list num pointer=
        match list with
        |[] ->num
        |h::t->
            match pointer with
            |0-> if h<>a then nNum t num pointer
                    else 
                        if h=min then nNum t (num+1) 1
                        else nNum t num 1
            |1-> match h with
                    |h when h=min ->nNum t (num+1) pointer
                    |h when h = b-> if h=min then nNum t (num+1) 2
                                               else  nNum t num 2
                    |_->nNum t num pointer
            |2-> nNum t num pointer
    nNum list 0 0 
       
[<EntryPoint>]
let main arg =
    printfn "%A" (readData)
    let a =System.Convert.ToInt32(Console.ReadLine())
    let b = System.Convert.ToInt32(Console.ReadLine())
    printfn "%i" (num readData a b)
    0
    