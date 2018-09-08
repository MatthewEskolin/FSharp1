open System
open System.Net
open System.Windows.Forms

let webclient = new WebClient()
let fsharpOrg = webclient.DownloadString(Uri "http://fsharp.org")
let browser = new WebBrowser(ScriptErrorsSuppressed = true, Dock = DockStyle.Fill,DocumentText = fsharpOrg)
let form = new Form(Text = "hello from F#!")
form.Controls.Add browser
form.Show()



