open System

//19.2
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

//19.1

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
                    let newSum = Incr x 
                    sSum a (acc+1) c newSum
                |_->sSum a (acc+1) c sum          
      sSum a 1 c 0
               
//19.3
