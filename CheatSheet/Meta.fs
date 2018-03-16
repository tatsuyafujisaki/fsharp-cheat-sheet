module Meta

open Microsoft.FSharp.Reflection

let ToUnionCase (x : 'T) =
    match FSharpValue.GetUnionFields(x, typeof<'T>) with
    | x, _ -> x.Name