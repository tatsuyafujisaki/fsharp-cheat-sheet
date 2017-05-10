module Collection1

// Explanatory wrapper
// There is no such function as "Set.choose".
let excludeNone1 xs = Array.choose id xs
let excludeNone2 xs = Seq.choose id xs
let excludeNone3 xs = List.choose id xs

// Explanatory wrapper
// There is no such function as "Array.last", "List.last" or "Set.last".
// "Seq.last" takes not only a sequence but also an array, a list or a set.
let last xs = Seq.last xs

let excludeFirst =
    function
    | [] -> invalidOp "The list is empty."
    | _ :: tail -> tail

let excludeLast xs =
    let rec excludeLast' acc =
        function
        | [] -> invalidOp "The list is empty."
        | [_] -> List.rev acc
        | head :: tail -> excludeLast' (head :: acc) tail

    excludeLast' [] xs

// Returns (listWithoutLast, last)
let separateLast xs =
    let rec separateLast' acc xs' =
        match xs' with
        | [] -> invalidOp "The list is empty."
        | [head] -> List.rev acc, head
        | head :: tail -> separateLast' (head :: acc) tail

    separateLast' [] xs