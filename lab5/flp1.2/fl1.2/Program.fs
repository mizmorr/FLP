open System
let func1  a =
    match a with
    |a when a ="Prolog" -> "sneaky"
    |a when a ="F#"-> "You are podliza"
    |"Python" ->   "-rep"
    |"C" ->  "+rep"
    | _ -> "idk"

let write a   =
    printfn "%A" a 

let  ob = 
    printfn "%s"("fav lang?") 
    Console.ReadLine()
 
//let main = 
//    let ffunc=func1>>write
//    ffunc ob

//let main  =
//    let ffunc a = write(func1 a)
//    ffunc ob

    
    