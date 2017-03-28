module DateTime1

open System

let nextBusinessDay (dt : DateTime) =
    match dt.DayOfWeek with
    | DayOfWeek.Friday -> dt.AddDays(3.0)
    | DayOfWeek.Saturday -> dt.AddDays(2.0)
    | _ -> dt.AddDays(1.0)