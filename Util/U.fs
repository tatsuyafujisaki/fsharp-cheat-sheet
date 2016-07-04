module U

open System
open System.Data
open System.Data.SqlClient
open System.Diagnostics
open System.IO
open System.Net
open System.Transactions

// Explanatory wrapper
let unSome (x: 'T option) = x.Value

let readAllBytes (stream : Stream) =
    use ms = new MemoryStream()
    stream.CopyTo(ms)
    ms.ToArray()

let ftpDownloadBinary (url : string) (user : string) (password : string) outputPath =
    let fwr = WebRequest.Create(url) :?> FtpWebRequest
    fwr.Credentials <- NetworkCredential(user, password)
    use wr = fwr.GetResponse()
    use s = wr.GetResponseStream()
    File.WriteAllBytes(outputPath, readAllBytes(s))

let startProcess fileName (arguments : string option) =
    let psi =
        match arguments with
        | Some args -> ProcessStartInfo(fileName, args)
        | None -> ProcessStartInfo(fileName)
    
    psi.CreateNoWindow <- true
    psi.UseShellExecute <- false
    psi.WindowStyle <- ProcessWindowStyle.Hidden
    psi.RedirectStandardInput <- true
    psi.RedirectStandardOutput <- true
    psi.RedirectStandardError <- true

    let p = Process.Start(psi)

    p.WaitForExit()

    if p.ExitCode <> 0 then
        failwithf "%A" (p.StandardError.ReadToEnd())

    p.StandardOutput.ReadToEnd()

let uncompressZ path =
    startProcess "7z.exe" (Some (sprintf @"e -y -o ""%s"" ""%s.Z""" (Path.GetTempPath()) path))

let toDataTable (dsv : string) delimiter hasHeading =
    let lines = dsv.Split([|'\n'|])
    let columnCount = (lines.[0]).Split([|delimiter|]).Length

    let dt = new DataTable()

    if hasHeading then
        let columnNames = (lines.[0]).Split([|delimiter|])
        for i in 0 .. columnCount - 1 do
            dt.Columns.Add(new DataColumn(columnNames.[i]))
        for line in (lines |> Seq.skip 1) do
            let row = dt.NewRow()
            row.ItemArray <- line.Split([|delimiter|])
                             |> Array.map box
            dt.Rows.Add(row)
    else
        for _ in 1 .. columnCount do
            dt.Columns.Add(new DataColumn())
        for line in lines do
        let row = dt.NewRow()
        row.ItemArray <- line.Split([|delimiter|])
                         |> Array.map box
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
        | e -> failwithf "%A%A" e.Message e.StackTrace

let importToDb connectionString tableName (dt : DataTable) =
    try
        use ts = new TransactionScope()
        use sc = new SqlConnection(connectionString)
        sc.Open()
        use c = sc.CreateCommand()
        c.CommandText <- "DELETE FROM" + tableName
        c.ExecuteNonQuery() |> ignore

        use sbc = new SqlBulkCopy(sc)
        sbc.DestinationTableName <- tableName
        sbc.WriteToServer(dt)

        ts.Complete()
    with
        e -> failwithf "%A%A" e.Message e.StackTrace