module Io

open System.IO
open Process1

let rec print xs =
    match xs with
        | [] -> ()
        | x::tail ->
            printfn "%A" x
            print tail

let rec reversePrint xs =
    match xs with
        | [] -> ()
        | x::tail ->
            reversePrint tail
            printfn "%A" x

let deleteDirectory path =
    // Avoid DirectoryNotFoundException
    if Directory.Exists(path) then Directory.Delete(path, true)

let deleteFile path =
    // Avoid ArgumentNullException by File.Delete("")
    // Avoid ArgumentException by File.Delete(null)
    // Avoid DirectoryNotFoundException by File.Delete(@"C:\NonExistingDirectory\Foo.txt")
    if File.Exists(path) then File.Delete(path)

let copyDirectory sourceDirectory destinationDirectory =
    deleteDirectory destinationDirectory
    startProcess "xcopy" (sprintf "%A %A /e /i /y" sourceDirectory destinationDirectory)

let rec walk dir pattern =
    seq { yield! Directory.EnumerateFiles(dir, pattern)
          for d in Directory.EnumerateDirectories(dir) do
              yield! walk d pattern }        