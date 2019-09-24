

|> Storytime
    |> What is familiar about Fabulous
    |> F# / MVU / Domain Modeling
|> What came before MVU / What problems does MVU solve?
    - where's the state?
|> What is MVU?
    - both strict and freeing
    - pattern not a framework, each piece considered separately
    - virtual ui
    - "fractal"
|> Introduce sameroom / gif demo
    -- What did I learn? / tips+tricks
    > layout
        - Look at Xamarin docs
        - Like with fable/elmish you have to "learn" how to read the docs 
            -> don't search for "fabulous stack panel" (or do?)
            -> search for xamarin forms stack panel
    > Animations
        - animations duringureother updates
        - virtual dom helps
    > Async callouts (from view)



# "storytime"
- First introduction to Fabulous
* joke
- Feeling of familiarity
* graphic

** central thesis of this talk:
Fabulous is familiar **

# Introduce SameRoom here?

# MVU
- What is MVU / how is it different from what came before?
    - MVC
        - "granddaddy"
        * diagram
    - MVVM
        variation on MVC which "simplifies" the controller
        renames it the viewmodel and uses bindings 
        uses a DSL (XAML) for UI
        * diagram
    - MVU aka TEA
        * diagram
        - inspired by functional programming
        - What problems does MVU Solve?
            races
            hidden state "restart to fix it"
            * graphic "hello IT"
            separate language for UI
                - xaml annoyances: converters, bindings, markup extensions
        - Components: fractal design
            -> segue into #DDD

# DDD
- Use the power of F# model our domain
- Make illegal states unrepresentable
* Talk about the domain of SameRoom


# 