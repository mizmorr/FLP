module Design.Main
open System
open System.Windows.Forms
open System.Drawing

[<EntryPoint; STAThread>]
let main argv =
    Application.EnableVisualStyles()
    Application.SetCompatibleTextRenderingDefault(false)
    use form = new StartForm()
    let lablog=new Label(ForeColor=Color.CadetBlue,Text="log", Left =100,Top=100,Font=new Font(familyName="Corbel",emSize = 14.0f))
    let n=new TextBox (ForeColor=Color.CadetBlue,Font=new Font(familyName="Corbel",emSize = 14.0f),Left=130,Top=100,Height=15,Width=30,BackColor=Color.AntiqueWhite)
    let ravno=new Button(ForeColor=Color.CadetBlue,Text="=", Left=165,Top=100,Font=new Font(familyName="Corbel",emSize = 14.0f),Width=30,BackColor=Color.AntiqueWhite,Height=30)
    let answtext=new RichTextBox(ForeColor=Color.CadetBlue,Font=new Font(familyName="Comic Sans MS",emSize = 11.0f),ReadOnly=true,Top=100, Left=200, Height=25,Width=150,BackColor=Color.AntiqueWhite)
    ravno.Click.Add(fun (e:EventArgs) ->
            let logn=Math.Log(float(n.Text))
            answtext.Text<-logn.ToString())
    form.Controls.Add(n)
    form.Controls.Add(ravno)
    form.Controls.Add(answtext)
    form.Controls.Add(lablog)
    Application.Run(form)    
    0 