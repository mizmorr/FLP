module Library.Program
open System


let rec gcd x y =
    match y with
    |y when y=0 -> x 
    |_-> gcd y (x%y)
let IsNotCoprIntg x y = gcd x y <> 1
let  sum a c = 
      let rec sSum a acc c sum=
            match acc with
            |acc when acc=c -> sum 
            |_-> 
                match acc with
                |acc when acc%2=0&&IsNotCoprIntg a acc = true&&a<>acc ->
                    let newSum = sum + 1 
                    sSum a (acc+1) c newSum
                |_->sSum a (acc+1) c sum          
      sSum a 1 c 0



let rec max d a =
    match d with
    |d when (d%10)>a&&(d%10)%3<>0 -> max (d/10) (d%10)
    |d when d=0->a
    |d->max(d/10) a

let obmax a =
    max a 0



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

let chooseFunc n a =
        match n with
        |1->sum a 200
        |2->obmax a
        |3->resFunc a 240
        |_->0





    
            
  
   