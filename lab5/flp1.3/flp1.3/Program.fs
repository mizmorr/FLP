open System

let rec max sss a =
    match sss with
    |sss when (sss%10)>a-> max (sss/10) (sss%10)
    |sss when sss=0->a
    |sss->max(sss/10) a

let rec kolvo a acc =
    match a with
    |a when (a%10=5) -> kolvo (a/10) acc+1
    |a when a=0->acc
    |a-> kolvo (a/10) acc
let mmax d =
    max d 0
let kkolvo a=
    kolvo a 0
let asd d =
    d+1
let rec min a acc=
    match a with
    |a when a=0->acc
    |a when (a%10)<acc -> min (a/10) (a%10)
    |a->min (a/10) acc
let mmin d=
    min d d%10
let rec mult a=
    match a with
    |a when a=1->1
    |a->a%10*mult(a/10)
//let rec min a =
//    match a with
//    |

[<EntryPoint>]
let main argv =
    printfn "%A" (mult 122)
    System.Console.ReadKey()
    0
