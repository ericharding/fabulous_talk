// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace multiCounter

open System.Diagnostics
open Fabulous
open Fabulous.XamarinForms
open Fabulous.XamarinForms.LiveUpdate
open Xamarin.Forms

module Counter =
    type Model = { count : int }
    type Msg =
        | Increment
        | Decrement
    let init() = { count = 0 }, Cmd.none
    let update msg model =
        match msg with
        | Increment -> { count = model.count + 1 }, Cmd.none
        | Decrement -> { count = model.count - 1 }, Cmd.none
    let view (model: Model) dispatch =
        View.StackLayout(padding = 20.0,
            children = [ 
                View.Label(text = sprintf "%d" model.count, 
                    widthRequest=200.0)
                View.Button(text = "Increment", 
                    command = (fun () -> dispatch Increment),
                    horizontalOptions = LayoutOptions.Center)
                View.Button(text = "Decrement", 
                    command = (fun () -> dispatch Decrement), 
                    horizontalOptions = LayoutOptions.Center)
            ])
 
module Reverser =
    type Model = { text : string }
    type Msg =
        | TextChanged of string
        | Reverse
    let init() = { text = ""}, Cmd.none
    let reverse (str:string) =
        str
        |> Seq.rev
        |> Seq.map string
        |> String.concat ""
    let update msg model =
        match msg with
        | TextChanged newName -> { text = newName }, Cmd.none
        | Reverse -> { text = reverse model.text }, Cmd.none
    let view model dispatch =
        View.StackLayout([
            View.Label(text = model.text)
            View.Entry(
                text = model.text,
                textChanged = (fun arg -> dispatch <| TextChanged arg.NewTextValue)
            )
            View.Button(text = "Reverse", command = (fun _ -> dispatch Reverse))
        ])


module App = 
    type Model = 
      { counter : Counter.Model
        text : Reverser.Model }

    type Msg = 
        | CounterMsg of Counter.Msg 
        | ReverserMsg of Reverser.Msg

    let init () = 
        let cstate, ccmd = Counter.init()
        let rstate, rcmd = Reverser.init()
        { counter = cstate; text = rstate }, 
        Cmd.batch [Cmd.map CounterMsg ccmd; Cmd.map ReverserMsg rcmd]

    let update msg model =
        match msg with
        | CounterMsg m -> 
            let (cstate, ccmd) = Counter.update m model.counter
            { model with counter = cstate }, Cmd.map CounterMsg ccmd
        | ReverserMsg m -> 
            let (rstate, rcmd) = Reverser.update m model.text
            { model with text = rstate }, Cmd.map ReverserMsg rcmd

    let view (model: Model) dispatch =
        View.ContentPage(
          content = View.StackLayout(padding = 20.0, verticalOptions = LayoutOptions.Center,
            children = [ 
                Counter.view model.counter (CounterMsg>>dispatch)
                Reverser.view model.text (ReverserMsg>>dispatch)
            ]))

    // Note, this declaration is needed if you enable LiveUpdate
    let program = Program.mkProgram init update view

type App () as app = 
    inherit Application ()

    let runner = 
        App.program
#if DEBUG
        |> Program.withConsoleTrace
#endif
        |> XamarinFormsProgram.run app

#if DEBUG
    // Uncomment this line to enable live update in debug mode. 
    // See https://fsprojects.github.io/Fabulous/Fabulous.XamarinForms/tools.html#live-update for further  instructions.
    //
    //do runner.EnableLiveUpdate()
#endif    

    // Uncomment this code to save the application state to app.Properties using Newtonsoft.Json
    // See https://fsprojects.github.io/Fabulous/Fabulous.XamarinForms/models.html#saving-application-state for further  instructions.
#if APPSAVE
    let modelId = "model"
    override __.OnSleep() = 

        let json = Newtonsoft.Json.JsonConvert.SerializeObject(runner.CurrentModel)
        Console.WriteLine("OnSleep: saving model into app.Properties, json = {0}", json)

        app.Properties.[modelId] <- json

    override __.OnResume() = 
        Console.WriteLine "OnResume: checking for model in app.Properties"
        try 
            match app.Properties.TryGetValue modelId with
            | true, (:? string as json) -> 

                Console.WriteLine("OnResume: restoring model from app.Properties, json = {0}", json)
                let model = Newtonsoft.Json.JsonConvert.DeserializeObject<App.Model>(json)

                Console.WriteLine("OnResume: restoring model from app.Properties, model = {0}", (sprintf "%0A" model))
                runner.SetCurrentModel (model, Cmd.none)

            | _ -> ()
        with ex -> 
            App.program.onError("Error while restoring model found in app.Properties", ex)

    override this.OnStart() = 
        Console.WriteLine "OnStart: using same logic as OnResume()"
        this.OnResume()
#endif


