module Program
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
let sum a b = a+b 
let min a b= 
    match a with
    |a when a<b->a
    |_->b
let max a b = 
    match a with
    |a when a>b->a
    |_->b
let mult a b = a*b
let chooser a n =
    match n with
    |1-> del sum a 
    |2->del mult a
    |3->del max a
    |4->del min a
    |_->0