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


let f10 list1 list2  = List.length (List.filter (fun x -> (List.exists (fun el -> el = x) list1)) list2)
    

[<EntryPoint>]

let main arg =
    let i1=[1;5;4]
    printfn "%A" (f10 i1 readData)
    0
    