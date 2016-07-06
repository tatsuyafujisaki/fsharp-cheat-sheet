module Converter

open Microsoft.VisualBasic
open System
open System.Xml

let toRadian degree = (Math.PI / 180.0) * degree
let toDegree radian = (180.0 / Math.PI) * radian

let trimXml (xml : string) =
    let xd = XmlDocument()
    xd.LoadXml(xml.Replace("&", "&amp;"))
    xd.OuterXml

// https://msdn.microsoft.com/en-us/library/ms912047.aspx
let hankaku s = Strings.StrConv(s, VbStrConv.Narrow, 1041)