open System
open System.Globalization 
let rev str =
    StringInfo.ParseCombiningCharacters(str) 
    |> Array.rev
    |> Seq.map (fun i -> StringInfo.GetNextTextElement(str, i))
    |> String.concat ""
    
let IsPalindr (str:string) = rev str =str

let answerAgent = MailboxProcessor.Start(fun inbox->
    let rec messageLoop() = async{
// чтение сообщения
    let! msg = inbox.Receive()
    if IsPalindr msg then Console.WriteLine("Строка - палиндром - "+msg)
    elif String.forall(fun x ->Char.IsLetter x) msg then Console.WriteLine("Строка буквенная " + msg)
    else printfn "%s - В строке содержаться цифры/_" msg
    return! messageLoop()}
// запуск обработки сообщений
    messageLoop())

[<EntryPoint>]
let main arg =
    let f1= answerAgent.Post("123321")
    let f2 = answerAgent.Post("aqsdasdas")
    Console.WriteLine("{0} , {1}",f1,f2)
    0
  
  