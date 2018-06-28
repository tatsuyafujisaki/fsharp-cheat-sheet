module U

open System
open System.Data
open System.Data.SqlClient
open System.IO
open System.Transactions

// Explanatory wrapper
let unSome (x : 'T option) = x.Value

// Explanatory wrapper
// Simpler than (List.reduce (+) ss)
let concat (ss : string seq) = String.Concat ss

let readAllBytes (stream : Stream) = 
    use ms = new MemoryStream()
    stream.CopyTo(ms)
    ms.ToArray()

let toDataTable (dsv : string) delimiter hasHeading = 
    let lines = dsv.Split([| '\n' |])
    let columnCount = (lines.[0]).Split([| delimiter |]).Length
    let dt = new DataTable()
    match hasHeading with
    | true ->
        let columnNames = (lines.[0]).Split([| delimiter |])
        for i in 0..columnCount - 1 do
            dt.Columns.Add(new DataColumn(columnNames.[i]))
        for line in (lines |> Seq.skip 1) do
            let row = dt.NewRow()
            row.ItemArray <- line.Split([| delimiter |]) |> Array.map box
            dt.Rows.Add(row)
    | false ->
        for _ in 1..columnCount do
            dt.Columns.Add(new DataColumn())
        for line in lines do
            let row = dt.NewRow()
            row.ItemArray <- line.Split([| delimiter |]) |> Array.map box
            dt.Rows.Add(row)
    dt

let toDsv (dt : DataTable) delimiter = 
    dt.Select()
    |> Array.map (fun columns -> String.Join(delimiter, columns.ItemArray))
    |> fun rows -> String.Join("\n", rows)

let executeNonQuery connectionString commandText = 
    try 
        use sc = new SqlConnection(connectionString)
        sc.Open()
        use c = sc.CreateCommand()
        c.CommandText <- commandText
        c.ExecuteNonQuery()
    with
        e -> failwithf "%A%A" e.Message e.StackTrace

let importToDatabase connectionString tableName (dt : DataTable) = 
    try 
        use ts = new TransactionScope()
        use sc = new SqlConnection(connectionString)
        sc.Open()
        use c = sc.CreateCommand()
        c.CommandText <- "DELETE FROM " + tableName
        c.ExecuteNonQuery() |> ignore
        use sbc = new SqlBulkCopy(sc)
        sbc.DestinationTableName <- tableName
        sbc.WriteToServer(dt)
        ts.Complete()
    with
        e -> failwithf "%A%A" e.Message e.StackTrace