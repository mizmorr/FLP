module Program
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
let max a b =
    match a with
    |a when a>b->a
    |_->b

let ListMax list =
    match list with
    |[]->0
    |h::t ->
        check max list h

let reverse (list:int list) =
    let rec r (list:int list) (list1:int list) =
        match list with
        |[] ->list1
        |h::t -> 
            let newlist1 = h::list1
            r t newlist1
    r list []

let centralpiece list =
    let min=listMin(list)
    let max=ListMax(list)
    let rec prl list list1 pointer= 
        match list with
        |[]->list1
        |h::t ->
           match pointer with
            |0 -> 
                    if h<>min then prl t list1 0
                    else prl t list1 1
           
            |1 -> if h<>max then prl t (h::list1) 1
                    else prl t list1 2
            |2-> prl t list1 pointer
    prl list [] 0
let firstpiece list =
    let min=listMin(list)
    let rec fp list list1 pointer =
        match list with
        |[]->list1
        |h::t->
            match pointer with
            |0 -> if h<>min then fp t (h::list1) pointer
                     else fp t (h::list1) 1
            |1-> fp t list1 pointer
    fp list [] 0

let thirdpiece list =
    let max=ListMax(list)
    let rec tp list list1 pointer =
        match list with
        |[]->list1
        |h::t ->
                match pointer with 
                |0 -> if h<>max then tp t list1 pointer
                         else tp t (h::list1) 1
                |1->tp t (h::list1) pointer
    tp list [] 0
     
let rec pluslist list list2 = 
    match list with
    |[] ->list2
    |h::t ->pluslist t (h::list2)
let MakeResList list=
    let list1=firstpiece(list)
    let list2=centralpiece(list)
    let list3=reverse(thirdpiece(list))
    pluslist (pluslist list2 list1) list3
