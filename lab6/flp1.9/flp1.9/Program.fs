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

let reverse (list:int list) =
    let rec r (list:int list) (list1:int list) =
        match list with
        |[] ->list1
        |h::t -> 
            let newlist1 = h::list1
            r t newlist1
    r list []

let numb list n =
    let rec nu list n numb = 
        match list with
        |[]->numb
        |h::t ->
            match h with
            |h when h=n -> nu t n (numb+1)
            |_->nu t n numb
    nu list n 0

let NumbMin list =
    numb list (listMin(list))
            
let PreResList list acc numb=
    let rec prl list acc numb list1 numb1=
        match list with
        |[] ->list1
        |h::t ->
            match numb1 with
            |numb1 when numb1<numb ->
                     if numb1=numb-1&& h=acc then prl t acc numb list1 (numb1+1)
                     else
                        match h with
                        |h when h=acc -> prl t acc numb (h::list1) (numb1+1)
                        |_->prl t acc numb (h::list1) numb1
             |_-> prl t acc numb list1 numb1
    prl list acc numb [] 0
let resList list =
    PreResList list (listMin(list)) (NumbMin(list))
        
            
[<EntryPoint>] 
let main argv =
    printfn "%A" (readData)
    printfn "%A" (reverse(resList(readData)))
    0

    