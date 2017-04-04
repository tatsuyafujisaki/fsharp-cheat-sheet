module Program

open log4net
open System

[<EntryPoint>]
let main argv = 
    let log = LogManager.GetLogger("Program")
    
    AppDomain.CurrentDomain.UnhandledException.AddHandler (fun _ e -> log.Error e.ExceptionObject)

    match argv with
    | [| _ |] ->
        // Wait without closing console 
        // stdin.Read() |> ignore
        0
    | _ -> 
        invalidOp "Must have only one argument."
        1