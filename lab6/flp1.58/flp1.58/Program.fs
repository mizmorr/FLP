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
    
let backlistWithoutNum list b =
  let rec blwn list list1= 
    match list with
    |[] -> list1
    |h::t ->
        if h<>b then blwn t (h::list1)
        else blwn t list1
  blwn list []
let sum a b = a+b

let Sum list a=
    let rec s list list1=
        match list with
        |[] ->list1
        |h::t->
            if a<>0 then
                s t ((sum a h)::list1)
            else s t list1
    s list []
let rec pluslist list1 list2 =
    match list1 with
    |[] ->list2
    |h::t -> pluslist  t (h::list2)

let AllSumListWithoutNum list b=
    let rec asl list list1  =
        match list with
        |[]-> list1
        |h::t ->  if h<>b then
                    let Newlist =Sum (backlistWithoutNum list h) h
                    asl t (pluslist list1 Newlist)
                  else asl t list1
    asl list []

let rec IssExist list a pointer=
    match list with
    |[]->pointer
    |h::t->
        if h=a then IssExist t a true
        else IssExist t a pointer
let IsExist list a =
    IssExist list a false

let ResNum list =
    let rec rn list value =
        match list with
        |[]-> value
        |h::t->
            if IsExist(AllSumListWithoutNum list h) h then rn t (value+1)
                else 
                    rn t value
    rn list 0

    
[<EntryPoint>]
let main arg =
    printfn"%A" (readData)
    printfn"%A" (AllSumListWithoutNum readData 3)
    0

