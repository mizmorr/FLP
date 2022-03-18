open System
let func1  a =
    printfn "%s"("fav lang?") 
    match a with
    |a when a ="Prolog" -> "sneaky"
    |a when a ="F#"-> "You are podliza"
    |"Python" ->   "-rep"
    |"C" ->  "+rep"
    | _ -> "idk"

let write a   =
    printfn "%A" a 

let  ob = Console.ReadLine()
    
[<EntryPoint>]

let main func  =  
    let fff a =
        match a with
        |a when System.String.IsNullOrEmpty(a.ToString())=false -> write(func1 a)
        |_ -> ( )
    fff ob
0

//let main func  =
//    let func2 a  = 
//         a+5
//    func2 5


    