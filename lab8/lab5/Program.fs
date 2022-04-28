open System
type Maybe<'a> =
    |Just of 'a
    |Nothing
let funcMaybe f p =
    match p with
    |Just a -> Just (f a)
    |Nothing->Nothing

let ApplyMaybe l p =
    match l,p with
    |Just f,Just a -> Just(f a)
    |_-> Nothing

let Monade p func =
    match p with    
    |Just a -> func a
    |Nothing->Nothing

[<EntryPoint>]
let main arg =
    //1.1 law    
    let id x =x
    let f =funcMaybe id (Just 1)
    Console.WriteLine(f)
    let ff = funcMaybe (fun x -> x) (Just 1)
    Console.WriteLine(ff)
    //2.1 law
    let func_x x =x+1
    let f2 = funcMaybe (fun x -> x+1) (Just 1)
    Console.WriteLine(f2)
    let ff2=funcMaybe func_x (Just 1)
    Console.WriteLine(ff2)
    
    //2.1 law
    Console.WriteLine(id (ApplyMaybe(Just(fun x->x+1))(Just 1)))

    //2.2 law 
    let app_x=1
    let app_y=ApplyMaybe (Just func_x) (Just app_x) 
    Console.WriteLine(app_y)
    //2.3 - law нельзя проверить, т.к. порядок аргументов важен
    0
