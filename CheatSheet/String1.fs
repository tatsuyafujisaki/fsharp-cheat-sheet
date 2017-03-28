module String1

open Microsoft.VisualBasic
open System

let split (s : string) (separator : string) =
    s.Split([| separator |], StringSplitOptions.None)

// https://msdn.microsoft.com/en-us/library/ms912047.aspx
let fullwidth s = Strings.StrConv(s, VbStrConv.Wide, 1041)

// https://msdn.microsoft.com/en-us/library/ms912047.aspx
let halfwidth s = Strings.StrConv(s, VbStrConv.Narrow, 1041)