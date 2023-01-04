open System
let rec gcd x y =
    match y with
    |y when y=0 -> x 
    |_-> gcd y (x%y)
let IsCoprIntg x y = gcd x y = 1

let CopInt (func:int->int->int)  a =  
    let rec cCopInt func a cuRn eValue = 
        match cuRn with
        |cuRn when cuRn = a -> eValue 
        |_-> 
            match cuRn with
            |cuRn when IsCoprIntg a cuRn ->
                let  nValue=func cuRn eValue
                cCopInt func a (cuRn+1)  nValue
             |_->cCopInt func a (cuRn+1)  eValue
    cCopInt func a 1  1

let sum a b = a+b 
let min a b= 
    match a with
    |a when a<b->a
    |_->b

let max a b = 
    match a with
    |a when a>b->a
    |_->b

[<EntryPointAttribute>]

let main arg=
    printfn "%i" (CopInt min 6) // for sum cCopInt func a 1  0
    0