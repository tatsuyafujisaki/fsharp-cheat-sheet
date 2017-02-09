module Collection1

// Explanatory wrapper
let excludeNone xs = List.choose id xs

// Explanatory wrapper
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