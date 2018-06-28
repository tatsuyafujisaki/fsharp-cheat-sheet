module Database

open FSharp.Data.TypeProviders

type SDC = SqlDataConnection<ConnectionString = @"Integrated Security=SSPI;Initial Catalog=WideWorldImporters;Data Source=.\SQLEXPRESS">

//let get customerName =
//    match query { for row in SDC.GetDataContext().Website_Customers do
//                  where(row.CustomerName = customerName)
//                  select row
//                  exactlyOneOrDefault } with
//    | null -> None
//    | x -> Some x