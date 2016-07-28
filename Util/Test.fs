module Test

let mutableVsRef() = 
    // Use mutable because its performance is better than that of ref.
    // ref is a wrapper of mutable.
    let a = ref 1 // allocates a new record on the heap
    let b = a // b references the same record
    b := 9 // modifies the value of 'a' as well!
    let mutable c = 1 // mutable value on the stack
    let mutable d = c // new mutable value initialized to current value of 'c'
    d <- 9 // modifies the value of 'd' only!
    printfn "a = %A" !a // 9
    printfn "b = %A" !b // 9
    printfn "c = %A" c // 1
    printfn "d = %A" d // 9