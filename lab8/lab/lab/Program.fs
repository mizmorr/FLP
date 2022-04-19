open System
open System.Diagnostics
open System.Text.RegularExpressions


type Passport ( name:string, surname:string, number:int, birthday:DateTime, birthPlace:string, series:int ) =
    member this.name =name
    member this.surname =surname 
    member this.number =number
    member this.series = series
    member this.birthday = birthday
    member this.birthPlace =birthPlace
    override this.Equals(a) =
        match a with    
        | :? Passport as p -> (p.number)=(this.number)&&(p.series)=(this.series)
        |_->false
    interface IComparable with
        member this.CompareTo obj =
            match obj with
            | :? Passport as passport -> 
                                                        this.series.CompareTo(passport.series)
                                                        this.number.CompareTo(passport.number)
            | _->1
    override this.ToString() = "name: "+this.name+"\n surname: "+this.surname+"\n number: "+this.number.ToString()+"\n series: "+this.series.ToString()+"\n birthday: "+this.birthday.ToString()+"\n birthplace: "+this.birthPlace
    override this.GetHashCode() = number.GetHashCode()+series.GetHashCode()

 

let PrintPassport (passport:Passport) =
    printfn " Passport:  \n %s" (passport.ToString())



[<EntryPoint>]
let main arg =
    let passport1=Passport("Ivan","Ivan",1 ,DateTime(5),"Ivan",2)
    PrintPassport passport1
    0
