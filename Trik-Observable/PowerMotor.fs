namespace TrikObservable.PowerMotor

open System
open TrikObservable

type PowerMotor(i2cCommandNumber) =
    let mutable inner = 0
    interface IObserver<int> with
        member this.OnNext(data) = 
            if inner > 10 then 
                inner <- 0
                printfn "%A" data
            else 
                inner <- inner + 1
            Extern.linux (fun() -> Extern.send i2cCommandNumber data 1)
        member this.OnError(e) = ()
        member this.OnCompleted() = ()
    
    