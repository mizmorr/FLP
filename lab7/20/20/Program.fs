open System

let glasstr = "aeyuioAEYUIO" 

let readStrArr n =
    let rec rsa n res =
        match n with
        |0 -> res
        |_-> 
            let z = Console.ReadLine()
            rsa (n-1) (res@[z])
    rsa n []

let rec writeStr = function
    [] -> let z =Console.ReadKey()
          0
    |(h:string)::tail->
                                System.Console.WriteLine(h)
                                writeStr(tail)

let IsGLas a =
   String.length (glasstr|>String.filter(fun el -> el=a)) = 1

let IsSoglass a =
    (Char.IsLetter a)&&(IsGLas a=false)

let NumGlas (str:string) =
    (str|>String.filter(fun x ->IsGLas x)).Length
let NumSoglass (str:string) =
    (str|>String.filter(fun x ->IsSoglass x)).Length

let del (l1:int) (l2:int) =
    Convert.ToDouble(l1)/Convert.ToDouble(l2)

let IfStringSame (str:string) =
    Convert.ToChar(str.Substring(0,1))

let preitem (str:string) (num:int) =
    str.Substring(num,(str.Length-num))

let item (str:string) (num:int) =
    preitem str num|>IfStringSame

let Indicator (str:string) =
    let ngInd = del (NumGlas str) (str.Length)
    let nsInd = del(NumSoglass str) (str.Length)
    nsInd-ngInd

let SortString str =
    List.sortBy (Indicator) str
    
let makeTuple str =
    List.map(fun x ->(x ,Indicator x)) str

let sort str =
    List.sortBy(fun x -> snd x) (makeTuple str)

let IsTripleMirror (str:string) =
    if (item str 0 = item str 2&& item str 2<>item str 1)&&(Char.IsLetter (item str 0 ) = Char.IsLetter(item str 2)= Char.IsLetter(item str 1)) then true
    else false

let NumMirror (str:string) =
    let rec boom n num =
        match n with
        |n when n = str.Length-2 -> num
        |_->
            let testStr = str.Substring(n,3)
            if IsTripleMirror testStr then boom (n+1) (num+1)
            else boom (n+1) num
    boom 0 0 


let bring y str func =
    (List.filter (fun x -> func x=y) str).Head

let resSortList str  funcPred=
    let MakeNeedList = List.map (fun x -> (funcPred x)) str
    let reallymndList =List.sort MakeNeedList
    List.map (fun x-> bring x str funcPred) reallymndList

let SortByInd str =
    resSortList str Indicator

let SortByNumMirror str =
    resSortList str NumMirror

let present =
    Console.Write ("Выберите функцию из предложенных. Введите размерность массива, после введите строки.\n 1. Отсортировать строки в порядке увеличения разницы между средним количеством соглас-
ных и средним количеством гласных букв в строке\n2. Отсортировать строки в порядке увеличения среднего количества «зеркальных» троек (например, «ada») символов в строке.\n ")

let chooser num str =
    match num with
    |1->writeStr (SortByInd str)
    |2->writeStr (SortByNumMirror str)
    |_->0

[<EntryPoint>]
let main arg =
    present
    let z=Convert.ToInt32(Console.ReadLine())
    let prechooser = chooser z 
    let bomb =  readStrArr(Convert.ToInt32(Console.ReadLine()))|>prechooser
    if bomb =0 then printfn "%A" "we have  probroblems......"
    bomb
    0
   
    
        