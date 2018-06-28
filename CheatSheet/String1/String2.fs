module String1

open Microsoft.VisualBasic
open System
open System.Text.RegularExpressions

// Explanatory wrapper
let repeat count = String.replicate count

// Explanatory wrapper
// There is no such function as string.Head.
let getChar (s : string) i = s.[i]

let split (s : string) (separator : string) = s.Split([| separator |], StringSplitOptions.None)

let getBetween s from to1 inclusive =
    let m = Regex.Match(s, (match inclusive with
                            | true -> sprintf "(%s.*?%s)" from to1
                            | false -> sprintf "%s(.*?)%s" from to1), RegexOptions.IgnoreCase)

    match m.Success with
    | true -> Some m.Groups.[1].Value
    | false -> None

let zenkaku s =
    let japaneseLocaleID = 1041
    Strings.StrConv(s, VbStrConv.Wide, japaneseLocaleID)

let hankaku s =
    let japaneseLocaleID = 1041
    Strings.StrConv(s, VbStrConv.Narrow, japaneseLocaleID)

let zenkakuWithUnicodeEscaped (s : string) =
    let unicodeToEscape = '®'
    s.Split unicodeToEscape
    |> Array.map (fun x -> Strings.StrConv(x, VbStrConv.Wide, 1041))
    |> String.concat (unicodeToEscape.ToString())
