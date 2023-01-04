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
type Circle(radius:int) =
    member this.radius 
        with get()=radius
        and set(r:int)=this.radius<-r
    override this.ToString()="Round:\n"+"Radius: "+radius.ToString()+"\nArea: "+(int(sqrt(Math.PI))*radius).ToString()
    interface  IPrint with
        override this.Print(): unit=Console.WriteLine(this.ToString())

    
//p2

type GeometryFigure = 
    |Square of int
    |Rectangle of int*int
    |Circle of int

let chooser (leng:int) (width:int) (num:int) = 
    match num  with
    |1->Square leng
    |2->Rectangle(leng,width)
    |3->Circle leng

let Area l w num =
    let figure = chooser l w num
    let area =
        match figure with
        |Square(a) -> a*a
        |Rectangle(w,l) ->w*l
        |Circle(r) -> int(sqrt(Math.PI))*r
    area
    
[<EntryPoint>]
let main arg = 
    printf "%i" (Area 2 2 1)
    0


    