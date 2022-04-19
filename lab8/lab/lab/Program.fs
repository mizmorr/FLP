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

[<AbstractClass>]
type DocumentaryCollection() = abstract member searchDocument:Passport->bool

type PassportList(pl: Passport list) =
        inherit DocumentaryCollection()
        member this.list: (Passport list) =pl
        override this.searchDocument(passport:Passport) =
            List.length(this.list|>List.filter(fun x-> x=passport))>0

type PassportArray(pa: Passport array) =
        inherit DocumentaryCollection()
        member this.array: (Passport array) =pa 
        override this.searchDocument(passport:Passport) =
            Array.length(this.array|>Array.filter(fun u->u=passport))>0

type PassportSet(ps: Passport list) =
        inherit DocumentaryCollection()
        member this.set: (Set<Passport>) = Set.ofList ps
        override this.searchDocument(passport:Passport) =
            this.set|>Set.contains passport

type PassportBinaryList(pbs: Passport list) =
        inherit DocumentaryCollection()
        let BinarySearch(pl:Passport list) (p:Passport) =
            let rec bsrec fpos lpos =
                  if fpos > lpos then false
                        else
                        let mid = (fpos + lpos) / 2
                        if p < pl.[mid] then bsrec fpos (mid-1)
                        elif p > pl.[mid] then bsrec (mid+1) lpos
                        else true
            bsrec 0 (pl.Length-1)
        member this.list:(Passport list)=List.sortBy(fun x->x.number) pbs
        override this.searchDocument(passport:Passport) =
            BinarySearch this.list passport


[<EntryPoint>]
let main arg =
    0
