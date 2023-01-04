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

let IsEasy (a:int) =
    let rec IseEasy a acc (value:bool) =
        match acc with
        |acc when acc=a/2 ->value
        |_->
                match acc with
                |acc when a%acc=0 -> IseEasy a (acc+1) false
                |_->IseEasy a (acc+1) value
    IseEasy a 2 true


let rec dDel a cuRn = 
        match cuRn with
        |cuRn when a%cuRn=0 -> cuRn
        |_-> 
               dDel  a (cuRn+1) 
       
let min a b= 
    match a with
    |a when a<b->a
    |_->b

let max a b =
        match b with
        |b when b<a->a
        |_->b
    
let miNdel a = 
    match a with
    |a when IsEasy a ->1
    |_->dDel a 2

let maXint a c =
    let rec mMaxint a c cuRn value = 
        match cuRn with
        |cuRn when cuRn=c -> value
        |_-> 
            match cuRn with
            |cuRn when IsNotCoprIntg a cuRn&&cuRn%(miNdel a)<>0->
                let nvalue = max value cuRn
                mMaxint a c (cuRn+1) nvalue
            |_->mMaxint a c (cuRn+1) value
    mMaxint a c 1 1

let resFunc a c = sum5 a * maXint a c

[<EntryPoint>]

let main func = 
    printfn "%i" (resFunc 24 250)
    0

