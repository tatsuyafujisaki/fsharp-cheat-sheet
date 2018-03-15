module Converter

open System
open System.Collections.Generic
open System.Data
open System.Xml
open System.Web.Script.Serialization

type Record1 =
    { Field1 : string
      Field2 : string
      Field3 : string }

let toIDictionary map = map |> Map.toSeq |> dict

let getKeys map = map |> Map.toSeq |> Seq.map fst
let getValues map = map |> Map.toSeq |> Seq.map snd

let toRadian degree = (Math.PI / 180.0) * degree
let toDegree radian = (180.0 / Math.PI) * radian

// Explanatory wrapper
let flattenArrays = Array.concat

// Explanatory wrapper
let flattenLists = List.concat

// Explanatory wrapper
let flattenSequences = Seq.concat

// seq { key1, seq { v1-1, v1-2 }; key2, seq { v2-1, v2-2 }}
let groupTuples xs = 
    xs
    |> Seq.groupBy fst
    |> Seq.map (fun (k, v) -> k, Seq.map snd v)

// [ key1, [ v1-1, v1-2 ]; key2, [ v2-1, v2-2 ]]
let groupTuplesAsList xs = 
    xs
    |> Seq.groupBy fst
    |> Seq.map (fun (k, v) -> k, Seq.map snd v |> Seq.toList)
    |> Seq.toList

let trimXml (xml : string) = 
    let xd = XmlDocument()
    xd.LoadXml(xml.Replace("&", "&amp;"))
    xd.OuterXml

let toListOfArray (dt : DataTable) = 
    dt.AsEnumerable()
    |> Seq.map (fun dr -> dr.ItemArray)
    |> Seq.toList

let toListOfRecord (dt : DataTable) = 
    dt.AsEnumerable()
    |> Seq.map (fun dr -> 
           let xs = dr.ItemArray |> Array.map string
           { Field1 = xs.[0]
             Field2 = xs.[1]
             Field3 = xs.[2] })
    |> Seq.toList

let toDataRows (dt : DataTable) = dt.Rows |> Seq.cast<DataRow>

// Dictionary to map
let dictionaryToMap kvps =
    kvps
    |> Seq.map (|KeyValue|)
    |> Map.ofSeq

// JSON to map
let jsonToMap json =
    let jss = JavaScriptSerializer()
    dictionaryToMap (jss.Deserialize<Dictionary<string, obj>>(json))