open System
open System.Globalization 

let rev str =
    StringInfo.ParseCombiningCharacters(str) 
    |> Array.rev
    |> Seq.map (fun i -> StringInfo.GetNextTextElement(str, i))
    |> String.concat ""

let item (str:string) num=
    Convert.ToChar(str|>String.filter(fun x -> num=(str.IndexOf x))) 

let IsPalindr (str:string) =
     if (str.Length%2<>0) then false
     else
        let fsthalf=str.Substring(0,(Convert.ToInt32(str.Length)/2))
        let sndhalf = rev (str.Substring((Convert.ToInt32(str.Length)/2),(Convert.ToInt32(str.Length)/2)))
        if (String.length (String.filter(fun el ->el = item sndhalf (fsthalf.IndexOf el)) fsthalf))=fsthalf.Length then true
        else false

[<EntryPoint>]
let main arg =
    let z =Console.ReadLine()
    printfn"%A" (IsPalindr z)
    0
   
