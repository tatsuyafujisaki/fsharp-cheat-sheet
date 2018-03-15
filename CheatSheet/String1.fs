module String1

open Microsoft.VisualBasic
open System
open System.Text.RegularExpressions

// Explanatory wrapper
let repeat count s = String.replicate count s

let rec concat = function
    | [] -> ""
    | [head] -> head
    | head :: [second] -> head + " and " + second
    | head :: tail -> head + ", " + (concat tail)

let split (s : string) (separator : string) =
    s.Split([| separator |], StringSplitOptions.None)

let getBetween s from to1 inclusive =
    let m = Regex.Match(s, (if inclusive then sprintf "(%s.*?%s)" from to1 else sprintf "%s(.*?)%s" from to1), RegexOptions.IgnoreCase)
    if m.Success then Some (m.Groups.[1].Value) else None

// https://msdn.microsoft.com/en-us/library/ms912047.aspx
let zenkaku s = Strings.StrConv(s, VbStrConv.Wide, 1041)

// https://msdn.microsoft.com/en-us/library/ms912047.aspx
let hankaku s = Strings.StrConv(s, VbStrConv.Narrow, 1041)

let zenkakuWithUnicodeEscaped (s : string) =
    let unicodeToEscape = '®'
    s.Split unicodeToEscape
    |> Array.map (fun x -> Strings.StrConv(x, VbStrConv.Wide, 1041))
    |> String.concat (unicodeToEscape.ToString())
