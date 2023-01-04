open System
let readline =  
    printfn"%s" ("what is your favorite programming language?")
    System.Console.ReadLine()

let func1 a =
    match a with
    |a when a ="Prolog" ->"sneaky"
    |a when a ="F#"->"You are podliza"
    |"Python" ->"-rep"
    |"C" ->"+rep"
    | _ ->"idk"

let writedata =
    printf "%s"(func1 readline)

[<EntryPoint>]
let main argv =
    writedata
    0 