module String1

open System

let split (s : string) (separator : string) =
    s.Split([| separator |], StringSplitOptions.None)