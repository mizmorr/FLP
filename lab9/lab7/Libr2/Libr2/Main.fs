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
    form.Text<-"Lllist"
    let list = new TextBox(ForeColor=Color.DarkSlateBlue,Font=new Font(familyName="Miriam Libre",emSize = 13.0f),Text="       Input list here! ",Width=200,Height=25,Left =250,Top=90, BackColor=Color.AliceBlue)
    list.Click.Add(fun (e:EventArgs) ->
                            let nul = ""
                            list.Text<-nul)
    let answtext=new RichTextBox(ForeColor=Color.DarkSlateBlue,Font=new Font(familyName="Miriam Libre",emSize = 13.0f),Width=200,Height=25,Left =250,Top=200, BackColor=Color.AliceBlue,ReadOnly=true)
    let btnres= new Button (Font=new Font(familyName="Miriam Libre",emSize = 14.0f),Text="Найти пропущенные элементы!",BackColor=Color.AliceBlue,Left=500,Top=200,Height=150,Width=150,ForeColor=Color.DarkSlateBlue)
    let pen=new Pen(Color.DarkSlateBlue, float32(3))
    let lab =new Label(Text="Success!",Font=new Font(familyName="Arial",emSize = 14.0f),ForeColor=Color.DarkSlateBlue, Top=150,Left=300 )
    btnres.Click.Add(fun (e:EventArgs) ->
        let prepreres=list.Text.Split(' ')
        let preres =List.map System.Int32.Parse (Seq.toList(prepreres))
        let res =reslist preres
        let  ListToString l =
             let rec tr s l =
                   match l with
                   |[]->s
                   |h::t ->
                                tr (s+h.ToString()+" ") t
             tr "" l
        let str=ListToString res
        form.Controls.Add(lab)
        answtext.Text<-str
        btnres.Dispose()
    )
   

    form.Controls.Add(btnres)
    form.Controls.Add(answtext)
    form.Controls.Add(list)
    Application.Run(form)    
    0 