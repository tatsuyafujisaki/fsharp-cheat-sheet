module DateTime1

open System

let getDateWithPadZero (dt : DateTime) = dt.ToString "yyyy年MM月dd日"

let getDateWithPadSpace (dt : DateTime) = sprintf "%d年%2d月%2d日" dt.Year dt.Month dt.Day

let nextBusinessDay (dt : DateTime) =
    match dt.DayOfWeek with
    | DayOfWeek.Friday -> dt.AddDays 3.0
    | DayOfWeek.Saturday -> dt.AddDays 2.0
    | _ -> dt.AddDays 1.0