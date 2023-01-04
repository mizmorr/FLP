open System


let dP d= d%10
let dS d =d/10
let IsNotMultiple3 d =d%3<>0
let rec max n a =
    match n with
    |n when dP n>a&&IsNotMultiple3 (dP n) -> max (dS n) (dP n)
    |n when n=0->a
    |n->max(dS n) a

let ObMax a =
    max a 0



let rec gcd x y =
    match y with
    |y when y=0 -> x 
    |_-> gcd y (x%y)

let IsNotCoprIntg x y = gcd x y <> 1
let IsMultiple2 x = x%2=0
let Incr x = x+1
let  sum a c = 
      let rec sSum a acc c sum=
            match acc with
            |acc when acc=c -> sum 
            |_-> 
                match acc with
                |acc when IsMultiple2 acc&&IsNotCoprIntg a acc&&a<>acc ->
                    let newSum = (Incr sum) 
                    sSum a (Incr acc) c newSum
                |_->sSum a (Incr acc) c sum          
      sSum a 1 c 0
               
let ddS x y =x%y
let IsMultiple x y = x%y=0
let IsNotMultiple x y =x%y<>0

let sum5 a =
    let rec sSum5 a value =
        match a with
        |a when a=0 ->value
        |_-> 
             let an= a%10 
             let aN=a/10
             let nValue=
                match an with
                |an when an<5->Incr value
                |_->value
             sSum5 aN nValue
    sSum5 a 0


let IsEasy a =
    let rec IseEasy a acc (value:bool) =
        match acc with
        |acc when acc=a/2 ->value
        |_->
                match acc with
                |acc when IsMultiple a acc -> IseEasy a (Incr acc) false
                |_->IseEasy a (Incr acc) value
    IseEasy a 2 true

let rec dDel a cuRn = 
        match cuRn with
        |cuRn when IsMultiple a cuRn -> cuRn
        |_-> 
               dDel  a (Incr cuRn) 
       
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
            |cuRn when IsNotCoprIntg a cuRn&&IsNotMultiple cuRn (miNdel a)->
                let nvalue = max value cuRn
                mMaxint a c (Incr cuRn) nvalue
            |_->mMaxint a c (Incr cuRn) value
    mMaxint a c 1 1

let resFunc a c = sum5 a * maXint a c


[<EntryPoint>]
let main agr = 
        printfn "%i" (maXint 24 250)
        0