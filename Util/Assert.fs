module Assert

let assertAllSame xs =
    match Seq.distinct xs |> Seq.length with
    | 1 -> xs
    | 0 -> failwithf "%A has no value." xs
    | _ -> failwithf "%A has multiple values." xs