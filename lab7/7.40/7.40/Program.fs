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


let f40 list= List.min (List.filter(fun x->x%2=0) list)
    

[<EntryPoint>]
let main arg =
    let list = readData
    printfn "%A" list
    printfn"Min even - %i" (f40 list)
    0