open System
let rec rL n = 
    if n=0 then []
    else
    let h = System.Convert.ToInt32(System.Console.ReadLine())
    let t = rL (n-1)
    h::t

let readData = 
    let n=System.Convert.ToInt32(System.Console.ReadLine())
    rL n

let f50 list1 list2 =
    let nl1 =List.distinct list1
    let nl2=List.distinct list2
    List.append (List.filter(fun x->(List.exists (fun el ->el =x ) nl2)=false) nl1) (List.filter(fun x->(List.exists (fun el ->el =x ) nl1)=false) nl2) 

[<EntryPoint>]
let main arg =
    let y =readData
    let Y1=[3;3;6;7;8;2]  //example
    let Y=List.append y Y1
    let X= [2;5;6;2;3;4]  
    printfn "%A" (f50 Y X)
    0