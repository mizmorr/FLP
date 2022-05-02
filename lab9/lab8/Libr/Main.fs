module Design.Main
open System

open System.Windows.Forms
open System.Drawing

[<EntryPoint; STAThread>]
let main argv =
    Application.EnableVisualStyles()
    Application.SetCompatibleTextRenderingDefault(false)
    use form = new StartForm()
    let arr = new RichTextBox(BackColor=Color.AntiqueWhite,Font=new Font(familyName="Comic Sans MS",emSize = 12.0f),Text ="Input coefficients here!", Top=100,Left=150,Height=20,Width=150)
    arr.Click.Add(fun (e:EventArgs)->
            let s=""
            arr.Text<-s)
    let btnres=new Button(BackColor=Color.AntiqueWhite,Text="Solve",Height=60,Width=60, Top=140, Left=200)
    let fstres=new RichTextBox(BackColor=Color.AntiqueWhite,Font=new Font(familyName="Comic Sans MS",emSize = 12.0f),ReadOnly=true,Height=25,Width=75,Top=250, Left=125)
    let sndres=new RichTextBox(BackColor=Color.AntiqueWhite,Font=new Font(familyName="Comic Sans MS",emSize = 12.0f),ReadOnly=true,Height=25,Width=75,Top=250, Left=250)
    btnres.Click(fun (e:EventArgs) ->
        let prepreres=mass.Text.Split(' ')
        let preres =Array.map System.Int32.Parse (Seq.toList(prepreres))
        let compILTN (a:double) =
            if Seq.head(a.ToString()) ='-' then true
            else false
        let func (str1:string) (str2:string) =
            fstres.Text<-str1
            sndres.Text<-str2
        let res polyn =
            if Array.length polyn<>3 then None
            else
                let a =itd (Array.get polyn 2)
                let b =itd(Array.get polyn 1)
                let c =itd(Array.get polyn 0)
                let d =b*b-4.0*a*c
                if (compILTN d) then arr.Text<-"bad type"
                    else 
                        let f1= ((-b+sqrt(d))/2.0*a)
                        let asd = ((-b-sqrt(d))/2.0*a)) 
                        func (f1.ToString()) (asd.ToString())
          res preres
        )
   
    form.Controls.Add(arr)
    form.Controls.Add(btnres)
    form.Controls.Add(fstres)
    form.Controls.Add(sndres)
    Application.Run(form)    
    0 