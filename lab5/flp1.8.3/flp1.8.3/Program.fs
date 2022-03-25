open System

let sum5 a =
    let rec sSum5 a value =
        match a with
        |a when a=0 ->value
        |_-> 
             let an= a%10 
             let aN=a/10
             let nValue=
                match an with
                |an when an<5->value+1
                |_->value
             sSum5 aN nValue
    sSum5 a 0

let rec gcd x y =
    match y with
    |y when y=0 -> x 
    |_-> gcd y (x%y)
let IsNotCoprIntg x y = gcd x y <> 1

let del (func:int->int->int)  a =  
    let rec dDel func a cuRn eValue = 
        match cuRn with
        |cuRn when cuRn = a -> eValue 
        |_-> 
            match cuRn with
            |cuRn when a%cuRn=0 ->
                let  nValue=func cuRn eValue
                dDel func a (cuRn+1)  nValue
             |_->dDel func a (cuRn+1)  eValue
    dDel func a 1  1

let min a b= 
    match a with
    |a when a<b->a
    |_->b

let max a b =
        match b with
        |b when b<a->a
        |_->b
    
let mindel a =
    del min a

let maxint a c =
    let rec mMaxint a c cuRn value = 
        match cuRn with
        |cuRn when cuRn=c -> value
        |_-> 
            match cuRn with
            |cuRn when IsNotCoprIntg a cuRn&&cuRn%mindel a<>0 ->
                let nvalue = max value cuRn
                mMaxint a c (cuRn+1) nvalue
            |_->mMaxint a c (cuRn+1) value
    mMaxint a c 1 1

let resFunc a c = sum5 a * maxint a c

[<EntryPoint>]

let main func = 
    printfn "%i" (resFunc 35 200)
    0

