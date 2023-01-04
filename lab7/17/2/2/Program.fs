open System

let rec readList n = 
    if n=0 then []
    else
    let Head = System.Convert.ToInt32(System.Console.ReadLine())
    let Tail = readList (n-1)
    Head::Tail

let readData = 
    let n=System.Convert.ToInt32(System.Console.ReadLine())
    readList n
    //second mthod
let firstlist list =
    let even, odds =list|>List.partition (fun x->x%2=0)
    List.map (fun x->x/2) even

let secondlist list= 
    List.map (fun x->x/3) (List.filter(fun x ->x%3=0) list)
    
let thirdlist list =
    let l =secondlist list
    List.map (fun x->x*x) l

let fourthlist list =
    let l1=firstlist list
    let l2 =thirdlist list
    List.filter(fun x->(List.exists(fun el->el=x) l1)) l2

let fifthlist list = 
    List.append(List.append (secondlist list) (thirdlist list)) (fourthlist list)

let tuple list =
   List.append (List.singleton (firstlist list)) (List .append (List.singleton(secondlist list)) (List .append (List.singleton(thirdlist list)) (List.append (List.singleton(fourthlist list )) (List.singleton (fifthlist list)))))
    
        


[<EntryPoint>]
let main arg =
    printfn "%A" (tuple readData)
    0