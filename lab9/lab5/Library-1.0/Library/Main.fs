module Library.Main
open System
open System.Windows.Forms
open System.Drawing

[<EntryPoint; STAThread>]
let main argv =
    Application.EnableVisualStyles()
    Application.SetCompatibleTextRenderingDefault(false)
    use form = new StartupForm()
    Application.Run(form)    
    0 // return an integer exit code