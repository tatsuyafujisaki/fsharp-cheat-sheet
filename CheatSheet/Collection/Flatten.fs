module Flatten

// Explanatory wrapper
let flatten1 = Seq.concat
let flatten2 = Array.concat
let flatten3 = List.concat

// List.concat [[1; 2]; [3; 4]]
// -> [1; 2; 3; 4]

// Explanatory wrapper
let flattenAfterApplyingFunction1 f =
    List.collect f

// Explanatory wrapper
let flattenAfterApplyingFunction2 f =
    List.map f >> List.concat

// let f = List.map (fun x -> x * 10)
// List.collect f [[1; 2]; [3; 4]]
// -> [10; 20; 30; 40]

// let f = List.map (fun x -> x * 10)
// (List.map f >> List.concat) [[1; 2]; [3; 4]]
// -> [10; 20; 30; 40]