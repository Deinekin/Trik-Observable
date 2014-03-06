﻿namespace TrikObservable.LED

open System
open TrikObservable 
type LED(commandNumbers: int array) =
    let mutable inner = 0
    interface IObserver<int array> with
        member this.OnNext(data: int array) = 
            if inner > 10 then 
                inner <- 0
                printfn "%A" data
            else 
                inner <- inner + 1
            Array.iter2 (fun x v -> Extern.linux (fun() -> Extern.send x v 1)) commandNumbers data
        member this.OnError(e) = ()
        member this.OnCompleted() = ()
    

    
    