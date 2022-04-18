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
        | :? Passport as p -> (p.number)=(this.number)
        |_->false

    override this.ToString() = "name: "+this.name+"\n surname:  " + this.surname+"\n number:  "+this.number.ToString()+"\n series: "+ this.series.ToString()+ "\n birthday: "+this.birthday.ToString()+"\n birthplace: "+this.birthPlace
    override this.GetHashCode() = number.GetHashCode()+series.GetHashCode()
