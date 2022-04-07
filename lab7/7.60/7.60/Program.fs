open System


let rec readList n = 
    if n=0 then []
    else
    let Head = System.Convert.ToInt32(System.Console.ReadLine())
    let Tail = readList (n-1)
    Head::Tail

let readData = 
    let n=System.Convert.ToInt32(System.Console.ReadLine())
    readList n

//возвращает лист без одного эл-та значения num
let WithoutNum list num=
    List.removeAt (List.findIndex (fun x-> x=num) list) list

let ListIsOnly list =
    List.filter (fun x ->(List.exists(fun y->y=x)(WithoutNum list x))=false) list
    
let resList list=
    List.filter (fun x -> x%(List.findIndex(fun y ->y=x) list)=0) (ListIsOnly list)
    

