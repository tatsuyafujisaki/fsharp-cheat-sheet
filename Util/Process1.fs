module Process1

open System.Diagnostics

let startProcess fileName arguments = 
    use p = Process.Start(fileName, arguments)
    p.Start() |> ignore
    p.WaitForExit()