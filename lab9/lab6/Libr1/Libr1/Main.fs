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
    form.Text<-"MmMMassive"
    let text= new RichTextBox(Font=new Font(familyName="Comic Sans MS",emSize = 12.0f),Text ="\n\tInput massive: \n\t*without last _ ", Width=200,Height=75,ReadOnly=true,Left=250,BackColor=Color.AntiqueWhite)
    let mass = new TextBox(Width=200,Height=25,Left =250,Top=90, BackColor=Color.AntiqueWhite )
    let btnsolve=new Button(Font=new Font(familyName="Comic Sans MS",emSize = 14.0f),Text="SoLVE", BackColor=Color.AntiqueWhite, Left=500,Top=200,Height=150,Width=150)
    let answtext=new RichTextBox(Width=200,Height=25,Left =250,Top=200, BackColor=Color.AntiqueWhite,ReadOnly=true)
    let answbox = new RichTextBox(Width=200,Height=50,Left =250,Top=125, BackColor=Color.AntiqueWhite,ReadOnly=true, Text="\tComPlEte!!\n(reverse between max min)",Font=new Font(familyName="Comic Sans MS",emSize = 12.0f))
    let _=btnsolve.Click.Add((fun (e:EventArgs)->
                    let prepreres=mass.Text.Split(' ')
                    let preres =List.map System.Int32.Parse (Seq.toList(prepreres))
                    let res = MakeResList preres
                    let  ListToString l =
                        let rec tr s l =
                            match l with
                            |[]->s
                            |h::t ->
                                tr (s+h.ToString()+" ") t
                        tr "" l
                    let ss=ListToString res
                    answtext.Text<-ss
                    btnsolve.Dispose()
                    form.Controls.Add(answbox)
                    ))
    form.Controls.Add(text)
    form.Controls.Add(mass)
    form.Controls.Add(btnsolve)
    form.Controls.Add(answtext)
    Application.Run(form)    
    0 
