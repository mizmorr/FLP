open System

let glasstr = "aeyuioAEYUIO" 

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

let Indicator (str:string) =
    let ngInd = del (NumGlas str) (str.Length)
    let nsInd = del(NumSoglass str) (str.Length)
    nsInd-ngInd

let SortString str =
    List.sortBy(Indicator) str

let readStrArr n =
    let rec rsa n res =
        match n with
        |0 -> res
        |_-> 
            let z =Console.ReadLine()
            rsa (n-1) (res@[z])
    rsa n []

let rec writeStr = function
    [] -> let z =Console.ReadKey()
          0
    |(h:string)::tail->
                                System.Console.WriteLine(h)
                                writeStr(tail)


[<EntryPoint>]
let main arg =
    let z=Convert.ToInt32(Console.ReadLine())
    writeStr (readStrArr z)
    writeStr(SortString (readStrArr z))
    
        