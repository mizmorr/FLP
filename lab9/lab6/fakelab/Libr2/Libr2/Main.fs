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
    form.Text<-"FoFofform"
    let text= new RichTextBox(ForeColor=Color.CadetBlue,Font=new Font(familyName="Comic Sans MS",emSize = 13.0f),Text ="\tInput massive: \n\t*without last _ ", Width=210,Height=65,ReadOnly=true,Left=250,BackColor=Color.AntiqueWhite)
    let mass = new TextBox(ForeColor=Color.CadetBlue,Font=new Font(familyName="Comic Sans MS",emSize = 13.0f),Text="           Input here! ",Width=210,Height=25,Left =250,Top=90, BackColor=Color.AntiqueWhite)
    let fstmax = new RichTextBox(ForeColor=Color.CadetBlue,Font=new Font(familyName="Comic Sans MS",emSize = 11.0f), Width=80,Height=80,ReadOnly=true,Left=200,BackColor=Color.AntiqueWhite,Top=200)
    let sndmax = new RichTextBox(ForeColor=Color.CadetBlue,Font=new Font(familyName="Comic Sans MS",emSize = 11.0f), Width=80,Height=80,ReadOnly=true,Left=425,BackColor=Color.AntiqueWhite,Top=200)
    form.Controls.Add(fstmax)
    mass.Click.Add(fun (e:EventArgs) ->
                            let nul = ""
                            mass.Text<-nul)
    let btnsolve = new Button(Font=new Font(familyName="Comic Sans MS",emSize = 10.0f), Text="Find the two max elems", Top=200,ForeColor=Color.CadetBlue, Left =320,Height=80,Width=80)
    btnsolve.Click.Add(fun (e:EventArgs)->
                    let preres=mass.Text.Split(' ')
                    let res =List.map System.Int32.Parse (Seq.toList(preres))
                    let first= ListMax res
                    let second = SndMax res
                    fstmax.Text<-"\nFirst - "+first.ToString()
                    sndmax.Text<-"\nSecond - "+second.ToString()
                    btnsolve.Dispose()
                    mass.Dispose()
                    )
    form.Controls.Add(btnsolve)
    form.Controls.Add(sndmax)
    form.Controls.Add(text)
    form.Controls.Add(mass)

    Application.Run(form)    
    0 