module Program

open log4net
open System

[<EntryPoint>]
let main _ = 
    let log = LogManager.GetLogger("Program")
    
    AppDomain.CurrentDomain.UnhandledException.AddHandler (fun _ e -> log.Error e.ExceptionObject)

    printfn "%s" "Hello world!"

    0

    //match argv with
    //| [| _ |] ->
    //    // Wait without closing console 
    //    // stdin.Read() |> ignore
    //    0
    //| _ -> 
    //    invalidOp "Must have only one argument."
    //    1