open System
open System.Diagnostics
open System.Text.RegularExpressions


type Passport (name:string, surname:string, number:int, birthday:string, birthPlace:string, series:int) =
    member this.name 
        with get()=name 
        and set(testName:string) = 
                if (Regex.IsMatch(testName, @"[A-Za-z]"))
                then this.name<-testName
                else printfn "%s"("bad format")
    member this.surname 
                    with get()=surname
                    and set(testSn:string) =
                            if (Regex.IsMatch(testSn,@"[A-Za-z]"))
                            then this.surname<-testSn
                            else printfn "%s"("bad format")
    member this.number 
                   with get()= number
                   and set(testNumber:int) =
                           if (Regex.IsMatch(testNumber.ToString(),@"[0-9]{6}"))
                           then this.number<-testNumber
                           else printfn "%s"("bad format")
    member this.series 
                   with get()=series
                   and set(testSeries:int) =
                           if (Regex.IsMatch(testSeries|>string,@"[0-9]{4}"))
                           then this.series<-testSeries
                           else printfn "%s"("bad format")
    member this.birthday 
                   with get() = birthday
                   and set(testBday:string) =
                           if(Regex.IsMatch(testBday,@"[1-30]:[1-12]:[1900-2022]"))
                           then this.birthday<-testBday
                           else printfn "%s"("bad format")
    member this.birthPlace
                    with get() =birthPlace
                    and set(testbirthPlace:string) =
                            if (Regex.IsMatch(testbirthPlace,@"[A-Za-z]+"))
                            then this.birthPlace<-testbirthPlace
                            else printfn "%s"("bad format")
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
