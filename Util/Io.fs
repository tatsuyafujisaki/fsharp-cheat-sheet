module Io

open System.IO

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

let rec walk dir pattern =
    seq { yield! Directory.EnumerateFiles(dir, pattern)
          for d in Directory.EnumerateDirectories(dir) do
              yield! walk d pattern }