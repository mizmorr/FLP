open FParsec
open System

type Expr =
    | Num of float
    | Plus of Expr * Expr
    | Minus of Expr * Expr

let pstring_ws s = spaces >>. pstring s .>> spaces
let float_ws = spaces >>. pfloat .>> spaces
let parseExpression, implementation =
    createParserForwardedToRef<Expr, unit>()

let parsePlus = tuple2 (parseExpression .>> pstring_ws "+") parseExpression |>> Plus
let parseMinus = tuple2 (parseExpression .>> pstring_ws "-") parseExpression |>> Minus
let parseOp = between (pstring_ws "(") (pstring_ws ")") (attempt parsePlus <|> parseMinus)
let parseNum = float_ws |>> Num
implementation := parseNum <|> parseOp

let rec resExpr(e:Expr):float =
    match e with
    | Num(num) -> num
    | Plus(a,b) ->
        let L =
            match a with
            | Num(num) -> num
            | _ -> resExpr(a)
        let R =
            match b with
            | Num(num) -> num
            |_->resExpr(b)
        let res1 = L + R
        printfn "%f + %f = %f" L R res1
        res1
     |Minus(c,d) ->
            let L =
                match c with
                | Num(num) -> num
                | _ -> resExpr(c)
            let R =
                match d with
                |Num(num) -> num
                | _ -> resExpr(d)
            let res2 = L - R
            printfn "%f - %f = %f" L R res2
            res2

[<EntryPoint>]
let main arg =
    let testParser = run parseExpression "(4+((5-12)+(-7+4)))" //-6
    printfn "%A" testParser
    match testParser with
    |Success(result,_,_) ->
        let res=resExpr(result)
        Console.WriteLine("Результат вычислений - {0}",res)
        0
    |Failure(errorMsg,_,_) -> 
        printfn "Failure: %s" errorMsg 
        0