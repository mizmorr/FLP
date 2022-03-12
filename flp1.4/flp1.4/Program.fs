
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
    match a with
    |a when a>0 ->
        match acc with
        |acc when a%acc=0-> acc+ del a acc-1
        |acc->