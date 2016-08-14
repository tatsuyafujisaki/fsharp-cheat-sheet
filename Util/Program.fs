module Program

open log4net
open System

[<EntryPoint>]
let main argv = 
    let logger = LogManager.GetLogger("Program")
    
    AppDomain.CurrentDomain.UnhandledException.AddHandler (fun _ e -> logger.Error e.ExceptionObject)

    match argv with
    | [| _ |] ->
        logger.Error "Sample error."

        // Wait without closing console 
        // stdin.Read() |> ignore

        0
    | _ -> 
        invalidOp "Must have only one argument."