module Program

open log4net
open System
open System.Reflection

[<EntryPoint>]
let main _ = 
    let logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    
    AppDomain.CurrentDomain.UnhandledException.AddHandler (fun _ e -> logger.Error e.ExceptionObject)
 
    0