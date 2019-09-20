

Storytime
|> What is familiar about Fabulous
|> F# / MVU / Domain Modeling
|> What is MVU?
|> What came before MVU?



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