- title : Developing a Fabulous Mobile App
- description : Getting started with Fabulous
- author : Eric Harding
- theme : Night
- transition : default

***
<!-- theme: sky -->

## Developing a Fabulous Mobile App

> Eric Harding  
@digitalsorcery  
https://blog.digitalsorcery.net

---

## Thanks to 
<img src="images/openfsharp.svg" width="200" />

***

# Storytime
# <i class="fas fa-book"></i> 
<!-- Introduction to fabulous at the meetup
    "do you like it? is it any good?" "it's fabulous"
-->

---

![](images/idontknow.jpg)

---
![](images/i-know-this.jpg)

### I know this
<!-- Even though Fabulous is relatively new
it feels familiar because most pieces stay the same
-->

---

## F#
* No separate UI language
* No new tools needed

---

## Domain Modeling
* Works with your _existing_ model
* Make illegal states unrepresentable

---

## Immutability
* Designed for functional languages
* No required mutability

---
## Model View Update
* One way data flow
* Single source of truth
<!-- * "fractal" components -->
* A library Not a framework

---

***

### Before MVU?

> We are all here for some special reason. Stop being a prisoner of your past. Become the architect of your future. 
> ― WiseOldSayings.com

---

# MVC

![](images/Abe_Simpson.png)
<!-- The classic UI pattern, 
MVC Smalltalk 79
Ask 5 developers what MVC is and you'll get 5 answers
-->

---

# MVP
<!-- basically still MVC... -->

---

# MVVM

<!-- ![](images/MVVMPattern.png) -->
<img src="images/MVVMPattern.png" width="70%" />

---

# MV_ 
### Can be a bit vague

> Where's the State?
> -- @jimbobbennett

<!-- MVU is not vague.  You can tell by the type signatures 
Where's the state?
-->

---


## Tech Support
![](images/hello_it.jpg)

***

# MVU

Not Vague

* view  : Model -> (Msg->unit) -> Elements
* update : Model -> Msg -> Model

---

![](images/mvu.svg)

---

# TODO: more about MVU

***

## Xamarin Forms

A _Fabulous_ View

---

## Where to look for help?

***

# SameRoom

![](images/sameroom.gif)

***

## Animations 
* Get them off the UI thread
* Handling animations during state changes

