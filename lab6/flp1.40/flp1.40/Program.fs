open System
let min a b =
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

let rec listCheck list (pred:int->bool) (func:int->int->int) (value:int) (acc:int) pointer=
        match list with
        |[]->value
        |h::t -> 
                  if pred h<>true&&pointer=0 then listCheck t pred func value h pointer
                  else
                    if pred h&&value=0 then listCheck t pred func h h 1
                    else 
                        if pred h&&pointer=1 then listCheck t pred func (func acc  h) h pointer
                        else listCheck t pred func value h pointer
                

let isEven x = x%2=0

let MinEvenList list =
    match list with
    |[]->0
    |h::t ->
        listCheck list isEven min 0 h 0


//let EvenList list =
//    let rec el list list1 =
//        match list with
//        |[]->list1
//        |h::t-> if isEven h then el t (h::list1)
//                   else el t list1
//    el list []

[<EntryPoint>]

let main arg = 
    printfn "%A" (readData)
    printfn "%i" (MinEvenList readData)
    0