module Program
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
let rec check (func:int->int->int) list value =
    match list with
    |[]->value
    |h::t->
        let newvalue = func value h
        check func t newvalue
let max a b =
    match a with
    |a when a>b->a
    |_->b
let ListMax list =
    match list with
    |[]->0
    |h::t ->
        check max list h
let ListWithoutNum list num =
    let rec lwn list reslist = 
        match list with
        |[]->reslist
        |h::t ->
            if h<>num then lwn t (h::reslist)
            else lwn t reslist
    lwn list []
let ListWithoutMax list =
    ListWithoutNum list (ListMax list)
let SndMax list = 
    ListMax(ListWithoutMax list)

