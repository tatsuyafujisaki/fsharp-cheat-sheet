module Collection1

// Explanatory wrapper
let excludeNone xs = List.choose id xs

// Explanatory wrapper
let last xs = Seq.last xs

let excludeLast xs =
    let rec excludeLast' acc xs' =
        match xs' with
        | [_] -> List.rev acc
        | head :: tail -> excludeLast' (head :: acc) tail
        | _ -> failwith "Impossible"

    match List.isEmpty xs with
    | true -> invalidOp "xs should have one element or more."
    | false -> excludeLast' [] xs

// Returns (listWithoutLast, last)
let separateLast xs =
    let rec separateLast' acc xs' =
        match xs' with
        | [head] -> List.rev acc, head
        | head :: tail -> separateLast' (head :: acc) tail
        | _ -> failwith "Impossible"

    match List.isEmpty xs with
    | true -> invalidOp "xs should have one element or more."
    | false -> separateLast' [] xs