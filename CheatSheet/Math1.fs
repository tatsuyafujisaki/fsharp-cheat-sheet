module Math1

open System

// Math.Round(x) and Math.Round(x, fractionalDigitCount) return the nearest *even* whole number, which is useless.
// e.g. Math.Round(2.5) returns 2 rather than 3.
// e.g. Math.Round(2.05, 1) returns 2.0 rather than 2.1.

// No F# operator equivalent to Math.Round(x, MidpointRounding.AwayFromZero)
let roundToNearestWholeNumber (x : decimal) = Math.Round(x, MidpointRounding.AwayFromZero)

// No F# operator equivalent to Math.Round(x, fractionalDigitCount, MidpointRounding.AwayFromZero)
let round1 (x : decimal) fractionalDigitCount = Math.Round(x, fractionalDigitCount, MidpointRounding.AwayFromZero)

let roundToNearestWholeNumberAsString (x : decimal) = x.ToString "#,##0"
let roundToTwoDecimalPlacesAsString (x : decimal) = x.ToString "#,##0.##"

// Explanatory wrapper
let roundUpToNearestWholeNumber = ceil

let roundUp (x : decimal) fractionalDigitCount =
    let power = (10.0 ** fractionalDigitCount) |> decimal
    (x * power |> ceil) / power

// Explanatory wrapper
let roundDownToNearestWholeNumber = floor

let roundDown (x : decimal) fractionalDigitCount =
    let power = (10.0 ** fractionalDigitCount) |> decimal
    (x * power |> floor) / power