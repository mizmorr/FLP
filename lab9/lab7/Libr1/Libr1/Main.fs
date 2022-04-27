module Design.Main
open System
open Program
open System.Windows.Forms
open System.Drawing
[<EntryPoint; STAThread>]
let main argv =
    Application.EnableVisualStyles()
    Application.SetCompatibleTextRenderingDefault(false)
    use form = new StartForm()
    form.Text<-"Ssstring"
    let text= new RichTextBox(ForeColor=Color.RosyBrown,Font=new Font(familyName="Corbel Light",emSize = 13.0f),Text ="\tInput string: \n\tchoose func ", Width=210,Height=65,ReadOnly=true,Left=250,BackColor=Color.AntiqueWhite)
    let str = new TextBox(ForeColor=Color.RosyBrown,Font=new Font(familyName="Corbel Light",emSize = 13.0f),Text="                 Input here! ",Width=210,Height=25,Left =250,Top=90, BackColor=Color.AntiqueWhite)
    str.Click.Add(fun (e:EventArgs) ->
                            let nul = ""
                            str.Text<-nul)
    let present = new RichTextBox(ForeColor=Color.RosyBrown,Font=new Font(familyName="Corbel Light",emSize = 14.0f),Text ="\tIs palindome? \n\n\tNumber words\n\n\tNumber digits", Width=210,Height=120,ReadOnly=true,Left=500,BackColor=Color.AntiqueWhite)
    let btn1=new Button(Text="Solve",Left=720)
    let btn2=new Button(Text="Solve",Left=720,Top=50)
    let btn3=new Button(Text="Solve",Left=720,Top=100)
    let answtext=new RichTextBox(ForeColor=Color.RosyBrown,Font=new Font(familyName="Corbel Light",emSize = 13.0f),Width=200,Height=50,Left =250,Top=200, BackColor=Color.AntiqueWhite,ReadOnly=true)
    btn1.Click.Add(fun (e:EventArgs)->
        btn1.Dispose()
        btn2.Dispose()
        btn3.Dispose()
        let (y:int) = chooser (str.Text) 1
        match y with
        |1 -> answtext.Text<-"\t"+true.ToString()
        |0->answtext.Text<-"\t"+false.ToString()
        |_->answtext.Text<-"idkwhatsgoingon")
    btn2.Click.Add(fun (e:EventArgs)->
        btn1.Dispose()
        btn2.Dispose()
        btn3.Dispose()
        let (y:int) = chooser (str.Text) 2
        answtext.Text<-y.ToString())
    btn3.Click.Add(fun (e:EventArgs)->
        btn1.Dispose()
        btn2.Dispose()
        btn3.Dispose()
        let (y:int) = chooser (str.Text) 3
        answtext.Text<-y.ToString())
    form.Controls.Add(text)
    form.Controls.Add(str)
    form.Controls.Add(present)
    form.Controls.Add(btn1)
    form.Controls.Add(btn2)
    form.Controls.Add(btn3)
    form.Controls.Add(answtext)
    Application.Run(form)    
    0 