module Union

open Microsoft.FSharp.Reflection

let toUnionCaseName (x : 'T) =
    match FSharpValue.GetUnionFields(x, typeof<'T>) with
    | x, _ -> x.Name

let invalidArg1 argumentName expected =
    sprintf "Must be %A, but was %A." expected
    >> invalidArg argumentName

let invalidArg2 argumentName expected1 expected2 =
    sprintf "Must be %A or %A, but was %A." expected1 expected2
    >> invalidArg argumentName

let invalidArg3 argumentName expected1 expected2 expected3 =
    sprintf "Must be %A, %A, or %A, but was %A." expected1 expected2 expected3
    >> invalidArg argumentName

let invalidUnionCase1 argumentName expected =
    toUnionCaseName
    >> sprintf "Must be %A, but was %A." expected
    >> invalidArg argumentName

let invalidUnionCase2 argumentName expected1 expected2 =
    toUnionCaseName
    >> sprintf "Must be %A or %A, but was %A." expected1 expected2
    >> invalidArg argumentName

let invalidUnionCase3 argumentName expected1 expected2 expected3 =
    toUnionCaseName
    >> sprintf "Must be %A, %A, or %A, but was %A." expected1 expected2 expected3
    >> invalidArg argumentName

type Type1 =
| Case1 of string
| Case2 of string
| Case3 of string

// Sample
let unUnion = function
    | Case1 v -> v
    | Case2 v -> v
    | x -> invalidArg2 "x" "Case1" "Case2" x