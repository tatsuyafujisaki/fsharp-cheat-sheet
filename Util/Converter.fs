module Converter

open System
open Microsoft.VisualBasic

let toRadian degree = (Math.PI / 180.0) * degree
let toDegree radian = (180.0 / Math.PI) * radian

// https://msdn.microsoft.com/en-us/library/ms912047.aspx
let hankaku s = Strings.StrConv(s, VbStrConv.Narrow, 1041)