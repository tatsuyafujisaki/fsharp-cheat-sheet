module Bool

open System

let eqIgnoreCase (s1 : string) s2 = s1.Equals(s2, StringComparison.OrdinalIgnoreCase)

// Explanatory wrapper
let isSome (x: 'T option) = x.IsSome

// Explanatory wrapper
let isEmpty xs = Array.isEmpty xs

let isNumeric x = Double.TryParse x |> fst

let isNonZero x =
    match Double.TryParse x with
    | true, x when x <> 0.0 -> true
    | _ -> false

let caseInsensitiveContains (s : string) findMe =
    -1 < s.IndexOf(findMe, StringComparison.OrdinalIgnoreCase)

let isCommentLine (s : string) =
    s.TrimStart().[0] = '#'

let areAllSame xs =
    match Seq.distinct xs |> Seq.length with
    | 1 -> true
    | _ -> false

let areSameLists f (xs : 'a list) (ys : 'a list) =
    xs.Length = ys.Length &&
    List.forall2 f xs ys

let excludeNone (xs : 'a option[]) =
    Array.filter (fun (x : 'a option) -> x.IsSome) xs