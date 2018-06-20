module Bool

open System

let eqIgnoreCase (s1 : string) s2 = s1.Equals(s2, StringComparison.OrdinalIgnoreCase)

let equals a b = (a - b |> abs) <= Double.Epsilon

// Explanatory wrapper
let isSome (x : 'T option) = x.IsSome

// Explanatory wrapper
let isEmpty = Array.isEmpty

let isNumeric = Double.TryParse >> fst

let IsNotZero x =
    match Double.TryParse x with
    | true, x -> x <> 0.0
    | _ -> false

let containsIgnoreCase (s : string) findMe =
    -1 < s.IndexOf(findMe, StringComparison.OrdinalIgnoreCase)

let areAllDigits xs =
    xs |> Seq.forall Char.IsDigit

let areSameElements xs =
    xs |> (Seq.distinct >> Seq.length) = 1

let areSameLists f (xs : 'a list) (ys : 'a list) =
    xs.Length = ys.Length && List.forall2 f xs ys