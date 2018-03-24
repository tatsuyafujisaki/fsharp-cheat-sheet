module Concat1

let rec concatWithoutOxfordComma = function
    | [] -> ""
    | [head] -> head
    | head :: [second] -> head + " and " + second
    | head :: tail -> head + ", " + concatWithoutOxfordComma tail

let concatWithOxfordComma (ss : string list) =
    let rec concat = function
        | [] -> ""
        | [head] -> head
        | head :: [second] -> head + ", and " + second
        | head :: tail -> head + ", " + concat tail

    match ss.Length with
    | 2 -> ss.Head + " and " + ss.[1]
    | _ -> concat ss