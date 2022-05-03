open System
open System.Windows.Controls
open System.Windows.Markup
open System.Windows

let mwXaml = " 
<Window 
xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'
 xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'
 Title='Area of ' Height='300' Width='300'>
 <Grid>
 <GroupBox Header='Введите длину и ширину прямоугольника' Height='100' HorizontalAlignment='Left' Name='groupBox1' VerticalAlignment='Top' Width='350' 
 Grid.ColumnSpan='2'>
  <Grid>
  <TextBox Height = '25' HorizontalAlignment = 'Left' Margin = '56,-50,0,0' Name = 'textBox1' Width = '150' Grid.ColumnSpan='3'  />
  <TextBox Height = '25' HorizontalAlignment = 'Left' IsReadOnly='True' Text = 'Длина' Margin = '6,-50,0,0' Name = 'textBox11' Width = '50' Grid.ColumnSpan='2'  />
  <TextBox Height = '25' HorizontalAlignment = 'Left' Margin = '56,0,0,0' Name = 'textBox2' Width = '150' Grid.ColumnSpan='2' />
  <TextBox Height = '25' HorizontalAlignment = 'Left' IsReadOnly='True' Text = 'Ширина' Margin = '6,0,0,0' Name = 'textBox12' Width = '50' Grid.ColumnSpan='2'  />
  <Button Content='Solve' Height='50' HorizontalAlignment='Left' Margin='206,1,0,0' Name='button' VerticalAlignment='Top' 
  Width='75' Grid.Column='2' />
  </Grid>
  </GroupBox>
 
 <Grid>
<TextBox Height = '50' TextWrapping='Wrap' AcceptsReturn='True' HorizontalAlignment = 'Left' Text = '' Margin = '6,0,0,0' Name = 'Answer' Width = '250' Grid.ColumnSpan='2'  />
 </Grid>
 </Grid>
</Window>
" 


let getWindow(mwXaml) =
    let xamlObj=XamlReader.Parse(mwXaml)
    xamlObj :?> Window

let win = getWindow(mwXaml)

let btn = win.FindName("button") :?> Button
let textbox1 = win.FindName("textBox1") :?>TextBox
let textbox2 = win.FindName("textBox2") :?>TextBox
let answer = win.FindName("Answer") :?>TextBox

btn.Click.Add(fun e ->
    let leng=double(textbox1.Text)
    let width=double(textbox2.Text)
    let out="Area of rectangle: "+Convert.ToString(leng*width)
    answer.Text<-out
    )
[<STAThread>] ignore <| (new Application()).Run win 