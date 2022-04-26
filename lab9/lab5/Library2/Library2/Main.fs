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
    form.Text<-"MmMM"
    let text= new RichTextBox(Font=new Font(familyName="Comic Sans MS",emSize = 10.0f),Text ="Input number and choose func ", Width=200,Height=50,ReadOnly=true,Left=250,BackColor=Color.AntiqueWhite)
    let items =[|1;2;3;4|] 
    let comb=new ComboBox(Top=120,Left=280,BackColor=Color.AntiqueWhite,DataSource=items)
    let num=new RichTextBox(Left=280,Top=75,Height=20,Width=120,BackColor=Color.AntiqueWhite)
    let answer=new RichTextBox(Top=200,Left=500,ReadOnly=true,Height=20,Width=120,BackColor=Color.AntiqueWhite)
    let func =new RichTextBox(Font=new Font(familyName="Comic Sans MS",emSize = 10.0f),Text ="1 - Сумма делителей\n2 - Произведение делителей \n3 - Максимальный делитель\n4 - Минимальный делитель",BackColor=Color.AntiqueWhite,Width=200,Height=85,ReadOnly=true,Left=250,Top=200)
    let btn =new Button(Text="Solve",BackColor=Color.AntiqueWhite, Left=500, Top=250,Height=35,Width=75)
    let _ = btn.Click.Add((fun (e:EventArgs)->
                    let n =System.Convert.ToInt32(comb.Text)
                    let num =System.Convert.ToInt32(num.Text)
                    let answ=
                        "Answer = "+(chooser num n).ToString()
                    answer.Text<-answ ))
    form.Controls.Add(text);
    form.Controls.Add(comb)
    form.Controls.Add(num)
    form.Controls.Add(answer)
    form.Controls.Add(func)
    form.Controls.Add(btn)
    Application.Run(form)    
    0 
