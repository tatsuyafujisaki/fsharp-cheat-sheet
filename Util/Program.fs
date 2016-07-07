module Program

open log4net

[<EntryPoint>]
let main argv = 
   match argv with
   | [|first|] ->
       let logger = LogManager.GetLogger("Main")
       logger.Error "Ouch!"
       
       stdin.Read() |> ignore
       0
   | _ -> failwith "Must have only one argument."