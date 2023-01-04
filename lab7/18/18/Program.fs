// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from F#"

open System

let readArray n=
    let rec rA n ar =
        match n with
        |n when n=0 -> ar
        |_->
            let t =System.Convert.ToInt32(Console.ReadLine())
            let newar = Array.append ar [|t|]
            rA (n-1) newar
    rA n Array.empty
let readData =
    let n =System.Convert.ToInt32(Console.ReadLine())
    readArray n

let itd (a:int) = (System.Convert.ToDouble a)

let compILTN (a:double) =
    if Seq.head(a.ToString()) ='-' then true
    else false

let prEres polyn =
    if Array.length polyn<>3 then None
    else
    let a =itd (Array.get polyn 2)
    let b =itd(Array.get polyn 1)
    let c =itd(Array.get polyn 0)
    let d =b*b-4.0*a*c
    if (compILTN d) then None
    else Some(((-b+sqrt(d))/2.0*a),((-b-sqrt(d))/2.0*a)) 
let res polyn =
    printfn "%s" ((prEres polyn).ToString())