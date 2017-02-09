module Converter

open Microsoft.VisualBasic
open System
open System.Collections.Generic
open System.Data
open System.Xml

type Record1 = 
    { Field1 : string
      Field2 : string
      Field3 : string }

// Explanatory wrapper
let toIEnumerable xs = List.toSeq xs

let toIDictionary map = map |> Map.toSeq |> dict

let getKeys map = map |> Map.toSeq |> Seq.map fst
let getValues map = map |> Map.toSeq |> Seq.map snd

let toRadian degree = (Math.PI / 180.0) * degree
let toDegree radian = (180.0 / Math.PI) * radian

// Explanatory wrapper
let flattenArrays xss = Array.concat xss

// Explanatory wrapper
let flattenLists xss = List.concat xss

// Explanatory wrapper
let flattenSequences xss = Seq.concat xss

// seq { key1, seq { v1-1, v1-2 }; key2, seq { v2-1, v2-2 }}
let groupTuples xs = 
    xs
    |> Seq.groupBy fst
    |> Seq.map (fun (k, v) -> k, Seq.map snd v)

// [ key1, [ v1-1, v1-2 ]; key2, [ v2-1, v2-2 ]]
let groupTuplesAsList xs = 
    xs
    |> Seq.groupBy fst
    |> Seq.map (fun (k, v) -> k, Seq.map snd v |> List.ofSeq)
    |> List.ofSeq

let trimXml (xml : string) = 
    let xd = XmlDocument()
    xd.LoadXml(xml.Replace("&", "&amp;"))
    xd.OuterXml

let toListOfArray (dt : DataTable) = 
    dt.AsEnumerable()
    |> Seq.map (fun dr -> dr.ItemArray)
    |> List.ofSeq

let toListOfRecord (dt : DataTable) = 
    dt.AsEnumerable()
    |> Seq.map (fun dr -> 
           let xs = dr.ItemArray |> Array.map string
           { Field1 = xs.[0]
             Field2 = xs.[1]
             Field3 = xs.[2] })
    |> List.ofSeq

let toDataRows (dt : DataTable) = dt.Rows |> Seq.cast<DataRow>

// https://msdn.microsoft.com/en-us/library/ms912047.aspx
let hankaku s = Strings.StrConv(s, VbStrConv.Narrow, 1041)