module Program

open log4net
open System

[<EntryPoint>]
let main _ = 
    let log = LogManager.GetLogger("Program")
    
    AppDomain.CurrentDomain.UnhandledException.AddHandler (fun _ e -> log.Error e.ExceptionObject)
 
    0