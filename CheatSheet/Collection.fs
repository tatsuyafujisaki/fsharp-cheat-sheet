module Collection

open System.Linq

// Explanatory wrapper
// There is no such function as "Set.choose".
let excludeNone1 xs = Array.choose id xs
let excludeNone2 xs = Seq.choose id xs
let excludeNone3 xs = List.choose id xs

// Explanatory wrapper
// There is no such function as "Array.last" or "List.last" but "Seq.last" takes not only a sequence but also an array, a list or a set.
let last = Seq.last

// In reality, use Seq.last.
let rec myLast = function
  | [head] -> head
  | _ :: tail -> myLast tail
  | _ -> invalidOp "The list is empty."

let rec secondToLast = function
  | [] -> invalidOp "The list is empty."
  | [_] -> invalidOp "The list has only one element." 
  | head :: _ :: [] -> head
  | _ :: tail -> secondToLast tail

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

let insertIfCharExistsInEndOfPreviousLine (ss: string List) (c : char) sToInsert =
    let countGivenCharInEnd (s : string) c = s.Length - s.TrimEnd([|c|]).Length

    ss
    |> List.map (fun s -> match s.EndsWith(c.ToString()) with
                          | true -> s.TrimEnd([|c|]) :: (Seq.toList (Enumerable.Repeat(sToInsert, (countGivenCharInEnd s c))))
                          | false -> [s])
    |> List.concat