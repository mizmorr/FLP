open System

let rec gcd x y =
    match y with
    |y when y=0 -> x 
    |_-> gcd y (x%y)
let IsCoprIntg x y = gcd x y = 1

let CopInt (func:int->int->int)  a (cond:int->bool)=  
    let rec cCopInt func a cuRn eValue (cond:int->bool)= 
        match cuRn with
        |cuRn when cuRn = a -> eValue 
        |_-> 
            match cuRn with
            |cuRn when IsCoprIntg a cuRn&&cond cuRn->
                let  nValue=func cuRn eValue
                cCopInt func a (cuRn+1)  nValue cond
             |_->cCopInt func a (cuRn+1)  eValue cond
    cCopInt func a 1  1 cond

    //Examples of conditions:
let cond1 x= x>5
let cond2 x = x%2
    //Examples of functions
let sum a b = a+b
let mul a b =a*b
let min a b= 
        match a with
        |a when a<b->a
        |_->b
let max a b = 
        match a with
        |a when a>b->a
        |_->b

let del (func:int->int->int)  a (cond:int->bool) =  
            let rec dDel func a cuRn eValue (cond:int->bool) = 
                match cuRn with
                |cuRn when cuRn = a -> eValue 
                |_-> 
                    match cuRn with
                    |cuRn when a%cuRn=0&&cond cuRn ->
                        let  nValue=func cuRn eValue
                        dDel func a (cuRn+1)  nValue cond
                     |_->dDel func a (cuRn+1)  eValue cond
            dDel func a 1  1 cond
[<EntryPoint>]
let main arg = 
    printfn "%i" (del mul 6 cond1)
    0