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
let re list num a=
    List.insertAt num  a list


let retlist  list=
    let nlist=[for i in 1 .. List.max list->i]
    List.insertManyAt 0 nlist [] 
let reslist list =
    let nlist = List.sortDescending (List.distinct list)
    List.filter (fun x -> (List.contains x nlist)=false) (retlist list)
[<EntryPoint>]
let main arg =
    printfn "%A" (reslist readData)
    0