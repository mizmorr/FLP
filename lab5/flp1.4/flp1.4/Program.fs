open System

let rec del (func:int->int->int)  a acc =  
    let z = acc
    match acc with
    |acc when acc<a ->
        match acc with
        |acc when a%acc=0 ->
            func acc z
            del func a (acc+1)
        |_->del func a (acc+1)


let print a b = 
    printfn "%i" (a)
    printfn "%i" (b)
let s a b = a+b 
[<EntryPointAttribute>]
let main arg =
    printfn "%i " (del s 6 1)
    0