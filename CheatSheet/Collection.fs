module Collection

// Explanatory wrapper
// There is no such function as "Array.last" or "List.last" but "Seq.last" takes not only a sequence but also an array, a list or a set.
let last = Seq.last

// Explanatory wrapper
let repeat = List.replicate

// Explanatory wrapper
// There is no such function as "Set.choose".
// Explicit argument is to avoid the FS0030 (Value restriction) error.
let excludeNone1 xs = Seq.choose id xs
let excludeNone2 xs = Array.choose id xs
let excludeNone3 xs = List.choose id xs

// Explanatory wrapper
let flatten1 = Seq.concat
let flatten2 = Array.concat
let flatten3 = List.concat

// In practice, use Seq.last.
let rec myLast = function
  | [head] -> head
  | _ :: tail -> myLast tail
  | _ -> invalidOp "The list is empty."

let rec secondToLast = function
  | [] -> invalidOp "The list is empty."
  | [_] -> invalidOp "The list has only one element." 
  | head :: [_] -> head
  | _ :: tail -> secondToLast tail

let excludeFirst = function
    | [] -> invalidOp "The list is empty."
    | _ :: tail -> tail

// Explicit argument is to avoid the FS0030 (Value restriction) error.
let excludeLast xs =
    let rec excludeLast' acc = function
        | [] -> invalidOp "The list is empty."
        | [_] -> List.rev acc
        | head :: tail -> excludeLast' (head :: acc) tail

    excludeLast' [] xs

// Explicit argument is to avoid the FS0030 (Value restriction) error.
let separateLast xs =
    let rec separateLast' acc = function
        | [] -> invalidOp "The list is empty."
        | [head] -> List.rev acc, head
        | head :: tail -> separateLast' (head :: acc) tail

    separateLast' [] xs

let replaceLast newLast =
    let rec replaceLast' acc = function
        | [] -> invalidOp "The list is empty."
        | [_] -> List.rev acc @ [ newLast ]
        | head :: tail -> replaceLast' (head :: acc) tail

    replaceLast' []