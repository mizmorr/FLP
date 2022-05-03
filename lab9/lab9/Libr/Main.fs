module Design.Main
open System
open System.Windows.Forms
open System.Drawing
[<EntryPoint; STAThread>]
let main argv =
    Application.EnableVisualStyles()
    Application.SetCompatibleTextRenderingDefault(false)
    use form = new StartForm()
    let btn1=new Button(Text="Все элементы четные?", Left=125,Top=80,Height=65,Width=95)
    let btn2=new Button(Text="Является ли 6-ой элемент простым?",Left=125,Top=180,Height=65,Width=95)
    let btn3= new Button(Text="Является ли 3-ий элемент совершенным?",Left=125,Top=280,Height=65,Width=95)
    let lab1=new Label(Left=325,Top=100,Width=100,Height=50)
    let lab2=new Label(Left=325,Top=200,Width=100,Height=50)
    let lab3=new Label(Left=325,Top=300,Width=100,Height=50)
    let listtext=new RichTextBox(Text="\t\tInput list here!", Left=125,Top=20,Height=25,Width=225)
    listtext.Click.Add(fun (e:EventArgs)->
        let s=""
        listtext.Text<-s)
    btn1.Click.Add(fun (e:EventArgs)->

        let l=List.map System.Int32.Parse  (Seq.toList (listtext.Text.Split(' ')))
        let b = List.forall(fun e -> e%2=0) l
        lab1.Text<-b.ToString()
        )
    btn2.Click.Add(fun (e:EventArgs)->

        let IsEasy (a:int) =
            let rec IseEasy a acc (value:bool) =
                match acc with
                |acc when acc=a ->value
                |_->
                    match acc with
                    |acc when a%acc=0 -> IseEasy a (acc+1) false
                    |_->IseEasy a (acc+1) value
            IseEasy a 2 true
        let l=List.map System.Int32.Parse  (Seq.toList (listtext.Text.Split(' ')))
        if (l.Length<7) then lab2.Text<-"Элемент не найден"
        else 
            let b=IsEasy(List.item 6 l)
            lab2.Text<-b.ToString()
        )
    btn3.Click.Add(fun (e:EventArgs)->

        let l=List.map System.Int32.Parse  (Seq.toList (listtext.Text.Split(' ')))
        let del (func:int->int->int)  a =  
            let rec dDel func a cuRn eValue = 
                match cuRn with
                |cuRn when cuRn = a -> eValue 
                |_-> 
                    match cuRn with
                    |cuRn when a%cuRn=0 ->
                        let  nValue=func cuRn eValue
                        dDel func a (cuRn+1)  nValue
                    |_->dDel func a (cuRn+1)  eValue
            dDel func a 1  1
        let IsSoversh a =
            (del (fun x y ->x+y) a )=a
        if (l.Length<4) then lab3.Text<-"Элемент не найден"
        else
            let b =IsSoversh(List.item 3 l)
            lab3.Text<-b.ToString()
        )
    form.Controls.Add(btn1)
    form.Controls.Add(btn2)
    form.Controls.Add(btn3)
    form.Controls.Add(lab1)
    form.Controls.Add(lab2)
    form.Controls.Add(lab3)
    form.Controls.Add(listtext)
    Application.Run(form)    
    0 