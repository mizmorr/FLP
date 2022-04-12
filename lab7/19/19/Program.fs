open System
open System.Globalization 

let rev str =
    StringInfo.ParseCombiningCharacters(str) 
    |> Array.rev
    |> Seq.map (fun i -> StringInfo.GetNextTextElement(str, i))
    |> String.concat ""

let IfStringSame (str:string) =
    Convert.ToChar(str.Substring(0,1))

let preitem (str:string) (num:int) =
    str.Substring(num,(str.Length-num))

let item (str:string) (num:int) =
    preitem str num|>IfStringSame


let IsPalindr (str:string) =
     if (str.Length%2<>0) then false
     else
        let fsthalf=str.Substring(0,(Convert.ToInt32(str.Length)/2))
        let sndhalf = rev (str.Substring((Convert.ToInt32(str.Length)/2),(Convert.ToInt32(str.Length)/2)))
        if (String.length (String.filter(fun el ->el = item sndhalf (fsthalf.IndexOf el)) fsthalf))=fsthalf.Length then true
        else false



let IsNotCont (str:string) a =
    (String.filter(fun i-> i=a)str).Length=0

let preNumNums (str:string) =
    let rec pnn (resstr:string) num =
        match num with
        |num when num =str.Length -> resstr
        |_->
            let ch =item str num
            if IsNotCont resstr ch then pnn (resstr+ch.ToString()) (num+1)
            else pnn resstr (num+1)
    pnn "" 0

let NumNums (str:string) =
    String.length(preNumNums str)

[<EntryPoint>]
let main arg =
    let z =Console.ReadLine()
    printfn "%s" (preNumNums z)
    0
   
