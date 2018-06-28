module Process1

open System.Diagnostics

let startAndForget fileName arguments = 
    Process.Start(fileName, arguments) |> ignore

let startAndWait fileName arguments = 
    use p = Process.Start(fileName, arguments)

    let millisecondsToTimout = 60_000

    match p.WaitForExit millisecondsToTimout with
    | true -> p.ExitCode
    | false -> sprintf "%s(%s) did not exit in %d milliseconds and timed out." fileName arguments millisecondsToTimout |> invalidOp

let startAndGetResult fileName arguments = 
    let p = Process.Start(ProcessStartInfo(FileName = fileName,
                                           Arguments = arguments,
                                           CreateNoWindow = true,
                                           UseShellExecute = false,
                                           WindowStyle = ProcessWindowStyle.Hidden,
                                           RedirectStandardOutput = true,
                                           RedirectStandardError = true))

    let millisecondsToTimout = 60_000

    match p.WaitForExit millisecondsToTimout with
    | true -> p.ExitCode, p.StandardOutput.ReadToEnd(), p.StandardError.ReadToEnd()
    | false -> sprintf "%s(%s) did not exit in %d milliseconds and timed out." fileName arguments millisecondsToTimout |> invalidOp