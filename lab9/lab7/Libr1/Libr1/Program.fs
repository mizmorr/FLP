module Program
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
let IsPalindr (str:string) = rev str =str
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
let NumWords (str:string) =
    (str|>String.filter(fun x ->Char.IsSeparator x)).Length+1
let chooser (str:string) (num:int) =
    match num with
        |1-> System.Convert.ToInt32(IsPalindr str)
        |2->NumWords str
        |3-> NumNums str
        |_->0

   
