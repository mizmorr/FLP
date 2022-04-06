open System
let f list numb =
    List.item numb list

let rec readlist n =
    match n with
    |n when n=0 -> []
    |_->
        let h = System.Convert.ToInt32(Console.ReadLine())
        let t = readlist (n-1)
        h::t
let readData =
    let n =  System.Convert.ToInt32(Console.ReadLine())
    readlist n

let isMax list a = a =List.max list
let f4 list numb = 
    let n =List.item numb list
    isMax (fst (List.splitAt 3 (List.skip (numb-1) list))) n

[<EntryPoint>]
let main arg =
    let list = readData
    let z=System.Convert.ToInt32(Console.ReadLine())
    printfn "%A" list
    printfn "%b" (f4 list z)
    0
    
