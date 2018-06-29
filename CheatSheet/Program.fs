module Program

open log4net
open System
open System.Linq
open System.Reflection
open System.Text

[<EntryPoint>]
let main argv = 
    let logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
    
    // AppDomain.CurrentDomain.UnhandledException.AddHandler (fun _ e -> logger.Error e)

    try
        Process1.killOldSelf ()

        let printUsage () =
            let friendlyName = AppDomain.CurrentDomain.FriendlyName

            let sb = StringBuilder()

            sprintf "Usage 1: %s Foo" friendlyName |> sb.AppendLine |> ignore
            sprintf "Usage 2: %s Bar" friendlyName |> sb.AppendLine |> ignore

            sb.ToString() |> printfn "%s"

        match argv.Any() with
        | true -> logger.InfoFormat("Starts with arguments: {0}", String.Join(" ", argv))
        | false ->
            logger.Info "Starts with no arguments"

            printUsage ()

            invalidArg "argv" ""

        printfn "%A" DateTime.Now

        logger.Info "Exits with 0"

        0
    with
    | e ->
        logger.Error e

        logger.Info "Exits with 1"

        1