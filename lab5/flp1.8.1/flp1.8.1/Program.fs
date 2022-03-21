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
               
    

[<EntryPointAttribute>]

let main agr =
    printfn "%i" (sum 8 10) //count NotCoprInt [0, 10] with 8
    0
    