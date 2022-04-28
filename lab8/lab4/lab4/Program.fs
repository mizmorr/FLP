open System

type IPrint = interface
    abstract member Print: unit->unit
    end
type Square(lenght:int)=
    member this.lenght 
        with get()=lenght
        and set(leng:int)=this.lenght<-leng
    override this.ToString()="Square:\n"+"Lenght: "+lenght.ToString()+"\nArea: "+(lenght*lenght).ToString()
    interface IPrint with
        override this.Print(): unit=Console.WriteLine(this.ToString())
type Rectangle(lenght:int,width:int) =
    member this.lenght 
        with get()=lenght
        and set(leng:int)=this.lenght<-leng
    member this.width 
        with get()=width
        and set(wt:int)=this.width<-wt
    override this.ToString()="Rectangle:\n"+"Lenght: "+lenght.ToString()+"\nWidth:"+width.ToString()+"\nArea: "+(width*lenght).ToString()
    interface  IPrint with
        override this.Print(): unit=Console.WriteLine(this.ToString())
type Round(radius:int) =
    member this.radius 
        with get()=radius
        and set(r:int)=this.radius<-r
    override this.ToString()="Round:\n"+"Radius: "+radius.ToString()+"\nArea: "+(2*int(Math.PI)*radius).ToString()
    interface  IPrint with
        override this.Print(): unit=Console.WriteLine(this.ToString())

    



    