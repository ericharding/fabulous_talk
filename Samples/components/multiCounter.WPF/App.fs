namespace multiCounter.WPF

open System

open Xamarin.Forms
open Xamarin.Forms.Platform.WPF

type MainWindow() = 
    inherit FormsApplicationPage()

module Main = 
    [<EntryPoint>]
    [<STAThread>]
    let main(_args) =

        let app = new System.Windows.Application()
        Forms.Init()
        let window = MainWindow() 
        window.LoadApplication(new multiCounter.App())

        app.Run(window)
