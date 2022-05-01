module Design.Main
open System

open System.Windows.Forms
open System.Drawing

[<EntryPoint; STAThread>]
let main argv =
    Application.EnableVisualStyles()
    Application.SetCompatibleTextRenderingDefault(false)
    use form = new StartForm()
    let leng = new RichTextBox (ForeColor=Color.CadetBlue,Font=new Font(familyName="Comic Sans MS",emSize = 8.0f),Text ="Input lenght here!", Top=100, Left =100,Height=25,BackColor=Color.AntiqueWhite)
    let width=new RichTextBox (ForeColor=Color.CadetBlue,Font=new Font(familyName="Comic Sans MS",emSize = 8.0f),Text ="Input width here!", Top=100, Left =300,Height=25,BackColor=Color.AntiqueWhite)
    let answtext=new RichTextBox(ForeColor=Color.CadetBlue,Font=new Font(familyName="Comic Sans MS",emSize = 11.0f),ReadOnly=true,Top=275, Left=180, Height=25,Width=105,BackColor=Color.AntiqueWhite)
    let btnres=new Button(ForeColor=Color.CadetBlue,Font=new Font(familyName="Comic Sans MS",emSize = 11.0f),Text="Solve", Top=150,Left = 200,Height=75,BackColor=Color.AntiqueWhite)
    
    leng.Click.Add(fun (e:EventArgs)->
            let s=""
            leng.Text<-s)
    width.Click.Add(fun (e:EventArgs)->
            let s=""
            width.Text<-s)
    let _=btnres.Click.Add(fun (e:EventArgs)->
        let len=Convert.ToInt32(leng.Text)
        let wid=Convert.ToInt32(width.Text)
        let area=len*wid
        answtext.Text<-area.ToString()
        btnres.Dispose()
        )

    form.Controls.Add(leng)
    form.Controls.Add(btnres)
    form.Controls.Add(answtext)
    form.Controls.Add(width)
    Application.Run(form)    
    0 