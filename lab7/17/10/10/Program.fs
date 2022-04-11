open System

let rec readlist n =
    match n with
    |n when n=0 -> []
    |_->
        let Head = System.Convert.ToInt32(Console.ReadLine())
        let Tail = readlist (n-1)
        Head::Tail
let readData =
    let n =  System.Convert.ToInt32(Console.ReadLine())
    readlist n
    
let listWithout list n =
        List.filter(fun x -> x<>n) list

let listAllpairs list =List.filter (fun x->(fst x) <>(snd x)) (List.allPairs list list)

let tuplemult (x,y)=x*y

let tuplesum (x,y)=x+y


let AllPairsFuncWoutN list (n:int) (func:int*int->int)= 
   let nlist = listWithout list n
   let lap = listAllpairs nlist
   List.distinct (List.map (fun x -> func x) lap) 

let IsCont list a =
    (List.tryFind (fun x->x=a) list)<>None

let List2 list =
    List.map(fun x->List.findIndex (fun el->el=x) list) (List.filter(fun x-> IsCont (AllPairsFuncWoutN list x tuplemult) x) list)


let List4 list =
    let prelist4=List.filter(fun x-> List.length(List.filter(fun el -> x%el=0)(listWithout list x))=4) list 
    List.map(fun x->List.findIndex (fun el->el=x) list) prelist4



let ListMakeTripleSumWoutN list n=
    let nlist =listWithout list n
    let length = List.length (List.map (fun x-> (List.map(fun el-> tuplesum el) (List.allPairs (x::[]) (AllPairsFuncWoutN (nlist) x tuplesum)))) nlist)
    let rec lmt lengh reslist =
        match lengh with
        |lengh when lengh = length ->List.distinct reslist
        |_->
            let newlist = (List.append reslist (List.item lengh (List.map (fun x-> List.map(fun x-> tuplesum x) (List.allPairs (x::[]) (AllPairsFuncWoutN (nlist) x tuplesum))) nlist)))
            lmt (lengh+1) newlist
    lmt 0 []

let List3 list =
    let prelist3 = List.filter(fun x -> IsCont (ListMakeTripleSumWoutN list x) x) list
    List.map(fun x->List.findIndex (fun el->el=x) list) prelist3 


let reslist list =
    List.append (List.singleton(List2 list))(List.append (List.singleton(List3 list))(List.singleton(List4 list)))

[<EntryPoint>]
let main arg =
    printfn "%A" (reslist readData)
    0