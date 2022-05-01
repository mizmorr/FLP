namespace Library
open Design
open System.Drawing
open System.Windows.Forms
open System
open Program


type StartupForm() as this = 
    inherit Form1()
    do
        this.button1.Click.Add <| fun _->this.label1.Text <- (chooseFunc (System.Convert.ToInt32(this.comboBox1.Text))(System.Convert.ToInt32(this.textBox2.Text))).ToString()

