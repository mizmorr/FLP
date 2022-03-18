
let sum a b =
    a+b

let mult a b =
    a*b

//let del a func acc =
//    match a with
//    |acc when acc<sqrt(a) -> 
//        match acc with
//        |acc when 


let rec  del a acc =
    match acc with
    |acc when acc>0 -> 
      match acc with  
        |acc when a%acc=0 -> acc + del a acc-1
        |acc -> del a acc-1
    |acc-> 0


//let rec ddel a ac1 =
//    let d = sqrt(a)
//    match a with
//    |a when System.Convert.ToDouble(a)%10=2

let rec ddel a ac =
    match ac with
    |ac when ac<sqrt(a) ->
        match ac with   
        |ac when System.Convert.ToDouble(a)%ac=0 -> System.Convert.ToDouble(ac) +ddel a ac+1


let sda d =
    del d d-1

[<EntryPointAttribute>]

let main arg = 
    printf"%d" (sda 6)
    0